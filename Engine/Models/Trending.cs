using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Trending
    {
        public List<Image> Images { get; set; }
        public Pagination Pagination { get; set; }
    }
}
