namespace KeepaModule.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.price_history")]
    public partial class price_history
    {
        public price_history(ulong? product_id, int? ob_history_type, decimal? ob_date, decimal? ob_price, decimal? ob_shipping, decimal? time_stamp)
        {
            this.product_id = product_id ?? throw new ArgumentNullException(nameof(product_id));
            this.ob_history_type = ob_history_type ?? throw new ArgumentNullException(nameof(ob_history_type));
            this.ob_date = ob_date ?? throw new ArgumentNullException(nameof(ob_date));
            this.ob_price = ob_price ?? throw new ArgumentNullException(nameof(ob_price));
            this.ob_shipping = ob_shipping ?? throw new ArgumentNullException(nameof(ob_shipping));
            this.time_stamp = time_stamp ?? throw new ArgumentNullException(nameof(time_stamp));
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int product_history_id { get; set; }

        public ulong? product_id { get; set; }

        public int? ob_history_type { get; set; }

        public decimal? ob_date { get; set; }

        public decimal? ob_price { get; set; }

        public decimal? ob_shipping { get; set; }

        public decimal? time_stamp { get; set; }
    }
}
