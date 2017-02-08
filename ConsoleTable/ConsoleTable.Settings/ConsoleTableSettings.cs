using ConsoleTable.Settings.Border;
using ConsoleTable.Settings.Symbols;

namespace ConsoleTable.Settings
{
    public class ConsoleTableSettings : IConsoleTableSettings
    {
        public ConsoleTableSettings(TableSymbols tableSymbols = null, bool sameRowLength = false)
        {
            if (tableSymbols == null)
            {
                tableSymbols = new TableSymbols();
            }
            
            TableSymbols = tableSymbols;
            SameRowLength = sameRowLength;
        }

        public bool SameRowLength { get; set; }

        public TableSymbols TableSymbols { get; set; }

        public void ToDefault()
        {
            SameRowLength = false;
            TableSymbols = new TableSymbols();
        }
        
        public char GetBorderSymbol(HorizontalBorder horizontalBorder, VerticalBorder verticalBorder)
        {
            return TableSymbols.GetBorderSymbol(horizontalBorder, verticalBorder);
        }
    }
}