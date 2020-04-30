namespace NtfsModule.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using XModule.Interfaces;

    //[Table("public.statistics")]
    public partial class statistic : IEntity
    {
        public statistic(ulong? product_id, int? stat_type, long? current, long? avg, long? avg_30, long? avg_90, long? avg_180, long? at_interval_start, long? min_price_type, long? min_price_rec_time, long? min_price_value, long? max_price_type, long? max_price_rec_time, long? max_price_value, long? interval_min_price_type, long? interval_min_price_rec_time, long? interval_min_price_value, long? interval_max_price_type, long? interval_max_price_rec_time, long? interval_max_price_value, long? out_of_stock_percentage_ininterval, long? out_of_stock_percentage_30, long? out_of_stock_percentage_90, long? last_offers_update, long? total_offer_count, long? lightning_deal_info, long? retrieved_offer_count, long? buy_box_price, long? buy_box_shipping, bool? buy_box_is_unqualified, bool? buy_box_is_shippable, bool? buy_box_is_preorder, bool? buy_box_is_fba, bool? buy_box_is_amazon, bool? buy_box_is_map, bool? buy_box_is_used, string seller_ids_lowest_fba, string seller_ids_lowest_fbm, long? offer_count_fba, long? offer_count_fbm, long? time_stamp)
        {
            this.product_id = product_id ?? null;
            this.stat_type = stat_type ?? null;
            this.current = current ?? null;
            this.avg = avg ?? null;
            this.avg_30 = avg_30 ?? null;
            this.avg_90 = avg_90 ?? null;
            this.avg_180 = avg_180 ?? null;
            this.at_interval_start = at_interval_start ?? null;
            this.min_price_type = min_price_type ?? null;
            this.min_price_rec_time = min_price_rec_time ?? null;
            this.min_price_value = min_price_value ?? null;
            this.max_price_type = max_price_type ?? null;
            this.max_price_rec_time = max_price_rec_time ?? null;
            this.max_price_value = max_price_value ?? null;
            this.interval_min_price_type = interval_min_price_type ?? null;
            this.interval_min_price_rec_time = interval_min_price_rec_time ?? null;
            this.interval_min_price_value = interval_min_price_value ?? null;
            this.interval_max_price_type = interval_max_price_type ?? null;
            this.interval_max_price_rec_time = interval_max_price_rec_time ?? null;
            this.interval_max_price_value = interval_max_price_value ?? null;
            this.out_of_stock_percentage_ininterval = out_of_stock_percentage_ininterval ?? null;
            this.out_of_stock_percentage_30 = out_of_stock_percentage_30 ?? null;
            this.out_of_stock_percentage_90 = out_of_stock_percentage_90 ?? null;
            this.last_offers_update = last_offers_update ?? null;
            this.total_offer_count = total_offer_count ?? null;
            this.lightning_deal_info = lightning_deal_info ?? null;
            this.retrieved_offer_count = retrieved_offer_count ?? null;
            this.buy_box_price = buy_box_price ?? null;
            this.buy_box_shipping = buy_box_shipping ?? null;
            this.buy_box_is_unqualified = buy_box_is_unqualified ?? null;
            this.buy_box_is_shippable = buy_box_is_shippable ?? null;
            this.buy_box_is_preorder = buy_box_is_preorder ?? null;
            this.buy_box_is_fba = buy_box_is_fba ?? null;
            this.buy_box_is_amazon = buy_box_is_amazon ?? null;
            this.buy_box_is_map = buy_box_is_map ?? null;
            this.buy_box_is_used = buy_box_is_used ?? null;
            this.seller_ids_lowest_fba = seller_ids_lowest_fba ?? null;
            this.seller_ids_lowest_fbm = seller_ids_lowest_fbm ?? null;
            this.offer_count_fba = offer_count_fba ?? null;
            this.offer_count_fbm = offer_count_fbm ?? null;
            this.time_stamp = time_stamp ?? null;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Primary_key { get; set; }

        public ulong? product_id { get; set; }

        public int? stat_type { get; set; }

        public long? current { get; set; }

        public long? avg { get; set; }

        public long? avg_30 { get; set; }

        public long? avg_90 { get; set; }

        public long? avg_180 { get; set; }

        public long? at_interval_start { get; set; }

        public long? min_price_type { get; set; }

        public long? min_price_rec_time { get; set; }

        public long? min_price_value { get; set; }

        public long? max_price_type { get; set; }

        public long? max_price_rec_time { get; set; }

        public long? max_price_value { get; set; }

        public long? interval_min_price_type { get; set; }

        public long? interval_min_price_rec_time { get; set; }

        public long? interval_min_price_value { get; set; }

        public long? interval_max_price_type { get; set; }

        public long? interval_max_price_rec_time { get; set; }

        public long? interval_max_price_value { get; set; }

        public long? out_of_stock_percentage_ininterval { get; set; }

        public long? out_of_stock_percentage_30 { get; set; }

        public long? out_of_stock_percentage_90 { get; set; }

        public long? last_offers_update { get; set; }

        public long? total_offer_count { get; set; }

        public long? lightning_deal_info { get; set; }

        public long? retrieved_offer_count { get; set; }

        public long? buy_box_price { get; set; }

        public long? buy_box_shipping { get; set; }

        public bool? buy_box_is_unqualified { get; set; }

        public bool? buy_box_is_shippable { get; set; }

        public bool? buy_box_is_preorder { get; set; }

        public bool? buy_box_is_fba { get; set; }

        public bool? buy_box_is_amazon { get; set; }

        public bool? buy_box_is_map { get; set; }

        public bool? buy_box_is_used { get; set; }

        public string seller_ids_lowest_fba { get; set; }

        public string seller_ids_lowest_fbm { get; set; }

        public long? offer_count_fba { get; set; }

        public long? offer_count_fbm { get; set; }

        public long? time_stamp { get; set; }
    }
}
