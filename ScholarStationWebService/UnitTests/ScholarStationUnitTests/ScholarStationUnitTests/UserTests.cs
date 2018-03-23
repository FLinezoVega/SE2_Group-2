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
            var user0 = new Mock<User>(UserType.Basic);
            var user1 = new Mock<User>(UserType.Tutor);
            var user2 = new Mock<User>(UserType.Faculty);
            var user3 = new Mock<User>(UserType.Admin);

            //Act

            //Assert
        }
    }
}
