using System.Data.Entity;
using Snippy.App.Model;

namespace Snippy.App.Data
{
    public interface IApplicaitonDbContext
    {
        IDbSet<Comment> Comments { get; set; }
        IDbSet<Label> Labels { get; set; }
        IDbSet<Language> Languages { get; set; }
        IDbSet<Snippet> Snippets { get; set; }
        IDbSet<User> Users { get; set; }
    }
}