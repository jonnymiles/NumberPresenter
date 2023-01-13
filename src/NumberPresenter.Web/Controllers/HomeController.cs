using Microsoft.AspNetCore.Mvc;
using NumberPresenter.Core;
using NumberPresenter.Web.Models;

namespace NumberPresenter.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRomanService _romanService;

        public HomeController(IRomanService romanService)
        {
            _romanService = romanService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IndexModel model)
        {
            var romanResult = _romanService.NumericToRoman(model.UserInput);

            if (!romanResult.Success)
            {
                model.ErrorMessage = romanResult.ErrorMessage;
                return View(model);
            }

            model.Result = romanResult.Result;

            return View(model);
        }
    }
}
