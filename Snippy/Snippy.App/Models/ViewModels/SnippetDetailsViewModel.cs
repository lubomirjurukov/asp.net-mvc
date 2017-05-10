using System;
using System.Collections.Generic;
using Snippy.App.Model;

namespace Snippy.App.Models.ViewModels
{
    public class SnippetDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public virtual Language Language { get; set; }

        public virtual User Author { get; set; }

        public DateTime CreationDateTime { get; set; }

        public virtual IEnumerable<LabelButtonViewModel> Labels { get; set; }

        public virtual IEnumerable<CommentShortViewModel> Comments { get; set; }
    }
}