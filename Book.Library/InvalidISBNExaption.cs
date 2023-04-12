using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Library
{
    public class InvalidISBNExaption:Exception
    {
        public override string Message => "Invalid ISBN"; 
    }
}
