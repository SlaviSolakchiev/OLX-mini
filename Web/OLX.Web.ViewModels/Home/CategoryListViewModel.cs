namespace OLX.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc.Rendering;

    public class CategoryListViewModel
    {
        public List<SelectListItem> Categories { get; set; }

        public string Id { get; set; }
    }
}
    