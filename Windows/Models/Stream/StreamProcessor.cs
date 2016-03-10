using System;
using System.IO;

namespace Windows.Models.Stream
{
    public static partial class StreamProcessor
    {
        private static DateTime _start;
        private static DateTime _end;
        private static string _fileName = "Performance_Test_File.txt";
        private static string _line;
        private static string[] _allLines;
        private static int _max;

        public static void Start()
        {
            var start = DateTime.Now;
            Console.WriteLine(@"### Overall Start Time: " + start.ToLongTimeString());
            Console.WriteLine();
            var numberOfLines = (int) Math.Floor(int.MaxValue/10000d); //change this to alter the number of lines
            const int numberOfColumns = 5; //change this to alter the size of each line

            TestReadingAndProcessingLinesFromFile(numberOfLines, numberOfColumns);
            _end = DateTime.Now;
            Console.WriteLine();
            Console.WriteLine(@"### Overall End Time: " + _end.ToLongTimeString());
            Console.WriteLine(@"### Overall Run Time: " + (_end - start));
            Console.WriteLine();
        }

        //####################################################
        //Does a comparison of reading all the lines in from a file and performing some rudimentary
        //operations on them. Which way is fastest?
        private static void TestReadingAndProcessingLinesFromFile(int numberOfLines, int numTimesGuidRepeated)
        {
            CreateTestFile(numberOfLines, numTimesGuidRepeated);

            //Just read everything into one string
            //RunFunction(Function1, "Function 1", "Reading file reading to end into string: ");

            //Read the entire contents into a StringBuilder object
            //RunFunction(Function2, "Function 2", "Reading file reading to end into stringbuilder: ");

            //Standard and probably most common way of reading a file. 
            //RunFunction(Function3, "Function 3", "Reading file assigning each line to string: ");

            //Doing it the most common way, but using a Buffered Reader now.
            //RunFunction(Function4, "Function 4", "Buffered reading file assigning each line to string: ");

            //Reading each line using a buffered reader again, but setting the buffer size since we know what it will be.
            //RunFunction(Function5, "Function 5",
                //"Buffered reading with preset buffer size assigning each line to string: ");

            //Read every line of the file reusing a StringBuilder object to save on string memory allocation times
            //RunFunction(Function6, "Function 6", "Reading file assigning each line to StringBuilder: ");

            //Reading each line into a StringBuilder, but setting the StringBuilder object to an initial
            //size since we know how long the longest line in the file is.
            //RunFunction(Function7, "Function 7", "Reading file assigning each line to preset size StringBuilder: ");

            //Read each line into an array index. 
            //RunFunction(Function8, "Function 8", "Reading each line into string array. Process with Parallel.For: ");

            //Read the entire file using File.ReadAllLines. 
            RunFunction(Function9, "Function 9", "Performing File ReadAllLines into array. Process with Parallel.For: ");

            File.Delete(_fileName);
            _fileName = null;
            GC.Collect();
        }
    } //class
} //namespace