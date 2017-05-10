using System.Collections.Generic;
using Snippy.App.Model;

namespace Snippy.App.Models.ViewModels
{
    public class SnippetViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual IEnumerable<LabelButtonViewModel> Labels { get; set; }
    }
}