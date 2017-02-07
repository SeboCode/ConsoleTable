﻿namespace ConsoleTable.Settings.Symbols
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
    }
}