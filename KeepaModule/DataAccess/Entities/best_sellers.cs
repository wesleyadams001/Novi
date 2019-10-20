namespace KeepaModule.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using XModule.Interfaces;

    [Table("public.best_sellers")]
    public partial class best_sellers : IEntity
    {
        public best_sellers(int? domain_id, int? last_update, long? category_id, string asin_list, long? time_stamp)
        {
            this.domain_id = domain_id ?? throw new ArgumentNullException(nameof(domain_id));
            this.last_update = last_update ?? throw new ArgumentNullException(nameof(last_update));
            this.category_id = category_id ?? throw new ArgumentNullException(nameof(category_id));
            this.asin_list = asin_list ?? throw new ArgumentNullException(nameof(asin_list));
            this.time_stamp = time_stamp ?? throw new ArgumentNullException(nameof(time_stamp));
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Primary_key { get; set; }

        public int? domain_id { get; set; }

        public int? last_update { get; set; }

        public long? category_id { get; set; }

        public string asin_list { get; set; }

        public long? time_stamp { get; set; }
    }
}
