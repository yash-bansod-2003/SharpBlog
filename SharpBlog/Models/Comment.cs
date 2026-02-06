using System;
using System.ComponentModel.DataAnnotations;

namespace SharpBlog.Models;

public class Comment
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public required string Commenter { get; set; }

    [Required, MaxLength(500)]
    public required string Content { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime CommentedAt { get; set; } = DateTime.UtcNow;
}
