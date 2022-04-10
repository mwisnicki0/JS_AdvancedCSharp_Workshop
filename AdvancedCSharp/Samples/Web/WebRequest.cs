using System;
using System.IO;
using System.Net;
using System.Net.Http;

namespace AdvancedCSharp.Samples.Web
{
    class WebRequest
    {
        static void Main()
        {
            var url = @"https://powerbi.microsoft.com/en-us/windows-license-terms/";
            var request = System.Net.WebRequest.Create(url);
            
            using (var response = (HttpWebResponse)request.GetResponse())
            {                
                Console.WriteLine(response.StatusDescription);
                Console.WriteLine();
                var stream = response.GetResponseStream();
                var reader = new StreamReader(stream);

                string responseStr = reader.ReadToEnd();
                Console.WriteLine(responseStr);
                reader.Close();
                stream.Close();
            }
            
            Console.ReadKey();
        }
    }
}
