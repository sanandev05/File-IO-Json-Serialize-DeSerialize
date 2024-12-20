using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIO_JSON_Serialize.Desrialize
{
    public class BelowSalePriceException:Exception
    {
        public BelowSalePriceException(string message) : base(message)
        {
            
        }
    }
}
