using ConsoleTable.Settings.Border;
using ConsoleTable.Settings.Symbols;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleTable.Settings.Test.Symbols
{
    [TestClass]
    public class TableSymbolsTest
    {
        [TestMethod]
        public void Test_GetBorderSymbol_Default()
        {
            var tableSymbols = new TableSymbols();
            Assert.AreEqual(tableSymbols.TopRightCorner, tableSymbols.GetBorderSymbol(HorizontalBorder.Right, VerticalBorder.Top));
            Assert.AreEqual(tableSymbols.TopLeftCorner, tableSymbols.GetBorderSymbol(HorizontalBorder.Left, VerticalBorder.Top));
            Assert.AreEqual(tableSymbols.BottomRightCorner, tableSymbols.GetBorderSymbol(HorizontalBorder.Right, VerticalBorder.Bottom));
            Assert.AreEqual(tableSymbols.BottomLeftCorner, tableSymbols.GetBorderSymbol(HorizontalBorder.Left, VerticalBorder.Bottom));
            Assert.AreEqual(tableSymbols.RightRowSeperator, tableSymbols.GetBorderSymbol(HorizontalBorder.Right, VerticalBorder.Center));
            Assert.AreEqual(tableSymbols.LeftRowSeperator, tableSymbols.GetBorderSymbol(HorizontalBorder.Left, VerticalBorder.Center));
            Assert.AreEqual(tableSymbols.TopColumnSeperator, tableSymbols.GetBorderSymbol(HorizontalBorder.Center, VerticalBorder.Top));
            Assert.AreEqual(tableSymbols.BottomColumnSeperator, tableSymbols.GetBorderSymbol(HorizontalBorder.Center, VerticalBorder.Bottom));
            Assert.AreEqual(tableSymbols.TableFieldCorner, tableSymbols.GetBorderSymbol(HorizontalBorder.Center, VerticalBorder.Center));
        }

        [TestMethod]
        public void Test_GetBorderSymbol_Custom_TableSymbols()
        {
            var topRightCorner = 'a';
            var topLeftCorner = 'b';
            var bottomRightCorner = 'c';
            var bottomLeftCorner = 'd';
            var rightRowSeperator = 'e';
            var leftRowSeperator = 'f';
            var topColumnSeperator = 'g';
            var bottomColumnSeperator = 'h';
            var tableFieldCorner = 'i';
            var horizontalTableFieldBorder = 'j';
            var verticalTableFieldBorder = 'k';

            var tableSymbols = new TableSymbols
            {
                TopRightCorner = topRightCorner,
                TopLeftCorner = topLeftCorner,
                BottomRightCorner = bottomRightCorner,
                BottomLeftCorner = bottomLeftCorner,
                RightRowSeperator = rightRowSeperator,
                LeftRowSeperator = leftRowSeperator,
                TopColumnSeperator = topColumnSeperator,
                BottomColumnSeperator = bottomColumnSeperator,
                TableFieldCorner = tableFieldCorner,
                HorizontalTableFieldBorder = horizontalTableFieldBorder,
                VerticalTableFieldBorder = verticalTableFieldBorder
            };
            
            Assert.AreEqual(topRightCorner, tableSymbols.GetBorderSymbol(HorizontalBorder.Right, VerticalBorder.Top));
            Assert.AreEqual(topLeftCorner, tableSymbols.GetBorderSymbol(HorizontalBorder.Left, VerticalBorder.Top));
            Assert.AreEqual(bottomRightCorner, tableSymbols.GetBorderSymbol(HorizontalBorder.Right, VerticalBorder.Bottom));
            Assert.AreEqual(bottomLeftCorner, tableSymbols.GetBorderSymbol(HorizontalBorder.Left, VerticalBorder.Bottom));
            Assert.AreEqual(rightRowSeperator, tableSymbols.GetBorderSymbol(HorizontalBorder.Right, VerticalBorder.Center));
            Assert.AreEqual(leftRowSeperator, tableSymbols.GetBorderSymbol(HorizontalBorder.Left, VerticalBorder.Center));
            Assert.AreEqual(topColumnSeperator, tableSymbols.GetBorderSymbol(HorizontalBorder.Center, VerticalBorder.Top));
            Assert.AreEqual(bottomColumnSeperator, tableSymbols.GetBorderSymbol(HorizontalBorder.Center, VerticalBorder.Bottom));
            Assert.AreEqual(tableFieldCorner, tableSymbols.GetBorderSymbol(HorizontalBorder.Center, VerticalBorder.Center));
        }
    }
}