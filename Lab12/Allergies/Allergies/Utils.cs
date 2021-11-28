using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allergies
{
    public static class TupleExtensions
    {
        public static string ToPrettyString(this Tuple<string, int> el)
        {
            return $"{el.Item1} ({el.Item2})";
        }
    }
}
