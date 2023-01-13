using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cab_Invoice_Generator
{
    public class EnhancedInvoiceSummary
    {
        public double totalNumberOfRides;
        public double totalFare;
        public double averageFarePerRide;

        public EnhancedInvoiceSummary(double totalFare, double totalNumberOfRides)
        {
            this.totalFare = totalFare;
            this.totalNumberOfRides = totalNumberOfRides;
            this.averageFarePerRide = this.totalFare / this.totalNumberOfRides;
        }
    }
}
