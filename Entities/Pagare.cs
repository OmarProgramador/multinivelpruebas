using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Pagare
    {
        public int Id { get; set; }

        public string Codigo { get; set; }

        public decimal MontoSoles { get; set; }

        public string MontoSolesLetras { get; set; }

        public string NombreCompleto { get; set; }

        public string Dni { get; set; }

        public string Domicilio { get; set; }

        public int NCuotas { get; set; }

        public string FechaCuotas { get; set; }

        public decimal ValorCuotas { get; set; }

        public string Fecha { get; set; }

    }
}
