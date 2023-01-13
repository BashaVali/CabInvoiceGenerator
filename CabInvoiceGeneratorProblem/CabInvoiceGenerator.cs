using System;
using System.Collections.Generic;
using static Cab_Invoice_Generator.RideOption;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
namespace Cab_Invoice_Generator
{
    public class CabInvoiceGenerator
    {
        private static readonly double COST_PER_KILOMETER = 10.0;
        private static readonly double COST_PER_MINUTE = 1.0;
        private static readonly double MINIMUM_FARE = 5.0;
        private double CAB_FARE = 0.0;
        private RideRepository rideRepository = new RideRepository();
        public double CalculateFare(RideTypes rideTypes, double distance, double time)
        {
            RideOption ride = new RideOption();
            RideOption rides = ride.SetRideValues(rideTypes);
            this.CAB_FARE = (distance * rides.COST_PER_KM) + (time * rides.COST_PER_MINUTE);
            return Math.Max(this.CAB_FARE, rides.MINIMUM_FARE);
        }
        public EnhancedInvoiceSummary GetMultipleRideFare(RideTypes rideTypes, Ride[] rides)
        {
            double totalFare = 0.0;
            foreach (var data in rides)
            {
                totalFare += this.CalculateFare(rideTypes, data.distance, data.time);
            }
            return new EnhancedInvoiceSummary(totalFare, rides.Length);
        }
        public void MapRidesToUser(string userID, Ride[] rides)
        {
            this.rideRepository.AddCabRides(userID, rides);
        }
        public EnhancedInvoiceSummary GetEnhancedInvoiceSummary(RideTypes rideTypes, string userID)
        {
            return this.GetMultipleRideFare(rideTypes, this.rideRepository.GetCabRides(userID));
        }
    }
}
