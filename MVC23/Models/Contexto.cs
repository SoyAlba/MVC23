using Microsoft.EntityFrameworkCore;
using MVC23.Models;
using static MVC23.Controllers.VeiculoController;

namespace MVC23.Models
{
    public class Contexto : DbContext
    {
        public Contexto()
        {
        }
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<VehiculoTotal>(
                    eb =>
                    {
                        eb.HasNoKey();
                    });
        }
        public DbSet<MarcaModelo> Marcas { get; set; }
        public DbSet<SerieModelo> Series { get; set; }
        public DbSet<VeiculoModelo> Vehiculos { get; set; }
        public DbSet<ExtraModelo> Extras { get; set; }
        public DbSet<MVC23.Models.VeiculoModelo> VeiculoModelo { get; set; }
        public DbSet<VehiculoTotal> VistaTotal { get; set; }
        public List<VehiculoExtraModelo> vehiculoExtras { get; set; }
    }
}
