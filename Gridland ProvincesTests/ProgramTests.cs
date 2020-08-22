using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gridland_Provinces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gridland_Provinces.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void ShiftRightTest()
        {
            var str = Program.ShiftRight("");
            Assert.AreEqual(str, null);

            str = Program.ShiftRight(null);
            Assert.AreEqual(str, null);

            str = Program.ShiftRight("a");
            Assert.AreEqual(str, "a");

            str = Program.ShiftRight("abc");
            Assert.AreEqual(str, "cab");
        }

        [TestMethod()]
        public void ShiftLeftTest()
        {
            var str = Program.ShiftLeft("");
            Assert.AreEqual(str, null);

            str = Program.ShiftLeft(null);
            Assert.AreEqual(str, null);

            str = Program.ShiftLeft("a");
            Assert.AreEqual(str, "a");

            str = Program.ShiftLeft("abc");
            Assert.AreEqual(str, "bca");
        }

        [TestMethod()]
        public void ZigzagTest()
        {
            var str = Program.Zigzag("");
            Assert.AreEqual(str, null);

            str = Program.Zigzag(null);
            Assert.AreEqual(str, null);

            var list = Program.Zigzag("abcd");
            Assert.AreEqual(list.Contains("acdb"), true);
            Assert.AreEqual(list.Contains("cabd"), true);
            Assert.AreEqual(list.Contains("bdca"), true);
            Assert.AreEqual(list.Contains("dbac"), true);

            list = Program.Zigzag("dababd");
            Assert.AreEqual(list.Count, 4);
            Assert.AreEqual(list.Contains("dababd"), true);
            Assert.AreEqual(list.Contains("adabdb"), true);
            Assert.AreEqual(list.Contains("bdbada"), true);
            Assert.AreEqual(list.Contains("dbabad"), true);
        }

        [TestMethod()]
        public void SwapOddEvenCharsTest()
        {
            var str = Program.SwapOddEvenChars("");
            Assert.AreEqual(str, null);

            str = Program.SwapOddEvenChars(null);
            Assert.AreEqual(str, null);

            str = Program.SwapOddEvenChars("abcd");
            Assert.AreEqual(str, "badc");
        }
    }
}