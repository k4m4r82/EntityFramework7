using System;
using System.Collections.Generic;

namespace Retail.Model
{
    public partial class Supplier
    {
        public Supplier()
        {
            this.Belis = new List<Beli>();
        }

        public int SupplierID { get; set; }
        public string NamaSupplier { get; set; }
        public string Jalan { get; set; }
        public string Kota { get; set; }
        public virtual ICollection<Beli> Belis { get; set; }
    }
}
