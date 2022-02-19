using System;
using System.Text;

namespace CH_CW2_PP_APP
{
	public class Utils
	{
        private static int getWordCountFromArgs()
        {
            string countString;
            if (Environment.GetCommandLineArgs()[2] == "-s")
            {
                countString = Environment.GetCommandLineArgs()[3];
            }
            else
            {
                countString = Environment.GetCommandLineArgs()[4];
            }
            return int.Parse(countString);
        }

        private static string RandomString(int length)
        {
            /// <summary>
            /// Create string randomly
            /// </summary>
            /// 
            /// <param name="length">string length</params>
            /// <returns>string generated</returns>
            /// 

            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static List<string> GenerateRandomStrings()
        {
            int count = getWordCountFromArgs();
            List<string> strings = new List<string>();
            for (int i = 0; i < count; i++)
            {
                strings.Add(RandomString(256));
            }

            return strings;
        }

        public static List<string> GetWordsFromFile(string path)
        {
            List<string> strings = new List<string>();
            foreach (string line in File.ReadLines(path))
            {
                strings.Add(line);
            }
            return strings;
        }

        public static bool ExportTextFile(string path, List<string> txtList)
        {
            try
            {
                // Create a new file
                using (FileStream fs = File.Create(path))
                {
                    foreach (var txt in txtList)
                    {
                        byte[] line = new UTF8Encoding(true).GetBytes(txt + "\n");
                        fs.Write(line, 0, line.Length);
                    }
                }
                return true;
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
                return false;
            }
        }

        private static bool isTxtFile(string fileName)
        {
            if (fileName.Split(".")[1] == "txt")
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}

