using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspCMS.Models
{

    [Index(nameof(Post.Slug), IsUnique = true)]
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required(ErrorMessage = "Please enter the title.")]
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        // Foreign key relationship with User
    
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [Required(ErrorMessage = "Please enter the slug.")]
        public string Slug { get; set; }

        public string CoverPhoto { get; set; }


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

    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }


    }
}
