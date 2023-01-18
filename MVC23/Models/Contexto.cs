using Microsoft.EntityFrameworkCore;
using MVC23.Models;

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
        public DbSet<MarcaModelo> Marcas { get; set; }
        public DbSet<SerieModelo> Series { get; set; }
        public DbSet<VeiculoModelo> Vehiculos { get; set; }
        public DbSet<MVC23.Models.VeiculoModelo> VeiculoModelo { get; set; }
    }
}
