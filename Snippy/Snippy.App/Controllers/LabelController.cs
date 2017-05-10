using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Snippy.App.Data.UnitOfWork;
using Snippy.App.Models.ViewModels;

namespace Snippy.App.Controllers
{
    public class LabelController : BaseController
    {
        public LabelController(ISnippyData data) : base(data)
        {
        }

        public ActionResult Details(int id)
        {
            var label = this.Data.Labels
                .All()
                .Where(l => l.Id == id)
                .ProjectTo<LabelDetailsViewModel>()
                .FirstOrDefault();

            return View(label);
        }
    }
}