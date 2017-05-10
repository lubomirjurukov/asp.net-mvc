using Snippy.App.Data.Repository;
using Snippy.App.Model;

namespace Snippy.App.Data.UnitOfWork
{
    public interface ISnippyData
    {
        IRepository<User> Users { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Label> Labels { get; }

        IRepository<Language> Languages { get; }

        IRepository<Snippet> Snippets { get; }

        void SaveChanges();
    }
}