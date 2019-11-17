using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WCount01
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Please enter file path");
                return;
            }
            else
            {
                string text = null;
                string textFileName = args[0];
                try
                {
                    text = File.ReadAllText(textFileName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

                Regex reg_exp = new Regex("[^a-zA-Z0-9]");

                var wordString = reg_exp.Replace(text, " ").ToLower();
                var words = wordString.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);


                var groups = words.GroupBy(w => w).OrderByDescending(g => g.Count()).Take(20);

                foreach (var item in groups)
                {
                    Console.WriteLine($"{item.Count()} {item.Key}");
                }
            }
        }
    }
}
