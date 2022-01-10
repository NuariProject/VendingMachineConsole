using System;
using VendingMachine.Machine;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string status;
            int NoMakanan, JmlPembelian, TotalPemesanan, Uang = 0;
            bool condition;

            MakeList GetListObject = new MakeList();
            MachineClass GetmachineObject = new MachineClass();
            var MakananList = GetListObject.MakananList();
            var PecahanList = GetListObject.PecahanUangList();

            do
            {
                Console.WriteLine("Menu Makanam");
                foreach (var item in MakananList)
                {
                    status = item.stok > 0 ? "":"Stok Habis"; 
                    Console.WriteLine("|| "+item.id+" || "+item.makanan+" || "+item.harga+" || "+ status);
                }

                #region Pemesanan
                Console.WriteLine();
                Console.Write("Pilih Nomor Makanan : ");
                NoMakanan = Convert.ToInt32(Console.ReadLine());
                Console.Write("Jumlah Pembelian : ");
                JmlPembelian = Convert.ToInt32(Console.ReadLine());
                status = GetmachineObject.PengecekanStok(MakananList, NoMakanan, JmlPembelian);
                Console.WriteLine(status);
                #endregion
                if(!status.Equals("Stok Makanan Kurang"))
                {
                    #region Konfirmasi
                    Console.WriteLine();
                    Console.Write("Lanjutkan Pemesanan y/n : ");
                    condition = Console.ReadLine().Equals("y") ? true : false;
                    if (condition)
                    {
                        #region Pembelian
                        Console.WriteLine();
                        Console.WriteLine("Pembayaran harus dengan pecahan : ");
                        foreach (var item in PecahanList)
                        {
                            Console.WriteLine("|| " + item.pecahan + " || ");
                        }

                        Console.WriteLine();

                        do
                        {
                            Console.Write("Masukan uang anda : ");
                            var getuang = Convert.ToInt32(Console.ReadLine());
                            if (GetmachineObject.PengecekanUang(PecahanList, getuang))
                            {
                                Uang += getuang;
                                TotalPemesanan = GetmachineObject.TotalPemesanan(MakananList, NoMakanan, JmlPembelian);
                                condition = TotalPemesanan > Uang ? true : false;
                                Console.WriteLine("Total Uang : " + Uang);
                            }
                            else
                            {
                                Console.WriteLine("Pecahan Uang Anda Tidak Di Kenal");
                            }

                        } while (condition);

                        Console.WriteLine();
                        GetmachineObject.Report(MakananList, NoMakanan, JmlPembelian, Uang);
                        MakananList = GetmachineObject.UpdateStok(MakananList, NoMakanan, JmlPembelian);
                        #endregion

                    }
                    #endregion
                }

                Console.WriteLine();
                Console.Write("Lakukan Pemesanan Lagi y/n : ");
                condition = Console.ReadLine().Equals("y") ? true : false;
                Console.WriteLine();

            } while (condition);
            Console.WriteLine("Terima Kasih");
            Environment.Exit(0);
        }
    }
}
