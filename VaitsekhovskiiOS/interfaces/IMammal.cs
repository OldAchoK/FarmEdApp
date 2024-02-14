using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaitsekhovskiiOS.interfaces
{
    internal interface IMammal : IAnimal
    {
        string Gender { get; set; }
    }
}
