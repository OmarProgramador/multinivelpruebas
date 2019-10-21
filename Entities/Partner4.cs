using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Partner4 : Partner
    {
        public List<Partner5> children { get; set; }
    }
}
