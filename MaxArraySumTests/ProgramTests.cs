using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaxArraySum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaxArraySum.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void MaxSubsetSumTest()
        {
            var list = new List<int>() {2, 1, 5};
            Assert.AreEqual(Program.MaxSubsetSum(list), 7);

            list = new List<int>() { 2, 1 };
            Assert.AreEqual(Program.MaxSubsetSum(list), 2);

            list = new List<int>() { 1 };
            Assert.AreEqual(Program.MaxSubsetSum(list), 1);

            list = new List<int>() {2, 1, 5, 8};
            Assert.AreEqual(Program.MaxSubsetSum(list), 10);

            list = new List<int>() {2, 1, 5, 8, 4};
            Assert.AreEqual(Program.MaxSubsetSum(list), 11);


        }
    }
}