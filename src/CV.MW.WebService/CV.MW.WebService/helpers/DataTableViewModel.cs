using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CV.MW.WebService.helpers
{
    public class DataTableViewModel
    {
        public string Id { get; set; }
        public List<DataTableRowViewModel> Rows { get; set; }
        public DataTableViewModel(string id, List<string> rows)
        {
            Id = id;
            Rows = new List<DataTableRowViewModel>();

            foreach (string row in rows)
            {
                Rows.Add(new DataTableRowViewModel() {DataFieldName = row });
            }
        }
    }
}
