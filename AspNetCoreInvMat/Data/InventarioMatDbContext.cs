using AspNetCoreInvMat.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreInvMat.Data
{
    public class InventarioMatDbContext : DbContext
    {
        public InventarioMatDbContext(DbContextOptions<InventarioMatDbContext> options) : base(options)
        {
                
        }

        public DbSet<Inventario> Inventario { get; set; }
    }
}
