using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScholarStationUnitTests;
using Moq;
using DataClasses;

namespace ScholarStationUnitTests
{
    [TestClass]
    public class ListingTests
    {
        [TestMethod]
        public void TestListing()
        {
            //Arrange
            var listingA = new Listing();
            listingA.Author = null;
            listingA.Body = null;
            listingA.Heading = null;
            var sut = listingA;

            var listingB = new Listing();
            listingB.Author = "Bub Skebulba";
            listingB.Body = "It's Wednesday my dudes.";
            listingB.Heading = "Procrastination Station";
            listingB.ListingID = 12345;
            var sut1 = listingB;

            //Act
            var sutResult = sut.isNull();
            var sut1Result = sut1.isNull();


            //Assert
            Assert.AreEqual(sutResult, true);
            Assert.AreNotEqual(sut1Result, true);


        }
    }
}
