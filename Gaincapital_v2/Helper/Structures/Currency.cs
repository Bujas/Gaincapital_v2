using System;
using System.Collections.Generic;
using System.Text;

namespace Gaincapital_v2.Helper.Structures
{
    public struct Currency
    {
        public double value;
        public string country;

        public Currency(string country, double value)
        {
            this.country = country;
            this.value = value;
        }
    }
}
