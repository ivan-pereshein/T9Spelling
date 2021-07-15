using System;
using System.IO;

namespace T9Spelling
{
    class Program
    {
        private const string defaultFileIn = "C-large-practice.in";
        private const string defaultFileOut = "C-large-practice.out";

        static void Main(string[] args)
        {
            string fileIn = args.Length == 2 ? args[0] : defaultFileIn;
            string fileOut = args.Length == 2 ? args[1] : defaultFileOut;

            var phoneKeyboard = new PhoneKeyboard();
            Console.WriteLine("Starting (input file: {0}, output file: {1})...", fileIn, fileOut);
            try
            {
                using (var streamIn = new StreamReader(fileIn))
                {
                    var numberOfCases = Convert.ToInt32(streamIn.ReadLine());

                    using (var streamOut = new StreamWriter(fileOut))
                    {
                        for (var i = 1; i <= numberOfCases; i++)
                        {
                            string line = streamIn.ReadLine();
                            streamOut.WriteLine("Case #{0}: {1}", i, phoneKeyboard.GetPressedKeysSequence(line));
                        }
                    }
                }
                Console.WriteLine("Done.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong. See details below:");
                Console.WriteLine(ex);
            }

            Console.ReadLine();
        }
    }
}
