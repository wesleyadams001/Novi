namespace KeepaModule.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using XModule.Interfaces;

    //[Table("public.category_tree")]
    public partial class category_tree : IEntity
    {
        public category_tree(ulong? product_id, decimal? amzn_cat_id, string amzn_cat_name)
        {
            this.product_id = product_id ?? throw new ArgumentNullException(nameof(product_id));
            this.amzn_cat_id = amzn_cat_id ?? throw new ArgumentNullException(nameof(amzn_cat_id));
            this.amzn_cat_name = amzn_cat_name ?? throw new ArgumentNullException(nameof(amzn_cat_name));
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Primary_key { get; set; }

        public ulong? product_id { get; set; }

        public decimal? amzn_cat_id { get; set; }

        public string amzn_cat_name { get; set; }
    }
}
