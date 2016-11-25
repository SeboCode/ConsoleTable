using System.Collections.Generic;

namespace ConsoleTable.Settings
{
    public class Settings
    {
        private readonly Dictionary<Borders, char> _borderAssignment;

        public Settings(ITableSymbols tableSymbols)
        {
            _borderAssignment = new Dictionary<Borders, char>();
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

        private void AssignBorders()
        {
            _borderAssignment.Clear();
            _borderAssignment.Add(new Borders(HorizontalBorder.Left, VerticalBorder.Bottom), TableSymbols.LeftBottomCorner);
            _borderAssignment.Add(new Borders(HorizontalBorder.Left, VerticalBorder.Between), TableSymbols.LeftBorder);
            _borderAssignment.Add(new Borders(HorizontalBorder.Left, VerticalBorder.Top), TableSymbols.LeftTopCorner);
            _borderAssignment.Add(new Borders(HorizontalBorder.Between, VerticalBorder.Bottom), TableSymbols.BottomBorder);
            _borderAssignment.Add(new Borders(HorizontalBorder.Between, VerticalBorder.Between), TableSymbols.BetweenBorder);
            _borderAssignment.Add(new Borders(HorizontalBorder.Between, VerticalBorder.Top), TableSymbols.TopBorder);
            _borderAssignment.Add(new Borders(HorizontalBorder.Right, VerticalBorder.Bottom), TableSymbols.RightBottomCorner);
            _borderAssignment.Add(new Borders(HorizontalBorder.Right, VerticalBorder.Between), TableSymbols.RightBorder);
            _borderAssignment.Add(new Borders(HorizontalBorder.Right, VerticalBorder.Top), TableSymbols.RightTopCorner);
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