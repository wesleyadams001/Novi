namespace NtfsModule.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using XModule.Interfaces;

    //[Table("public.most_rated_sellers")]
    public partial class most_rated_sellers : IEntity
    {
        public most_rated_sellers(string seller, long? time_stamp)
        {
            this.seller = seller;
            this.time_stamp = time_stamp;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Primary_key { get; set; }

        public string seller { get; set; }

        public long? time_stamp { get; set; }
    }
}
