using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity;

using Retail.Model;
using RetailUsingEntityFramework.Mapping;

namespace RetailUsingEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            var beli = GetPembelianUsingEF("N001");

            Console.WriteLine("Nota : {0},\nTanggal : {1}, \nSupplier : {2}",
                               beli.Nota, beli.Tanggal, beli.Supplier.NamaSupplier);

            Console.WriteLine("\nItem Beli :");

            // ekstrak item beli
            foreach (var item in beli.ItemBelis)
            {
                Console.WriteLine("Barang : {0}, Jumlah : {1}, Harga Jual : {2}",
                                   item.Barang.NamaBarang, item.Jumlah, item.HargaJual);
            }

            Console.WriteLine("\nPress any key to exit ...");
            Console.ReadKey();
        }

        private static Beli GetPembelianUsingEF(string nota)
        {
            Beli beli;

            using (var db = new RetailContext())
            {
                beli = db.Belis
                         .Include(bl => bl.Supplier)
                         .Include(bl => bl.ItemBelis.Select(ib => ib.Barang))
                         .Where(bl => bl.Nota == nota)
                         .SingleOrDefault();
            }

            return beli;
        }
    }
}
