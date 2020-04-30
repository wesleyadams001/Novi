namespace NtfsModule.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using XModule.Interfaces;

    //[Table("public.features")]
    public partial class feature : IEntity
    {
        public feature(ulong? product_id, string features, long? time_stamp)
        {
            this.product_id = product_id;
            this.features = features;
            this.time_stamp = time_stamp;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Primary_key { get; set; }

        public ulong? product_id { get; set; }

        public string features { get; set; }

        public long? time_stamp { get; set; }
    }
}
