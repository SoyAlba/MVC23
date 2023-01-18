namespace MVC23.Models
{
    public class SerieModelo
    {
        public int Id { get; set; }
        public string Nom_Serie { get; set; }
        public MarcaModelo Marca { get; set; }
        public int MarcaID { get; set; }
    }
}
