using System.Web.Mvc;

namespace LocalStore.WebApp.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            return View();
        }
    }
}