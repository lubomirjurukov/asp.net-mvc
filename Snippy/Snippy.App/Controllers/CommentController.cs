using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNet.Identity;
using Snippy.App.Data.UnitOfWork;
using Snippy.App.Models.ViewModels;

namespace Snippy.App.Controllers
{
    public class CommentController : BaseController
    {
        public CommentController(ISnippyData data) : base(data)
        {
        }

        public ActionResult Delete(int id)
        {
            var comment = this.Data.Comments.All()
                .Where(c => c.Id == id)
                .ProjectTo<CommentViewModel>()
                .FirstOrDefault();

            return View(comment);
        }

        public ActionResult RealDelete(int id)
        {
            var comment = this.Data.Comments.All().FirstOrDefault(c => c.Id == id);

            if (comment != null && comment.AuthorId == this.User.Identity.GetUserId())
            {
                this.Data.Comments.Remove(comment);
                this.Data.SaveChanges();

                return RedirectToAction("Details", "Snippet", new {id = comment.SnippetId});
            }
            else
            {
                @ViewBag["message"] = "You can't delete this comment, because you are not the author.";
            }

            return new EmptyResult();
        }

        public ActionResult CancelDelete(int id)
        {
            var comment = this.Data.Comments.All().FirstOrDefault(c => c.Id == id);

            return RedirectToAction("Details", "Snippet", new { id = comment.SnippetId });
        }
    }
}