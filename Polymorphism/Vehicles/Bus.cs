using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double BusAirConditionModifier = 1.4;

        public Bus(double fuel, double fuelConsumption, double tankCapacity)
            : base(fuel, fuelConsumption, tankCapacity, BusAirConditionModifier)
        {
        }

        public void TurnOnAirConditioner()
        {
            this.AirConditionerModifier = BusAirConditionModifier;
        }

        public void TurnOffAirConditioner()
        {
            this.AirConditionerModifier = 0;
        }
    }
}
