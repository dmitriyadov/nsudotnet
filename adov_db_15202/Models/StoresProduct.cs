using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adov_db_15202.Models
{
    public class StoresProduct
    {
        public long ID { get; set; }
        public long StoreID { get; set; }
        public long ProductID { get; set; }
        public long Number { get; set; }
        public long Price { get; set; }
        public DateTime Date { get; set; }

        public virtual Store Store { get; set; }
        public virtual Product Product { get; set; }
    }
}