using BAL.Model;
using DAL;
using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IApplicationDbContext _dbContext;
        public ProductService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ProductModel> GetAll()
        {
            var time = new Stopwatch();
            time.Start();
            var result = _dbContext.Products.Include(_ => _.Volumes).ThenInclude(_ => _.PropertyVolumes).ToList();
            List<ProductModel> productModels = new List<ProductModel>();
            foreach (var temp in result)
            {
                List<VolumeModel> volumeModels = new List<VolumeModel>();
                foreach (var temp2 in temp.Volumes)
                {
                    List<PropertyVolumeModel> propertyVolumeModels = new List<PropertyVolumeModel>();
                    foreach (var temp3 in temp2.PropertyVolumes)
                    {
                        var pvModel = new PropertyVolumeModel
                        {
                            Id = temp3.Id,
                            Heigth = temp3.Heigth,
                            Width = temp3.Width,
                            Weigth = temp3.Weigth
                        };
                        propertyVolumeModels.Add(pvModel);
                    }
                    var vModel = new VolumeModel
                    {
                        Id = temp2.Id,
                        PropertyVolumes = propertyVolumeModels
                    };
                    volumeModels.Add(vModel);
                }
                var pModel = new ProductModel
                {
                    Id = temp.Id,
                    Name = temp.Name,
                    Volumes = volumeModels
                };
                productModels.Add(pModel);
            }
            time.Stop();
            var ellapsedTime = time.Elapsed.TotalMilliseconds;

            return productModels;
        }
        
    }
}
