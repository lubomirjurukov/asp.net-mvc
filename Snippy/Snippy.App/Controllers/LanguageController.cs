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
    public class LanguageController : BaseController
    {
        public LanguageController(ISnippyData data) : base(data)
        {
        }

        public ActionResult Details(int id)
        {
            var language = this.Data.Languages
                .All()
                .Where(l => l.Id == id)
                .ProjectTo<LanguageViewModel>()
                .FirstOrDefault();
                
            return View(language);
        }

    }
}