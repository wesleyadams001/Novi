namespace KeepaModule.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.sellers")]
    public partial class seller
    {
        public seller(ulong seller_id, int? domain_id, int? tracking_since, int? last_update, string amzn_seller_id, string seller_name, bool? is_scammer, bool? has_fba, int? total_store_front_rec_time, int? total_store_front_asins, int? rating, int? rating_time, int? rating_count, long? rating_count_time, long? time_stamp)
        {
            this.seller_id = seller_id;
            this.domain_id = domain_id ?? throw new ArgumentNullException(nameof(domain_id));
            this.tracking_since = tracking_since ?? throw new ArgumentNullException(nameof(tracking_since));
            this.last_update = last_update ?? throw new ArgumentNullException(nameof(last_update));
            this.amzn_seller_id = amzn_seller_id ?? throw new ArgumentNullException(nameof(amzn_seller_id));
            this.seller_name = seller_name ?? throw new ArgumentNullException(nameof(seller_name));
            this.is_scammer = is_scammer ?? throw new ArgumentNullException(nameof(is_scammer));
            this.has_fba = has_fba ?? throw new ArgumentNullException(nameof(has_fba));
            this.total_store_front_rec_time = total_store_front_rec_time ?? throw new ArgumentNullException(nameof(total_store_front_rec_time));
            this.total_store_front_asins = total_store_front_asins ?? throw new ArgumentNullException(nameof(total_store_front_asins));
            this.rating = rating ?? throw new ArgumentNullException(nameof(rating));
            this.rating_time = rating_time ?? throw new ArgumentNullException(nameof(rating_time));
            this.rating_count = rating_count ?? throw new ArgumentNullException(nameof(rating_count));
            this.rating_count_time = rating_count_time ?? throw new ArgumentNullException(nameof(rating_count_time));
            this.time_stamp = time_stamp ?? throw new ArgumentNullException(nameof(time_stamp));
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int t_id { get; set; }

        public ulong seller_id { get; set; }

        public int? domain_id { get; set; }

        public int? tracking_since { get; set; }

        public int? last_update { get; set; }

        public string amzn_seller_id { get; set; }

        public string seller_name { get; set; }

        public bool? is_scammer { get; set; }

        public bool? has_fba { get; set; }

        public int? total_store_front_rec_time { get; set; }

        public int? total_store_front_asins { get; set; }

        public int? rating { get; set; }

        public int? rating_time { get; set; }

        public int? rating_count { get; set; }

        public long? rating_count_time { get; set; }

        public long? time_stamp { get; set; }
    }
}
