using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMJI.Models.Sortable
{
    public class SortableTable :IComparable<SortableTable>
    {
        public Table table;
        public int CompareTo(SortableTable other)
        {
            if(other == null || other.table == null) return 1;
            else
                if(table == null) return -1;
            else
            return this.table.LastUpdated.CompareTo(other.table.LastUpdated);
        }
        public SortableTable(Table t)
        {
            table = t;
        }
    }
}
