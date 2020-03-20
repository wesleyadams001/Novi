namespace KeepaModule.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using XModule.Interfaces;

    //[Table("public.products")]
    public partial class product : IEntity
    {
        
        public product(ulong product_id, string product_type, string asin, long? domain_id, string title, long? tracking_since, long? listed_sinceint, long? last_update, long? last_rating_update, long? last_price_change, long? last_ebay_update, string images_csv, decimal? root_category, string parent_asin, string variation_csv, string mpn, bool? has_reviews, string type, string manufacturer, string brand, string label, string department, string publisher, string product_group, string part_number, string author, string binding, long? number_of_items, long? number_of_pages, long? publication_date, long? release_date, string studio, string genre, string model, string color, string size, string edition, string platform, string format, string description, long? hazardous_material_type, long? package_height, long? package_length, long? package_width, long? package_weight, long? package_quantity, long? availability_amazon, bool? is_adult_product, bool? new_price_is_map, bool? is_eligible_for_trade_in, bool? is_eligible_for_super_saver_shipping, bool? is_redirect_asin, bool? is_sns, bool? offers_successful, long? time_stamp)
        {
            this.product_id = product_id;
            this.product_type = product_type ?? null;
            this.asin = asin ?? null;
            this.domain_id = domain_id ?? null;
            this.title = title ?? null;
            this.tracking_since = tracking_since ?? null;
            this.listed_sinceint = listed_sinceint ?? null;
            this.last_update = last_update ?? null;
            this.last_rating_update = last_rating_update ?? null;
            this.last_price_change = last_price_change ?? null;
            this.last_ebay_update = last_ebay_update ?? null;
            this.images_csv = images_csv ?? null;
            this.root_category = root_category ?? null;
            this.parent_asin = parent_asin ?? null;
            this.variation_csv = variation_csv ?? null;
            this.mpn = mpn ?? null;
            this.has_reviews = has_reviews ?? null;
            this.type = type ?? null;
            this.manufacturer = manufacturer ?? null;
            this.brand = brand ?? null;
            this.label = label ?? null;
            this.department = department ?? null;
            this.publisher = publisher ?? null;
            this.product_group = product_group ?? null;
            this.part_number = part_number ?? null;
            this.author = author ?? null;
            this.binding = binding ?? null;
            this.number_of_items = number_of_items ?? null;
            this.number_of_pages = number_of_pages ?? null;
            this.publication_date = publication_date ?? null;
            this.release_date = release_date ?? null;
            this.studio = studio ?? null;
            this.genre = genre ?? null;
            this.model = model ?? null;
            this.color = color ?? null;
            this.size = size ?? null;
            this.edition = edition ?? null;
            this.platform = platform ?? null;
            this.format = format ?? null;
            this.description = description ?? null;
            this.hazardous_material_type = hazardous_material_type ?? null;
            this.package_height = package_height ?? null;
            this.package_length = package_length ?? null;
            this.package_width = package_width ?? null;
            this.package_weight = package_weight ?? null;
            this.package_quantity = package_quantity ?? null;
            this.availability_amazon = availability_amazon ?? null;
            this.is_adult_product = is_adult_product ?? null;
            this.new_price_is_map = new_price_is_map ?? null;
            this.is_eligible_for_trade_in = is_eligible_for_trade_in ?? null;
            this.is_eligible_for_super_saver_shipping = is_eligible_for_super_saver_shipping ?? null;
            this.is_redirect_asin = is_redirect_asin ?? null;
            this.is_sns = is_sns ?? null;
            this.offers_successful = offers_successful ?? null;
            this.time_stamp = time_stamp ?? null;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Primary_key { get; set; }

        public ulong product_id { get; set; }

        public string product_type { get; set; }

        public string asin { get; set; }

        public long? domain_id { get; set; }

        public string title { get; set; }

        public long? tracking_since { get; set; }

        public long? listed_sinceint { get; set; }

        public long? last_update { get; set; }

        public long? last_rating_update { get; set; }

        public long? last_price_change { get; set; }

        public long? last_ebay_update { get; set; }

        public string images_csv { get; set; }

        public decimal? root_category { get; set; }

        public string parent_asin { get; set; }

        public string variation_csv { get; set; }

        public string mpn { get; set; }

        public bool? has_reviews { get; set; }

        public string type { get; set; }

        public string manufacturer { get; set; }

        public string brand { get; set; }

        public string label { get; set; }

        public string department { get; set; }

        public string publisher { get; set; }

        public string product_group { get; set; }

        public string part_number { get; set; }

        public string author { get; set; }

        public string binding { get; set; }

        public long? number_of_items { get; set; }

        public long? number_of_pages { get; set; }

        public long? publication_date { get; set; }

        public long? release_date { get; set; }

        public string studio { get; set; }

        public string genre { get; set; }

        public string model { get; set; }

        public string color { get; set; }

        public string size { get; set; }

        public string edition { get; set; }

        public string platform { get; set; }

        public string format { get; set; }

        public string description { get; set; }

        public long? hazardous_material_type { get; set; }

        public long? package_height { get; set; }

        public long? package_length { get; set; }

        public long? package_width { get; set; }

        public long? package_weight { get; set; }

        public long? package_quantity { get; set; }

        public long? availability_amazon { get; set; }

        public bool? is_adult_product { get; set; }

        public bool? new_price_is_map { get; set; }

        public bool? is_eligible_for_trade_in { get; set; }

        public bool? is_eligible_for_super_saver_shipping { get; set; }

        public bool? is_redirect_asin { get; set; }

        public bool? is_sns { get; set; }

        public bool? offers_successful { get; set; }

        public long? time_stamp { get; set; }
    }
}
