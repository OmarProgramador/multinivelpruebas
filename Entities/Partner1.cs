using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Partner1 : Partner
    {
        public List<Partner2> children { get; set; }
    }
}
