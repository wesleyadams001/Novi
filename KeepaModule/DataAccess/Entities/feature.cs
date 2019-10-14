namespace KeepaModule.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.features")]
    public partial class feature
    {
        public feature(ulong? product_id, string features, long? time_stamp)
        {
            this.product_id = product_id ?? throw new ArgumentNullException(nameof(product_id));
            this.features = features ?? throw new ArgumentNullException(nameof(features));
            this.time_stamp = time_stamp ?? throw new ArgumentNullException(nameof(time_stamp));
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int features_id { get; set; }

        public ulong? product_id { get; set; }

        public string features { get; set; }

        public long? time_stamp { get; set; }
    }
}
