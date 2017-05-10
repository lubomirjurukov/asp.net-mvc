using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Snippy.App.Model
{
    public class Label
    {
        private ICollection<Snippet> snippets;

        public Label()
        {
            this.Snippets = new HashSet<Snippet>();
        }

        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Text { get; set; }

        public virtual ICollection<Snippet> Snippets
        {
            get { return this.snippets; }
            set { this.snippets = value; }
        }
    }
}