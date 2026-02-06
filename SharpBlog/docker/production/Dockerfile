# Build stage: use full SDK to restore and publish the app.
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

# Set the working directory inside the build container.
WORKDIR /src

# Copy the project file first to maximize layer caching for restore.
COPY ["SharpBlog.csproj", "./"]

# Restore NuGet dependencies.
RUN dotnet restore "SharpBlog.csproj"

# Copy the remaining source and assets.
COPY . .

# Publish a release build to a clean output folder.
RUN dotnet publish "SharpBlog.csproj" -c Release -o /app/publish -p:UseAppHost=false

# Runtime stage: use the smaller ASP.NET runtime image.
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime

# Create a non-root user for running the app.
RUN groupadd -r yashb \
	&& useradd -r -g yashb -d /home/yashb -s /sbin/nologin yashb \
	&& mkdir -p /home/yashb/app \
	&& chown -R yashb:yashb /home/yashb

# Set the working directory inside the runtime container.
WORKDIR /home/yashb/app

# Bind Kestrel to port 8080 inside the container.
ENV ASPNETCORE_URLS=http://+:8080

# Document the port the app listens on.
EXPOSE 8080

# Copy published output from the build stage and set ownership.
COPY --from=build --chown=yashb:yashb /app/publish .

# Run the app as the non-root user.
USER yashb

# Start the application.
ENTRYPOINT ["dotnet", "SharpBlog.dll"]
