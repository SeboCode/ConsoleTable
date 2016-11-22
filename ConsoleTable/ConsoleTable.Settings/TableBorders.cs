using System;

namespace ConsoleTable.Settings
{
    public static class TableBorders
    {
        public static readonly char HorizontalLine = '─';

        public static readonly char VerticalLine = '│';

        public static readonly char RightTopCorner = '┐';

        public static readonly char RightBottomCorner = '┘';

        public static readonly char LeftBottomCorner = '└';

        public static readonly char LeftTopCorner = '┌';

        public static readonly char TopBorder = '┬';

        public static readonly char RightBorder = '┤';

        public static readonly char BottomBorder = '┴';

        public static readonly char LeftBorder = '├';

        public static readonly char BetweenBorder = '┼';

        public static char GetBorderSymbol(HorizontalBorder horizontalBorder, VerticalBorder verticalBorder)
        {
            switch (horizontalBorder)
            {
                case HorizontalBorder.Left:
                    switch (verticalBorder)
                    {
                        case VerticalBorder.Bottom:
                            return LeftBottomCorner;
                        case VerticalBorder.Between:
                            return LeftBorder;
                        case VerticalBorder.Top:
                            return LeftTopCorner;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(verticalBorder), verticalBorder, null);
                    }
                case HorizontalBorder.Between:
                    switch (verticalBorder)
                    {
                        case VerticalBorder.Bottom:
                            return BottomBorder;
                        case VerticalBorder.Between:
                            return BetweenBorder;
                        case VerticalBorder.Top:
                            return TopBorder;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(verticalBorder), verticalBorder, null);
                    }
                case HorizontalBorder.Right:
                    switch (verticalBorder)
                    {
                        case VerticalBorder.Bottom:
                            return RightBottomCorner;
                        case VerticalBorder.Between:
                            return RightBorder;
                        case VerticalBorder.Top:
                            return RightTopCorner;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(verticalBorder), verticalBorder, null);
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(horizontalBorder), horizontalBorder, null);
            }
        }
    }

    public enum VerticalBorder
    {
        Top,
        Between,
        Bottom
    }

    public enum HorizontalBorder
    {
        Left,
        Between,
        Right
    }
}