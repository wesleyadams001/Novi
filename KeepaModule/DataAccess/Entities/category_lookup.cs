using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Interfaces;

namespace KeepaModule.DataAccess.Entities
{
    public partial class category_lookup : IEntity
    {
        /// <summary>
        /// The default constructor for a category look up record
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="catId"></param>
        /// <param name="name"></param>
        /// <param name="children"></param>
        /// <param name="parent"></param>
        /// <param name="highestRank"></param>
        /// <param name="productCount"></param>
        public category_lookup(byte domainId, long catId, string name, long[] children, long parent, int highestRank, int productCount, long timestamp)
        {
            this.domainId = domainId;
            this.catId = catId;
            this.name = name;
            this.children = children;
            this.parent = parent;
            this.highestRank = highestRank;
            this.productCount = productCount;
            this.time_stamp = timestamp;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Primary_key { get; set; }

        /// <summary>
        ///  Integer value for the Amazon locale this category belongs to.
        ///  {@link AmazonLocale}
        /// </summary>
        public byte domainId { get; set; }

        /// <summary>
        ///  The category node id used by Amazon. Represents the identifier of the category. Also part of the Product object's categories and rootCategory fields. Always a positive Long value.
        /// </summary>
        public long catId { get; set; }

        /// <summary>
        ///  The name of the category.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        ///  List of all sub categories. null or [] (empty array) if the category has no sub categories.
        /// </summary>
        public long[] children { get; set; }

        /// <summary>
        ///  The parent category's Id. Always a positive Long value. If it is 0 the category is a root category and has no parent category.
        /// </summary>
        public long parent { get; set; }

        /// <summary>
        ///  The highest (root category) sales rank we have observed of a product that is listed in this category. Note: Estimate, as the value is from the Keepa product database and not retrieved from Amazon.
        /// </summary>
        public int highestRank { get; set; }

        /// <summary>
        ///  Number of products that are listed in this category. Note: Estimate, as the value is from the Keepa product database and not retrieved from Amazon.
        /// </summary>
        public int productCount { get; set; }

        /// <summary>
        /// Timestamp for when created
        /// </summary>
        public long time_stamp { get; set; }
    }
}
