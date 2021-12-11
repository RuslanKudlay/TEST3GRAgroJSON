using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class PropertyVolume
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public int Heigth { get; set; }
        public int Width { get; set; }
        public int Weigth { get; set; }
        public Volume Volume { get; set; }
    }
}
