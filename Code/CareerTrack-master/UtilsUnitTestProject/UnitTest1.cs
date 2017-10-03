using CareerTrack.Utils.Functionalities.SimilarStrings;
using CarrerTrack.Data.Repositories.Read;
using CarrerTrack.Domain.Interfaces.Read;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Diagnostics;

namespace UtilsUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        ISimilarStrings similarStrings;
        [TestMethod]
        public void ArticlesAreSimilar()
        {
            //Arrange
            similarStrings = new SimilarStrings();
            string articleTitle1 = ".NET Fundamentals";
            string articleTitle2 = ".net Fundamental";

            //Act
            bool result = similarStrings.StringComparer(articleTitle1, articleTitle2, 3);

            //Assert
            Assert.AreEqual(result,true);
        }

        [TestMethod]
        public void ArticlesAreSimilar2()
        {
            //Arrange
            similarStrings = new SimilarStrings();
            string articleTitle1 = ".NET Fundamentals";
            string articleTitle2 = ".NET Fundamen4444";

            //Act
            bool result = similarStrings.StringComparer(articleTitle1, articleTitle2, 3);

            //Assert
            Assert.AreNotEqual(result, true);
        }

        //[Ignore]
        //http://stackoverflow.com/questions/11650228/microsoft-unit-testing-is-it-possible-to-skip-test-from-test-method-body
        [TestMethod]
        public void GetUser()
        {
             //http://stackoverflow.com/questions/336288/how-can-i-use-mock-objects-in-my-unit-tests-and-still-use-code-coverage
             Mock <IReadUserRepository> myMock = new Mock<IReadUserRepository>();
            myMock.Setup(m=>m.GetById(1));
            //  string email = (myMock.Object.GetUserByEmail("sosuliviu@gmail.com").Email);
            // Debug.WriteLine("email: "+ email);

            ReadUserRepository myobject = new ReadUserRepository();
              Assert.AreEqual( "sosuliviu@gmail.com", "sosuliviu@gmail.com");
            myMock.VerifyAll();
            /*
             myMock.Expect(m => m.GiveMeAString()).Returns("Hello World");

                MyClass myobject = new MyClass();

                string someString = myobject.GetSomeString(myMock.Object);

                Assert.AreEqual(EXPECTED_STRING, someString);
                myMock.VerifyAll();
            */
        }
    }
}
