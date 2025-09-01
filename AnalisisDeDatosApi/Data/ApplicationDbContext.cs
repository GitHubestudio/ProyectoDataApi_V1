using Microsoft.EntityFrameworkCore;
using AnalisisDeDatosApi.Models;

namespace AnalisisDeDatosApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<DatoDeVenta> DatosDeVentas { get; set; }

    }
}
