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
            userB.UserID = "Bub Skebulba";
            userB.University = "Clown College";
            userB.Bio = "One time I ate sand in math class.";
            var sut = userB;

            var userA = new User();
            userA.UserID = null;
            userA.University = null;
            userA.Bio = null;
            var sut1 = userA;


            //Act
            sut.isNull();
            sut1.isNull();

            //Assert
            Assert.AreNotEqual(sut.isNull(), true);
            Assert.AreEqual(sut1.isNull(), true);

        }
    }
}
