namespace OLX.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using OLX.Services.Data;
    using OLX.Web.ViewModels;
    using OLX.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly ICategoriesService categoriesService;

        public HomeController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new CategoryListViewModel();
            viewModel.Categories = this.categoriesService.GetAllAsSelectListItems();
            return this.View(viewModel);
        }


        [HttpPost]
        public IActionResult Index(int Id)
        {
            // TODO
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
