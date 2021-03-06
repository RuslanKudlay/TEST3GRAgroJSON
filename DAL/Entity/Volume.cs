using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Volume
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public Product Product { get; set; }
        public List<PropertyVolume> PropertyVolumes { get; set; } = new List<PropertyVolume>();
    }
}
