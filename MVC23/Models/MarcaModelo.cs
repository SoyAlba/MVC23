using Microsoft.EntityFrameworkCore;
namespace MVC23.Models
    
{
    public class MarcaModelo
    {
        public int ID { get; set; }
        public string Nom_marca { get; set; }
        public List<SerieModelo> Series { get; set; }
    }
}
