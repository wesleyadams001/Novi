namespace KeepaModule.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.variations")]
    public partial class variation
    {
        public variation(ulong? product_id, string variation_asin, string variation_dimension, string variation_value, long? time_stamp)
        {
            
            this.product_id = product_id ?? throw new ArgumentNullException(nameof(product_id));
            this.variation_asin = variation_asin ?? throw new ArgumentNullException(nameof(variation_asin));
            this.variation_dimension = variation_dimension ?? throw new ArgumentNullException(nameof(variation_dimension));
            this.variation_value = variation_value ?? throw new ArgumentNullException(nameof(variation_value));
            this.time_stamp = time_stamp ?? throw new ArgumentNullException(nameof(time_stamp));
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int product_variation_id { get; set; }

        public ulong? product_id { get; set; }

        public string variation_asin { get; set; }

        public string variation_dimension { get; set; }

        public string variation_value { get; set; }

        public long? time_stamp { get; set; }
    }
}
