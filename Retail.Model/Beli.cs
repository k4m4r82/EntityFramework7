using System;
using System.Collections.Generic;

namespace Retail.Model
{
    public partial class Beli
    {
        public Beli()
        {
            this.ItemBelis = new List<ItemBeli>();
        }

        public string Nota { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public Nullable<System.DateTime> Tanggal { get; set; }
        public string Keterangan { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<ItemBeli> ItemBelis { get; set; }
    }
}
