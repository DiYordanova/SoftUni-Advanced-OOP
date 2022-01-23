using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    class Coffee : HotBeverage
    {
        private const decimal DefaultPrice = 3.5M;

        private const double DefaultMilliliters = 50;

        public Coffee(string name, double coffeine)
            : base(name, DefaultPrice, DefaultMilliliters)
        {
            this.Coffeine = coffeine;
        }

        public double Coffeine { get; set; }
    }
}
