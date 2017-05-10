using System.Collections.Generic;

namespace Snippy.App.Models.ViewModels
{
    public class LanguageViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<SnippetViewModel> Snippets { get; set; }
    }
}