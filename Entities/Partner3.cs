using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Partner3 : Partner
    {
        public List<Partner4> children { get; set; }
    }
}
