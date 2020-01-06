using KeepaModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Tools;
using XModule.Interfaces;
using KeepaModule.DataAccess.Records;
using KeepaModule.Tools;
using System.Threading.Tasks.Dataflow;
using static XModule.Constants.Enums;

namespace KeepaModule.Factories
{
    /// <summary>
    /// Factory class that processes Response objects and produces
    /// the associated record objects
    /// </summary>
    public class KeepaRecordFactory
    {
        private ILoggerFactory _loggerFactory;
        private ILogger _logger;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="loggerFac"></param>
        public KeepaRecordFactory(ILoggerFactory loggerFac)
        {
            this._loggerFactory = loggerFac;
            this._logger = loggerFac.Create<KeepaRecordFactory>();
        }

        /// <summary>
        /// Service constructor
        /// </summary>
        public KeepaRecordFactory()
        {

        }

        /// <summary>
        /// Method to markup and create database records from response objects
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public List<IRecord> Create(Response response)
        {
            //list of records
            List<IRecord> recList = new List<IRecord>();
            BufferBlock<IRecord> reListBlock = new BufferBlock<IRecord>();
            //case to appropriate response type
            Response r = response;

            //Default type
            KeepaRecordType type = KeepaRecordType.Default;

            //Determine Appropriate record type
            var responseFlags = InspectResponse(r, type);

            //Generate appropriate records from response
            if (responseFlags.HasFlag(KeepaRecordType.BestSellerRecord))
            {
                //passing recList by ref to update the recList we already have with void methods
                CreateBestSeller(r, ref recList);
            }
            if (responseFlags.HasFlag(KeepaRecordType.DealRecord))
            {
                CreateDeal(r, ref recList);
            }
            if (responseFlags.HasFlag(KeepaRecordType.MarketplaceOfferRecord))
            {
                CreateMarketplaceOffer(r, ref recList);
            }
            if (responseFlags.HasFlag(KeepaRecordType.NotificationRecord))
            {
                CreateNotification(r, ref recList);
            }
            if (responseFlags.HasFlag(KeepaRecordType.ProductRecord))
            {
                //create base product record
                var guidlist = CreateProduct(r, ref recList);

                //inspect product property of response here
                KeepaRecordType productProperties = KeepaRecordType.Default;
                productProperties = InspectResponse(r.products[0], productProperties);

                //Create associated records from objects 
                if (productProperties.HasFlag(KeepaRecordType.PriceHistoryRecord))
                {
                    CreatePriceHistory(r.products, ref recList, ref guidlist);
                }
                if (productProperties.HasFlag(KeepaRecordType.StatisitcsRecord))
                {
                    CreateStatistics(r.products, ref recList, ref guidlist);
                }
                if (productProperties.HasFlag(KeepaRecordType.CategoryRecord))
                {
                    CreateCategory(r.products, ref recList, ref guidlist);
                }
                if (productProperties.HasFlag(KeepaRecordType.EanRecord))
                {
                    CreateEan(r.products, ref recList, ref guidlist);
                }
                if (productProperties.HasFlag(KeepaRecordType.EbayListingRecord))
                {
                    CreateEbayListing(r.products, ref recList, ref guidlist);
                }
                if (productProperties.HasFlag(KeepaRecordType.FeaturesRecord))
                {
                    CreateFeatures(r.products, ref recList, ref guidlist);
                }
                if (productProperties.HasFlag(KeepaRecordType.FrequentlyBoughtTogetherRecord))
                {
                    CreateFreqBoughtTgthr(r.products, ref recList, ref guidlist);
                }
                if (productProperties.HasFlag(KeepaRecordType.LanguagesRecord))
                {
                    CreateLanguages(r.products, ref recList, ref guidlist);
                }
                if (productProperties.HasFlag(KeepaRecordType.LiveOffersOrderRecord))
                {
                    CreateLiveOfferOrder(r.products, ref recList, ref guidlist);
                }
                if (productProperties.HasFlag(KeepaRecordType.OffersRecord))
                {
                    CreateOffers(r.products, ref recList, ref guidlist);
                }
                if (productProperties.HasFlag(KeepaRecordType.PromotionsRecord))
                {
                    CreatePromotion(r.products, ref recList, ref guidlist);
                }
                if (productProperties.HasFlag(KeepaRecordType.UpcRecord))
                {
                    CreateUpc(r.products, ref recList, ref guidlist);
                }
                if (productProperties.HasFlag(KeepaRecordType.VariationsRecord))
                {
                    CreateVariations(r.products, ref recList, ref guidlist);
                }
            }
            if (responseFlags.HasFlag(KeepaRecordType.SellerRecord))
            {
                CreateSeller(r, ref recList);
            }
            if (responseFlags.HasFlag(KeepaRecordType.TopSellerRecord))
            {
                CreateTopSeller(r, ref recList);
            }
            if (responseFlags.HasFlag(KeepaRecordType.TrackingCreationRecord))
            {
                CreateTrackingCreation(r, ref recList);
            }
            if (responseFlags.HasFlag(KeepaRecordType.TrackingRecord))
            {
                CreateTracking(r, ref recList);
            }
            if (responseFlags.HasFlag(KeepaRecordType.CategoryLookupRecord))
            {
                CreateCategoryLookupRecord(r, ref recList);
            }
            if (responseFlags.HasFlag(KeepaRecordType.CategoryTreeRecord))
            {
                CreateCategoryTreeRecord(r, ref recList);
            }

            return recList;
        }



        /// <summary>
        /// Inspect a response and apply appropriate bit flags
        /// </summary>
        /// <param name="r"></param>
        private KeepaRecordType InspectResponse(Response r, KeepaRecordType type)
        {
            if (r.bestSellersList != null)
            {
                //add best seller flag
                type |= KeepaRecordType.BestSellerRecord;
            }
            if (r.deals != null)
            {
                //add deal flag
                type |= KeepaRecordType.DealRecord;
            }
            if (r.categories != null)
            {
                //add category flag
                type |= KeepaRecordType.CategoryLookupRecord;
            }
            if (r.notifications != null)
            {
                //add notification flag
                type |= KeepaRecordType.NotificationRecord;
            }
            if (r.products != null)
            {
                // add product flag
                type |= KeepaRecordType.ProductRecord;

            }
            if (r.trackings != null)
            {
                //add tracking flag
                type |= KeepaRecordType.TrackingRecord;
            }
            if (r.sellers != null)
            {
                //add seller flag
                type |= KeepaRecordType.SellerRecord;
            }
            if (r.sellerIdList != null)
            {
                //add sellers id list flag
                type |= KeepaRecordType.TopSellerRecord;
            }

            return type;
        }

        /// <summary>
        /// Inspect a responses product property and apply appropriate bit flags
        /// </summary>
        /// <param name="p"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private KeepaRecordType InspectResponse(Product p, KeepaRecordType type)
        {
            if (p.categories != null)
            {
                //categories flag
                type |= KeepaRecordType.CategoryRecord;
            }
            if (p.eanList != null)
            {
                //eanlist flag
                type |= KeepaRecordType.EanRecord;
            }
            if (p.ebayListingIds != null)
            {
                //ebaylists flag
                type |= KeepaRecordType.EbayListingRecord;
            }
            if (p.features != null)
            {
                //features flag
                type |= KeepaRecordType.FeaturesRecord;
            }
            if (p.frequentlyBoughtTogether != null)
            {
                //frequently bought together flag
                type |= KeepaRecordType.FrequentlyBoughtTogetherRecord;
            }
            if (p.languages != null)
            {
                //languages flag
                type |= KeepaRecordType.LanguagesRecord;
            }
            if (p.liveOffersOrder != null)
            {
                //live offers order flag
                type |= KeepaRecordType.LiveOffersOrderRecord;
            }
            if (p.offers != null)
            {
                //offers flag
                type |= KeepaRecordType.OffersRecord;
            }
            if (p.promotions != null)
            {
                //promotions flag
                type |= KeepaRecordType.PromotionsRecord;
            }
            if (p.stats != null)
            {
                //stats flag
                type |= KeepaRecordType.StatisitcsRecord;
            }
            if (p.upcList != null)
            {
                //upc list flag
                type |= KeepaRecordType.UpcRecord;
            }
            if (p.variations != null)
            {
                //Variations flag
                type |= KeepaRecordType.VariationsRecord;
            }
            if (p.csv != null)
            {
                //price history flag
                type |= KeepaRecordType.PriceHistoryRecord;
            }
            if (p.fbaFees != null)
            {
                //fba fees flag
                type |= KeepaRecordType.FbaFeesRecord;
            }

            return type;
        }

        /// <summary>
        /// Create EAN records
        /// </summary>
        /// <param name="products"></param>
        /// <param name="recList"></param>
        private void CreateEan(Product[] products, ref List<IRecord> recList, ref List<ulong> indexList)
        {
            //for each product
            for (int x = 0; x < products.Length; x++)
            {
                //if the list is null skip iteration
                if (products[x].eanList == null)
                {
                    continue;
                }

                //for each ean in said product
                for (int y = 0; y < products[x].eanList.Length; y++)
                {
                    //create ean records
                    EanRecord eanRec = new EanRecord(indexList[x], products[x].eanList[y]);

                    //add ean record
                    recList.Add(eanRec);

                }

            }
        }

        /// <summary>
        /// Create ebay listings records
        /// </summary>
        /// <param name="products"></param>
        /// <param name="recList"></param>
        private void CreateEbayListing(Product[] products, ref List<IRecord> recList, ref List<ulong> indexList)
        {
            for (int x = 0; x < products.Length; x++)
            {
                //if the list is null skip iteration
                if (products[x].ebayListingIds == null)
                {
                    continue;
                }
                for (int y = 0; y < products[x].ebayListingIds.Length; y++)
                {
                    //create an ebay listing record

                }

            }
        }

        /// <summary>
        /// Create features records
        /// </summary>
        /// <param name="products"></param>
        /// <param name="recList"></param>
        private  void CreateFeatures(Product[] products, ref List<IRecord> recList, ref List<ulong> indexList)
        {
            for (int x = 0; x < products.Length; x++)
            {
                //if the list is null skip iteration
                if (products[x].features == null)
                {
                    continue;
                }
                for (int y = 0; y < products[x].features.Length; y++)
                {
                    FeaturesRecord featuresRec = new FeaturesRecord(indexList[x], products[x].features[y]);

                    //add features record
                    recList.Add(featuresRec);
                }

            }
        }

        /// <summary>
        /// Create Fba Fees Records
        /// </summary>
        /// <param name="products"></param>
        /// <param name="recList"></param>
        /// <param name="indexList"></param>
        private  void CreateFbaFees(Product[] products, ref List<IRecord> recList, ref List<ulong> indexList)
        {
            for (int x = 0; x < products.Length; x++)
            {
                //if the object is null there is not a fee object to interpret
                if (products[x].fbaFees == null)
                {
                    //so exit
                    return;
                }

                //otherwise create record
                FbaFeesRecord fbafeesRec = new FbaFeesRecord(indexList.ElementAt(x), products[x].fbaFees.pickAndPackFee, products[x].fbaFees.pickAndPackFeeTax, products[x].fbaFees.storageFee, products[x].fbaFees.storageFeeTax);

                //add to list of records
                recList.Add(fbafeesRec);
            }
        }

        /// <summary>
        /// Create FreqBoughtTogether records
        /// </summary>
        /// <param name="products"></param>
        /// <param name="recList"></param>
        private  void CreateFreqBoughtTgthr(Product[] products, ref List<IRecord> recList, ref List<ulong> indexList)
        {
            //for each product...
            for (int x = 0; x < products.Length; x++)
            {
                //if the list is null skip iteration
                if (products[x].frequentlyBoughtTogether == null)
                {
                    continue;
                }
                //for each frequently bought together object...
                for (int y = 0; y < products[x].frequentlyBoughtTogether.Length; y++)
                {
                    //Create record
                    FreqBoughtTogetherRecord FreqRec = new FreqBoughtTogetherRecord(indexList[x], products[x].frequentlyBoughtTogether[y]);

                    //add record to list
                    recList.Add(FreqRec);
                }
            }
        }

        /// <summary>
        /// Create languages records
        /// </summary>
        /// <param name="products"></param>
        /// <param name="recList"></param>
        private  void CreateLanguages(Product[] products, ref List<IRecord> recList, ref List<ulong> indexList)
        {
            //for each product...
            for (int x = 0; x < products.Length; x++)
            {
                //if the list is null skip iteration
                if (products[x].languages == null)
                {
                    continue;
                }
                //for each language...
                for (int y = 0; y < products[x].languages.Length; y++)
                {
                    //if the list is null skip iteration
                    if (products[x].languages[y] == null)
                    {
                        continue;
                    }

                    // set var to track values to extract from array
                    int a, b, c;
                    a = 0;
                    b = 1;
                    c = 2;

                    //loop through items in each language array
                    if (products[x].languages[y].Length > 2)
                    {
                        //New language record with an audio format
                        LanguagesRecord languagesRec = new LanguagesRecord(indexList[x], products[x].languages[y].ElementAt(a), products[x].languages[y].ElementAt(b), products[x].languages[y].ElementAt(c));

                        //add to list
                        recList.Add(languagesRec);

                    }
                    else
                    {
                        if (products[x].languages[y].Length == 1)
                        {
                            //New language record without an audio format
                            LanguagesRecord languagesRec = new LanguagesRecord(indexList[x], products[x].languages[y].ElementAt(a), null, null);

                            //add to list
                            recList.Add(languagesRec);
                        }
                        else
                        {
                            //New language record without an audio format
                            LanguagesRecord languagesRec = new LanguagesRecord(indexList[x], products[x].languages[y].ElementAt(a), products[x].languages[y].ElementAt(b), null);

                            //add to list
                            recList.Add(languagesRec);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Create live offer order records
        /// </summary>
        /// <param name="products"></param>
        /// <param name="recList"></param>
        private  void CreateLiveOfferOrder(Product[] products, ref List<IRecord> recList, ref List<ulong> indexList)
        {
            //for each product...
            for (int x = 0; x < products.Length; x++)
            {
                //if the list is null skip iteration
                if (products[x].liveOffersOrder == null)
                {
                    continue;
                }
                //for each liveoffersorder...
                for (int y = 0; y < products[x].liveOffersOrder.Length; y++)
                {
                    //new liveofferorder

                }
            }
        }

        /// <summary>
        /// Create offers records
        /// </summary>
        /// <param name="products"></param>
        /// <param name="recList"></param>
        private  void CreateOffers(Product[] products, ref List<IRecord> recList, ref List<ulong> indexList)
        {
            //for each product
            for (int x = 0; x < products.Length; x++)
            {
                //if the list is null skip iteration
                if (products[x].offers == null)
                {
                    continue;
                }
                //for each offer in a said product....
                for (int y = 0; y < products[x].offers.Length; y++)
                {
                    //new offer record

                }

            }
        }

        /// <summary>
        /// Create Promotion records
        /// </summary>
        /// <param name="products"></param>
        /// <param name="recList"></param>
        private  void CreatePromotion(Product[] products, ref List<IRecord> recList, ref List<ulong> indexList)
        {
            //for each product...
            for (int x = 0; x < products.Length; x++)
            {
                //if the list is null skip iteration
                if (products[x].promotions == null)
                {
                    continue;
                }
                //for each promotion...
                for (int y = 0; y < products[x].promotions.Length; y++)
                {
                    //Promotion Record
                    PromotionRecord promotionRec = new PromotionRecord(indexList[x], products[x].promotions[y].type.value, products[x].promotions[y].eligibilityRequirementDescription, products[x].promotions[y].benefitDescription, products[x].promotions[y].promotionId);

                    //add to list
                    recList.Add(promotionRec);
                }
            }
        }

        /// <summary>
        /// Create Upc records
        /// </summary>
        /// <param name="products"></param>
        /// <param name="recList"></param>
        private  void CreateUpc(Product[] products, ref List<IRecord> recList, ref List<ulong> indexList)
        {
            //for each product...
            for (int x = 0; x < products.Length; x++)
            {
                //if the list is null skip iteration
                if (products[x].upcList == null)
                {
                    continue;
                }
                //for each upc in product...
                for (int y = 0; y < products[x].upcList.Length; y++)
                {
                    UpcRecord upcRec = new UpcRecord(indexList[x], products[x].upcList[y]);

                    //add record
                    recList.Add(upcRec);
                }
            }
        }

        /// <summary>
        /// Create variation records
        /// </summary>
        /// <param name="products"></param>
        /// <param name="recList"></param>
        private  void CreateVariations(Product[] products, ref List<IRecord> recList, ref List<ulong> indexList)
        {
            //for each product...
            for (int x = 0; x < products.Length; x++)
            {
                //if the list is null skip iteration
                if (products[x].variations == null)
                {
                    continue;
                }
                //for each variation in said product...
                for (int y = 0; y < products[x].variations.Length; y++)
                {
                    //if the list is null skip iteration
                    if (products[x].variations[y].attributes == null)
                    {
                        continue;
                    }
                    //for each variation in said product...
                    for (int z = 0; z < products[x].variations[y].attributes.Length; z++)
                    {
                        //variation record
                        VariationRecord varRec = new VariationRecord(indexList[x], products[x].variations[y].asin, products[x].variations[y].attributes[z].dimension, products[x].variations[y].attributes[z].value);

                        //add variation record
                        recList.Add(varRec);
                    }
                }
            }
        }


        /// <summary>
        /// Create a Most Rated Seller record
        /// </summary>
        /// <param name="r"></param>
        /// <param name="recList"></param>
        private  void CreateTopSeller(Response r, ref List<IRecord> recList)
        {
            var TopSeller = r.sellerIdList;
            for (int x = 0; x < TopSeller.Length; x++)
            {
                //Create a new most rated sellers record
                MostRatedSellersRecord rec = new MostRatedSellersRecord(TopSeller[x]);

                //Add that record to the list of record items
                recList.Add(rec);
            }

        }

        /// <summary>
        /// Create a tracking record
        /// </summary>
        /// <param name="r"></param>
        private  void CreateTracking(Response r, ref List<IRecord> recList)
        {
            var x = r.trackings;

        }

        /// <summary>
        /// Create a tracking creation record
        /// </summary>
        /// <param name="r"></param>
        private  void CreateTrackingCreation(Response r, ref List<IRecord> recList)
        {

            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a statistics record
        /// The statistics record is almost entirely arrays so there was a choice to be made with regards to how this should be done
        /// I chose to use array type in postgres. If you are a purist about relational concepts it would behove you to spit this into multiple tables
        /// However I am laazy and this works for my purposes
        /// </summary>
        /// <param name="r"></param>
        private  void CreateStatistics(Product[] products, ref List<IRecord> recList, ref List<ulong> indexList)
        {
            //for each product
            for (int x = 0; x < products.Length; x++)
            {
                //set integers
                int a, b;
                a = 0;
                b = 1;

                //for each unit in the arrays
                for (int y = 0; y < products[x].stats.current.Length; y++)
                {
                    //set val to reduce length of identifier
                    var val = products[x].stats;

                    //get longest array length
                    int len = GetLongestArrayProperty(val);

                    if (len == 0)
                    {
                        //if zero there is no additional dimension
                        //no values in two; could be malformed object 
                        continue;
                    }
                    else
                    {
                        try { 
                            //two dimensional arrays are flattened
                            StatisticsRecord statsRec = new StatisticsRecord(indexList[x], y, val.current?[y], val.avg?[y], val.avg30?[y], val.avg90?[y],
                            val.avg180?[y], val.atIntervalStart?[y], y, val.min[y]?.ElementAtOrDefault(a), val.min[y]?.ElementAtOrDefault(b), y, val.max[y]?.ElementAtOrDefault(a), val.max[y]?.ElementAt(b),
                            y, val.minInInterval[y]?.ElementAtOrDefault(a), val.minInInterval[y]?.ElementAtOrDefault(b),
                            y, val.maxInInterval[y]?.ElementAt(a), val.maxInInterval[y]?.ElementAt(b), val.outOfStockPercentageInInterval?[y],
                            val.outOfStockPercentage30?[y], val.outOfStockPercentage90?[y], val.lastOffersUpdate, val.totalOfferCount, val.lightningDealInfo?[y],
                            val.retrievedOfferCount, val.buyBoxPrice, val.buyBoxShipping, val.buyBoxIsUnqualified, val.buyBoxIsShippable, val.buyBoxIsPreorder,
                            val.buyBoxIsFBA, val.buyBoxIsAmazon, val.buyBoxIsMAP, val.buyBoxIsUsed, val.isAddonItem, val.sellerIdsLowestFBA?[y],
                            val.sellerIdsLowestFBM?[y], val.offerCountFBA, val.offerCountFBM);

                            //add stats record
                            recList.Add(statsRec);
                        }
                        catch(Exception e)
                        {
                            this._logger.Error("Filed to create: " + nameof(StatisticsRecord) + " with message: " + e.Message);
                        }
                        

                    }
                }
            }
        }

        /// <summary>
        /// Retrieves the appropriate length to iterate through
        /// for the statistics object
        /// </summary>
        /// <param name="val"></param>
        private  int GetLongestArrayProperty(Stats val)
        {
            var length = 0;

            //check each property that is a jagged array 
            //Retrieve longest value
            if (val.min != null)
            {
                for (int x = 0; x < val.min.Length; x++)
                {
                    if (val.min[x] != null && val.min[x].Length > length)
                    {
                        length = val.min[x].Length;
                    }

                }
            }

            if (val.max != null)
            {
                for (int x = 0; x < val.max.Length; x++)
                {
                    if (val.max[x] != null && val.max[x].Length > length)
                    {
                        length = val.max[x].Length;
                    }
                }
            }

            if (val.minInInterval != null)
            {
                for (int x = 0; x < val.minInInterval.Length; x++)
                {
                    if (val.minInInterval[x] != null && val.minInInterval.Length > length)
                    {
                        length = val.minInInterval[x].Length;
                    }
                }
            }

            if (val.maxInInterval != null)
            {
                for (int x = 0; x < val.maxInInterval.Length; x++)
                {
                    if (val.maxInInterval[x] != null && val.maxInInterval.Length > length)
                    {
                        length = val.maxInInterval[x].Length;
                    }
                }
            }

            return length;
        }

        /// <summary>
        /// Create a seller record
        /// </summary>
        /// <param name="r"></param>
        private  void CreateSeller(Response r, ref List<IRecord> recList)
        {
            //for each entry in dictionary
            foreach (KeyValuePair<string, Seller> entry in r.sellers)
            {
                //set the value that we care about
                var val = entry.Value.csv;

                IncrementalNumberGenerator generator = new IncrementalNumberGenerator();
                var Id = generator.Next(); //Common.Tools.SequentialGuid.NewGuid();

                //if array is null skip
                if (val == null)
                {
                    continue;
                }

                //if even split
                if (val.Length % 2 == 0)
                {
                    //create a usable tuple from the csv
                    var tuple = ExtractRatings(val);

                    //Only gets the most recent ratings and their associated timestamps this is faster and makes more sense for multiple request over time
                    //create seller record
                    SellerRecord sellerRec = new SellerRecord(Id, entry.Value.domainId, entry.Value.trackedSince, entry.Value.lastUpdate, entry.Value.sellerId, entry.Value.sellerName, entry.Value.isScammer, entry.Value.hasFBA, entry.Value.totalStorefrontAsins[0], entry.Value.totalStorefrontAsins[1], tuple.value, tuple.time, tuple.value2, tuple.time2);

                    //add seller Record
                    recList.Add(sellerRec);

                    //if asin list is null skip
                    if (entry.Value.asinList == null)
                    {
                        continue;
                    }

                    for (int z = 0; z < entry.Value.asinList.Length; z++)
                    {
                        //create seller record
                        SellerItemRecord sellerItemRec = new SellerItemRecord(sellerRec.SellerUid, entry.Value.asinList[z], entry.Value.asinListLastSeen[z]);

                        //add seller item record
                        recList.Add(sellerItemRec);
                    }


                }


            }

        }

        /// <summary>
        /// Extracts relevant values from the CSV for rating and timestamps
        /// Keepa provides a way to get the most recent values 
        /// </summary>
        /// <param name="Arr"></param>
        /// <returns></returns>
        private  (int time, int value, int time2, int value2) ExtractRatings(int[][] Arr)
        {
            //RATING: split into relative arrays
            int time = Arr[0].ElementAt(Arr[0].Length - 2);
            int value = Arr[0].ElementAt(Arr[0].Length - 1);

            //RATING_COUNT: split into relative arrays
            int time2 = Arr[1].ElementAt(Arr[1].Length - 2);
            int value2 = Arr[1].ElementAt(Arr[1].Length - 1);

            return (time, value, time2, value2);
        }

        /// <summary>
        /// Create a product record
        /// So that it is written Java does not support multi-dimensional array in the same way as
        /// .Net rather they are considered jagged arrays:
        /// https://stackoverflow.com/questions/5313832/multidimensional-arrays-in-java-and-c-sharp
        /// In conversion I have converted them to multidimensional arrays in C# [,] as postgresql does not like
        /// jagged arrays
        /// </summary>
        /// <param name="r"></param>
        private  List<ulong> CreateProduct(Response r, ref List<IRecord> recList)
        {
            List<ulong> indexList = new List<ulong>();
            var products = r.products;
            for (int x = 0; x < products.Length; x++)
            {
                ProductRecord productRec = new ProductRecord(products[x].productType, products[x].asin, products[x].domainId, products[x].title, products[x].trackingSince
                    , products[x].listedSince, products[x].lastUpdate, products[x].lastRatingUpdate, products[x].lastPriceChange, products[x].lastEbayUpdate, products[x].imagesCSV,
                    products[x].rootCategory, products[x].parentAsin, products[x].variationCSV, products[x].mpn, products[x].hasReviews, products[x].type, products[x].manufacturer,
                    products[x].brand, products[x].label, products[x].department, products[x].publisher, products[x].productGroup, products[x].partNumber, products[x].author,
                    products[x].binding, products[x].numberOfItems, products[x].numberOfPages, products[x].publicationDate, products[x].releaseDate, products[x].studio, products[x].genre,
                    products[x].model, products[x].color, products[x].size, products[x].edition, products[x].platform, products[x].format, products[x].description,
                    products[x].hazardousMaterialType != null ? products[x].hazardousMaterialType.Key : 0,
                    products[x].packageHeight, products[x].packageLength, products[x].packageWidth, products[x].packageWeight, products[x].packageQuantity, products[x].availabilityAmazon,
                    products[x].isAdultProduct, products[x].newPriceIsMAP, products[x].isEligibleForTradeIn, products[x].isEligibleForSuperSaverShipping, products[x].isRedirectASIN,
                    products[x].isSNS, products[x].offersSuccessful);

                //add new record to list
                recList.Add(productRec);

                //add generated guid to list
                indexList.Add(productRec.ProductId);
            }
            return indexList;
        }

        /// <summary>
        /// Create a notification record
        /// </summary>
        /// <param name="r"></param>
        private  void CreateNotification(Response r, ref List<IRecord> recList)
        {
            var x = r.notifications;
        }

        /// <summary>
        /// Create a Marketplace Offer record
        /// </summary>
        /// <param name="r"></param>
        private  void CreateMarketplaceOffer(Response r, ref List<IRecord> recList)
        {
            //var x = r.offer;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Crate a Deal record
        /// </summary>
        /// <param name="r"></param>
        private  void CreateDeal(Response r, ref List<IRecord> recList)
        {
            var x = r.deals;
        }

        /// <summary>
        /// Creates a category record
        /// </summary>
        /// <param name="r"></param>
        private  void CreateCategory(Product[] products, ref List<IRecord> recList, ref List<ulong> indexList)
        {
            for (int x = 0; x < products.Length; x++)
            {
                //if the list is null skip iteration
                if (products[x].categories == null)
                {
                    continue;
                }
                for (int y = 0; y < products[x].categories.Length; y++)
                {
                    //new category record
                    CategoryRecord catRec = new CategoryRecord(indexList[x], products[x].categories[y]);

                    //add to recList 
                    recList.Add(catRec);
                }
            }
        }

        /// <summary>
        /// Creates a category record
        /// </summary>
        /// <param name="r"></param>
        /// <param name="recList"></param>
        private void CreateCategoryLookupRecord(Response r, ref List<IRecord> recList)
        {
            var categorySet = r.categories;
            foreach(KeyValuePair<long, Category> entry in categorySet)
            {
                //create a new categoy lookup record for each entry in the dictionary and add to the recList
                var rec = new CategoryLookupRecord(entry.Value.domainId, entry.Value.catId, entry.Value.name, entry.Value.children, entry.Value.parent, entry.Value.highestRank, entry.Value.productCount);
                recList.Add(rec);
            }
        }
        /// <summary>
        /// Create Category Tree Record
        /// </summary>
        /// <param name="r"></param>
        /// <param name="recList"></param>
        private void CreateCategoryTreeRecord(Response r, ref List<IRecord> recList)
        {
            var CategoryTree = r.categories;

            foreach (KeyValuePair<long, Category> entry in CategoryTree)
            {
                ///Make this fucker relational....
                //var rec = new CategoryTreeRecord(entry.Value.catId, entry.Value.name);
            }

        }

        /// <summary>
        /// Create a best seller record
        /// </summary>
        /// <param name="r"></param>
        private  void CreateBestSeller(Response r, ref List<IRecord> recList)
        {
            var BestSeller = r.bestSellersList;
            for (int x = 0; x < BestSeller.asinList.Length; x++)
            {
                //Create record
                BestSellerRecord rec = new BestSellerRecord(BestSeller.domainId, BestSeller.lastUpdate, BestSeller.categoryId, BestSeller.asinList[x]);

                //add to record list
                recList.Add(rec);
            }

        }

        /// <summary>
        /// Create a price history record
        /// </summary>
        /// <param name="products"></param>
        /// <param name="recList"></param>
        /// <param name="indexList"></param>
        private  void CreatePriceHistory(Product[] products, ref List<IRecord> recList, ref List<ulong> indexList)
        {
            //for each product
            for (int x = 0; x < products.Length; x++)
            {
                //if the list is null skip iteration
                if (products[x].csv == null)
                {
                    continue;
                }
                //for each unit in csv
                for (int y = 0; y < products[x].csv.Length; y++)
                {
                    //if the array at enum is null skip iteration
                    if (products[x].csv[y] == null)
                    {
                        continue;
                    }

                    //else set a = to csv at y
                    var a = products[x].csv[y];

                    //additional logic required for *_SHIPPING arrays 7, 18-29
                    if (y == 7 || (y <= 29 && y >= 18))
                    {
                        //set vars
                        int n1 = 0;
                        int n2 = 1;
                        int n3 = 2;

                        //loop through array
                        for (int v = 0; v < products[x].csv[y].Length; v += 3)
                        {
                            //shorten expression cause I'm lazy
                            var val = products[x].csv[y];

                            //create a priceHistoryRecord
                            PriceHistoryRecord priceHistoryRec = new PriceHistoryRecord(indexList[x], y, XModule.Tools.Utilities.GetUnixTimeFromKeepaTime(val[n1]), val[n2], val[n3]);

                            //add record
                            recList.Add(priceHistoryRec);

                            //increment vars
                            n1 += 3;
                            n2 += 3;
                            n3 += 3;

                        }

                    }
                    else
                    {
                        //TODO: change to array segment object to increase speed
                        //split into corresponding values time array and price array.
                        int[] time = a.Where((k, i) => i % 2 == 0).ToArray();
                        int[] price = a.Where((k, i) => i % 2 != 0).ToArray();

                        //next level loop to create a record for every entry in the arrays time and price 
                        for (int v = 0; v < time.Length; v++)
                        {

                            //create a priceHistoryRecord
                            PriceHistoryRecord priceHistoryRec = new PriceHistoryRecord(indexList[x], y, XModule.Tools.Utilities.GetUnixTimeFromKeepaTime(time[v]), price[v], null);

                            //add record
                            recList.Add(priceHistoryRec);
                        }
                    }

                }
            }
        }


    }
}
