namespace OLX.Web.ViewModels.Ad
{
    using System.Collections.Generic;

    public class AdsListByCategoryViewModel : PagingViewModel
    {
        public IEnumerable<AdsInListByCategoryViewModel> AdsByCategory { get; set; }
    }
}
