namespace MVC23.Models
{
    public class VehiculoExtraModelo
    {
        public int ID { get; set; }
        public int extraID { get; set; }
        public ExtraModelo Extra { get; set; }
        public int vehiculoID { get; set; }
        public VehiculoExtraModelo vehiculo { get; set; }
    }
}
