﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleTable.Core.Test
{
    [TestClass]
    public class ConsoleTableTest
    {
        [TestMethod]
        public void Test_Create_ConsoleTable_Table_Valid()
        {
            var title = "Title";
            var headers = new[] { "Header 1", "Header2" };
            var consoleTable = new ConsoleTable<string>(table: new string[1, 1], title: title, header: headers);
            Assert.AreEqual(title, consoleTable.Title);
            Assert.AreEqual(headers[0], consoleTable.Header[0]);
            Assert.AreEqual(headers[1], consoleTable.Header[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Create_ConsoleTable_Table_Null()
        {
            new ConsoleTable<string>(table: null);
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_Table_Title_Empty()
        {
            var consoleTable = new ConsoleTable<string>(table: new string[1, 1], title: string.Empty);
            Assert.IsNull(consoleTable.Title);
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_Table_Title_WhiteSpace()
        {
            var consoleTable = new ConsoleTable<string>(table: new string[1, 1], title: "    ");
            Assert.IsNull(consoleTable.Title);
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_Table_Title_Tabs_And_Line_Breaks()
        {
            var consoleTable = new ConsoleTable<string>(table: new string[1, 1], title: "  \n  \t\t\n  \r ");
            Assert.IsNull(consoleTable.Title);
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_RowColumn_Valid()
        {
            var title = "Title";
            var headers = new[] { "Header 1", "Header2" };
            var consoleTable = new ConsoleTable<string>(10, 10, title, headers);
            Assert.AreEqual(title, consoleTable.Title);
            Assert.AreEqual(headers[0], consoleTable.Header[0]);
            Assert.AreEqual(headers[1], consoleTable.Header[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Create_ConsoleTable_RowColumn_Illegal_Rownumber()
        {
            new ConsoleTable<string>(0, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Create_ConsoleTable_RowColumn_Illegal_Columnnumber()
        {
            new ConsoleTable<string>(10, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Create_ConsoleTable_Rows_Null()
        {
            new ConsoleTable<string>(rows: null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Create_ConsoleTable_Rows_First_Dimension_Empty()
        {
            new ConsoleTable<string>(rows: new string[0][]);
        }
    }
}