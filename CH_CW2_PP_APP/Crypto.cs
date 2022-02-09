using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH_CW2_PP_APP
{
    internal class Crypto
    {
        /// <summary>
        /// This is Crypto Class
        /// It has some crypto functions and utils for itself.
        /// Because it is singleton object, all methods are Static.
        /// </summary>

        const int MAX = 21200;
        const int SHIFT = 3;
        const string path = @"C:\Users\tama0\source\repos\CH_CW2_PP_APP\CH_CW2_PP_APP\words.txt";

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

        private static List<string> GenerateRandomStrings()
        {
            int count = getWordCountFromArgs();
            List<string> strings = new List<string>();
            for (int i = 0; i < count; i++)
            {
                strings.Add(RandomString(100));
            }

            return strings;
        }

        private static List<string> GenerateStrings()
        {
            /// <summary>
            /// Generate string list from Text file.
            /// </summary>
            /// 
            /// <returns>string list</returns>

            List<string> strings = new List<string>();
            int count = getWordCountFromArgs();
            foreach (string line in File.ReadLines(path))
            {
                strings.Add(line);
                if (count == strings.Count) break;
            }

            return strings;
        }

        public static void SerialCaesar()
        {
            /// <summary>
            /// This is Caesar Encryp function.
            /// </summary>

            // Text datas setup
            var textList = GenerateRandomStrings();

            // Start Timer
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            // Start Routine
            for (int i = 0; i < textList.Count; i++)
            {
                char[] chArr = textList[i].ToCharArray();

                // All character encrypt
                for (int x = 0; x < chArr.Length; x++)
                {
                    // Caesar encrypt
                    if (chArr[x] >= 'a' && chArr[x] <= 'z')
                    {
                        chArr[x] = (char)('a' + ((chArr[x] - 'a' + SHIFT) % 26));
                    }
                    else if (chArr[x] >= 'A' && chArr[x] <= 'Z')
                    {
                        chArr[x] = (char)('A' + ((chArr[x] - 'A' + SHIFT) % 26));
                    }
                }

                textList[i] = new String(chArr);
            };

            // Stop Rountine and Timer
            watch.Stop();
            Console.WriteLine(watch.Elapsed.ToString());
        }

        public static void ParallelCaesar(int threadCount = 4)
        {
            /// <summary>
            /// This is Caesar Encrypt function, but this is parallel.
            /// </summary>
            /// 
            /// <param name="threadCount">Thread Count for Parallel</param>

            
            // Text datas setup
            var textList = GenerateRandomStrings();

            // Start Timer
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            // Start Routine
            Parallel.For(0, textList.Count, new ParallelOptions { MaxDegreeOfParallelism = threadCount }, i =>
            {
                char[] chArr = textList[i].ToCharArray();

                // All character encrypt
                for (int x = 0; x < chArr.Length; x++)
                {
                    // Caesar encrypt
                    if (chArr[x] >= 'a' && chArr[x] <= 'z')
                    {
                        chArr[x] = (char)('a' + ((chArr[x] - 'a' + SHIFT) % 26));
                    }
                    else if (chArr[x] >= 'A' && chArr[x] <= 'Z')
                    {
                        chArr[x] = (char)('A' + ((chArr[x] - 'A' + SHIFT) % 26));
                    }
                }

                textList[i] = new String(chArr);
            });

            // Stop Rountine and Timer
            watch.Stop();
            Console.WriteLine(watch.Elapsed.ToString());
        }
    }
}
