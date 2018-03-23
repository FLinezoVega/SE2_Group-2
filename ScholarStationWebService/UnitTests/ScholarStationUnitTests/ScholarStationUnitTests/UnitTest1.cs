using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScholarStationUnitTests;
using Moq;
using DataClasses;

namespace ScholarStationUnitTests
{
    [TestClass]
    public class UserClassTests
    {
        [TestMethod]
        public void TestUser()
        {
            //Arrange
            var user = new Mock<User>(UserType.Basic);

            //Act

            //Assert
        }
    }
}
