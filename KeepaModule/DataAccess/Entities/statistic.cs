namespace KeepaModule.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.statistics")]
    public partial class statistic
    {
        public statistic(ulong? product_id, int? stat_type, long? current, long? avg, long? avg_30, long? avg_90, long? avg_180, long? at_interval_start, long? min_price_type, long? min_price_rec_time, long? min_price_value, long? max_price_type, long? max_price_rec_time, long? max_price_value, long? interval_min_price_type, long? interval_min_price_rec_time, long? interval_min_price_value, long? interval_max_price_type, long? interval_max_price_rec_time, long? interval_max_price_value, long? out_of_stock_percentage_ininterval, long? out_of_stock_percentage_30, long? out_of_stock_percentage_90, long? last_offers_update, long? total_offer_count, long? lightning_deal_info, long? retrieved_offer_count, long? buy_box_price, long? buy_box_shipping, bool? buy_box_is_unqualified, bool? buy_box_is_shippable, bool? buy_box_is_preorder, bool? buy_box_is_fba, bool? buy_box_is_amazon, bool? buy_box_is_map, bool? buy_box_is_used, string seller_ids_lowest_fba, string seller_ids_lowest_fbm, long? offer_count_fba, long? offer_count_fbm, long? time_stamp)
        {
            this.product_id = product_id ?? throw new ArgumentNullException(nameof(product_id));
            this.stat_type = stat_type ?? throw new ArgumentNullException(nameof(stat_type));
            this.current = current ?? throw new ArgumentNullException(nameof(current));
            this.avg = avg ?? throw new ArgumentNullException(nameof(avg));
            this.avg_30 = avg_30 ?? throw new ArgumentNullException(nameof(avg_30));
            this.avg_90 = avg_90 ?? throw new ArgumentNullException(nameof(avg_90));
            this.avg_180 = avg_180 ?? throw new ArgumentNullException(nameof(avg_180));
            this.at_interval_start = at_interval_start ?? throw new ArgumentNullException(nameof(at_interval_start));
            this.min_price_type = min_price_type ?? throw new ArgumentNullException(nameof(min_price_type));
            this.min_price_rec_time = min_price_rec_time ?? throw new ArgumentNullException(nameof(min_price_rec_time));
            this.min_price_value = min_price_value ?? throw new ArgumentNullException(nameof(min_price_value));
            this.max_price_type = max_price_type ?? throw new ArgumentNullException(nameof(max_price_type));
            this.max_price_rec_time = max_price_rec_time ?? throw new ArgumentNullException(nameof(max_price_rec_time));
            this.max_price_value = max_price_value ?? throw new ArgumentNullException(nameof(max_price_value));
            this.interval_min_price_type = interval_min_price_type ?? throw new ArgumentNullException(nameof(interval_min_price_type));
            this.interval_min_price_rec_time = interval_min_price_rec_time ?? throw new ArgumentNullException(nameof(interval_min_price_rec_time));
            this.interval_min_price_value = interval_min_price_value ?? throw new ArgumentNullException(nameof(interval_min_price_value));
            this.interval_max_price_type = interval_max_price_type ?? throw new ArgumentNullException(nameof(interval_max_price_type));
            this.interval_max_price_rec_time = interval_max_price_rec_time ?? throw new ArgumentNullException(nameof(interval_max_price_rec_time));
            this.interval_max_price_value = interval_max_price_value ?? throw new ArgumentNullException(nameof(interval_max_price_value));
            this.out_of_stock_percentage_ininterval = out_of_stock_percentage_ininterval ?? throw new ArgumentNullException(nameof(out_of_stock_percentage_ininterval));
            this.out_of_stock_percentage_30 = out_of_stock_percentage_30 ?? throw new ArgumentNullException(nameof(out_of_stock_percentage_30));
            this.out_of_stock_percentage_90 = out_of_stock_percentage_90 ?? throw new ArgumentNullException(nameof(out_of_stock_percentage_90));
            this.last_offers_update = last_offers_update ?? throw new ArgumentNullException(nameof(last_offers_update));
            this.total_offer_count = total_offer_count ?? throw new ArgumentNullException(nameof(total_offer_count));
            this.lightning_deal_info = lightning_deal_info ?? throw new ArgumentNullException(nameof(lightning_deal_info));
            this.retrieved_offer_count = retrieved_offer_count ?? throw new ArgumentNullException(nameof(retrieved_offer_count));
            this.buy_box_price = buy_box_price ?? throw new ArgumentNullException(nameof(buy_box_price));
            this.buy_box_shipping = buy_box_shipping ?? throw new ArgumentNullException(nameof(buy_box_shipping));
            this.buy_box_is_unqualified = buy_box_is_unqualified ?? throw new ArgumentNullException(nameof(buy_box_is_unqualified));
            this.buy_box_is_shippable = buy_box_is_shippable ?? throw new ArgumentNullException(nameof(buy_box_is_shippable));
            this.buy_box_is_preorder = buy_box_is_preorder ?? throw new ArgumentNullException(nameof(buy_box_is_preorder));
            this.buy_box_is_fba = buy_box_is_fba ?? throw new ArgumentNullException(nameof(buy_box_is_fba));
            this.buy_box_is_amazon = buy_box_is_amazon ?? throw new ArgumentNullException(nameof(buy_box_is_amazon));
            this.buy_box_is_map = buy_box_is_map ?? throw new ArgumentNullException(nameof(buy_box_is_map));
            this.buy_box_is_used = buy_box_is_used ?? throw new ArgumentNullException(nameof(buy_box_is_used));
            this.seller_ids_lowest_fba = seller_ids_lowest_fba ?? throw new ArgumentNullException(nameof(seller_ids_lowest_fba));
            this.seller_ids_lowest_fbm = seller_ids_lowest_fbm ?? throw new ArgumentNullException(nameof(seller_ids_lowest_fbm));
            this.offer_count_fba = offer_count_fba ?? throw new ArgumentNullException(nameof(offer_count_fba));
            this.offer_count_fbm = offer_count_fbm ?? throw new ArgumentNullException(nameof(offer_count_fbm));
            this.time_stamp = time_stamp ?? throw new ArgumentNullException(nameof(time_stamp));
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int statistics_id { get; set; }

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
