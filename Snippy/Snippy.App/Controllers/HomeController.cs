using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Snippy.App.Data.UnitOfWork;
using Snippy.App.Models.ViewModels;

namespace Snippy.App.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ISnippyData data) : base(data)
        {
        }

        public ActionResult Index()
        {
            var snippets = this.Data.Snippets
               .All()
               .OrderByDescending(s => s.CreationDateTime)
               .Take(5)
               .ProjectTo<SnippetViewModel>();

            var comments = this.Data.Comments
               .All()
               .OrderByDescending(c => c.CreationDateTime)
               .Take(5)
               .ProjectTo<CommentViewModel>();

            var labels = this.Data.Labels
               .All()
               .OrderByDescending(l => l.Snippets.Count())
               .Take(5)
               .ProjectTo<LabelViewModel>();

            var result = new HomeViewModel()
            {
                BestLabels = labels,
                LatestSnippets = snippets,
                LatestComments = comments
            };

            return View(result);
        }
    }
}