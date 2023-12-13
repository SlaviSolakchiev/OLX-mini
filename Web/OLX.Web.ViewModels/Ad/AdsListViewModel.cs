namespace OLX.Web.ViewModels.Ad
{
    using System;
    using System.Collections.Generic;

    using OLX.Web.ViewModels;

    public class AdsListViewModel : PagingViewModel
    {
        public IEnumerable<AdsInListViewModel> Ads { get; set; }
    }
}
