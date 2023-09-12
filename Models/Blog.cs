using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace aspCMS.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        // Foreign key relationship with User
        public int AuthorId { get; set; }

        public int CategoryId { get; set; }

        public string Slug { get; set;}

    }

    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }

    }

    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public int PostId { get; set; }
        public int AuthorId { get; set; }

    }
}
