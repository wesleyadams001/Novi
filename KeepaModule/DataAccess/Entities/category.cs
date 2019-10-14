namespace KeepaModule.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.category")]
    public partial class category
    {
        public category(ulong? product_id, long? amzn_category_id, long? time_stamp)
        {
            this.product_id = product_id ?? throw new ArgumentNullException(nameof(product_id));
            this.amzn_category_id = amzn_category_id ?? throw new ArgumentNullException(nameof(amzn_category_id));
            this.time_stamp = time_stamp ?? throw new ArgumentNullException(nameof(time_stamp));
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int category_id { get; set; }

        public ulong? product_id { get; set; }

        public long? amzn_category_id { get; set; }

        public long? time_stamp { get; set; }
    }
}
