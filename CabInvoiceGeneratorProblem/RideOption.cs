using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cab_Invoice_Generator
{
    public class RideOption
    {
        public double COST_PER_KM;
        public double COST_PER_MINUTE;
        public double MINIMUM_FARE;
        public enum RideTypes
        {
            NORMAL,
            PREMIUM
        }
        public RideTypes rideTypes;
        public RideOption(double COST_PER_KM, double COST_PER_MINUTE, double MINIMUM_FARE)
        {
            this.COST_PER_KM = COST_PER_KM;
            this.COST_PER_MINUTE = COST_PER_MINUTE;
            this.MINIMUM_FARE = MINIMUM_FARE;
        }
        public RideOption()
        {

        }
        public RideOption SetRideValues(RideTypes rideTypes)
        {
            switch (rideTypes)
            {
                case RideTypes.NORMAL:
                    return new RideOption(10.0, 1.0, 5.0);
                case RideTypes.PREMIUM:
                    return new RideOption(15.0, 2.0, 20.0);
                default:
                    return null;
            }
        }
    }
}
