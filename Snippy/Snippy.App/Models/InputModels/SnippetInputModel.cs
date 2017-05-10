using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Snippy.App.Model;

namespace Snippy.App.Models.InputModels
{
    public class SnippetInputModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} is required.")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} is required.")]
        public string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} is required.")]
        [DataType(DataType.MultilineText)]
        public string Code { get; set; }

        [Display(Name = "Language")]
        public int LanguageId { get; set; }

        public string LabelsString { get; set; }

        public ICollection<Label> Labels { get; set; }
    }
}