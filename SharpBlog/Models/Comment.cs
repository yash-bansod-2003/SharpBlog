using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    public required Post Post { get; set; }

    [ForeignKey("Post")]
    public int PostId { get; set; }
}
