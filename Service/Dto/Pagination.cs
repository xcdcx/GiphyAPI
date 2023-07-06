using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class Pagination
    {
        public int Total_Count { get; set; }
        public int Count { get; set; }
        public int Offset { get; set; }
    }
}
