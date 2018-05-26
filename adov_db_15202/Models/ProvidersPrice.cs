using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adov_db_15202.Models
{
    public class ProvidersPrice
    {
        public long ID { get; set; }
        public long ProviderID { get; set; }
        public long ProductID { get; set; }
        public long Price { get; set; }
        public DateTime Date { get; set; }

        public virtual Provider Provider { get; set; }
        public virtual Product Product { get; set; }
    }
}