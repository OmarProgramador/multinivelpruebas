using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Partner2 : Partner
    {
        public List<Partner3> children { get; set; }
    }
}
