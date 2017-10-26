using ReckonCodingTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class TextSearchUtilityTests
    {
        private const string TextToSearch = "Peter told me (actually he slurrred) that peter the pickle piper piped a pitted pickle before he petered out. Phew!";
        private const string NoOutput = "<No Output>";
        private TextSearchUtility _textSearchUtility;

        [TestInitialize]
        public void SetUp()
        {
            _textSearchUtility = new TextSearchUtility();
        }

        [TestMethod]
        public void Find_Should_Return_Correct_Output_for_Any_Case()
        {
            var output = "1, 43, 98";
            Assert.AreEqual(_textSearchUtility.Find(TextToSearch, "PETER"), output);
            Assert.AreEqual(_textSearchUtility.Find(TextToSearch, "PeTeR"), output);
            Assert.AreEqual(_textSearchUtility.Find(TextToSearch, "peter"), output);
        }

        [TestMethod]
        public void Find_Should_Work_for_Partial_search()
        {
            Assert.AreEqual(_textSearchUtility.Find(TextToSearch, "Pi"), "53, 60, 66, 74, 81");
            Assert.AreEqual(_textSearchUtility.Find(TextToSearch, "Pick"), "53, 81");
        }
        
        [TestMethod]
        public void Find_Should_Return_No_Output_for_No_Match()
        {
            Assert.AreEqual(_textSearchUtility.Find(TextToSearch, "z"), NoOutput);
        }

        [TestMethod]
        public void Find_Should_Return_No_Output_for_Empty_text()
        {
            Assert.AreEqual(_textSearchUtility.Find(string.Empty, string.Empty), NoOutput);
        }
    }
}
