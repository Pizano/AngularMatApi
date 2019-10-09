using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreInvMat.EntityModels
{
    public class Inventario
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public string Symbol { get; set; }

    }
}
