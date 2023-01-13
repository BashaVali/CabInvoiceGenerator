using Cab_Invoice_Generator;

namespace Cab_Invoice_GeneratorTest
{
    public class CabInvoiceTest
    {
        private CabInvoiceGenerator cabInvoiceGenerator;
        [SetUp]
        public void Setup()            //For creating instance of class
        {
            this.cabInvoiceGenerator = new CabInvoiceGenerator();
        }

        [Test]
        //Test to get total fare using given time and distance
        public void GivenProperDistanceAndTimeForSingleRide_ShouldReturnTotalFare()
        {
            double totalFare = cabInvoiceGenerator.CalculateFare(3.0, 5.0);
            Assert.AreEqual(35.0, totalFare);
        }
        [Test]
        //Test to get Mininum Fare when given less than minimum fare
        public void GivenProperDistanceAndTimeForSingleRide_LessThanMinFare_ShouldReturnMinimumFare()
        {
            double CabFare = cabInvoiceGenerator.CalculateFare(0.1, 0.5);
            Assert.AreEqual(5, CabFare);
        }
        [Test]
        //Test to get aggregate fare for multiple rides
        public void GivenProperDistanceAndTimeForMultipleRide_ShouldReturnAggregateFare()
        {
            Ride[] ride = { new Ride(3.0, 5.0), new Ride(2.0, 5.0), new Ride(0.1, 0.5) };
            double INVOICE_SUMMARY = this.cabInvoiceGenerator.GetMultipleRideFare(ride);
            Assert.AreEqual(65, INVOICE_SUMMARY);
        }
    }
}
