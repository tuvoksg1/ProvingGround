using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Windows.Models.Stream
{
    static partial class StreamProcessor
    {
        private static void CreateTestFile(int numberOfLines, int numTimesGuidRepeated)
        {
            Console.WriteLine(@"######## " + MethodBase.GetCurrentMethod().Name);
            Console.WriteLine(@"######## Number of lines in file: " + numberOfLines);
            Console.WriteLine(@"######## Number of times Guid repeated on each line: " + numTimesGuidRepeated);
            Console.WriteLine(@"###########################################################");
            Console.WriteLine();
            _line = string.Join(" ", Enumerable.Repeat(new Guid().ToString(), numTimesGuidRepeated));
            _allLines = null;
            _max = numberOfLines;
            _start = DateTime.Now;
            //Create the file populating it with GUIDs
            Console.WriteLine($"Generating file: {_start.ToLongTimeString()}");
            using (var writer = File.CreateText(_fileName))
            {
                for (var count = 0; count < _max; count++)
                {
                    writer.WriteLine(_line);
                }
            }

            LogTimings("Generated test file");
        }

        private static void RunFunction(Action function, string functioname, string description)
        {
            //give disk hardware time to recover from previous task
            GC.Collect();
            Thread.Sleep(1000);

            Console.WriteLine(description);
            _start = DateTime.Now;

            try
            {
                function();
                _end = DateTime.Now;
                LogTimings($"{functioname} complete");
            }
            catch (OutOfMemoryException)
            {
                LogTimings("Not enough memory.Couldn't perform this test.");
            }
            catch (Exception)
            {
                LogTimings("EXCEPTION. Couldn't perform this test.");
            }
            finally
            {
                if (_allLines != null)
                {
                    Array.Clear(_allLines, 0, _allLines.Length);
                    _allLines = null;
                }
            }
        }

        //Just simulates doing work on a line read from an input file
        private static void TestReadingAndProcessingLinesFromFile_DoStuff(string line)
        {
            var lineParts = line.Split(new char[' ']);
            var resultList = new int[lineParts.Length];
            int number;

            for (var index = 0; index < lineParts.Length; index++)
            {
                foreach (var character in lineParts[index])
                {
                    if (int.TryParse(character.ToString(), out number))
                    {   //just doing some bogus mathematical calculations to simulate work
                        resultList[index] = (int)((Math.Sqrt(Math.Log(number) % Math.Log10(number))) * (Math.Log(Math.Log10(number) / Math.Sqrt(number))));
                    }
                }
            }
            //clean up
            Array.Clear(resultList, 0, resultList.Length);
            Array.Clear(lineParts, 0, lineParts.Length);
        }

        private static void LogTimings(string message)
        {
            _end = DateTime.Now;
            Console.WriteLine(message);
            Console.WriteLine($"Finished at: {_end.ToLongTimeString()}");
            Console.WriteLine($"Time: {_end - _start}");
            Console.WriteLine();
        }
    }
}
