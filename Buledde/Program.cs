using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Buledde
{
    class Program
    {
        public static string code;
        public static List<string> methods = new List<string>();
        public static List<string> functions = new List<string>();

        static void Main(string[] args)
        {
            // code = System.IO.File.ReadAllText(System.Console.ReadLine());
            code = System.IO.File.ReadAllText(@"\\bk174518\f.mueller8\Desktop\HC\ToiletPaperIDE-main\testcode.txt");
            lexer();
            Console.ReadLine();
        }

        /*
         * 
         * (?<=METHOD (.*?)\{)((.|\n?)*?.*?)(?=\})
         * 
         * (?<=METHOD )(.*?)(?=\{)
         * 
         * 
         * (?<=FUNCTION (.*?)\{)((.|\n?)*?.*?)(?=\})
         * 
         * (?<=FUNCTION )(.*?)(?=\{)
         * 
         */

        public static void processSignatures()
        {
            string methodPattern = @"(?<=METHOD )(.*?)(?=\{)";
            Regex rgxm = new Regex(methodPattern);
            string sentence = code;
            foreach (Match match in rgxm.Matches(sentence))
            {
                Console.WriteLine(match.Value + " Methode gefunden");
                methods.Add(match.Value.ToString());
            }

            string funcitonPattern = @"(?<=FUNCTION )(.*?)(?=\{)";
            Regex rgxf = new Regex(funcitonPattern);
            foreach (Match match in rgxf.Matches(sentence))
            {
                Console.WriteLine(match.Value + " Function gefunden");
                functions.Add(match.Value);
            }

        }


        public static void lexer()
        {

            processSignatures();
            foreach (string entry in methods)
            {
                string pattern = @"(?<=METHOD " + entry + @"\{)((.|\n?)*?.*?)(?=\})";
                Regex rgx = new Regex(pattern);
                string sentence = code;

                foreach (Match match in rgx.Matches(sentence))
                {
                    Console.WriteLine("Found {2} '{0}' at position {1}",
                                      match.Value, match.Index, entry);
                }
            }

            Console.WriteLine("FUNCTIONS======================");
            foreach (string entry in functions)
            {

                Console.WriteLine("FUNCTION " + Regex.Escape(entry) + "{");
                string pattern = @"(?<=FUNCTION " + Regex.Escape(entry) + @"\{)((.|\n?)*?.*?)(?=\})";
                Regex rgx = new Regex(pattern);
                string sentence = code;

                foreach (Match match in rgx.Matches(sentence))
                {
                    Console.WriteLine("Found {2} '{0}' at position {1}",
                                      match.Value, match.Index, entry);
                }
            }
        }

        public static void interpret()
        {


        }
    }
}
