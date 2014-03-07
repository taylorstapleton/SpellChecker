using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpellCheckerConsole.Classes;
using SpellCheckerConsole.Interfaces;
using System.Collections.Generic;

namespace SpellCheckerTests
{
    [TestClass]
    public class TestOf_Utilities
    {
        [TestMethod]
        public void Success_Validate()
        {
            IUtilities utilities = new Utilities();

            List<string> toTest = new List<string>() { "asdf", "aaa", "AAA", "aAa", "abcdefghijklmnopqrstuvwxyz", "ABCDEFGHIJKLMNOPQRSTUVWXYZ", };

            foreach(string i in toTest)
            {
                bool current = utilities.validateInput(i);
                Assert.IsTrue(current, i + " failed validation");
            }
        }

        [TestMethod]
        public void Failure_Validate()
        {
            IUtilities utilities = new Utilities();

            List<string> toTest = new List<string>() { "asdf123asdf", "a123a", "A123", "a123", "", "1234567890", null};

            foreach (string i in toTest)
            {
                bool current = utilities.validateInput(i);
                Assert.IsFalse(current, i + " failed validation");
            }
        }

        [TestMethod]
        public void Success_listDuplicateVariations()
        {
            string toTest = "abcccdefff";
            List<string> oracle = new List<string>() { "abcdef", "abccdef", "abcccdef", "abcdeff", "abccdeff", "abcccdeff", "abcdefff", "abccdefff", "abcccdefff" };

            IUtilities utilities = new Utilities();

            List<string> result = utilities.listDuplicateVariations(toTest);

            Assert.AreEqual(result.Count, oracle.Count, "count is wrong");
            
            foreach(string i in oracle)
            {
                Assert.IsTrue(result.Contains(i), i);
            }

            foreach(string i in result)
            {
                Assert.IsTrue(oracle.Contains(i), i);
            }
        }

        [TestMethod]
        public void Success_listDuplicateVariations2()
        {
            string toTest = "abcccdef";
            List<string> oracle = new List<string>() { "abcdef", "abccdef", "abcccdef" };

            IUtilities utilities = new Utilities();

            List<string> result = utilities.listDuplicateVariations(toTest);

            Assert.AreEqual(result.Count, oracle.Count, "count is wrong");

            foreach (string i in oracle)
            {
                Assert.IsTrue(result.Contains(i), i);
            }

            foreach (string i in result)
            {
                Assert.IsTrue(oracle.Contains(i), i);
            }
        }

        [TestMethod]
        public void Success_listDuplicateVariations3()
        {
            string toTest = "abcdef";
            List<string> oracle = new List<string>() { "abcdef"};

            IUtilities utilities = new Utilities();

            List<string> result = utilities.listDuplicateVariations(toTest);

            Assert.AreEqual(result.Count, oracle.Count, "count is wrong");

            foreach (string i in oracle)
            {
                Assert.IsTrue(result.Contains(i), i);
            }

            foreach (string i in result)
            {
                Assert.IsTrue(oracle.Contains(i), i);
            }
        }

        [TestMethod]
        public void Success_listDuplicateVariations4()
        {
            string toTest = "a";
            List<string> oracle = new List<string>() { "a" };

            IUtilities utilities = new Utilities();

            List<string> result = utilities.listDuplicateVariations(toTest);

            Assert.AreEqual(result.Count, oracle.Count, "count is wrong");

            foreach (string i in oracle)
            {
                Assert.IsTrue(result.Contains(i), i);
            }

            foreach (string i in result)
            {
                Assert.IsTrue(oracle.Contains(i), i);
            }
        }
    }
}
