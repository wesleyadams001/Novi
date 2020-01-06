namespace KeepaModule.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using XModule.Interfaces;

    //[Table("public.sellers_listed_items")]
    public partial class sellers_listed_items : IEntity
    {
        public sellers_listed_items(ulong? seller_id, string asin, long? asin_last_verified, long? time_stamp)
        {
            this.seller_id = seller_id;
            this.asin = asin;
            this.asin_last_verified = asin_last_verified;
            this.time_stamp = time_stamp;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Primary_key { get; set; }

        public ulong? seller_id { get; set; }

        public string asin { get; set; }

        public long? asin_last_verified { get; set; }

        public long? time_stamp { get; set; }
    }
}
