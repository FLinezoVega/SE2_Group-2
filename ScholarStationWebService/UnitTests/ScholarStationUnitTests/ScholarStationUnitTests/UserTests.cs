using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScholarStationUnitTests;
using Moq;
using DataClasses;

namespace ScholarStationUnitTests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void TestUser()
        {
            //Arrange
            var userB = new User();
            var sut = userB;


            //Act
            sut.isNull();

            //Assert
            Assert.AreNotEqual(sut.isNull(), null);

        }
    }
}
