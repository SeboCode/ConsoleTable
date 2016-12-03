using ConsoleTable.Settings.Border;
using ConsoleTable.Settings.Symbols;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleTable.Settings.Test
{
    [TestClass]
    public class SettingsTest
    {
        [TestMethod]
        public void Test_Create_Valid()
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

            var settings = new Settings(tableSymbols, true);
            Assert.AreEqual(tableSymbols, settings.TableSymbols);
            Assert.AreEqual(topRightCorner, settings.TableSymbols.TopRightCorner);
            Assert.AreEqual(topLeftCorner, settings.TableSymbols.TopLeftCorner);
            Assert.AreEqual(bottomRightCorner, settings.TableSymbols.BottomRightCorner);
            Assert.AreEqual(bottomLeftCorner, settings.TableSymbols.BottomLeftCorner);
            Assert.AreEqual(rightRowSeperator, settings.TableSymbols.RightRowSeperator);
            Assert.AreEqual(leftRowSeperator, settings.TableSymbols.LeftRowSeperator);
            Assert.AreEqual(topColumnSeperator, settings.TableSymbols.TopColumnSeperator);
            Assert.AreEqual(bottomColumnSeperator, settings.TableSymbols.BottomColumnSeperator);
            Assert.AreEqual(tableFieldCorner, settings.TableSymbols.TableFieldCorner);
            Assert.AreEqual(horizontalTableFieldBorder, settings.TableSymbols.HorizontalTableFieldBorder);
            Assert.AreEqual(verticalTableFieldBorder, settings.TableSymbols.VerticalTableFieldBorder);
            Assert.IsTrue(settings.SameRowLength);
        }

        [TestMethod]
        public void Test_Create_Default_Values()
        {
            var settings = new Settings();
            Assert.IsNotNull(settings.TableSymbols);
            Assert.IsFalse(settings.SameRowLength);
        }

        [TestMethod]
        public void Test_ToDefault()
        {
            var tableSymbols = new TableSymbols
            {
                TopRightCorner = 'a',
                TopLeftCorner = 'b',
                BottomRightCorner = 'c',
                BottomLeftCorner = 'd',
                RightRowSeperator = 'e',
                LeftRowSeperator = 'f',
                TopColumnSeperator = 'g',
                BottomColumnSeperator = 'h',
                TableFieldCorner = 'i',
                HorizontalTableFieldBorder = 'j',
                VerticalTableFieldBorder = 'k'
            };

            var settings = new Settings(tableSymbols, true);
            settings.ToDefault();
            var defaultTableSymbols = new TableSymbols();
            
            Assert.IsNotNull(settings.TableSymbols);
            Assert.AreEqual(defaultTableSymbols.TopRightCorner, settings.TableSymbols.TopRightCorner);
            Assert.AreEqual(defaultTableSymbols.TopLeftCorner, settings.TableSymbols.TopLeftCorner);
            Assert.AreEqual(defaultTableSymbols.BottomRightCorner, settings.TableSymbols.BottomRightCorner);
            Assert.AreEqual(defaultTableSymbols.BottomLeftCorner, settings.TableSymbols.BottomLeftCorner);
            Assert.AreEqual(defaultTableSymbols.RightRowSeperator, settings.TableSymbols.RightRowSeperator);
            Assert.AreEqual(defaultTableSymbols.LeftRowSeperator, settings.TableSymbols.LeftRowSeperator);
            Assert.AreEqual(defaultTableSymbols.TopColumnSeperator, settings.TableSymbols.TopColumnSeperator);
            Assert.AreEqual(defaultTableSymbols.BottomColumnSeperator, settings.TableSymbols.BottomColumnSeperator);
            Assert.AreEqual(defaultTableSymbols.TableFieldCorner, settings.TableSymbols.TableFieldCorner);
            Assert.AreEqual(defaultTableSymbols.HorizontalTableFieldBorder, settings.TableSymbols.HorizontalTableFieldBorder);
            Assert.AreEqual(defaultTableSymbols.VerticalTableFieldBorder, settings.TableSymbols.VerticalTableFieldBorder);
            Assert.IsFalse(settings.SameRowLength);
        }

        [TestMethod]
        public void Test_GetBorderSymbol_Default()
        {
            var settings = new Settings();
            Assert.AreEqual(settings.TableSymbols.TopRightCorner, settings.GetBorderSymbol(HorizontalBorder.Right, VerticalBorder.Top));
            Assert.AreEqual(settings.TableSymbols.TopLeftCorner, settings.GetBorderSymbol(HorizontalBorder.Left, VerticalBorder.Top));
            Assert.AreEqual(settings.TableSymbols.BottomRightCorner, settings.GetBorderSymbol(HorizontalBorder.Right, VerticalBorder.Bottom));
            Assert.AreEqual(settings.TableSymbols.BottomLeftCorner, settings.GetBorderSymbol(HorizontalBorder.Left, VerticalBorder.Bottom));
            Assert.AreEqual(settings.TableSymbols.RightRowSeperator, settings.GetBorderSymbol(HorizontalBorder.Right, VerticalBorder.Between));
            Assert.AreEqual(settings.TableSymbols.LeftRowSeperator, settings.GetBorderSymbol(HorizontalBorder.Left, VerticalBorder.Between));
            Assert.AreEqual(settings.TableSymbols.TopColumnSeperator, settings.GetBorderSymbol(HorizontalBorder.Between, VerticalBorder.Top));
            Assert.AreEqual(settings.TableSymbols.BottomColumnSeperator, settings.GetBorderSymbol(HorizontalBorder.Between, VerticalBorder.Bottom));
            Assert.AreEqual(settings.TableSymbols.TableFieldCorner, settings.GetBorderSymbol(HorizontalBorder.Between, VerticalBorder.Between));
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

            var settings = new Settings();
            settings.TableSymbols = tableSymbols;
            Assert.AreEqual(tableSymbols, settings.TableSymbols);
            Assert.AreEqual(topRightCorner, settings.GetBorderSymbol(HorizontalBorder.Right, VerticalBorder.Top));
            Assert.AreEqual(topLeftCorner, settings.GetBorderSymbol(HorizontalBorder.Left, VerticalBorder.Top));
            Assert.AreEqual(bottomRightCorner, settings.GetBorderSymbol(HorizontalBorder.Right, VerticalBorder.Bottom));
            Assert.AreEqual(bottomLeftCorner, settings.GetBorderSymbol(HorizontalBorder.Left, VerticalBorder.Bottom));
            Assert.AreEqual(rightRowSeperator, settings.GetBorderSymbol(HorizontalBorder.Right, VerticalBorder.Between));
            Assert.AreEqual(leftRowSeperator, settings.GetBorderSymbol(HorizontalBorder.Left, VerticalBorder.Between));
            Assert.AreEqual(topColumnSeperator, settings.GetBorderSymbol(HorizontalBorder.Between, VerticalBorder.Top));
            Assert.AreEqual(bottomColumnSeperator, settings.GetBorderSymbol(HorizontalBorder.Between, VerticalBorder.Bottom));
            Assert.AreEqual(tableFieldCorner, settings.GetBorderSymbol(HorizontalBorder.Between, VerticalBorder.Between));
        }
    }
}