using ConsoleTable.Settings.Border;
using ConsoleTable.Settings.Symbols;

namespace ConsoleTable.Settings
{
    public interface IConsoleTableSettings
    {
        bool SameRowLength { get; set; }
        
        ITableSymbols TableSymbols { get; set; }

        void ToDefault();

        char GetBorderSymbol(HorizontalBorder horizontalBorder, VerticalBorder verticalBorder);
    }
}