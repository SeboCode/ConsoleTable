using ConsoleTable.Settings.Symbols;

namespace ConsoleTable.Settings
{
    public interface IConsoleTableSettings
    {
        bool SameRowLength { get; set; }
        
        TableSymbols TableSymbols { get; set; }

        void ToDefault();
    }
}