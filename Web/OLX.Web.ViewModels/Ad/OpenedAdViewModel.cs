namespace OLX.Web.ViewModels.Ad
{
    using System.Collections.Generic;
    using OLX.Data.Models;
    using OLX.Services.Mapping;

    public class OpenedAdViewModel : IMapFrom<Ad>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        // Phone number/Email
        public string ContactData { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual IEnumerable<Image> Images { get; set; }

    }
}
