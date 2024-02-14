using VaitsekhovskiiOS.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaitsekhovskiiOS.classes
{
    internal class Artiodactyl : Mammal, IArtidactyl
    {
        private new string type = "Artiodactyl";
        private bool horns;

        public Artiodactyl() : base()
        {
            horns = false;
        }
        public Artiodactyl(string n, double w, string g, bool h) : base(n, w, g)
        {
            horns = h;
        }
        public override string Type
        {
            get => type;
        }
        public bool Horns
        {
            get => horns;
            set => horns = value;
        }
        /*public override string ToString()
        {
            return this.Type + this.Name + Convert.ToString(this.Weight) + this.Gender + Convert.ToString(this.Horns);
        }*/
    }
}
