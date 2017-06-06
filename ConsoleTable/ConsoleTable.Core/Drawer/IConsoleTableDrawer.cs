using ConsoleTable.Settings;

namespace ConsoleTable.Core.Drawer
{
    public interface IConsoleTableDrawer
    {
        IConsoleTableSettings Settings { get; set; }

        void Write();

        string ToString();
    }
}