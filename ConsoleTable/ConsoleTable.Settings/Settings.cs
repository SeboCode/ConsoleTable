using System;

namespace ConsoleTable.Settings
{
    public class Settings
    {
        public bool SameRowLength { get; set; }

        public ITableSymbols TableSymbols { get; set; }

        public static Settings Default
        {
            get
            {
                var settings = new Settings
                {
                    SameRowLength = false,
                    TableSymbols = new TableSymbols()
                };

                return settings;
            }
        }

        // TODO: reimplement
        public char GetBorderSymbol(HorizontalBorder horizontalBorder, VerticalBorder verticalBorder)
        {
            switch (horizontalBorder)
            {
                case HorizontalBorder.Left:
                    switch (verticalBorder)
                    {
                        case VerticalBorder.Bottom:
                            return TableSymbols.LeftBottomCorner;
                        case VerticalBorder.Between:
                            return TableSymbols.LeftBorder;
                        case VerticalBorder.Top:
                            return TableSymbols.LeftTopCorner;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(verticalBorder), verticalBorder, null);
                    }
                case HorizontalBorder.Between:
                    switch (verticalBorder)
                    {
                        case VerticalBorder.Bottom:
                            return TableSymbols.BottomBorder;
                        case VerticalBorder.Between:
                            return TableSymbols.BetweenBorder;
                        case VerticalBorder.Top:
                            return TableSymbols.TopBorder;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(verticalBorder), verticalBorder, null);
                    }
                case HorizontalBorder.Right:
                    switch (verticalBorder)
                    {
                        case VerticalBorder.Bottom:
                            return TableSymbols.RightBottomCorner;
                        case VerticalBorder.Between:
                            return TableSymbols.RightBorder;
                        case VerticalBorder.Top:
                            return TableSymbols.RightTopCorner;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(verticalBorder), verticalBorder, null);
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(horizontalBorder), horizontalBorder, null);
            }
        }
    }
}
