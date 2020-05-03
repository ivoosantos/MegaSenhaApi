using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSenhaApi.Helper
{
    public class PaginationList<T>
    {
        public List<T> Results { get; set; } = new List<T>();
    }
}
