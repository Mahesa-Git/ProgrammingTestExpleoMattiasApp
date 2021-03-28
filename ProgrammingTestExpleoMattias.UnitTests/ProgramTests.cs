using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammingTestExpleoMattias.UnitTests
{
    [TestClass] //MSTest framework is used for the unit testing.
    public class ProgramTests
    {
        [TestMethod]
        public void AnagramChecker_IsAnagram_ReturnsTrue()
        {
            //arrange
            string inputOne = "ex pl Eo";
            string inputTwo = "Xe lPoE ";
            //act
            var result = Anagram.AnagramChecker(inputOne, inputTwo);
            //assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void AnagramChecker_IsNotAnagram_ReturnsFalse()
        {
            //arrange
            string inputOne = "ex pl EY";
            string inputTwo = "Xe lPoE ";
            //act
            var result = Anagram.AnagramChecker(inputOne, inputTwo);
            //assert
            Assert.IsFalse(result);
        }
    }
}
