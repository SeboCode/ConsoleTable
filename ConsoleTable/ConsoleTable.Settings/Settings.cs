using System;
using System.Collections.Generic;

namespace ConsoleTable.Settings
{
    public class Settings
    {
        private Dictionary<Borders, char> _borderAssignment;

        public Settings(ITableSymbols tableSymbols)
        {
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
            _borderAssignment = new Dictionary<Borders, char>
            {
                {new Borders(HorizontalBorder.Left, VerticalBorder.Bottom), TableSymbols.LeftBottomCorner},
                {new Borders(HorizontalBorder.Left, VerticalBorder.Between), TableSymbols.LeftBorder},
                {new Borders(HorizontalBorder.Left, VerticalBorder.Top), TableSymbols.LeftTopCorner},
                {new Borders(HorizontalBorder.Between, VerticalBorder.Bottom), TableSymbols.BottomBorder},
                {new Borders(HorizontalBorder.Between, VerticalBorder.Between), TableSymbols.BetweenBorder},
                {new Borders(HorizontalBorder.Between, VerticalBorder.Top), TableSymbols.TopBorder},
                {new Borders(HorizontalBorder.Right, VerticalBorder.Bottom), TableSymbols.RightBottomCorner},
                {new Borders(HorizontalBorder.Right, VerticalBorder.Between), TableSymbols.RightBorder},
                {new Borders(HorizontalBorder.Right, VerticalBorder.Top), TableSymbols.RightTopCorner}
            };
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

        // TODO: reimplement
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

            public HorizontalBorder HorizontalBorder { get; }
            public VerticalBorder VerticalBorder { get; }

            public override int GetHashCode()
            {
                return HorizontalBorder.GetHashCode() ^ VerticalBorder.GetHashCode();
            }
        }
    }
}