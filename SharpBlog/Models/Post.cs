using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharpBlog.Models;

public class Post
{
  [Key]
  public int Id { get; set; }
  [Required(ErrorMessage = "Title is required.")]
  [MaxLength(200)]
  public required string Title { get; set; }
  [Required]
  public required string Content { get; set; }
  [Required]
  public required string Author { get; set; }
  [Url]
  public string? FeaturedImageUrl { get; set; }

  [DataType(DataType.DateTime)]
  public DateTime PublishedAt { get; set; } = DateTime.UtcNow;

  [DataType(DataType.DateTime)]
  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

  public required Category Category { get; set; }

  [ForeignKey("Category")]
  public int CategoryId { get; set; }

  public ICollection<Comment>? Comments { get; set; }
}
