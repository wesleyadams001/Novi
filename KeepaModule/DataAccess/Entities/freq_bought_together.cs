namespace KeepaModule.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using XModule.Interfaces;

    [Table("public.freq_bought_together")]
    public partial class freq_bought_together : IEntity
    {
        public freq_bought_together(ulong? product_id, string associated_asin, long? time_stamp)
        {
            this.product_id = product_id ?? throw new ArgumentNullException(nameof(product_id));
            this.associated_asin = associated_asin ?? throw new ArgumentNullException(nameof(associated_asin));
            this.time_stamp = time_stamp ?? throw new ArgumentNullException(nameof(time_stamp));
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Primary_key { get; set; }

        public ulong? product_id { get; set; }

        public string associated_asin { get; set; }

        public long? time_stamp { get; set; }
    }
}
