using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNet.Identity;
using Snippy.App.Data.UnitOfWork;
using Snippy.App.Model;
using Snippy.App.Models.InputModels;
using Snippy.App.Models.ViewModels;

namespace Snippy.App.Controllers
{
    public class SnippetController : BaseController
    {
        public SnippetController(ISnippyData data) : base(data)
        {
        }

        public ActionResult All()
        {
            var snippets = this.Data.Snippets
                .All()
                .OrderByDescending(s => s.CreationDateTime)
                .ProjectTo<SnippetViewModel>(); 
            
            return View(snippets);
        }

        public ActionResult Details(int id)
        {
            var snippet = this.Data.Snippets
                .All()
                .Where(s => s.Id == id)
                .ProjectTo<SnippetDetailsViewModel>()
                .FirstOrDefault();

            var oldComments = snippet.Comments;
            var newComments = oldComments.OrderByDescending(c => c.CreationDateTime);
            snippet.Comments = newComments;

            return View(snippet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(CommentInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                model.AuthorId = this.User.Identity.GetUserId();
                model.CreationDateTime = DateTime.Now;
                model.SnippetId = Int16.Parse(RouteData.Values["id"].ToString());
                var comment = Mapper.Map<Comment>(model);
                this.Data.Comments.Add(comment);
                this.Data.SaveChanges();

                var commentDb = this.Data.Comments
                    .All()
                    .Where(c => c.Id == comment.Id)
                    .ProjectTo<CommentShortViewModel>()
                    .FirstOrDefault();

                return this.PartialView("DisplayTemplates/CommentShortViewModel", commentDb);
            }

            return this.Json("Error");
        }

        [Authorize]
        public ActionResult MySnippets()
        {
            var userId = this.User.Identity.GetUserId();

            var snippets = this.Data.Snippets
                .All()
                .Where(s => s.AuthorId == userId)
                .OrderByDescending(s => s.CreationDateTime)
                .ProjectTo<SnippetViewModel>();

            return View(snippets);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            this.LoadLanguages();

            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SnippetInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var labelsString = Regex.Replace(model.LabelsString, @"\s*", "");
                var labels = new HashSet<Label>();
                List<string> labelNames = labelsString.Split(';').ToList<string>();
                foreach (var labelName in labelNames)
                {
                    var label = this.Data.Labels.All().FirstOrDefault(l => l.Text.ToLower() == labelName.ToLower());
                    if (label != null)
                    {
                        labels.Add(label);
                    }
                    else
                    {
                        var newLabel = new Label()
                        {
                            Text = labelName
                        };

                        this.Data.Labels.Add(newLabel);
                        this.Data.SaveChanges();

                        labels.Add(newLabel);
                    }
                }

                model.Labels = labels;               

                var snippet = Mapper.Map<Snippet>(model);
                snippet.AuthorId = this.User.Identity.GetUserId();
                snippet.CreationDateTime = DateTime.Now;
                this.Data.Snippets.Add(snippet);
                this.Data.SaveChanges();

                return this.RedirectToAction("Details", new { id = snippet.Id });
            }

            this.LoadLanguages();

            return this.View(model);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            var snippet = this.Data.Snippets
                .All()
                .Where(s => s.Id == id)
                .FirstOrDefault();          
            var snippetInputModel = Mapper.Map<SnippetInputModel>(snippet);

            snippetInputModel.LabelsString = string.Join(";", snippet.Labels.Select(l => l.Text).ToList());

            this.LoadLanguages();

            return View(snippetInputModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SnippetInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var labelsString = Regex.Replace(model.LabelsString, @"\s*", "");
                var labels = new HashSet<Label>();
                List<string> labelNames = labelsString.Split(';').ToList<string>();
                foreach (var labelName in labelNames)
                {
                    var label = this.Data.Labels.All().FirstOrDefault(l => l.Text.ToLower() == labelName.ToLower());
                    if (label != null)
                    {
                        labels.Add(label);
                    }
                    else
                    {
                        var newLabel = new Label()
                        {
                            Text = labelName
                        };

                        this.Data.Labels.Add(newLabel);
                        this.Data.SaveChanges();

                        labels.Add(newLabel);
                    }
                }

                model.Labels = labels;

                var snippet = Mapper.Map<Snippet>(model);
                snippet.AuthorId = this.User.Identity.GetUserId();

                var snippetFromDb = this.Data.Snippets.All().FirstOrDefault(s => s.Id == model.Id);
                snippetFromDb.Title = snippet.Title;
                snippetFromDb.Labels = snippet.Labels;
                snippetFromDb.Description = snippet.Description;
                snippetFromDb.Code = snippet.Code;
                snippetFromDb.Language = snippet.Language;

                this.Data.Snippets.Update(snippetFromDb);
                this.Data.SaveChanges();

                return this.RedirectToAction("Details", new { id = snippetFromDb.Id });
            }

            this.LoadLanguages();

            return this.View(model);
        }

        private void LoadLanguages()
        {
            var languages = this.Data
                .Languages.All()
                .OrderBy(l => l.Name)
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });

            ViewBag.Languages = languages;
        }

    }
}