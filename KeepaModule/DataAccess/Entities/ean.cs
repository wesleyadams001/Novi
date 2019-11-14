namespace KeepaModule.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using XModule.Interfaces;

    //[Table("public.eans")]
    public partial class ean : IEntity
    {
        public ean(ulong? product_id, string ean_number, long? time_stamp)
        {
            this.product_id = product_id ?? throw new ArgumentNullException(nameof(product_id));
            this.ean_number = ean_number ?? throw new ArgumentNullException(nameof(ean_number));
            this.time_stamp = time_stamp ?? throw new ArgumentNullException(nameof(time_stamp));
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Primary_key { get; set; }

        public ulong? product_id { get; set; }

        public string ean_number { get; set; }

        public long? time_stamp { get; set; }
    }
}
