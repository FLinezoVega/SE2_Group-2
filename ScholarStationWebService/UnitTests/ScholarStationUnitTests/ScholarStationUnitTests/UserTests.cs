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
            userB.Email = "sandy@students.uwf.edu";
            userB.Score = "5";
            userB.Verified = true;
            var sut = userB;

            var userA = new User();
            userA.UserID = null;
            userA.University = null;
            userA.Bio = null;
            userA.Email = null;
            userA.Score = null;
            var sut1 = userA;

            var userVerified = new User();
            var userScore = new User();

            //Act
            var sutResult = sut.isNull();
            var sut1Result = sut1.isNull();

            userVerified.Verified = true;
            userB.Verfication.Equals(userB);

            //Assert
            Assert.AreNotEqual(sutResult, true);
            Assert.AreEqual(sut1Result, true);
            Assert.IsTrue(userVerified.Verified);
            Assert.AreEqual("Verfied with " + userB.University, userB.Verfication);



        }
    }
}
