using Microsoft.AspNetCore.Mvc;

namespace NumberPresenter.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
