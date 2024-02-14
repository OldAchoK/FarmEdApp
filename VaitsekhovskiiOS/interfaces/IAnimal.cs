using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaitsekhovskiiOS.interfaces
{
    internal interface IAnimal
    {
        string Type { get; }
        string Name { get; set; }
        double Weight { get; set; }
    }
}
