namespace NtfsModule.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using XModule.Interfaces;

    //[Table("public.upcs")]
    public partial class upc : IEntity
    {
        public upc(ulong? product_id, string upc_number, long? time_stamp)
        {
            this.product_id = product_id;
            this.upc_number = upc_number;
            this.time_stamp = time_stamp;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Primary_key { get; set; }

        public ulong? product_id { get; set; }

        public string upc_number { get; set; }

        public long? time_stamp { get; set; }
    }
}
