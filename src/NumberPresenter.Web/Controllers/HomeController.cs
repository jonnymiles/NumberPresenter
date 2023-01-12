using Microsoft.AspNetCore.Mvc;
using NumberPresenter.Core;
using NumberPresenter.Web.Models;

namespace NumberPresenter.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly INumberService _numberService;
        private readonly IRomanService _romanService;

        public HomeController(INumberService numberService, IRomanService romanService)
        {
            _numberService = numberService;
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
            var numberResult = _numberService.ExtractNumber(model.UserInput);

            if (!numberResult.Success)
            {
                model.ErrorMessage = numberResult.ErrorMessage;
                return View(model);
            }

            if (!numberResult.Result.HasValue)
            {
                model.ErrorMessage = "Unknown error";
                return View(model);
            }

            var romanResult = _romanService.NumericToRoman(numberResult.Result.Value);

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
