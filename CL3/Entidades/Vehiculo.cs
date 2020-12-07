using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL3.Entidades
{
    public class Vehiculo
    {
        public int IdVehiculo { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string AnioFabricacion { get; set; }
        public string Certificado { get; set; }
        public decimal PesoMaximo { get; set; }
        public decimal VolumenMaximo { get; set; }
    }
}
