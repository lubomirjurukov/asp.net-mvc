using AutoMapper;

namespace Snippy.App
{
    using Snippy.App.Model;
    using Snippy.App.Models.InputModels;
    using Snippy.App.Models.ViewModels;

    public class AutoMapperConfig
    {
        public void Execute()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Label, LabelViewModel>().ForMember(x => x.SnippersCount, cnf => cnf.MapFrom(l => l.Snippets.Count));
                cfg.CreateMap<Snippet, SnippetInputModel>();
                cfg.CreateMap<CommentInputModel, Comment>();
                cfg.CreateMap<SnippetInputModel, Snippet>();
                cfg.CreateMap<Snippet, SnippetViewModel>();
                cfg.CreateMap<Snippet, SnippetDetailsViewModel>();
                cfg.CreateMap<Language, LanguageViewModel>();
                cfg.CreateMap<Label, LabelDetailsViewModel>();
                cfg.CreateMap<Label, LabelButtonViewModel>();
                cfg.CreateMap<Comment, CommentViewModel>();
                cfg.CreateMap<Comment, CommentShortViewModel>();
            });
        }
    }
}
