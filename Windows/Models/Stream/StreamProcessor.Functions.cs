using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Windows.Models.Stream
{
    static partial class StreamProcessor
    {
        private static void Function1()
        {
            //Just read everything into one string
            using (var reader = File.OpenText(_fileName))
            {
                var contents = reader.ReadToEnd();
                TestReadingAndProcessingLinesFromFile_DoStuff(contents);
            }
        }

        private static void Function2()
        {
            //Read the entire contents into a StringBuilder object
            using (var reader = File.OpenText(_fileName))
            {
                var builder = new StringBuilder();
                builder.Append(reader.ReadToEnd());
                TestReadingAndProcessingLinesFromFile_DoStuff(builder.ToString()); //to simulate work
            }
        }

        private static void Function3()
        {
            //Standard and probably most common way of reading a file. 
            using (var reader = File.OpenText(_fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    TestReadingAndProcessingLinesFromFile_DoStuff(line); //to simulate work
                }
            }
        }

        private static void Function4()
        {
            //Doing it the most common way, but using a Buffered Reader now.
            using (var stream = File.Open(_fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var buffer = new BufferedStream(stream))
                {
                    using (var reader = new StreamReader(buffer))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            TestReadingAndProcessingLinesFromFile_DoStuff(line); //to simulate work
                        }
                    }
                }
            }
        }

        private static void Function5()
        {
            //Reading each line using a buffered reader again, but setting the buffer size since we know what it will be.
            using (var stream = File.Open(_fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var buffer = new BufferedStream(stream, Encoding.ASCII.GetByteCount(_line)))
                {
                    using (var reader = new StreamReader(buffer))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            TestReadingAndProcessingLinesFromFile_DoStuff(line); //to simulate work
                        }
                    }
                }
            }
        }

        private static void Function6()
        {
            //Read every line of the file reusing a StringBuilder object to save on string memory allocation times
            using (var reader = File.OpenText(_fileName))
            {
                var builder = new StringBuilder();
                while (builder.Append(reader.ReadLine()).Length > 0)
                {
                    TestReadingAndProcessingLinesFromFile_DoStuff(builder.ToString()); //to simulate work
                    builder.Clear();
                }
            }
        }

        private static void Function7()
        {
            //Reading each line into a StringBuilder, but setting the StringBuilder object to an initial
            //size since we know how long the longest line in the file is.
            using (var reader = File.OpenText(_fileName))
            {
                var builder = new StringBuilder(_line.Length);
                while (builder.Append(reader.ReadLine()).Length > 0)
                {
                    TestReadingAndProcessingLinesFromFile_DoStuff(builder.ToString()); //to simulate work
                    builder.Clear();
                }
            }
        }

        private static void Function8()
        {
            //Read each line into an array index. 
            _allLines = new string[_max]; //only allocate memory here
            using (var reader = File.OpenText(_fileName))
            {
                var index = 0;
                while (!reader.EndOfStream)
                {
                    //we're just testing read speeds
                    _allLines[index] = reader.ReadLine();
                    index++;
                }
            } //CLOSE THE FILE because we are now DONE with it.

            Parallel.For(0, _allLines.Length, index =>
            {
                TestReadingAndProcessingLinesFromFile_DoStuff(_allLines[index]); //to simulate work
            });
        }

        private static void Function9()
        {
            //Read the entire file using File.ReadAllLines. 
            //_allLines = new string[_max]; //only allocate memory here
            _allLines = File.ReadAllLines(_fileName);
            Parallel.For(0, _allLines.Length, index =>
            {
                TestReadingAndProcessingLinesFromFile_DoStuff(_allLines[index]); //to simulate work
            });
        }
    }
}
