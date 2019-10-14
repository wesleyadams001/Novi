namespace KeepaModule.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.most_rated_sellers")]
    public partial class most_rated_sellers
    {
        public most_rated_sellers(string seller, long? time_stamp)
        {
            this.seller = seller ?? throw new ArgumentNullException(nameof(seller));
            this.time_stamp = time_stamp ?? throw new ArgumentNullException(nameof(time_stamp));
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int seller_id { get; set; }

        public string seller { get; set; }

        public long? time_stamp { get; set; }
    }
}
