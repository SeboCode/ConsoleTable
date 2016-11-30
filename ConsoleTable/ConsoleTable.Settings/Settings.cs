using System.Collections.Generic;
using ConsoleTable.Settings.Util;

namespace ConsoleTable.Settings
{
    public class Settings
    {
        private readonly Dictionary<Borders, char> _borderAssignment;

        public Settings(ITableSymbols tableSymbols)
        {
            _borderAssignment = new Dictionary<Borders, char>(EnumUtil.Size<HorizontalBorder>() * EnumUtil.Size<VerticalBorder>());
            TableSymbols = tableSymbols;
        }

        public bool SameRowLength { get; set; }

        private ITableSymbols _tableSymbols;
        public ITableSymbols TableSymbols
        {
            get { return _tableSymbols; }
            set
            {
                _tableSymbols = value;
                AssignBorders();
            }
        }

        public static Settings Default
        {
            get
            {
                var settings = new Settings(new TableSymbols())
                {
                    SameRowLength = false
                };

                return settings;
            }
        }
        
        public char GetBorderSymbol(HorizontalBorder horizontalBorder, VerticalBorder verticalBorder)
        {
            return _borderAssignment[new Borders(horizontalBorder, verticalBorder)];
        }

        private void AssignBorders()
        {
            _borderAssignment[new Borders(HorizontalBorder.Left, VerticalBorder.Bottom)] = TableSymbols.BottomLeftCorner;
            _borderAssignment[new Borders(HorizontalBorder.Left, VerticalBorder.Between)] =  TableSymbols.LeftRowSeperator;
            _borderAssignment[new Borders(HorizontalBorder.Left, VerticalBorder.Top)] =  TableSymbols.TopLeftCorner;
            _borderAssignment[new Borders(HorizontalBorder.Between, VerticalBorder.Bottom)] =  TableSymbols.BottomColumnSeperator;
            _borderAssignment[new Borders(HorizontalBorder.Between, VerticalBorder.Between)] =  TableSymbols.TableFieldCorner;
            _borderAssignment[new Borders(HorizontalBorder.Between, VerticalBorder.Top)] =  TableSymbols.TopColumnSeperator;
            _borderAssignment[new Borders(HorizontalBorder.Right, VerticalBorder.Bottom)] =  TableSymbols.BottomRightCorner;
            _borderAssignment[new Borders(HorizontalBorder.Right, VerticalBorder.Between)] =  TableSymbols.RightRowSeperator;
            _borderAssignment[new Borders(HorizontalBorder.Right, VerticalBorder.Top)] =  TableSymbols.TopRightCorner;
        }

        private struct Borders
        {
            public Borders(HorizontalBorder horizontalBorder, VerticalBorder verticalBorder)
            {
                HorizontalBorder = horizontalBorder;
                VerticalBorder = verticalBorder;
            }

            private HorizontalBorder HorizontalBorder { get; }
            private VerticalBorder VerticalBorder { get; }

            public override int GetHashCode()
            {
                return HorizontalBorder.GetHashCode() ^ VerticalBorder.GetHashCode();
            }
        }
    }
}