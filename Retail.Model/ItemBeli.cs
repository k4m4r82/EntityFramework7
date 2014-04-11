using System;
using System.Collections.Generic;

namespace Retail.Model
{
    public partial class ItemBeli
    {
        public int ItemBeliID { get; set; }
        public string Nota { get; set; }
        public string BarangID { get; set; }
        public Nullable<int> Jumlah { get; set; }
        public Nullable<int> HargaBeli { get; set; }
        public Nullable<int> HargaJual { get; set; }
        public virtual Barang Barang { get; set; }
        public virtual Beli Beli { get; set; }
    }
}
