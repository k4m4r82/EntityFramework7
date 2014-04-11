using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using System.Data.SqlClient;
using Retail.Model;

namespace RetailUsingADONET
{
    class Program
    {        
        static void Main(string[] args)
        {
            var beli = GetPembelianUsingADONET("N001");
            Console.WriteLine("Nota : {0}\nTanggal : {1}\nSupplier : {2}", 
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

        private static Beli GetPembelianUsingADONET(string nota)
        {
            Beli beli = null;

            using (var conn = GetOpenConnection())
            {
                // ambil data header
                var sql = @"SELECT Beli.Nota, Beli.Tanggal, Supplier.SupplierID, Supplier.NamaSupplier
                            FROM Supplier INNER JOIN Beli ON Supplier.SupplierID = Beli.SupplierID
                            WHERE Beli.Nota = @1";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@1", nota);

                    using (var dtr = cmd.ExecuteReader())
                    {
                        if (dtr.Read())
                        {
                            // mapping record ke objek supplier
                            var supplier = new Supplier
                            {
                                SupplierID = dtr["SupplierID"] is DBNull ? 0 : (int)dtr["SupplierID"],
                                NamaSupplier = dtr["NamaSupplier"] is DBNull ? string.Empty : (string)dtr["NamaSupplier"]                                
                            };

                            // mapping record ke objek beli
                            beli = new Beli();
                            beli.Nota = dtr["Nota"] is DBNull ? string.Empty : (string)dtr["Nota"];
                            beli.Tanggal = dtr["Tanggal"] is DBNull ? DateTime.MinValue : (DateTime)dtr["Tanggal"];
                            beli.Supplier = supplier; // hubungkan objek supplier dan beli                            
                        }
                    }
                }

                if (beli != null)
                {
                    // ambil data detail
                    var daftarItemBeli = GetDetailPembelian(nota, conn);
                    beli.ItemBelis = daftarItemBeli; // hubungkan objek beli dg detail beli
                }
            }

            return beli;
        }

        private static IList<ItemBeli> GetDetailPembelian(string nota, SqlConnection conn)
        {
            var daftarItemBeli = new List<ItemBeli>();

            var sql = @"SELECT Barang.BarangID, Barang.NamaBarang, ItemBeli.Jumlah, ItemBeli.HargaBeli, ItemBeli.HargaJual
                        FROM Barang INNER JOIN ItemBeli ON Barang.BarangID = ItemBeli.BarangID
                        WHERE ItemBeli.Nota = @1";
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@1", nota);

                using (var dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        // mapping record ke objek barang
                        var barang = new Barang
                        {
                            BarangID = dtr["BarangID"] is DBNull ? string.Empty : (string)dtr["BarangID"],
                            NamaBarang = dtr["NamaBarang"] is DBNull ? string.Empty : (string)dtr["NamaBarang"]
                        };

                        // mapping record ke objek item beli
                        var itemBeli = new ItemBeli
                        {
                            Barang = barang, // hubungkan barang dg item beli
                            Jumlah = dtr["Jumlah"] is DBNull ? 0 : (int)dtr["Jumlah"],
                            HargaBeli = dtr["HargaBeli"] is DBNull ? 0 : (int)dtr["HargaBeli"],
                            HargaJual = dtr["HargaJual"] is DBNull ? 0 : (int)dtr["HargaJual"]
                        };

                        daftarItemBeli.Add(itemBeli);
                    }
                }
            }

            return daftarItemBeli;
        }

        private static SqlConnection GetOpenConnection()
        {
            SqlConnection conn = null;

            try
            {
                var strConn = @"Data Source=.\sqlexpress2008;Initial Catalog=Retail;Integrated Security=True";

                conn = new SqlConnection(strConn);                
                conn.Open();

            }
            catch (Exception)
            {
            }

            return conn;
        }
    }
}
