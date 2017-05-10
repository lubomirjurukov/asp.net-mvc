using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snippy.App.Model
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [Required]
        public DateTime CreationDateTime { get; set; }

        [Required]
        public string Content { get; set; }

        [ForeignKey("SnippetId")]
        public virtual Snippet Snippet { get; set; }

        [Required]
        public int SnippetId { get; set; }
    }
}