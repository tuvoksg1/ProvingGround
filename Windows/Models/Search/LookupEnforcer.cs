using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pledge.Common.Models;
using Pledge.Lookup.Core.IO;

namespace Windows.Models.Search
{
    public class LookupEnforcer
    {
        private List<Cell> _rowCells = null;

        public List<Cell> LoadRecords(string file)
        {
            using (var reader = new StreamReader(file))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var cells = line.Split(new[] { '|' }, StringSplitOptions.None);

                    _rowCells = cells.Select(item => new Cell
                    {
                        Value = item
                    }).ToList();
                }
            }

            return _rowCells;
        }

        public void PerformLookup(string listId, string listName, string tenantId)
        {
            var listProvider = new FileListProvider();
            var list = listProvider.GetList(listId, listName, tenantId);

            foreach (var cell in _rowCells)
            {
                
            }
        }

        public bool IsInList(string text)
        {
            
        }
    }
}
