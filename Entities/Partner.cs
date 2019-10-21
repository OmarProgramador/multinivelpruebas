using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Entities
{
    public class Partner
    {    
        public int id { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string Rango { get; set; }
        public string Documento { get; set; }
       
        public string Estado { get; set; }
        public string NivelP { get; set; }
        public string Nivel { get; set; }
        public string Rama { get; set; }
        public string PatrocinadorP { get; set; }
        public string Upline { get; set; }
        public string ProximaCuota { get; set; }
        public string Puntos { get; set; }
        public string ActivoHasta { get; set; }
        public string TipoCa { get; set; }
        public string NAsociate { get; set; }
        public string FAfiliacion { get; set; }
        public string CalPuntos { get; set; }
        public string TotalAmort { get; set; }
        public string TotalQuote { get; set; }
        public string TotalAff { get; set; }
    }
}
