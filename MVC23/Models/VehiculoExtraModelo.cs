﻿namespace MVC23.Models
{
    public class VehiculoExtraModelo
    {
        public int ID { get; set; }
        public VeiculoModelo vehiculo { get; set; }
        public int VehiculoID { get; set; }
        public ExtraModelo Extra { get; set; }
        public int ExtraID { get; set; }
    }
}
