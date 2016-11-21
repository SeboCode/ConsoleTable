using System.Linq;

namespace ConsoleTable.Core
{
	public static class StringExtensions
	{
		public static bool IsEmptyOrWhiteSpace(this string str)
		{
			if (str == null)
			{
				return false;
			}

			if (str == string.Empty)
			{
				return true;
			}

            var whitespaceChars = new char[]
            {
                ' ',
                '\n',
                '\t',
                '\r'
            };

			return str.AsEnumerable().All(element => whitespaceChars.Any(c => c == element));
		}
	}
}