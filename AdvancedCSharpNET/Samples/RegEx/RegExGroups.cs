using System;
using System.Text.RegularExpressions;

namespace AdvancedCSharp.Samples.RegEx
{
    class RegExGroups
    {
        static void Main()
        {
            var dateStr = "Today is 18/09/2018.";
            var datePattern = @"\b(?<day>\d{1,2})/(?<month>\d{1,2})/(?<year>\d{2,4})\b";
            //var datePattern = @"\b\d{1,2}/\d{1,2}/\d{2,4}\b";
            var matchd = Regex.Match(dateStr, datePattern);
            var convertedDate = Regex.Replace(dateStr,
                      datePattern,
                      "${day}-${month}-${year}", RegexOptions.None,
                      TimeSpan.FromMilliseconds(150));

            Console.WriteLine("Original string: {0}", dateStr);
            Console.WriteLine("Converted string: {0}", convertedDate);
            var matched = Regex.Match(dateStr, datePattern);
            Console.WriteLine("Found groups are: ");
            foreach (Group item in matched.Groups)
            {
                Console.WriteLine("\t{0} = {1}", item.Name, item.Value);
            }
            Console.WriteLine();
            //string pattern = @"\b(\w+)\s\1\b";
            string pattern = @"\b(?<word>\w+)\s\k<word>\b";
            string input = "This this is a nice day. What about this? This tastes good. I saw a a dog.";
            foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
            {                
                Console.WriteLine("{0} (duplicates '{1}') at position {2}",
                                  match.Value, match.Groups[1].Value, match.Index);                
                foreach (Group item in match.Groups)
                {
                    Console.WriteLine("\t{0} = {1}", item.Name, item.Value);
                }
            }


            var emailPatternWithGroups = @"^(?<userName>[\w\.\-]+)@(?<domain>[\w\-]+)\.(?<global>((\w){2,3})+)$";
            var matchWitGroups = Regex.Match("contoso@microsoft.com", emailPatternWithGroups);
            if (matchWitGroups.Success)
            {
                Console.WriteLine("email address contoso@microsoft.com");
                Console.WriteLine("\tuserName = {0}", matchWitGroups.Groups["userName"].Value);
                Console.WriteLine("\tdomain = {0}", matchWitGroups.Groups["domain"].Value);
                Console.WriteLine("\tglobal domain = {0}", matchWitGroups.Groups["global"].Value);
            }

            Console.ReadKey();
        }

    }
}
