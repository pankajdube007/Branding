using System;

namespace GoldMedal.Branding.Core.UAParser.Utils
{
    internal static class StringExtensions
    {
        public static string ReplaceFirstOccurence(this string input, string search, string replacement)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var index = input.IndexOf(search, StringComparison.Ordinal);
            return index >= 0
                 ? input.Substring(0, index) + replacement + input.Substring(index + search.Length)
                 : input;
        }
    }
}