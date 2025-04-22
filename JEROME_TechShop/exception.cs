using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEROME_TechShop.exception
{
    public class InvalidDataException : Exception
    {
        public InvalidDataException(string message) : base(message) { }
    }

    public class InsufficientStockException : Exception
    {
        public InsufficientStockException(string message) : base(message) { }
    }
}
