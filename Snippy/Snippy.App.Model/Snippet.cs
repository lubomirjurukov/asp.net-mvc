using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snippy.App.Model
{
    public class Snippet
    {
        private ICollection<Label> labels; 
        private ICollection<Comment> comments; 

        public Snippet()
        {
            this.Labels = new HashSet<Label>();
            this.Comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public DateTime CreationDateTime { get; set; }

        [ForeignKey("LanguageId")]
        public virtual Language Language { get; set; }

        [Required]
        public int LanguageId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual ICollection<Label> Labels
        {
            get { return this.labels; }
            set { this.labels = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

    }
}