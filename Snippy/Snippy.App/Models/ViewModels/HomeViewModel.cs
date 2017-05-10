using System.Collections.Generic;

namespace Snippy.App.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<SnippetViewModel> LatestSnippets { get; set; }

        public IEnumerable<CommentViewModel> LatestComments { get; set; }

        public IEnumerable<LabelViewModel> BestLabels { get; set; }
    }
}