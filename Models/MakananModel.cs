using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    public class MakananModel
    {
        public int id { get; set; }
        public string makanan { get; set; }
        public int harga { get; set; }
        public int stok { get; set; }
    }
}
