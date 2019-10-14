namespace KeepaModule.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.products")]
    public partial class product
    {
        public product(ulong product_id, string product_type, string asin, long? domain_id, string title, long? tracking_since, long? listed_sinceint, long? last_update, long? last_rating_update, long? last_price_change, long? last_ebay_update, string images_csv, decimal? root_category, string parent_asin, string variation_csv, string mpn, bool? has_reviews, string type, string manufacturer, string brand, string label, string department, string publisher, string product_group, string part_number, string author, string binding, long? number_of_items, long? number_of_pages, long? publication_date, long? release_date, string studio, string genre, string model, string color, string size, string edition, string platform, string format, string description, long? hazardous_material_type, long? package_height, long? package_length, long? package_width, long? package_weight, long? package_quantity, long? availability_amazon, bool? is_adult_product, bool? new_price_is_map, bool? is_eligible_for_trade_in, bool? is_eligible_for_super_saver_shipping, bool? is_redirect_asin, bool? is_sns, bool? offers_successful, long? time_stamp)
        {
            this.product_id = product_id;
            this.product_type = product_type ?? throw new ArgumentNullException(nameof(product_type));
            this.asin = asin ?? throw new ArgumentNullException(nameof(asin));
            this.domain_id = domain_id ?? throw new ArgumentNullException(nameof(domain_id));
            this.title = title ?? throw new ArgumentNullException(nameof(title));
            this.tracking_since = tracking_since ?? throw new ArgumentNullException(nameof(tracking_since));
            this.listed_sinceint = listed_sinceint ?? throw new ArgumentNullException(nameof(listed_sinceint));
            this.last_update = last_update ?? throw new ArgumentNullException(nameof(last_update));
            this.last_rating_update = last_rating_update ?? throw new ArgumentNullException(nameof(last_rating_update));
            this.last_price_change = last_price_change ?? throw new ArgumentNullException(nameof(last_price_change));
            this.last_ebay_update = last_ebay_update ?? throw new ArgumentNullException(nameof(last_ebay_update));
            this.images_csv = images_csv ?? throw new ArgumentNullException(nameof(images_csv));
            this.root_category = root_category ?? throw new ArgumentNullException(nameof(root_category));
            this.parent_asin = parent_asin ?? throw new ArgumentNullException(nameof(parent_asin));
            this.variation_csv = variation_csv ?? throw new ArgumentNullException(nameof(variation_csv));
            this.mpn = mpn ?? throw new ArgumentNullException(nameof(mpn));
            this.has_reviews = has_reviews ?? throw new ArgumentNullException(nameof(has_reviews));
            this.type = type ?? throw new ArgumentNullException(nameof(type));
            this.manufacturer = manufacturer ?? throw new ArgumentNullException(nameof(manufacturer));
            this.brand = brand ?? throw new ArgumentNullException(nameof(brand));
            this.label = label ?? throw new ArgumentNullException(nameof(label));
            this.department = department ?? throw new ArgumentNullException(nameof(department));
            this.publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
            this.product_group = product_group ?? throw new ArgumentNullException(nameof(product_group));
            this.part_number = part_number ?? throw new ArgumentNullException(nameof(part_number));
            this.author = author ?? throw new ArgumentNullException(nameof(author));
            this.binding = binding ?? throw new ArgumentNullException(nameof(binding));
            this.number_of_items = number_of_items ?? throw new ArgumentNullException(nameof(number_of_items));
            this.number_of_pages = number_of_pages ?? throw new ArgumentNullException(nameof(number_of_pages));
            this.publication_date = publication_date ?? throw new ArgumentNullException(nameof(publication_date));
            this.release_date = release_date ?? throw new ArgumentNullException(nameof(release_date));
            this.studio = studio ?? throw new ArgumentNullException(nameof(studio));
            this.genre = genre ?? throw new ArgumentNullException(nameof(genre));
            this.model = model ?? throw new ArgumentNullException(nameof(model));
            this.color = color ?? throw new ArgumentNullException(nameof(color));
            this.size = size ?? throw new ArgumentNullException(nameof(size));
            this.edition = edition ?? throw new ArgumentNullException(nameof(edition));
            this.platform = platform ?? throw new ArgumentNullException(nameof(platform));
            this.format = format ?? throw new ArgumentNullException(nameof(format));
            this.description = description ?? throw new ArgumentNullException(nameof(description));
            this.hazardous_material_type = hazardous_material_type ?? throw new ArgumentNullException(nameof(hazardous_material_type));
            this.package_height = package_height ?? throw new ArgumentNullException(nameof(package_height));
            this.package_length = package_length ?? throw new ArgumentNullException(nameof(package_length));
            this.package_width = package_width ?? throw new ArgumentNullException(nameof(package_width));
            this.package_weight = package_weight ?? throw new ArgumentNullException(nameof(package_weight));
            this.package_quantity = package_quantity ?? throw new ArgumentNullException(nameof(package_quantity));
            this.availability_amazon = availability_amazon ?? throw new ArgumentNullException(nameof(availability_amazon));
            this.is_adult_product = is_adult_product ?? throw new ArgumentNullException(nameof(is_adult_product));
            this.new_price_is_map = new_price_is_map ?? throw new ArgumentNullException(nameof(new_price_is_map));
            this.is_eligible_for_trade_in = is_eligible_for_trade_in ?? throw new ArgumentNullException(nameof(is_eligible_for_trade_in));
            this.is_eligible_for_super_saver_shipping = is_eligible_for_super_saver_shipping ?? throw new ArgumentNullException(nameof(is_eligible_for_super_saver_shipping));
            this.is_redirect_asin = is_redirect_asin ?? throw new ArgumentNullException(nameof(is_redirect_asin));
            this.is_sns = is_sns ?? throw new ArgumentNullException(nameof(is_sns));
            this.offers_successful = offers_successful ?? throw new ArgumentNullException(nameof(offers_successful));
            this.time_stamp = time_stamp ?? throw new ArgumentNullException(nameof(time_stamp));
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int p_id { get; set; }

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
