namespace ConsoleTable.Settings
{
    public class TableSymbols : ITableSymbols
    {
        // TODO: rename
        public virtual char HorizontalLine => '─';
        public virtual char VerticalLine => '│';
        public virtual char RightTopCorner => '┐';
        public virtual char RightBottomCorner => '┘';
        public virtual char LeftBottomCorner => '└';
        public virtual char LeftTopCorner => '┌';
        public virtual char TopBorder => '┬';
        public virtual char RightBorder => '┤';
        public virtual char BottomBorder => '┴';
        public virtual char LeftBorder => '├';
        public virtual char BetweenBorder => '┼';
    }
}