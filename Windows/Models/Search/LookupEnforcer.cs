using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Pledge.Common.Models;
using Pledge.Lookup.Core.IO;

namespace Windows.Models.Search
{
    public class LookupEnforcer
    {
        private readonly List<List<Cell>> _rowCells;
        private readonly int _cellIndex;

        public LookupEnforcer(string file, int cellIndex)
        {
            _rowCells = new List<List<Cell>>();
            LoadRecords(file);
            _cellIndex = cellIndex;
        }

        private void LoadRecords(string file)
        {
            using (var reader = new StreamReader(file))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var cells = line.Split(new[] { '|' }, StringSplitOptions.None);

                    var rowCells = cells.Select(item => new Cell
                    {
                        Value = item
                    }).ToList();

                    _rowCells.Add(rowCells);
                }
            }
        }

        public string PerformLookup(string listId, string listName, string tenantId)
        {
            var listProvider = new FileListProvider();
            var list = listProvider.GetList(listId, listName, tenantId).Select(arg => arg.First()).ToList();

            var result = new LookupResult(_rowCells.Count, list.Count);

            foreach (var cell in _rowCells)
            {
                if (IsInList(list, cell[_cellIndex].Value))
                {
                    break;
                }
            }

            return result.GetResult();
        }

        private static bool IsInList(IEnumerable<string> list, string text)
        {
            return list.Any(item => item.Equals(text,
                StringComparison.OrdinalIgnoreCase));
        }
    }
}
