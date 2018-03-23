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
            var userB = new Mock<User>(UserType.Basic);
            userB.Setup(r => r.isNull().Equals("Null"));
            /*var mockUser = new Mock<IUser>();
            userB.Setup(r => r.isNull().Equals(userB.Object));
            var sut = userB.Object;*/


            //Act
            /*sut.isNull();*/

            //Assert
            /*Assert.AreEqual(sut.isNull(), "Null");*/

        }
    }
}
