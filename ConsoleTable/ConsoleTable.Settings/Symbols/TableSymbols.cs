namespace ConsoleTable.Settings.Symbols
{
    public class TableSymbols : ITableSymbols
    {
        public virtual char TopRightCorner => '┐';
        public virtual char TopLeftCorner => '┌';
        public virtual char BottomRightCorner => '┘';
        public virtual char BottomLeftCorner => '└';
        public virtual char RightRowSeperator => '┤';
        public virtual char LeftRowSeperator => '├';
        public virtual char TopColumnSeperator => '┬';
        public virtual char BottomColumnSeperator => '┴';
        public virtual char TableFieldCorner => '┼';
        public virtual char HorizontalTableFieldBorder => '─';
        public virtual char VerticalTableFieldBorder => '│';
    }
}