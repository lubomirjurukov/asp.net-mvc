using System;
using Snippy.App.Model;

namespace Snippy.App.Models.InputModels
{
    public class CommentInputModel
    {
        public string Content { get; set; }

        public DateTime CreationDateTime { get; set; }

        public string AuthorId { get; set; }

        public int SnippetId { get; set; }
    }
}
    