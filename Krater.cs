using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kraterek
{
    internal class Krater
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double R { get; set; }
        public string Nev { get; set; }

        public Krater(string item)
        {
            string[] tmp = item.Split('\t');
            X = double.Parse(tmp[0]);
            Y = double.Parse(tmp[1]);
            R = double.Parse(tmp[2]);
            Nev = tmp[3];
        }
    }
}
