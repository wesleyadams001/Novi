﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtfsModule.Models
{
    public class DealRequest
    {

        /// <summary>
        /// Most deal queries have more than 150 results (which is the maximum page size). To browse all deals found by a query (which is cached for 120 seconds) you iterate the page parameter and keep all other parameters identical. You start with page 0 and stop when the response contains less than 150 results.
        /// </summary>
        public int? page;

        /// <summary>
        /// The domainId of the products Amazon locale {@link AmazonLocale}
        /// </summary>
        public int? domainId;

        /// <summary>
        /// Determines the type of the deal. Even though it is an integer array, it can contain only one entry. Multiple types per query are not yet supported.
        /// Uses {@link Product.CsvType}
        /// coding.Only those applicable with
        /// {
        /// @link Product.CsvType#isDealRelevant} set to true.
        /// </summary>
        public int[] priceTypes;

        /// <summary>
        /// Our deals are devided in different sets, determined by the time interval in which the product changed. The shorter the interval, the more recent the change; which is good for big price drops but bad for slow incremental drops that accumulate over a longer period.
        /// For most deals the shorter intervals can be considered as subsets of the longer intervals.To find more deals use the longer intervals.<br>
        /// <p>Possible values:
        /// <ul>
        /// <li>0 - day: the last 24 hours</li>
        /// <li>1 - week: the last 24 * 7 hours</li>
        /// <li>2 - month: the last 24 * 31 hours</li>
        /// <li>3 - 90 days: the last 24 * 90 hours</li>
        /// </ul></p>
        /// </summary>
        public int? dateRange;

        /// <summary>
        /// Limit the range of the absolute difference between the current value and the one at the beginning of the chosen dateRange interval.<br>
        /// Example: [0,999] (= no minimum difference, maximum difference of $9.99).
        /// </summary>
        public int[] deltaRange;

        /// <summary>
        /// Used to exclude products that are listed in these categories. If it is a sub category the product must be directly listed in this category. It will not exclude products in child categories of the specified ones, unless it is a root category.
        /// Array with category node ids14.
        /// </summary>
        public long[] excludeCategories;

        /// <summary>
        /// Used to only include products that are listed in these categories. If it is a sub category the product must be directly listed in this category. It will not include products in child categories of the specified ones, unless it is a root category. Array with category node ids14.
        /// </summary>
        public long[] includeCategories;

        /// <summary>
        /// Same as deltaRange, but given in percent instead of absolute values. Minimum percent is 10, for Sales Rank it is 80.<br>
        /// Example: [30,80] (= between 30% and 80%).
        /// </summary>
        public int[] deltaPercentRange;

        /// <summary>
        /// Limit the range of the current value of the price type.<br>
        /// Example: [105,50000] (= minimum price $1.05, maximum price $500, or a rank between 105 and 50000).
        /// </summary>
        public int[] currentRange;

        /// <summary>
        /// Only include products for which the specified price type is at its lowest value (since we started tracking it). If true, "isRisers" must be false.
        /// </summary>
        public bool? isLowest;

        /// <summary>
        /// Select deals by a keywords based product title search. The search is case-insensitive and supports multiple keywords which, if specified and separated by a space, must all match.<br>
        /// Examples:
        /// "samsung galaxy" matches all products which have the character sequences "samsung" AND "galaxy" within their title
        /// </summary>
        public String titleSearch;

        /// <summary>
        /// Only include products if the selected price type is the lowest of all New offers (applicable to Amazon and Marketplace New). Not applicable if "isRisers" is true.
        /// </summary>
        public bool? isLowestOffer;

        /// <summary>
        /// Only include products which were out of stock within the last 24 hours and can now be ordered.
        /// </summary>
        public bool? isBackInStock;

        /// <summary>
        /// Only include products which were available to order within the last 24 hours and now out of stock.
        /// </summary>
        public bool? isOutOfStock;

        /// <summary>
        /// Switch to enable the range options.
        /// </summary>
        public bool? isRangeEnabled;

        /// <summary>
        /// Excludes all products that are listed as adult items.
        /// </summary>
        public bool? filterErotic;

        /// <summary>
        /// Determines the sort order of the retrieved deals. To invert the sort order use negative values.
        /// <p>Possible sort by values:
        /// <ul>
        /// <li>1 - deal age.Newest deals first, not invertible.</li>
        /// <li>2 - absolute delta. (the difference between the current value and the one at the beginning of the chosen dateRange interval). Sort order is highest delta to lowest.</li>
        /// <li>3 - sales rank. Sort order is lowest rank o highest.</li>
        /// <li>4 - percentage delta (the percentage difference between the current value and the one at the beginning of the chosen dateRange interval). Sort order is highest percent to lowest.</li>
        /// </ul></p>
        /// </summary>
        public int? sortType;

        /// <summary>
        /// Limit the Sales Rank range of the product. Identical to currentRange if price type is set to Sales Rank. If you want to keep the upper bound open, you can specify -1 (which will translate to the maximum signed integer value).<br>
        /// <p>Important note: Once this range option is used all products with no Sales Rank will be excluded. Set it to null to not use it.</p>
        /// Examples:<br>
        /// [0,5000] (= only products which have a sales rank between 0 and 5000)<br>
        /// [5000,-1] (= higher than 5000)
        /// </summary>
        public int[] salesRankRange;

        /// <summary>
        /// Switch to enable the filter options.
        /// </summary>
        public bool? isFilterEnabled;

        /// <summary>
        /// Limit the range of the absolute difference between the current value and previous one.<br>
        /// Example: [100,500] (= last change between one $1 and $5)
        /// </summary>
        public int[] deltaLastRange;

        /// <summary>
        /// If true excludes all products with no reviews. If false the filter is inactive.
        /// </summary>
        public bool? hasReviews;

        /// <summary>
        /// Category search
        /// </summary>
        public String categorySearch;

        /// <summary>
        /// Override of to string to return json version of object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
