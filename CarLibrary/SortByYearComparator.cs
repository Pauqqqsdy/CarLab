using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    public class SortByYearComparator : IComparer<Transport>
    {
        public int Compare(Transport? x, Transport? y) => x.Year.CompareTo(y.Year);
    }
}
