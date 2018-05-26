using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adov_db_15202.Models
{
    public class Utilities
    {
        public long ID { get; set; }
        public long StoreID { get; set; }
        public long Sum { get; set; }
        public DateTime Date { get; set; }

        public virtual Store Store { get; set; }
    }
}