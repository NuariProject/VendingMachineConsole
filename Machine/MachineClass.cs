using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Models;

namespace VendingMachine.Machine
{
    class MachineClass
    {
        public List<MakananModel> GetMakananList(List<MakananModel> MakananList, int id)
        {
            var GetMakanan = MakananList.Where(ss => ss.id == id).ToList();
            return GetMakanan;
        }

        public string PengecekanStok(List<MakananModel> MakananList, int id, int stok)
        {
            var GetMakanan = GetMakananList(MakananList, id).FirstOrDefault();
            int Total = GetMakanan.harga * stok;
            string Val = GetMakanan.stok >= stok ? 
                        "Stok Makanan Tersedia\nTotal Pemesanan Rp. "+ Total : 
                        "Stok Makanan Kurang";
            return Val;
        }

        public bool PengecekanUang(List<UangPecahanModel> uangPecahanList, int uang)
        {
            bool Val = uangPecahanList.Any(ss => ss.pecahan == uang);
            return Val;
        }

        public int TotalPemesanan(List<MakananModel> MakananList, int id, int stok)
        {
            var GetMakanan = GetMakananList(MakananList, id).FirstOrDefault();
            return GetMakanan.harga * stok;
        }

        public int Pembelian(List<MakananModel> MakananList, int id, int stok, int uang)
        {
            var GetMakanan = GetMakananList(MakananList, id).FirstOrDefault();
            var kembalian = uang - (GetMakanan.harga * stok);
            return kembalian;
        }

        public List<MakananModel> UpdateStok(List<MakananModel> MakananList, int id, int stok)
        {
            MakananList.Where(ss => ss.id == id).ToList().ForEach(ss => ss.stok = ss.stok - stok);
            return MakananList;
        }

        public void Report(List<MakananModel> MakananList, int id, int stok, int uang)
        {
            Console.WriteLine("---------- Pembayaran ----------");
            Console.WriteLine("Pembayaran : " + uang);
            Console.WriteLine("Total Belanja : " + TotalPemesanan(MakananList,id,stok));
            Console.WriteLine("Kembalian : " + Pembelian(MakananList, id, stok, uang));
            Console.WriteLine("---------- Terima Kasih ----------");
        }
    }
}
