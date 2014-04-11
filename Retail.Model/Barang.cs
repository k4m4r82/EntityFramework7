using System;
using System.Collections.Generic;

namespace Retail.Model
{
    public partial class Barang
    {
        public Barang()
        {
            this.ItemBelis = new List<ItemBeli>();
        }

        public string BarangID { get; set; }
        public string NamaBarang { get; set; }
        public Nullable<int> HargaBeli { get; set; }
        public Nullable<int> HargaJual { get; set; }
        public string Stok { get; set; }
        public virtual ICollection<ItemBeli> ItemBelis { get; set; }
    }
}
