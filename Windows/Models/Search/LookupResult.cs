using System;

namespace Windows.Models.Search
{
    public class LookupResult
    {
        public LookupResult(int targetSize, int listSize)
        {
            TargetSize = targetSize;
            ListSize = listSize;
            StartDate = DateTime.Now;
        }

        private DateTime StartDate { get; }
        private int TargetSize { get; }
        private int ListSize { get; }

        public string GetResult()
        {
            var now = DateTime.Now;
            return $"It took {now - StartDate} to lookup {TargetSize} records in a list of {ListSize} items";
        }
    }
}
