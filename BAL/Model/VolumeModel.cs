using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Model
{
    public class VolumeModel
    {
        public string Id { get; set; }
        public List<PropertyVolumeModel> PropertyVolumes { get; set; } = new List<PropertyVolumeModel>();
    }
}
