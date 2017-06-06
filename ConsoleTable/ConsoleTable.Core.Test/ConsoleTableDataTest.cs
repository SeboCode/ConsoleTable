using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleTable.Core.Test
{
    [TestClass]
    public class ConsoleTableDataTest
    {
        [TestMethod]
        public void Test_Get_Value_Valid()
        {
            var firstRowFirstColumn = 2;
            var firstRowSecondColumn = 3;
            var secondRowFirstColumn = 3;
            var secondRowSecondColumn = 1;
            var thirdRowFirstColumn = 8;
            var thirdRowSecondColumn = 5;

            var table = new[,]
            {
                {firstRowFirstColumn, firstRowSecondColumn},
                {secondRowFirstColumn, secondRowSecondColumn},
                {thirdRowFirstColumn, thirdRowSecondColumn}
            };

            var consoleTable = new ConsoleTable<int>(table);
            Assert.AreEqual(firstRowFirstColumn, consoleTable[0, 0]);
            Assert.AreEqual(firstRowSecondColumn, consoleTable[0, 1]);
            Assert.AreEqual(secondRowFirstColumn, consoleTable[1, 0]);
            Assert.AreEqual(secondRowSecondColumn, consoleTable[1, 1]);
            Assert.AreEqual(thirdRowFirstColumn, consoleTable[2, 0]);
            Assert.AreEqual(thirdRowSecondColumn, consoleTable[2, 1]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Test_Get_Value_Row_Too_Large()
        {
            var table = new[,] {{2, 3}, {3, 1}, {8, 5}};
            var consoleTable = new ConsoleTable<int>(table);
            var value = consoleTable[10000, 0];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Test_Get_Value_Column_Too_Large()
        {
            var table = new[,] {{2, 3}, {3, 1}, {8, 5}};
            var consoleTable = new ConsoleTable<int>(table);
            var value = consoleTable[0, 10000];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Test_Get_Value_Row_Negative()
        {
            var table = new[,] {{2, 3}, {3, 1}, {8, 5}};
            var consoleTable = new ConsoleTable<int>(table);
            var value = consoleTable[-1, 0];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Test_Get_Value_Column_Negative()
        {
            var table = new[,] {{2, 3}, {3, 1}, {8, 5}};
            var consoleTable = new ConsoleTable<int>(table);
            var value = consoleTable[0, -1];
        }

        [TestMethod]
        public void Test_Set_Value_Valid()
        {
            var newValue = 10;
            var row = 2;
            var column = 1;
            var table = new[,] {{2, 3}, {3, 1}, {8, 5}};
            var consoleTable = new ConsoleTable<int>(table);
            consoleTable[row, column] = newValue;
            Assert.AreEqual(newValue, consoleTable[row, column]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Test_Set_Value_Row_Too_Large()
        {
            var table = new[,] {{2, 3}, {3, 1}, {8, 5}};
            var consoleTable = new ConsoleTable<int>(table);
            consoleTable[10000, 0] = 10;
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Test_Set_Value_Column_Too_Large()
        {
            var table = new[,] {{2, 3}, {3, 1}, {8, 5}};
            var consoleTable = new ConsoleTable<int>(table);
            consoleTable[0, 10000] = 10;
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Test_Set_Value_Row_Negative()
        {
            var table = new[,] {{2, 3}, {3, 1}, {8, 5}};
            var consoleTable = new ConsoleTable<int>(table);
            consoleTable[-1, 0] = 10;
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Test_Set_Value_Column_Negative()
        {
            var table = new[,] {{2, 3}, {3, 1}, {8, 5}};
            var consoleTable = new ConsoleTable<int>(table);
            consoleTable[0, -1] = 10;
        }

        #region Tests for table-constructor
        [TestMethod]
        public void Test_Create_Table_Valid()
        {
            var title = "Title";
            var header = new[] { "Header 1", "Header2" };
            var consoleTable = new ConsoleTable<string>(new string[1, 1], title, header);
            Assert.AreEqual(title, consoleTable.Title);
            Assert.AreEqual(header.First(), consoleTable.Header.First());
            Assert.AreEqual(header.Last(), consoleTable.Header.Last());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Create_Table_Null()
        {
            new ConsoleTable<string>(table: null);
        }

        [TestMethod]
        public void Test_Create_Table_Title_Empty()
        {
            var consoleTable = new ConsoleTable<string>(new string[1, 1], string.Empty);
            Assert.IsNull(consoleTable.Title);
        }

        [TestMethod]
        public void Test_Create_Table_Title_WhiteSpace()
        {
            var consoleTable = new ConsoleTable<string>(new string[1, 1], "    ");
            Assert.IsNull(consoleTable.Title);
        }

        [TestMethod]
        public void Test_Create_Table_Title_Tabs_And_Line_Breaks()
        {
            var consoleTable = new ConsoleTable<string>(new string[1, 1], "  \n  \t\t\n  \r ");
            Assert.IsNull(consoleTable.Title);
        }

        [TestMethod]
        public void Test_Create_Table_One_Header_Element_Empty()
        {
            var header = new[] {string.Empty};
            var consoleTable = new ConsoleTable<string>(new string[1, 1], header: header);
            Assert.IsNull(consoleTable.Header.First());
        }

        [TestMethod]
        public void Test_Create_Table_One_Header_Element_WhiteSpace()
        {
            var header = new[] {"    "};
            var consoleTable = new ConsoleTable<string>(new string[1, 1], header: header);
            Assert.IsNull(consoleTable.Header.First());
        }

        [TestMethod]
        public void Test_Create_Table_One_Header_Element_Tabs_And_Line_Breaks()
        {
            var header = new[] {"  \n  \t\t\n  \r "};
            var consoleTable = new ConsoleTable<string>(new string[1, 1], header: header);
            Assert.IsNull(consoleTable.Header.First());
        }

        [TestMethod]
        public void Test_Create_Table_Multiple_Header_Element_Empty()
        {
            var header = new[] {"Test", string.Empty};
            var consoleTable = new ConsoleTable<string>(new string[1, 1], header: header);
            Assert.AreEqual(header.First(), consoleTable.Header.First());
            Assert.IsNull(consoleTable.Header.Last());
        }

        [TestMethod]
        public void Test_Create_Table_Multiple_Header_Element_WhiteSpace()
        {
            var header = new[] {"Test", "    "};
            var consoleTable = new ConsoleTable<string>(new string[1, 1], header: header);
            Assert.AreEqual(header.First(), consoleTable.Header.First());
            Assert.IsNull(consoleTable.Header.Last());
        }

        [TestMethod]
        public void Test_Create_Table_Multiple_Header_Element_Tabs_And_Line_Breaks()
        {
            var header = new[] {"Test", "  \n  \t\t\n  \r "};
            var consoleTable = new ConsoleTable<string>(new string[1, 1], header: header);
            Assert.AreEqual(header.First(), consoleTable.Header.First());
            Assert.IsNull(consoleTable.Header.Last());
        }
        #endregion

        #region Tests for row-column-constructor
        [TestMethod]
        public void Test_Create_RowColumn_Valid()
        {
            var title = "Title";
            var header = new[] { "Header 1", "Header2" };
            var row = 5;
            var column = 10;
            var consoleTable = new ConsoleTable<string>(row, column, title, header);
            Assert.AreEqual(row, consoleTable.RowCount);
            Assert.AreEqual(column, consoleTable.ColumnCount);
            Assert.AreEqual(title, consoleTable.Title);
            Assert.AreEqual(header.First(), consoleTable.Header.First());
            Assert.AreEqual(header.Last(), consoleTable.Header.Last());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Create_RowColumn_Illegal_Rownumber()
        {
            new ConsoleTable<string>(0, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Create_RowColumn_Illegal_Columnnumber()
        {
            new ConsoleTable<string>(10, 0);
        }

        [TestMethod]
        public void Test_Create_RowColumn_Title_Empty()
        {
            var consoleTable = new ConsoleTable<string>(1, 1, string.Empty);
            Assert.IsNull(consoleTable.Title);
        }

        [TestMethod]
        public void Test_Create_RowColumn_Title_WhiteSpace()
        {
            var consoleTable = new ConsoleTable<string>(1, 1, "    ");
            Assert.IsNull(consoleTable.Title);
        }

        [TestMethod]
        public void Test_Create_RowColumn_Title_Tabs_And_Line_Breaks()
        {
            var consoleTable = new ConsoleTable<string>(1, 1, "  \n  \t\t\n  \r ");
            Assert.IsNull(consoleTable.Title);
        }

        [TestMethod]
        public void Test_Create_RowColumn_One_Header_Element_Empty()
        {
            var header = new[] {string.Empty};
            var consoleTable = new ConsoleTable<string>(1, 1, header: header);
            Assert.IsNull(consoleTable.Header.First());
        }

        [TestMethod]
        public void Test_Create_RowColumn_One_Header_Element_WhiteSpace()
        {
            var header = new[] {"    "};
            var consoleTable = new ConsoleTable<string>(1, 1, header: header);
            Assert.IsNull(consoleTable.Header.First());
        }

        [TestMethod]
        public void Test_Create_RowColumn_One_Header_Element_Tabs_And_Line_Breaks()
        {
            var header = new[] {"  \n  \t\t\n  \r "};
            var consoleTable = new ConsoleTable<string>(1, 1, header: header);
            Assert.IsNull(consoleTable.Header.First());
        }

        [TestMethod]
        public void Test_Create_RowColumn_Multiple_Header_Element_Empty()
        {
            var header = new[] {"Test", string.Empty};
            var consoleTable = new ConsoleTable<string>(1, 1, header: header);
            Assert.AreEqual(header.First(), consoleTable.Header.First());
            Assert.IsNull(consoleTable.Header.Last());
        }

        [TestMethod]
        public void Test_Create_RowColumn_Multiple_Header_Element_WhiteSpace()
        {
            var header = new[] {"Test", "    "};
            var consoleTable = new ConsoleTable<string>(1, 1, header: header);
            Assert.AreEqual(header.First(), consoleTable.Header.First());
            Assert.IsNull(consoleTable.Header.Last());
        }

        [TestMethod]
        public void Test_Create_RowColumn_Multiple_Header_Element_Tabs_And_Line_Breaks()
        {
            var header = new[] {"Test", "  \n  \t\t\n  \r "};
            var consoleTable = new ConsoleTable<string>(1, 1, header: header);
            Assert.AreEqual(header.First(), consoleTable.Header.First());
            Assert.IsNull(consoleTable.Header.Last());
        }
        #endregion

        #region Tests for rows-constructor
        [TestMethod]
        public void Test_Create_Rows_Valid()
        {
            var fillerElement = "filler";
            var title = "Title";
            var header = new[] {"Header 1", "Header2"};
            var row1 = new string[0];
            var row2 = new[] {"Hello", "World"};
            var consoleTable = new ConsoleTable<string>(new[] {row1, row2}, title, header, fillerElement);
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
        public void Test_Create_Rows_Null()
        {
            new ConsoleTable<string>(rows: null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Create_Rows_First_Dimension_Empty()
        {
            new ConsoleTable<string>(new string[0][]);
        }

        [TestMethod]
        public void Test_Create_Rows_Second_Dimension_Some_Empty()
        {
            var row1 = new[] {"Row1"};
            var row2 = new[] {"Hello", "World"};
            var consoleTable = new ConsoleTable<string>(new[] { row1, row2 });
            Assert.IsNull(consoleTable[0, 1]);
            Assert.AreEqual(row1.First(), consoleTable[0, 0]);
            Assert.AreEqual(row2.First(), consoleTable[1, 0]);
            Assert.AreEqual(row2.Last(), consoleTable[1, 1]);
        }

        [TestMethod]
        public void Test_Create_Rows_Second_Dimension_One_Row_Empty()
        {
            var row1 = new string[0];
            var row2 = new[] { "Hello", "World" };
            var consoleTable = new ConsoleTable<string>(new[] { row1, row2 });
            Assert.IsNull(consoleTable[0, 0]);
            Assert.IsNull(consoleTable[0, 1]);
            Assert.AreEqual(row2.First(), consoleTable[1, 0]);
            Assert.AreEqual(row2.Last(), consoleTable[1, 1]);
        }
        
        [TestMethod]
        public void Test_Create_Rows_Second_Dimension_One_Row_Set_But_Not_Filled()
        {
            var row1 = new string[4];
            var row2 = new[] {"Hello", "World"};
            var consoleTable = new ConsoleTable<string>(new[] { row1, row2 });
            Assert.IsNull(consoleTable[0, 0]);
            Assert.IsNull(consoleTable[0, 1]);
            Assert.AreEqual(row2.First(), consoleTable[1, 0]);
            Assert.AreEqual(row2.Last(), consoleTable[1, 1]);
        }

        [TestMethod]
        public void Test_Create_Rows_Second_Dimension_One_Row_Set_But_Not_Filled_ColumnCount()
        {
            var biggest = 4;
            var row1 = new string[biggest];
            var row2 = new[] {"Hello", "World"};
            var consoleTable = new ConsoleTable<string>(new[] { row1, row2 });
            Assert.AreEqual(biggest, consoleTable.ColumnCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Create_Rows_Second_Dimension_All_Empty()
        {
            var row1 = new string[0];
            var row2 = new string[0];
            new ConsoleTable<string>(new[] { row1, row2 });
        }

        [TestMethod]
        public void Test_Create_Rows_Second_Dimension_All_Set_But_Not_Filled()
        {
            var row1 = new string[3];
            var row2 = new string[6];
            new ConsoleTable<string>(new[] { row1, row2 });
        }

        [TestMethod]
        public void Test_Create_Rows_Second_Dimension_All_Set_But_Not_Filled_ColumnCount()
        {
            var biggest = 6;
            var row1 = new string[3];
            var row2 = new string[biggest];
            var consoleTable = new ConsoleTable<string>(new[] { row1, row2 });
            Assert.AreEqual(biggest, consoleTable.ColumnCount);
        }

        [TestMethod]
        public void Test_Create_Rows_Custom_FillerElement()
        {
            var fillerElement = "filler";
            var row1 = new string[0];
            var row2 = new[] {"Hello", "World"};
            var consoleTable = new ConsoleTable<string>(fillerElement: fillerElement, rows: new[] { row1, row2 });
            Assert.AreEqual(fillerElement, consoleTable[0, 0]);
            Assert.AreEqual(fillerElement, consoleTable[0, 1]);
        }
        
        [TestMethod]
        public void Test_Create_Rows_Title_Empty()
        {
            var row1 = new string[0];
            var row2 = new[] {"Hello", "World"};
            var consoleTable = new ConsoleTable<string>(title: string.Empty, rows: new[] { row1, row2 });
            Assert.IsNull(consoleTable.Title);
        }

        [TestMethod]
        public void Test_Create_Rows_Title_WhiteSpace()
        {
            var row1 = new string[0];
            var row2 = new[] {"Hello", "World"};
            var consoleTable = new ConsoleTable<string>(title: "    ", rows: new[] { row1, row2 });
            Assert.IsNull(consoleTable.Title);
        }

        [TestMethod]
        public void Test_Create_Rows_Title_Tabs_And_Line_Breaks()
        {
            var row1 = new string[0];
            var row2 = new[] {"Hello", "World"};
            var consoleTable = new ConsoleTable<string>(title: "  \n  \t\t\n  \r ", rows: new[] { row1, row2 });
            Assert.IsNull(consoleTable.Title);
        }

        [TestMethod]
        public void Test_Create_Rows_One_Header_Element_Empty()
        {
            var row1 = new string[0];
            var row2 = new[] {"Hello", "World"};
            var header = new[] {string.Empty};
            var consoleTable = new ConsoleTable<string>(header: header, rows: new[] { row1, row2 });
            Assert.IsNull(consoleTable.Header.First());
        }

        [TestMethod]
        public void Test_Create_Rows_One_Header_Element_WhiteSpace()
        {
            var row1 = new string[0];
            var row2 = new[] {"Hello", "World"};
            var header = new[] {"    "};
            var consoleTable = new ConsoleTable<string>(header: header, rows: new[] { row1, row2 });
            Assert.IsNull(consoleTable.Header.First());
        }

        [TestMethod]
        public void Test_Create_Rows_One_Header_Element_Tabs_And_Line_Breaks()
        {
            var row1 = new string[0];
            var row2 = new[] {"Hello", "World"};
            var header = new[] {"  \n  \t\t\n  \r "};
            var consoleTable = new ConsoleTable<string>(header: header, rows: new[] { row1, row2 });
            Assert.IsNull(consoleTable.Header.First());
        }

        [TestMethod]
        public void Test_Create_Rows_Multiple_Header_Element_Empty()
        {
            var row1 = new string[0];
            var row2 = new[] {"Hello", "World"};
            var header = new[] {"Test", string.Empty};
            var consoleTable = new ConsoleTable<string>(header: header, rows: new[] { row1, row2 });
            Assert.AreEqual(header.First(), consoleTable.Header.First());
            Assert.IsNull(consoleTable.Header.Last());
        }

        [TestMethod]
        public void Test_Create_Rows_Multiple_Header_Element_WhiteSpace()
        {
            var row1 = new string[0];
            var row2 = new[] {"Hello", "World"};
            var header = new[] {"Test", "    "};
            var consoleTable = new ConsoleTable<string>(header: header, rows: new[] { row1, row2 });
            Assert.AreEqual(header.First(), consoleTable.Header.First());
            Assert.IsNull(consoleTable.Header.Last());
        }

        [TestMethod]
        public void Test_Create_Rows_Multiple_Header_Element_Tabs_And_Line_Breaks()
        {
            var row1 = new string[0];
            var row2 = new[] {"Hello", "World"};
            var header = new[] {"Test", "  \n  \t\t\n  \r "};
            var consoleTable = new ConsoleTable<string>(header: header, rows: new[] { row1, row2 });
            Assert.AreEqual(header.First(), consoleTable.Header.First());
            Assert.IsNull(consoleTable.Header.Last());
        }
        #endregion
    }
}