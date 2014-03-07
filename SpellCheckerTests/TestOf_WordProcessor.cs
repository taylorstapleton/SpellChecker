using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpellCheckerConsole.Classes;
using SpellCheckerConsole.Interfaces;
using Moq;

namespace SpellCheckerTests
{
    /// <summary>
    /// Summary description for TestOf_WordProcessor
    /// </summary>
    [TestClass]
    public class TestOf_WordProcessor
    {
        [TestMethod]
        public void success_resolve()
        {
            IUtilities utilities = new Utilities();

            var mockWordDictionary = new Mock<IWordDictionary>();
            var mockUtilities = new Mock<IUtilities>();
            
            mockWordDictionary.Setup(m => m.checkWord(It.IsAny<string>())).Returns(false);
            mockWordDictionary.Setup(m => m.checkWord(It.IsRegex("cat"))).Returns(true);

            mockUtilities.Setup(m => m.listDuplicateVariations(It.IsRegex("caat"))).Returns(new List<string>(){"cat", "caat" });
            mockUtilities.Setup(m => m.listVowelVariations(It.IsRegex("caat"))).Returns(new List<string>() { 
            "caat", "caot", "caet", "cait", "caut",
            "coat", "coot", "coet", "coit", "cout",
            "cuat", "cuot", "cuet", "cuit", "cuut",
            "ciat", "ciot", "ciet", "ciit", "ciut",
            "coat", "coot", "coet", "coit", "cout"});

            mockUtilities.Setup(m => m.validateInput(It.IsAny<string>())).Returns(true);

            IWordProcessor wordProcessor = new WordProcessor(mockUtilities.Object, mockWordDictionary.Object);

            string result = wordProcessor.resolveWord("caat");

            Assert.AreEqual("cat", result);
        }
    }
}
