using VaitsekhovskiiOS.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaitsekhovskiiOS.classes
{
    internal class Mammal : Animal, IMammal
    {
        protected new string type = "Mammal";
        protected string gender;

        public Mammal(string n, double w, string g) : base(n, w)
        {
            gender = g;
        }
        public Mammal() : base()
        {
            gender = " ";
        }

        public string Gender
        {
            get => gender;
            set => gender = value;
        }
        public override string Type
        {
            get => type;
        }
        /*public override string ToString()
        {
            return this.Type + this.Name + Convert.ToString(this.Weight) + this.Gender; 
        }*/
    }
}
