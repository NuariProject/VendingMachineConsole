using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Models;

namespace VendingMachine.Machine
{
    class MakeList
    {
        public List<MakananModel> MakananList()
        {
            List<MakananModel> SetList = new List<MakananModel>()
            {
                new MakananModel(){id = 1, makanan = "Biskuit", harga = 6000, stok = 5 },
                new MakananModel(){id = 2, makanan = "Chips", harga = 8000, stok = 5 },
                new MakananModel(){id = 3, makanan = "Oreo", harga = 10000, stok = 5 },
                new MakananModel(){id = 4, makanan = "Tango", harga = 12000, stok = 5 },
                new MakananModel(){id = 5, makanan = "Cokelat", harga = 15000, stok = 5 }
            };

            return SetList;
        }

        public List<UangPecahanModel> PecahanUangList()
        {
            List<UangPecahanModel> SetList = new List<UangPecahanModel>()
            {
                new UangPecahanModel(){ id = 1, pecahan = 2000},
                new UangPecahanModel(){ id = 1, pecahan = 5000},
                new UangPecahanModel(){ id = 1, pecahan = 10000},
                new UangPecahanModel(){ id = 1, pecahan = 20000},
                new UangPecahanModel(){ id = 1, pecahan = 50000},
            };

            return SetList;
        }
    }
}
