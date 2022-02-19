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

        const int SHIFT = 3;

        public static int threadCount = 4;

        public static void SerialCaesar()
        {
            /// <summary>
            /// This is Caesar Encryp function.
            /// </summary>

            // Text data setup
            Console.WriteLine("Preparing Test cases...");
            var textList = Utils.GenerateRandomStrings();

            // Start Timer
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            Console.WriteLine("Start Encryption - Serial");

            // prepare console
            var curPos = Console.GetCursorPosition();

            // Start Routine
            for (int i = 0; i < textList.Count; i++)
            {
                // show progress
                UIClass.ShowProgressBar(i+1, textList.Count, curPos.Top, 0);

                // Convert string to char array
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
            Console.WriteLine("\nWork Finished");
            Console.WriteLine(watch.Elapsed.ToString());
        }

        public static List<string> ParallelCaesar(List<string>? _textList = null)
        {
            /// <summary>
            /// This is Caesar Encrypt function, but this is parallel.
            /// </summary>
            /// 
            /// <param name="threadCount">Thread Count for Parallel</param>


            // Text data setup
            List<string> textList;
            if (_textList == null)
            {
                Console.WriteLine("Preparing Test cases...");
                textList = Utils.GenerateRandomStrings();
            }
            else
            {
                textList = _textList.ToList();
            }

            Console.WriteLine("Start Encryption - Paralell");
            // prepare console
            var curPos = Console.GetCursorPosition();

            // Start Timer
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            // Start Routine
            Parallel.For(0, textList.Count, new ParallelOptions { MaxDegreeOfParallelism = threadCount }, i =>
            {
                // Show progress
                int threadId = Thread.CurrentThread.ManagedThreadId;
                UIClass.ShowProgressBar(i + 1, textList.Count, curPos.Top, threadId);
                
                // Convert string to char array
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
            Console.Clear();
            Console.WriteLine("\nWork Finished");
            Console.WriteLine(watch.Elapsed.ToString());

            return textList;
        }


        public static List<string> DecryptCaesar(List<string> _textList)
        {
            List<string> textList = _textList;

            // Start Routine
            Parallel.For(0, textList.Count, new ParallelOptions { MaxDegreeOfParallelism = threadCount }, i =>
            {
                char[] vs = textList[i].ToCharArray();
                char[] chArr = vs;

                // All character encrypt
                for (int x = 0; x < chArr.Length; x++)
                {
                    // Caesar encrypt
                    if (chArr[x] >= 'a' && chArr[x] <= 'z')
                    {
                        chArr[x] = (char)('a' + ((chArr[x] - 'a' - SHIFT) % 26));
                    }
                    else if (chArr[x] >= 'A' && chArr[x] <= 'Z')
                    {
                        chArr[x] = (char)('A' + ((chArr[x] - 'A' - SHIFT) % 26));
                    }
                }

                textList[i] = new String(chArr);
            });

            return textList;
        }
    }
}
