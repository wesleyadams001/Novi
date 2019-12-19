namespace KeepaModule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Novi.best_sellers",
                c => new
                    {
                        Primary_key = c.Int(nullable: false, identity: true),
                        domain_id = c.Int(),
                        last_update = c.Int(),
                        category_id = c.Long(),
                        asin_list = c.String(),
                        time_stamp = c.Long(),
                    })
                .PrimaryKey(t => t.Primary_key);
            
            CreateTable(
                "Novi.categories",
                c => new
                    {
                        Primary_key = c.Int(nullable: false, identity: true),
                        amzn_category_id = c.Long(),
                        time_stamp = c.Long(),
                    })
                .PrimaryKey(t => t.Primary_key);
            
            CreateTable(
                "Novi.category_lookup",
                c => new
                    {
                        Primary_key = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Primary_key);
            
            CreateTable(
                "Novi.category_tree",
                c => new
                    {
                        Primary_key = c.Int(nullable: false, identity: true),
                        amzn_cat_id = c.Decimal(precision: 18, scale: 2),
                        amzn_cat_name = c.String(),
                    })
                .PrimaryKey(t => t.Primary_key);
            
            CreateTable(
                "Novi.eans",
                c => new
                    {
                        Primary_key = c.Int(nullable: false, identity: true),
                        ean_number = c.String(),
                        time_stamp = c.Long(),
                    })
                .PrimaryKey(t => t.Primary_key);
            
            CreateTable(
                "Novi.fba_fees",
                c => new
                    {
                        Primary_key = c.Int(nullable: false, identity: true),
                        pick_pack_fee = c.Int(),
                        pick_pack_fee_tax = c.Int(),
                        storage_fee = c.Int(),
                        storage_fee_tax = c.Int(),
                        time_stamp = c.Long(),
                    })
                .PrimaryKey(t => t.Primary_key);
            
            CreateTable(
                "Novi.features",
                c => new
                    {
                        Primary_key = c.Int(nullable: false, identity: true),
                        features = c.String(),
                        time_stamp = c.Long(),
                    })
                .PrimaryKey(t => t.Primary_key);
            
            CreateTable(
                "Novi.freq_bought_together",
                c => new
                    {
                        Primary_key = c.Int(nullable: false, identity: true),
                        associated_asin = c.String(),
                        time_stamp = c.Long(),
                    })
                .PrimaryKey(t => t.Primary_key);
            
            CreateTable(
                "Novi.languages",
                c => new
                    {
                        Primary_key = c.Int(nullable: false, identity: true),
                        language_name = c.String(),
                        language_type = c.String(),
                        audio_format = c.String(),
                        time_stamp = c.Long(),
                    })
                .PrimaryKey(t => t.Primary_key);
            
            CreateTable(
                "Novi.most_rated_sellers",
                c => new
                    {
                        Primary_key = c.Int(nullable: false, identity: true),
                        seller = c.String(),
                        time_stamp = c.Long(),
                    })
                .PrimaryKey(t => t.Primary_key);
            
            CreateTable(
                "Novi.price_history",
                c => new
                    {
                        Primary_key = c.Int(nullable: false, identity: true),
                        ob_history_type = c.Int(),
                        ob_date = c.Decimal(precision: 18, scale: 2),
                        ob_price = c.Decimal(precision: 18, scale: 2),
                        ob_shipping = c.Decimal(precision: 18, scale: 2),
                        time_stamp = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Primary_key);
            
            CreateTable(
                "Novi.products",
                c => new
                    {
                        Primary_key = c.Int(nullable: false, identity: true),
                        product_type = c.String(),
                        asin = c.String(),
                        domain_id = c.Long(),
                        title = c.String(),
                        tracking_since = c.Long(),
                        listed_sinceint = c.Long(),
                        last_update = c.Long(),
                        last_rating_update = c.Long(),
                        last_price_change = c.Long(),
                        last_ebay_update = c.Long(),
                        images_csv = c.String(),
                        root_category = c.Decimal(precision: 18, scale: 2),
                        parent_asin = c.String(),
                        variation_csv = c.String(),
                        mpn = c.String(),
                        has_reviews = c.Boolean(),
                        type = c.String(),
                        manufacturer = c.String(),
                        brand = c.String(),
                        label = c.String(),
                        department = c.String(),
                        publisher = c.String(),
                        product_group = c.String(),
                        part_number = c.String(),
                        author = c.String(),
                        binding = c.String(),
                        number_of_items = c.Long(),
                        number_of_pages = c.Long(),
                        publication_date = c.Long(),
                        release_date = c.Long(),
                        studio = c.String(),
                        genre = c.String(),
                        model = c.String(),
                        color = c.String(),
                        size = c.String(),
                        edition = c.String(),
                        platform = c.String(),
                        format = c.String(),
                        description = c.String(),
                        hazardous_material_type = c.Long(),
                        package_height = c.Long(),
                        package_length = c.Long(),
                        package_width = c.Long(),
                        package_weight = c.Long(),
                        package_quantity = c.Long(),
                        availability_amazon = c.Long(),
                        is_adult_product = c.Boolean(),
                        new_price_is_map = c.Boolean(),
                        is_eligible_for_trade_in = c.Boolean(),
                        is_eligible_for_super_saver_shipping = c.Boolean(),
                        is_redirect_asin = c.Boolean(),
                        is_sns = c.Boolean(),
                        offers_successful = c.Boolean(),
                        time_stamp = c.Long(),
                    })
                .PrimaryKey(t => t.Primary_key);
            
            CreateTable(
                "Novi.sellers",
                c => new
                    {
                        Primary_key = c.Int(nullable: false, identity: true),
                        domain_id = c.Int(),
                        tracking_since = c.Int(),
                        last_update = c.Int(),
                        amzn_seller_id = c.String(),
                        seller_name = c.String(),
                        is_scammer = c.Boolean(),
                        has_fba = c.Boolean(),
                        total_store_front_rec_time = c.Int(),
                        total_store_front_asins = c.Int(),
                        rating = c.Int(),
                        rating_time = c.Int(),
                        rating_count = c.Int(),
                        rating_count_time = c.Long(),
                        time_stamp = c.Long(),
                    })
                .PrimaryKey(t => t.Primary_key);
            
            CreateTable(
                "Novi.sellers_listed_items",
                c => new
                    {
                        Primary_key = c.Int(nullable: false, identity: true),
                        asin = c.String(),
                        asin_last_verified = c.Long(),
                        time_stamp = c.Long(),
                    })
                .PrimaryKey(t => t.Primary_key);
            
            CreateTable(
                "Novi.statistics",
                c => new
                    {
                        Primary_key = c.Int(nullable: false, identity: true),
                        stat_type = c.Int(),
                        current = c.Long(),
                        avg = c.Long(),
                        avg_30 = c.Long(),
                        avg_90 = c.Long(),
                        avg_180 = c.Long(),
                        at_interval_start = c.Long(),
                        min_price_type = c.Long(),
                        min_price_rec_time = c.Long(),
                        min_price_value = c.Long(),
                        max_price_type = c.Long(),
                        max_price_rec_time = c.Long(),
                        max_price_value = c.Long(),
                        interval_min_price_type = c.Long(),
                        interval_min_price_rec_time = c.Long(),
                        interval_min_price_value = c.Long(),
                        interval_max_price_type = c.Long(),
                        interval_max_price_rec_time = c.Long(),
                        interval_max_price_value = c.Long(),
                        out_of_stock_percentage_ininterval = c.Long(),
                        out_of_stock_percentage_30 = c.Long(),
                        out_of_stock_percentage_90 = c.Long(),
                        last_offers_update = c.Long(),
                        total_offer_count = c.Long(),
                        lightning_deal_info = c.Long(),
                        retrieved_offer_count = c.Long(),
                        buy_box_price = c.Long(),
                        buy_box_shipping = c.Long(),
                        buy_box_is_unqualified = c.Boolean(),
                        buy_box_is_shippable = c.Boolean(),
                        buy_box_is_preorder = c.Boolean(),
                        buy_box_is_fba = c.Boolean(),
                        buy_box_is_amazon = c.Boolean(),
                        buy_box_is_map = c.Boolean(),
                        buy_box_is_used = c.Boolean(),
                        seller_ids_lowest_fba = c.String(),
                        seller_ids_lowest_fbm = c.String(),
                        offer_count_fba = c.Long(),
                        offer_count_fbm = c.Long(),
                        time_stamp = c.Long(),
                    })
                .PrimaryKey(t => t.Primary_key);
            
            CreateTable(
                "Novi.upcs",
                c => new
                    {
                        Primary_key = c.Int(nullable: false, identity: true),
                        upc_number = c.String(),
                        time_stamp = c.Long(),
                    })
                .PrimaryKey(t => t.Primary_key);
            
            CreateTable(
                "Novi.variations",
                c => new
                    {
                        Primary_key = c.Int(nullable: false, identity: true),
                        variation_asin = c.String(),
                        variation_dimension = c.String(),
                        variation_value = c.String(),
                        time_stamp = c.Long(),
                    })
                .PrimaryKey(t => t.Primary_key);
            
        }
        
        public override void Down()
        {
            DropTable("Novi.variations");
            DropTable("Novi.upcs");
            DropTable("Novi.statistics");
            DropTable("Novi.sellers_listed_items");
            DropTable("Novi.sellers");
            DropTable("Novi.products");
            DropTable("Novi.price_history");
            DropTable("Novi.most_rated_sellers");
            DropTable("Novi.languages");
            DropTable("Novi.freq_bought_together");
            DropTable("Novi.features");
            DropTable("Novi.fba_fees");
            DropTable("Novi.eans");
            DropTable("Novi.category_tree");
            DropTable("Novi.category_lookup");
            DropTable("Novi.categories");
            DropTable("Novi.best_sellers");
        }
    }
}
