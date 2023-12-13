namespace OLX.Services.Data
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc.Rendering;
    using OLX.Data.Models;

    public interface ICategoriesService
    {
        public List<SelectListItem> GetAllAsSelectListItems();

        public IEnumerable<Category> GetAllInList();

        public Category GetBySelectedName(string name);

    }
}
