namespace MVC23.Models
{
    public class VeiculoModelo
    {
        public int ID { get; set; }
        public string Matricula { get; set; }
        public string Color { get; set; }
        public SerieModelo Serie { get; set; }
        public int SerieID { get; set; }
    }
}
