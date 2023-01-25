using Microsoft.EntityFrameworkCore;
using SWProvincias_Tribulo.Models;

namespace SWProvincias_Tribulo.Context
{
    public class DBPaisFinalContext : DbContext
    {

        public DBPaisFinalContext(DbContextOptions options):base(options) { }

        public virtual DbSet<Provincia> Provincias { get; set; }

        public virtual DbSet<Ciudad> Ciudades { get; set; }

    }
}
