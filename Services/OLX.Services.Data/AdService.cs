namespace OLX.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using OLX.Data.Common.Repositories;
    using OLX.Data.Models;
    using OLX.Services.Mapping;
    using OLX.Web.ViewModels.Ad;

    public class AdService : IAdService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "jpeg", "png", "gif", "JPG", "JPEG" };

        private readonly IDeletableEntityRepository<Ad> adsRepository;
        private readonly IRepository<Image> imageRepository;

        public AdService(IDeletableEntityRepository<Ad> adsRepository, IRepository<Image> imageRepository)
        {
            this.adsRepository = adsRepository;
            this.imageRepository = imageRepository;
        }

        public async Task CreateAsync(CreateAdInputModel inputModel, string currentUserId, string imagePath)
        {
            Directory.CreateDirectory($"{imagePath}");

            // var currentAd = AutoMapperConfig.MapperInstance.Map<Ad>(inputModel);

            var ad = new Ad
            {
                AddedByUserId = currentUserId,
                CategoryId = inputModel.CategoryId,
                Description = inputModel.Description,
                Price = inputModel.Price,
                Title = inputModel.Title,
                Location = inputModel.Location,
            };

            foreach (var image in inputModel.Images)
            {
                var extension = Path.GetExtension(image.FileName);
                if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var dbImage = new Image
                {
                    AddedByUserId = currentUserId,
                    Extension = extension,
                };
                ad.Images.Add(dbImage);

                var physicalPAth = $"{imagePath}/ads/{dbImage.Id}{dbImage.Extension}";

                using (Stream fileStream = new FileStream(physicalPAth, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
            }

            await this.adsRepository.AddAsync(ad);
            await this.adsRepository.SaveChangesAsync();
        }

        public T GetAdByTitle<T>(string title)
        {
            var ad = this.adsRepository.AllAsNoTracking().Where(x => x.Title == title).To<T>().FirstOrDefault();

            return ad;
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12)
        {
            var list = this.adsRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * 12)
                .Take(itemsPerPage)
                .To<T>()
                .ToList();

            return list;
        }


        public IEnumerable<Т> GetAllByCategory<Т>(string name, int page, int itemsPerPage = 12)
        {
            var ads = this.adsRepository.AllAsNoTracking().Where(x => x.Category.Name == name)
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * 12)
                .Take(itemsPerPage)
                .To<Т>()
                .ToList();

            // var modelAds = AutoMapperConfig.MapperInstance.Map<IEnumerable<AdsInListByCategoryViewModel>>(ads);

            return ads;
        }

        public int GetCount()
        {
            return this.adsRepository.All().Count();
        }
    }
}
