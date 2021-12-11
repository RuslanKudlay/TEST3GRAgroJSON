using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Model
{
    public class ProductModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<VolumeModel> Volumes { get; set; } = new List<VolumeModel>();
    }
}
