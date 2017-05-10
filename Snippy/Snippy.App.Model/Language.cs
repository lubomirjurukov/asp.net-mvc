using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Snippy.App.Model
{
    public class Language
    {
        private ICollection<Snippet> snippets;

        public Language()
        {
            this.Snippets = new HashSet<Snippet>();
        }

        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Snippet> Snippets
        {
            get { return this.snippets; }
            set { this.snippets = value; }
        }
    }
}