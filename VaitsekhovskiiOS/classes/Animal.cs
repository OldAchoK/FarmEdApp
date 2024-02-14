
using VaitsekhovskiiOS.interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaitsekhovskiiOS.classes
{
    internal class Animal : IAnimal
    {
        protected string type = "Animal";
        protected string name;
        protected double weight;

        public Animal(string n, double w)
        {
            name = n;
            weight = w;
        }
        public Animal()
        {
            name = " ";
            weight = -1;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public double Weight
        {
            get => weight;
            set => weight = value;
        }
        public virtual string Type
        {
            get => type;
        }
        /*public override string ToString()
        {
            return this.Type+this.Name+Convert.ToString(this.Weight);
        }*/
    }
}
