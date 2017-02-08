using ConsoleTable.Settings.Border;

namespace ConsoleTable.Settings.Symbols
{
    public class TableSymbols
    {
        public virtual char TopRightCorner { get; set; } = '┐';

        public virtual char TopLeftCorner { get; set; } = '┌';

        public virtual char BottomRightCorner { get; set; } = '┘';

        public virtual char BottomLeftCorner { get; set; } = '└';

        public virtual char RightRowSeperator { get; set; } = '┤';

        public virtual char LeftRowSeperator { get; set; } = '├';

        public virtual char TopColumnSeperator { get; set; } = '┬';

        public virtual char BottomColumnSeperator { get; set; } = '┴';

        public virtual char TableFieldCorner { get; set; } = '┼';

        public virtual char HorizontalTableFieldBorder { get; set; } = '─';

        public virtual char VerticalTableFieldBorder { get; set; } = '│';

        public virtual char GetBorderSymbol(HorizontalBorder horizontalBorder, VerticalBorder verticalBorder)
        {
            if (horizontalBorder == HorizontalBorder.Left && verticalBorder == VerticalBorder.Top)
            {
                return TopLeftCorner;
            }

            if (horizontalBorder == HorizontalBorder.Left && verticalBorder == VerticalBorder.Center)
            {
                return LeftRowSeperator;
            }

            if (horizontalBorder == HorizontalBorder.Left && verticalBorder == VerticalBorder.Bottom)
            {
                return BottomLeftCorner;
            }

            if (horizontalBorder == HorizontalBorder.Center && verticalBorder == VerticalBorder.Top)
            {
                return TopColumnSeperator;
            }

            if (horizontalBorder == HorizontalBorder.Center && verticalBorder == VerticalBorder.Center)
            {
                return TableFieldCorner;
            }

            if (horizontalBorder == HorizontalBorder.Center && verticalBorder == VerticalBorder.Bottom)
            {
                return BottomColumnSeperator;
            }

            if (horizontalBorder == HorizontalBorder.Right && verticalBorder == VerticalBorder.Top)
            {
                return TopRightCorner;
            }

            if (horizontalBorder == HorizontalBorder.Right && verticalBorder == VerticalBorder.Center)
            {
                return RightRowSeperator;
            }

            return BottomRightCorner;
        }
    }
}