using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Snippy.App.Data.Repository;
using Snippy.App.Model;

namespace Snippy.App.Data.UnitOfWork
{
    public class SnippyData : ISnippyData
    {
        private ApplicationDbContext context;
        private IDictionary<Type, object> repositories;

        public SnippyData(ApplicationDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }

        public IRepository<Label> Labels
        {
            get { return this.GetRepository<Label>(); }
        }

        public IRepository<Language> Languages
        {
            get { return this.GetRepository<Language>(); }
        }

        public IRepository<Snippet> Snippets
        {
            get { return this.GetRepository<Snippet>(); }
        }

        public ApplicationDbContext Context
        {
            get { return this.context; }
        }

        public void SaveChanges()
        {
            this.Context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeof(T),
                    Activator.CreateInstance(type, this.Context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}