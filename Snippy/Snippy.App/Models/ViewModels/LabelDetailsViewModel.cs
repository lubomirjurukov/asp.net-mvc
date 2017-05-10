using System.Collections.Generic;

namespace Snippy.App.Models.ViewModels
{
    public class LabelDetailsViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public IEnumerable<SnippetViewModel> Snippets { get; set; }
    }
}