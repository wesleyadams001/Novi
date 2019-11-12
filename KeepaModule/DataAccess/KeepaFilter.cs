using KeepaModule.DataAccess.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using XModule.Interfaces;
using static XModule.Constants.Enums;
using KeepaModule.DataAccess.Entities;

namespace KeepaModule.DataAccess
{
    /// <summary>
    /// The Keepa Specific Filter
    /// </summary>
    public class KeepaFilter //: IFilter
    {
        /// <summary>
        /// Default constructor of KeepaFilter
        /// </summary>
        public KeepaFilter()
        {
            this.TopBlock = new BufferBlock<IRecord>();

            this.LinkOptions = new DataflowLinkOptions { PropagateCompletion = true };

            #region NewEndBlocks
            this.bestSellerBlock = new BufferBlock<best_sellers>();
            this.categoryBlock = new BufferBlock<category>();
            this.categoryTreeBlock = new BufferBlock<CategoryTreeRecord>();
            this.eanBlock = new BufferBlock<ean>();
            this.fbaFeesBlock = new BufferBlock<fba_fees>();
            this.featuresBlock = new BufferBlock<feature>();
            this.freqBoughtBlock = new BufferBlock<freq_bought_together>();
            this.languagesBlock = new BufferBlock<language>();
            this.mostRatedSellerBlock = new BufferBlock<most_rated_sellers>();
            this.priceHistoryBlock = new BufferBlock<price_history>();
            this.productBlock = new BufferBlock<product>();
            this.promotionBlock = new BufferBlock<PromotionRecord>();
            this.sellerItemBlock = new BufferBlock<sellers_listed_items>();
            this.sellerBlock = new BufferBlock<seller>();
            this.statisticsBlock = new BufferBlock<statistic>();
            this.topSellerBlock = new BufferBlock<TopSellersRecord>();
            this.upcBlock = new BufferBlock<upc>();
            this.variationBlock = new BufferBlock<variation>();
            #endregion

            #region NewTransformBlocks
            this.BestSellerTBlock = new TransformBlock<IRecord, best_sellers>(x => {

                var dobj = (BestSellerRecord)x;
                var val = new best_sellers(dobj.DomainId, dobj.LastUpdate, dobj.CategoryId, dobj.Asin, dobj.TimeStamp);
                return val;
            });
            this.CategoryTBlock = new TransformBlock<IRecord, category>(x => {

                var dobj = (CategoryRecord)x;
                var val = new category(dobj.ProductId, dobj.AmznCategoryId, dobj.TimeStamp);
                return val;
            });
            //this.CategoryTreeTBlock
            //this.DealTBlock
            this.EanTBlock = new TransformBlock<IRecord, ean>(x => {

                var dobj = (EanRecord)x;
                var val = new ean(dobj.ProductId, dobj.EanNumber, dobj.TimeStamp);
                return val;
            });
            this.FbaFeesTBlock = new TransformBlock<IRecord, fba_fees>(x => {

                var dobj = (FbaFeesRecord)x;
                var val = new fba_fees(dobj.ProductId, dobj.PickPackFee, dobj.PickPackFeeTax, dobj.StorageFee, dobj.StorageFeeTax, dobj.TimeStamp);
                return val;
            });
            this.FeatureTBlock = new TransformBlock<IRecord, feature>(x => {

                var dobj = (FeaturesRecord)x;
                var val = new feature(dobj.ProductId, dobj.Features, dobj.TimeStamp);
                return val;
            });
            this.FreqBoughtTBlock = new TransformBlock<IRecord, freq_bought_together>(x => {

                var dobj = (FreqBoughtTogetherRecord)x;
                var val = new freq_bought_together(dobj.ProductId, dobj.AssociatedAsin, dobj.TimeStamp);
                return val;
            });
            this.LanguageTBlock = new TransformBlock<IRecord, language>(x => {

                var dobj = (LanguagesRecord)x;
                var val = new language(dobj.ProductId, dobj.LanguageName, dobj.LanguageType, dobj.AudioFormat, dobj.TimeStamp);
                return val;
            });
            this.MostRatedSellersTBlock = new TransformBlock<IRecord, most_rated_sellers>(x => {

                var dobj = (MostRatedSellersRecord)x;
                var val = new most_rated_sellers(dobj.AmznSellerIdentifier, dobj.TimeStamp);
                return val;
            });
            this.PriceHistoryTBlock = new TransformBlock<IRecord, price_history>(x => {

                var dobj = (PriceHistoryRecord)x;
                var val = new price_history(dobj.ProductId, dobj.obHistoryType, dobj.obDate, dobj.obPrice, dobj.obShipping, dobj.TimeStamp);
                return val;
            });
            this.ProductTBlock = new TransformBlock<IRecord, product>(x =>
            {
                var dobj = (ProductRecord)x;
                var val = new product(dobj.ProductId, dobj.productType.ToString(), dobj.asin, dobj.domainId, dobj.title, dobj.trackingSince, dobj.listedSince, dobj.lastUpdate,
                    dobj.lastRatingUpdate, dobj.lastPriceChange, dobj.lastEbayUpdate, dobj.imagesCSV, dobj.rootCategory, dobj.parentAsin, dobj.variationCSV, dobj.mpn, dobj.hasReviews,
                    dobj.type, dobj.manufacturer, dobj.brand, dobj.label, dobj.department, dobj.publisher, dobj.productGroup, dobj.partNumber, dobj.author, dobj.binding,
                    dobj.numberOfItems, dobj.numberOfPages, dobj.publicationDate, dobj.releaseDate, dobj.studio, dobj.genre, dobj.model, dobj.color, dobj.size, dobj.edition,
                    dobj.platform, dobj.format, dobj.description, dobj.hazardousMaterialType, dobj.packageHeight, dobj.packageLength, dobj.packageWidth, dobj.packageWeight, dobj.packageQuantity, dobj.availabilityAmazon,
                    dobj.isAdultProduct, dobj.newPriceIsMAP, dobj.isEligibleForTradeIn, dobj.isEligibleForSuperSaverShipping, dobj.isRedirectASIN, dobj.isSNS, dobj.offersSuccessful, dobj.TimeStamp);
                return val;
            });
            this.SellerTBlock = new TransformBlock<IRecord, seller>(x => {

                var dobj = (SellerRecord)x;
                var val = new seller(dobj.SellerUid, dobj.DomainId, dobj.TrackingSince, dobj.LastUpdate, dobj.SellerId, dobj.SellerName, dobj.IsScammer, dobj.HasFba,
                    dobj.TotalStoreFrontAsinRecTime, dobj.TotalStoreFrontAsins, dobj.Rating, dobj.RatingTime, dobj.RatingCount, dobj.RatingCountTime, dobj.TimeStamp);
                return val;
            });
            this.SellerListedItemsTBlock = new TransformBlock<IRecord, sellers_listed_items>(x => {

                var dobj = (SellerItemRecord)x;
                var val = new sellers_listed_items(dobj.AssociatedSeller, dobj.Asin, dobj.AsinLastSeen, dobj.TimeStamp);
                return val;
            });
            this.StatisticsTBlock = new TransformBlock<IRecord, statistic>(x => {

                var dobj = (StatisticsRecord)x;
                var val = new statistic(dobj.ProductId, dobj.StatType, dobj.Current, dobj.Avg, dobj.Avg30, dobj.Avg90, dobj.Avg180, dobj.AtIntervalStart, dobj.MinPriceType, dobj.MinPriceRecTime,
                    dobj.MinPriceValue, dobj.MaxPriceType, dobj.MaxPriceRecTime, dobj.MaxPriceValue, dobj.IntervalMinPriceType, dobj.IntervalMinPriceRecTime, dobj.IntervalMinPriceValue,
                    dobj.IntervalMaxPriceType, dobj.IntervalMaxPriceRecTime, dobj.IntervalMaxPriceValue, dobj.OutOfStockPercentageInInterval, dobj.OutOfStockPercentage30, dobj.OutOfStockPercentage90,
                    dobj.LastOffersUpdate, dobj.TotalOffersCount, dobj.LightningDealInfo, dobj.RetrievedOfferCount, dobj.BuyBoxPrice, dobj.BuyBoxShipping, dobj.BuyBoxIsUnqualified,
                    dobj.BuyBoxIsShippable, dobj.BuyBoxIsPreorder, dobj.BuyBoxIsFba, dobj.BuyBoxIsAmazon, dobj.BuyBoxIsMap, dobj.BuyBoxIsUsed, dobj.SellerIdsLowestFba, dobj.SellerIdsLowestFbm,
                    dobj.OfferCountFba, dobj.OfferCountFbm, dobj.TimeStamp);
                return val;
            });
            this.UpcTBlock = new TransformBlock<IRecord, upc>(x => {

                var dobj = (UpcRecord)x;
                var val = new upc(dobj.ProductId, dobj.UpcNumber, dobj.TimeStamp);
                return val;
            });
            this.VariationTBlock = new TransformBlock<IRecord, variation>(x => {

                var dobj = (VariationRecord)x;
                var val = new variation(dobj.productId, dobj.Variation, dobj.vDimension, dobj.vValue, dobj.TimeStamp);
                return val;
            });
            #endregion

            #region newFilters
            this.BestSellerFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.BestSellerRecord; };
            this.CategoryFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.CategoryRecord; };
            this.CategoryTreeFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.CategoryTreeRecord; };
            this.DealFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.DealRecord; };
            this.EanFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.EanRecord; };
            this.FbaFeesFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.FbaFeesRecord; };
            this.FeatureFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.FeaturesRecord; };
            this.FreqBoughtTogetherFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.FrequentlyBoughtTogetherRecord; };
            this.LanguageFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.LanguagesRecord; };
            this.MRSFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.TopSellerRecord; };
            this.PriceHistoryFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.PriceHistoryRecord; };
            this.ProductFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.ProductRecord; };
            this.SellerFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.SellerRecord; };
            this.SLIFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.SellerItemRecord; };
            this.StatisticsFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.StatisitcsRecord; };
            this.UpcFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.UpcRecord; };
            this.VariationFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.VariationsRecord; };
            #endregion

            #region Links
            //set up links using propogate oncompletion and appropriate filters
            #region TopToTransform
            this.TopBlock.LinkTo(this.BestSellerTBlock, this.LinkOptions, this.BestSellerFilter);
            this.TopBlock.LinkTo(this.CategoryTBlock, this.LinkOptions, this.CategoryFilter);
            this.TopBlock.LinkTo(this.EanTBlock, this.LinkOptions, this.EanFilter);
            this.TopBlock.LinkTo(this.FbaFeesTBlock, this.LinkOptions, this.FbaFeesFilter);
            this.TopBlock.LinkTo(this.FeatureTBlock, this.LinkOptions, this.FeatureFilter);
            this.TopBlock.LinkTo(this.FreqBoughtTBlock, this.LinkOptions, this.FreqBoughtTogetherFilter);
            this.TopBlock.LinkTo(this.LanguageTBlock, this.LinkOptions, this.LanguageFilter);
            this.TopBlock.LinkTo(this.MostRatedSellersTBlock, this.LinkOptions, this.MRSFilter);
            this.TopBlock.LinkTo(this.PriceHistoryTBlock, this.LinkOptions, this.PriceHistoryFilter);
            this.TopBlock.LinkTo(this.ProductTBlock, this.LinkOptions, this.ProductFilter);
            this.TopBlock.LinkTo(this.SellerTBlock, this.LinkOptions, this.SellerFilter);
            this.TopBlock.LinkTo(this.SellerListedItemsTBlock, this.LinkOptions, this.SLIFilter);
            this.TopBlock.LinkTo(this.StatisticsTBlock, this.LinkOptions, this.StatisticsFilter);
            this.TopBlock.LinkTo(this.UpcTBlock, this.LinkOptions, this.UpcFilter);
            this.TopBlock.LinkTo(this.VariationTBlock, this.LinkOptions, this.VariationFilter);
            #endregion
            //attach transforms to buffer
            #region TransformToEnd
            this.bestSellerBlock.LinkTo(this.bestSellerBlock, this.LinkOptions);
            this.categoryBlock.LinkTo(this.categoryBlock, this.LinkOptions);
            this.eanBlock.LinkTo(this.eanBlock, this.LinkOptions);
            this.fbaFeesBlock.LinkTo(this.fbaFeesBlock, this.LinkOptions);
            this.featuresBlock.LinkTo(this.featuresBlock, this.LinkOptions);
            this.freqBoughtBlock.LinkTo(this.freqBoughtBlock, this.LinkOptions);
            this.languagesBlock.LinkTo(this.languagesBlock, this.LinkOptions);
            this.mostRatedSellerBlock.LinkTo(this.mostRatedSellerBlock, this.LinkOptions);
            this.priceHistoryBlock.LinkTo(this.priceHistoryBlock, this.LinkOptions);
            this.productBlock.LinkTo(this.productBlock, this.LinkOptions);
            this.sellerBlock.LinkTo(this.sellerBlock, this.LinkOptions);
            this.sellerItemBlock.LinkTo(this.sellerItemBlock, this.LinkOptions);
            this.statisticsBlock.LinkTo(this.statisticsBlock, this.LinkOptions);
            this.upcBlock.LinkTo(this.upcBlock, this.LinkOptions);
            this.variationBlock.LinkTo(this.variationBlock, this.LinkOptions);
            #endregion
            #endregion
        }
        private BufferBlock<IRecord> TopBlock { get; set; }

        private DataflowLinkOptions LinkOptions { get; set; }

        #region FinalBlocks
        public BufferBlock<best_sellers> bestSellerBlock { get; set; }
        public BufferBlock<category> categoryBlock { get; set; }
        public BufferBlock<CategoryTreeRecord> categoryTreeBlock { get; set; }
        public BufferBlock<ean> eanBlock { get; set; }
        public BufferBlock<fba_fees> fbaFeesBlock { get; set; }
        public BufferBlock<feature> featuresBlock { get; set; }
        public BufferBlock<freq_bought_together> freqBoughtBlock { get; set; }
        public BufferBlock<language> languagesBlock { get; set; }
        public BufferBlock<most_rated_sellers> mostRatedSellerBlock { get; set; }
        public BufferBlock<price_history> priceHistoryBlock { get; set; }
        public BufferBlock<product> productBlock { get; set; }
        public BufferBlock<PromotionRecord> promotionBlock { get; set; }
        public BufferBlock<sellers_listed_items> sellerItemBlock { get; set; }
        public BufferBlock<seller> sellerBlock { get; set; }
        public BufferBlock<statistic> statisticsBlock { get; set; }
        public BufferBlock<TopSellersRecord> topSellerBlock { get; set; }
        public BufferBlock<upc> upcBlock { get; set; }
        public BufferBlock<variation> variationBlock { get; set; }
        #endregion

        #region Filters
        private Predicate<IRecord> BestSellerFilter { get; set; }
        private Predicate<IRecord> CategoryFilter { get; set; }
        private Predicate<IRecord> CategoryTreeFilter { get; set; }
        private Predicate<IRecord> DealFilter { get; set; }
        private Predicate<IRecord> EanFilter { get; set; }
        private Predicate<IRecord> FbaFeesFilter { get; set; }
        private Predicate<IRecord> FeatureFilter { get; set; }
        private Predicate<IRecord> FreqBoughtTogetherFilter { get; set; }
        private Predicate<IRecord> LanguageFilter { get; set; }
        private Predicate<IRecord> MRSFilter { get; set; }
        private Predicate<IRecord> PriceHistoryFilter { get; set; }
        private Predicate<IRecord> ProductFilter { get; set; }
        private Predicate<IRecord> SellerFilter { get; set; }
        private Predicate<IRecord> SLIFilter { get; set; }
        private Predicate<IRecord> StatisticsFilter { get; set; }
        private Predicate<IRecord> UpcFilter { get; set; }
        private Predicate<IRecord> VariationFilter { get; set; }
        #endregion

        #region TransformBlocks
        private TransformBlock<IRecord, best_sellers> BestSellerTBlock { get; set; }
        private TransformBlock<IRecord, category> CategoryTBlock { get; set; }
        private TransformBlock<IRecord, ean> EanTBlock { get; set; }
        private TransformBlock<IRecord, fba_fees> FbaFeesTBlock { get; set; }
        private TransformBlock<IRecord, feature> FeatureTBlock { get; set; }
        private TransformBlock<IRecord, freq_bought_together> FreqBoughtTBlock {get;set;}
        private TransformBlock<IRecord, language> LanguageTBlock { get; set; }
        private TransformBlock<IRecord, most_rated_sellers> MostRatedSellersTBlock { get; set; }
        private TransformBlock<IRecord, price_history> PriceHistoryTBlock { get; set; }
        private TransformBlock<IRecord, product> ProductTBlock { get; set; }
        private TransformBlock<IRecord, seller> SellerTBlock { get; set; }
        private TransformBlock<IRecord, sellers_listed_items> SellerListedItemsTBlock { get; set; }
        private TransformBlock<IRecord, statistic> StatisticsTBlock { get; set; }
        private TransformBlock<IRecord, upc> UpcTBlock { get; set; }
        private TransformBlock<IRecord, variation> VariationTBlock { get; set; }
        #endregion

        /// <summary>
        /// Allocate IRecords to appropriate queues
        /// </summary>
        /// <param name="broadcast"></param>
        public void Allocate(IRecord[] broadcast)
        {

            for(int x= 0; x<broadcast.Length; x++)
            {
                this.TopBlock.Post(broadcast[x]);
            }
            
        }

    }
}
