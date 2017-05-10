using System.Web.Mvc;
using Snippy.App.Data.UnitOfWork;

namespace Snippy.App.Controllers
{
    public abstract class BaseController : Controller
    {
        protected ISnippyData Data { get; private set; }

        protected BaseController(ISnippyData data)
        {
            this.Data = data;
        }
      
    }
}