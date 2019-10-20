namespace KeepaModule.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using XModule.Interfaces;

    [Table("public.fba_fees")]
    public partial class fba_fees : IEntity
    {
        public fba_fees(ulong? product_id, int? pick_pack_fee, int? pick_pack_fee_tax, int? storage_fee, int? storage_fee_tax, long? time_stamp)
        {
            this.product_id = product_id ?? throw new ArgumentNullException(nameof(product_id));
            this.pick_pack_fee = pick_pack_fee ?? throw new ArgumentNullException(nameof(pick_pack_fee));
            this.pick_pack_fee_tax = pick_pack_fee_tax ?? throw new ArgumentNullException(nameof(pick_pack_fee_tax));
            this.storage_fee = storage_fee ?? throw new ArgumentNullException(nameof(storage_fee));
            this.storage_fee_tax = storage_fee_tax ?? throw new ArgumentNullException(nameof(storage_fee_tax));
            this.time_stamp = time_stamp ?? throw new ArgumentNullException(nameof(time_stamp));
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Primary_key { get; set; }

        public ulong? product_id { get; set; }

        public int? pick_pack_fee { get; set; }

        public int? pick_pack_fee_tax { get; set; }

        public int? storage_fee { get; set; }

        public int? storage_fee_tax { get; set; }

        public long? time_stamp { get; set; }
    }
}
