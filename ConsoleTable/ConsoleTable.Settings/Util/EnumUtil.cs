using System;
using System.Linq;

namespace ConsoleTable.Settings.Util
{
    public static class EnumUtil
    {
        public static int Size<TEnum>()
        {
            return Enum.GetNames(typeof(TEnum)).Count();
        } 
    }
}