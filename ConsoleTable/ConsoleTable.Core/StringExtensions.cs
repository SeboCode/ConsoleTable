using System.Linq;

namespace ConsoleTable.Core
{
	public static class StringExtensions
	{
	    public static bool IsNullOrEmptyOrWhiteSpace(this string str)
	    {
	        return str == null || IsEmptyOrWhiteSpace(str);
	    }

		public static bool IsEmptyOrWhiteSpace(this string str)
		{
			if (str == null)
			{
				return false;
			}

			return str == string.Empty || IsWhiteSpace(str);
		}

	    public static bool IsWhiteSpace(this string str)
	    {
            var whitespaceChars = new []
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