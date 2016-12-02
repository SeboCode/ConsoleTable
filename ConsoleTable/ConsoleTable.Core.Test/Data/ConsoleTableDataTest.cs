using System;
using System.Linq;
using ConsoleTable.Core.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleTable.Core.Test.Data
{
    [TestClass]
    public class ConsoleTableDataTest
    {
        #region Tests for table-constructor
        [TestMethod]
        public void Test_Create_ConsoleTable_Table_Valid()
        {
            var title = "Title";
            var header = new[] { "Header 1", "Header2" };
            var consoleTable = new ConsoleTableData<string>(new string[1, 1], title, header);
            Assert.AreEqual(title, consoleTable.Title);
            Assert.AreEqual(header.First(), consoleTable.Header.First());
            Assert.AreEqual(header.Last(), consoleTable.Header.Last());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Create_ConsoleTable_Table_Null()
        {
            new ConsoleTableData<string>(table: null);
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_Table_Title_Empty()
        {
            var consoleTable = new ConsoleTableData<string>(new string[1, 1], string.Empty);
            Assert.IsNull(consoleTable.Title);
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_Table_Title_WhiteSpace()
        {
            var consoleTable = new ConsoleTableData<string>(new string[1, 1], "    ");
            Assert.IsNull(consoleTable.Title);
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_Table_Title_Tabs_And_Line_Breaks()
        {
            var consoleTable = new ConsoleTableData<string>(new string[1, 1], "  \n  \t\t\n  \r ");
            Assert.IsNull(consoleTable.Title);
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_Table_One_Header_Element_Empty()
        {
            var header = new[] {string.Empty};
            var consoleTable = new ConsoleTableData<string>(new string[1, 1], header: header);
            Assert.IsNull(consoleTable.Header.First());
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_Table_One_Header_Element_WhiteSpace()
        {
            var header = new[] {"    "};
            var consoleTable = new ConsoleTableData<string>(new string[1, 1], header: header);
            Assert.IsNull(consoleTable.Header.First());
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_Table_One_Header_Element_Tabs_And_Line_Breaks()
        {
            var header = new[] {"  \n  \t\t\n  \r "};
            var consoleTable = new ConsoleTableData<string>(new string[1, 1], header: header);
            Assert.IsNull(consoleTable.Header.First());
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_Table_Multiple_Header_Element_Empty()
        {
            var header = new[] {"Test", string.Empty};
            var consoleTable = new ConsoleTableData<string>(new string[1, 1], header: header);
            Assert.AreEqual(header.First(), consoleTable.Header.First());
            Assert.IsNull(consoleTable.Header.Last());
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_Table_Multiple_Header_Element_WhiteSpace()
        {
            var header = new[] {"Test", "    "};
            var consoleTable = new ConsoleTableData<string>(new string[1, 1], header: header);
            Assert.AreEqual(header.First(), consoleTable.Header.First());
            Assert.IsNull(consoleTable.Header.Last());
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_Table_Multiple_Header_Element_Tabs_And_Line_Breaks()
        {
            var header = new[] {"Test", "  \n  \t\t\n  \r "};
            var consoleTable = new ConsoleTableData<string>(new string[1, 1], header: header);
            Assert.AreEqual(header.First(), consoleTable.Header.First());
            Assert.IsNull(consoleTable.Header.Last());
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_Table_Settings_Not_Null()
        {
            var consoleTable = new ConsoleTableData<string>(new string[1, 1]);
            Assert.IsNotNull(consoleTable.Settings);
        }
        #endregion

        #region Tests for row-column-constructor
        [TestMethod]
        public void Test_Create_ConsoleTable_RowColumn_Valid()
        {
            var title = "Title";
            var header = new[] { "Header 1", "Header2" };
            var row = 5;
            var column = 10;
            var consoleTable = new ConsoleTableData<string>(row, column, title, header);
            Assert.AreEqual(row, consoleTable.RowCount);
            Assert.AreEqual(column, consoleTable.ColumnCount);
            Assert.AreEqual(title, consoleTable.Title);
            Assert.AreEqual(header.First(), consoleTable.Header.First());
            Assert.AreEqual(header.Last(), consoleTable.Header.Last());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Create_ConsoleTable_RowColumn_Illegal_Rownumber()
        {
            new ConsoleTableData<string>(0, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Create_ConsoleTable_RowColumn_Illegal_Columnnumber()
        {
            new ConsoleTableData<string>(10, 0);
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_RowColumn_Title_Empty()
        {
            var consoleTable = new ConsoleTableData<string>(1, 1, string.Empty);
            Assert.IsNull(consoleTable.Title);
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_RowColumn_Title_WhiteSpace()
        {
            var consoleTable = new ConsoleTableData<string>(1, 1, "    ");
            Assert.IsNull(consoleTable.Title);
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_RowColumn_Title_Tabs_And_Line_Breaks()
        {
            var consoleTable = new ConsoleTableData<string>(1, 1, "  \n  \t\t\n  \r ");
            Assert.IsNull(consoleTable.Title);
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_RowColumn_One_Header_Element_Empty()
        {
            var header = new[] {string.Empty};
            var consoleTable = new ConsoleTableData<string>(1, 1, header: header);
            Assert.IsNull(consoleTable.Header.First());
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_RowColumn_One_Header_Element_WhiteSpace()
        {
            var header = new[] {"    "};
            var consoleTable = new ConsoleTableData<string>(1, 1, header: header);
            Assert.IsNull(consoleTable.Header.First());
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_RowColumn_One_Header_Element_Tabs_And_Line_Breaks()
        {
            var header = new[] {"  \n  \t\t\n  \r "};
            var consoleTable = new ConsoleTableData<string>(1, 1, header: header);
            Assert.IsNull(consoleTable.Header.First());
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_RowColumn_Multiple_Header_Element_Empty()
        {
            var header = new[] {"Test", string.Empty};
            var consoleTable = new ConsoleTableData<string>(1, 1, header: header);
            Assert.AreEqual(header.First(), consoleTable.Header.First());
            Assert.IsNull(consoleTable.Header.Last());
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_RowColumn_Multiple_Header_Element_WhiteSpace()
        {
            var header = new[] {"Test", "    "};
            var consoleTable = new ConsoleTableData<string>(1, 1, header: header);
            Assert.AreEqual(header.First(), consoleTable.Header.First());
            Assert.IsNull(consoleTable.Header.Last());
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_RowColumn_Multiple_Header_Element_Tabs_And_Line_Breaks()
        {
            var header = new[] {"Test", "  \n  \t\t\n  \r "};
            var consoleTable = new ConsoleTableData<string>(1, 1, header: header);
            Assert.AreEqual(header.First(), consoleTable.Header.First());
            Assert.IsNull(consoleTable.Header.Last());
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_RowColumn_Settings_Not_Null()
        {
            var consoleTable = new ConsoleTableData<string>(1, 1);
            Assert.IsNotNull(consoleTable.Settings);
        }
        #endregion

        #region Tests for rows-constructor
        [TestMethod]
        public void Test_Create_ConsoleTable_Rows_Valid()
        {
            var fillerElement = "filler";
            var title = "Title";
            var header = new[] {"Header 1", "Header2"};
            var row1 = new string[0];
            var row2 = new[] {"Hello", "World"};
            var consoleTable = new ConsoleTableData<string>(fillerElement, title, header, row1, row2);
            Assert.AreEqual(title, consoleTable.Title);
            Assert.AreEqual(header.First(), consoleTable.Header.First());
            Assert.AreEqual(header.Last(), consoleTable.Header.Last());
            Assert.AreEqual(fillerElement, consoleTable[0, 0]);
            Assert.AreEqual(fillerElement, consoleTable[0, 1]);
            Assert.AreEqual(row2.First(), consoleTable[1, 0]);
            Assert.AreEqual(row2.Last(), consoleTable[1, 1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Create_ConsoleTable_Rows_Null()
        {
            new ConsoleTableData<string>(rows: null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Create_ConsoleTable_Rows_First_Dimension_Empty()
        {
            new ConsoleTableData<string>(rows: new string[0][]);
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_Rows_Second_Dimension_Some_Empty()
        {
            var row1 = new[] {"Row1"};
            var row2 = new[] {"Hello", "World"};
            var consoleTable = new ConsoleTableData<string>(rows: new[] {row1, row2});
            Assert.IsNull(consoleTable[0, 1]);
            Assert.AreEqual(row1.First(), consoleTable[0, 0]);
            Assert.AreEqual(row2.First(), consoleTable[1, 0]);
            Assert.AreEqual(row2.Last(), consoleTable[1, 1]);
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_Rows_Second_Dimension_One_Row_Empty()
        {
            var row1 = new string[0];
            var row2 = new[] {"Hello", "World"};
            var consoleTable = new ConsoleTableData<string>(rows: new[] {row1, row2});
            Assert.IsNull(consoleTable[0, 0]);
            Assert.IsNull(consoleTable[0, 1]);
            Assert.AreEqual(row2.First(), consoleTable[1, 0]);
            Assert.AreEqual(row2.Last(), consoleTable[1, 1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Create_ConsoleTable_Rows_Second_Dimension_All_Empty()
        {
            var row1 = new string[0];
            var row2 = new string[0];
            new ConsoleTableData<string>(rows: new[] { row1, row2 });
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_Rows_Custom_FillerElement()
        {
            var fillerElement = "filler";
            var row1 = new string[0];
            var row2 = new[] {"Hello", "World"};
            var consoleTable = new ConsoleTableData<string>(fillerElement, rows: new[] {row1, row2});
            Assert.AreEqual(fillerElement, consoleTable[0, 0]);
            Assert.AreEqual(fillerElement, consoleTable[0, 1]);
        }
        
        [TestMethod]
        public void Test_Create_ConsoleTable_Rows_Title_Empty()
        {
            var row1 = new string[0];
            var row2 = new[] {"Hello", "World"};
            var consoleTable = new ConsoleTableData<string>(title: string.Empty, rows: new[] {row1, row2});
            Assert.IsNull(consoleTable.Title);
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_Rows_Title_WhiteSpace()
        {
            var row1 = new string[0];
            var row2 = new[] {"Hello", "World"};
            var consoleTable = new ConsoleTableData<string>(title: "    ", rows: new[] {row1, row2});
            Assert.IsNull(consoleTable.Title);
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_Rows_Title_Tabs_And_Line_Breaks()
        {
            var row1 = new string[0];
            var row2 = new[] {"Hello", "World"};
            var consoleTable = new ConsoleTableData<string>(title: "  \n  \t\t\n  \r ", rows: new[] {row1, row2});
            Assert.IsNull(consoleTable.Title);
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_Rows_One_Header_Element_Empty()
        {
            var row1 = new string[0];
            var row2 = new[] {"Hello", "World"};
            var header = new[] {string.Empty};
            var consoleTable = new ConsoleTableData<string>(header: header, rows: new[] {row1, row2});
            Assert.IsNull(consoleTable.Header.First());
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_Rows_One_Header_Element_WhiteSpace()
        {
            var row1 = new string[0];
            var row2 = new[] {"Hello", "World"};
            var header = new[] {"    "};
            var consoleTable = new ConsoleTableData<string>(header: header, rows: new[] {row1, row2});
            Assert.IsNull(consoleTable.Header.First());
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_Rows_One_Header_Element_Tabs_And_Line_Breaks()
        {
            var row1 = new string[0];
            var row2 = new[] {"Hello", "World"};
            var header = new[] {"  \n  \t\t\n  \r "};
            var consoleTable = new ConsoleTableData<string>(header: header, rows: new[] {row1, row2});
            Assert.IsNull(consoleTable.Header.First());
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_Rows_Multiple_Header_Element_Empty()
        {
            var row1 = new string[0];
            var row2 = new[] {"Hello", "World"};
            var header = new[] {"Test", string.Empty};
            var consoleTable = new ConsoleTableData<string>(header: header, rows: new[] {row1, row2});
            Assert.AreEqual(header.First(), consoleTable.Header.First());
            Assert.IsNull(consoleTable.Header.Last());
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_Rows_Multiple_Header_Element_WhiteSpace()
        {
            var row1 = new string[0];
            var row2 = new[] {"Hello", "World"};
            var header = new[] {"Test", "    "};
            var consoleTable = new ConsoleTableData<string>(header: header, rows: new[] {row1, row2});
            Assert.AreEqual(header.First(), consoleTable.Header.First());
            Assert.IsNull(consoleTable.Header.Last());
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_Rows_Multiple_Header_Element_Tabs_And_Line_Breaks()
        {
            var row1 = new string[0];
            var row2 = new[] {"Hello", "World"};
            var header = new[] {"Test", "  \n  \t\t\n  \r "};
            var consoleTable = new ConsoleTableData<string>(header: header, rows: new[] {row1, row2});
            Assert.AreEqual(header.First(), consoleTable.Header.First());
            Assert.IsNull(consoleTable.Header.Last());
        }

        [TestMethod]
        public void Test_Create_ConsoleTable_Rows_Settings_Not_Null()
        {
            var row1 = new string[0];
            var row2 = new[] {"Hello", "World"};
            var consoleTable = new ConsoleTableData<string>(rows: new[] {row1, row2});
            Assert.IsNotNull(consoleTable.Settings);
        }
        #endregion
    }
}