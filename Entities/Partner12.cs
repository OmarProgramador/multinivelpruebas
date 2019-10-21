using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Partner12 : Partner
    {
        public List<Partner13> children { get; set; }
    }
}
