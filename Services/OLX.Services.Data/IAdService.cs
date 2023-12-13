namespace OLX.Services.Data
{
    using System.Collections.Generic;
    using System.Reflection.Metadata.Ecma335;
    using System.Threading.Tasks;

    using OLX.Data.Models;
    using OLX.Web.ViewModels.Ad;

    public interface IAdService
    {
        public Task CreateAsync(CreateAdInputModel inputModel, string id, string imagePath);

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12);

        public T GetAdByTitle<T>(string title);

        public IEnumerable<Т> GetAllByCategory<Т>(string name, int page, int itemsPerPage = 12);

        int GetCount();
    }
}
