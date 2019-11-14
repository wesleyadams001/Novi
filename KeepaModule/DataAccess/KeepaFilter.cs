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
using KeepaModule.DataAccess.Entities.Actions;

namespace KeepaModule.DataAccess
{
    /// <summary>
    /// The Keepa Specific Allocator
    /// </summary>
    public class Allocator //: IAllocator
    {
        private const int BATCH_SIZE = 10000;
        /// <summary>
        /// Default constructor of Allocator
        /// </summary>
        public Allocator()
        {
            
            this.TopBlock = new BufferBlock<IRecord>();

            this.LinkOptions = new DataflowLinkOptions { PropagateCompletion = true };

            #region NewInsertBlocks
            this.InsertBestSellersAction = new ActionBlock<best_sellers[]>(a =>
            {
                using(var context = new KeepaContext())
                {
                    //context.Configuration.AutoDetectChangesEnabled = false;
                    context.best_sellers.AddRange(a);
                    context.SaveChanges();
                }
                 
            });
            this.InsertCategoryAction = new ActionBlock<category[]>(a =>
            {
                using (var context = new KeepaContext())
                {
                    //context.Configuration.AutoDetectChangesEnabled = false;
                    context.categories.AddRange(a);
                    context.SaveChanges();
                }
            });
            this.InsertCategoryTreeAction = new ActionBlock<category_tree[]>(a =>
            {
                using (var context = new KeepaContext())
                {
                    //context.Configuration.AutoDetectChangesEnabled = false;
                    context.category_tree.AddRange(a);
                    context.SaveChanges();
                }
            });
            this.InsertEanAction = new ActionBlock<ean[]>(a =>
            {
                using (var context = new KeepaContext())
                {
                    //context.Configuration.AutoDetectChangesEnabled = false;
                    context.eans.AddRange(a);
                    context.SaveChanges();
                }
            });
            this.InsertFbaFeesAction = new ActionBlock<fba_fees[]>(a =>
            {
                using (var context = new KeepaContext())
                {
                    //context.Configuration.AutoDetectChangesEnabled = false;
                    context.fba_fees.AddRange(a);
                    context.SaveChanges();
                }
            });
            this.InsertFeatureAction = new ActionBlock<feature[]>(a =>
            {
                using (var context = new KeepaContext())
                {
                    //context.Configuration.AutoDetectChangesEnabled = false;
                    context.features.AddRange(a);
                    context.SaveChanges();
                }
            });
            this.InsertFreqBoughtAction = new ActionBlock<freq_bought_together[]>(a =>
            {
                using (var context = new KeepaContext())
                {
                    //context.Configuration.AutoDetectChangesEnabled = false;
                    context.freq_bought_together.AddRange(a);
                    context.SaveChanges();
                }
            });
            this.InsertLanguageAction = new ActionBlock<language[]>(a =>
            {
                using (var context = new KeepaContext())
                {
                    //context.Configuration.AutoDetectChangesEnabled = false;
                    context.languages.AddRange(a);
                    context.SaveChanges();
                }
            });
            this.InsertMostRatedSellersAction = new ActionBlock<most_rated_sellers[]>(a =>
            {
                using (var context = new KeepaContext())
                {
                    //context.Configuration.AutoDetectChangesEnabled = false;
                    context.most_rated_sellers.AddRange(a);
                    context.SaveChanges();
                }
            });
            this.InsertPriceHistoryAction = new ActionBlock<price_history[]>(a =>
            {
                using (var context = new KeepaContext())
                {
                    //context.Configuration.AutoDetectChangesEnabled = false;
                    context.price_history.AddRange(a);
                    context.SaveChanges();
                }
            });
            this.InsertProductAction = new ActionBlock<product[]>(a =>
            {
                using (var context = new KeepaContext())
                {
                    //context.Configuration.AutoDetectChangesEnabled = false;
                    context.products.AddRange(a);
                    context.SaveChanges();
                }
            });
            this.InsertSellerAction = new ActionBlock<seller[]>(a =>
            {
                using (var context = new KeepaContext())
                {
                    //context.Configuration.AutoDetectChangesEnabled = false;
                    context.sellers.AddRange(a);
                    context.SaveChanges();
                }
            });
            this.InsertSellersListedItemsAction = new ActionBlock<sellers_listed_items[]>(a =>
            {
                using (var context = new KeepaContext())
                {
                    //context.Configuration.AutoDetectChangesEnabled = false;
                    context.sellers_listed_items.AddRange(a);
                    context.SaveChanges();
                }
            });
            this.InsertStatisticAction = new ActionBlock<statistic[]>(a =>
            {
                using (var context = new KeepaContext())
                {
                    //context.Configuration.AutoDetectChangesEnabled = false;
                    context.statistics.AddRange(a);
                    context.SaveChanges();
                }
            });
            this.InsertUpcAction = new ActionBlock<upc[]>(a =>
            {
                using (var context = new KeepaContext())
                {
                    //context.Configuration.AutoDetectChangesEnabled = false;
                    context.upcs.AddRange(a);
                    context.SaveChanges();
                }
            });
            this.InsertVariationAction = new ActionBlock<variation[]>(a =>
            {
                using (var context = new KeepaContext())
                {
                    //context.Configuration.AutoDetectChangesEnabled = false;
                    context.variations.AddRange(a);
                    context.SaveChanges();
                }
            });
            #endregion

            #region NewBatchBlocks 
            this.bestSellerBlock = new BatchBlock<best_sellers>(BATCH_SIZE);
            this.categoryBlock = new BatchBlock<category>(BATCH_SIZE);
            this.categoryTreeBlock = new BatchBlock<category_tree>(BATCH_SIZE);
            this.eanBlock = new BatchBlock<ean>(BATCH_SIZE);
            this.fbaFeesBlock = new BatchBlock<fba_fees>(BATCH_SIZE);
            this.featuresBlock = new BatchBlock<feature>(BATCH_SIZE);
            this.freqBoughtBlock = new BatchBlock<freq_bought_together>(BATCH_SIZE);
            this.languagesBlock = new BatchBlock<language>(BATCH_SIZE);
            this.mostRatedSellerBlock = new BatchBlock<most_rated_sellers>(BATCH_SIZE);
            this.priceHistoryBlock = new BatchBlock<price_history>(BATCH_SIZE);
            this.productBlock = new BatchBlock<product>(BATCH_SIZE);
            //this.promotionBlock = new BatchBlock<PromotionRecord>(BATCH_SIZE);
            this.sellerItemBlock = new BatchBlock<sellers_listed_items>(BATCH_SIZE);
            this.sellerBlock = new BatchBlock<seller>(BATCH_SIZE);
            this.statisticsBlock = new BatchBlock<statistic>(BATCH_SIZE);
            //this.topSellerBlock = new BatchBlock<TopSellersRecord>(BATCH_SIZE);
            this.upcBlock = new BatchBlock<upc>(BATCH_SIZE);
            this.variationBlock = new BatchBlock<variation>(BATCH_SIZE);
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

            #region NewFilters
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

            //Dataflow Links
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
            //attach transforms to batch
            #region TransformToBatch
            this.BestSellerTBlock.LinkTo(this.bestSellerBlock, this.LinkOptions);
            this.CategoryTBlock.LinkTo(this.categoryBlock, this.LinkOptions);
            this.EanTBlock.LinkTo(this.eanBlock, this.LinkOptions);
            this.FbaFeesTBlock.LinkTo(this.fbaFeesBlock, this.LinkOptions);
            this.FeatureTBlock.LinkTo(this.featuresBlock, this.LinkOptions);
            this.FreqBoughtTBlock.LinkTo(this.freqBoughtBlock, this.LinkOptions);
            this.LanguageTBlock.LinkTo(this.languagesBlock, this.LinkOptions);
            this.MostRatedSellersTBlock.LinkTo(this.mostRatedSellerBlock, this.LinkOptions);
            this.PriceHistoryTBlock.LinkTo(this.priceHistoryBlock, this.LinkOptions);
            this.ProductTBlock.LinkTo(this.productBlock, this.LinkOptions);
            this.SellerTBlock.LinkTo(this.sellerBlock, this.LinkOptions);
            this.SellerListedItemsTBlock.LinkTo(this.sellerItemBlock, this.LinkOptions);
            this.StatisticsTBlock.LinkTo(this.statisticsBlock, this.LinkOptions);
            this.UpcTBlock.LinkTo(this.upcBlock, this.LinkOptions);
            this.VariationTBlock.LinkTo(this.variationBlock, this.LinkOptions);
            #endregion
            //insert delegate for batches
            #region BatchToInsert
            this.bestSellerBlock.LinkTo(InsertBestSellersAction, this.LinkOptions);
            this.bestSellerBlock.Completion.ContinueWith(delegate 
            { 
                InsertBestSellersAction.Complete(); 
                InsertBestSellersAction.Completion.Wait(); 
            });
            this.categoryBlock.LinkTo(InsertCategoryAction, this.LinkOptions);
            this.categoryBlock.Completion.ContinueWith(delegate 
            { 
                InsertCategoryAction.Complete(); 
                InsertCategoryAction.Completion.Wait(); 
            });
            this.categoryTreeBlock.LinkTo(InsertCategoryTreeAction, this.LinkOptions);
            this.categoryTreeBlock.Completion.ContinueWith(delegate 
            { 
                InsertCategoryTreeAction.Complete(); 
                InsertCategoryTreeAction.Completion.Wait(); 
            });
            this.eanBlock.LinkTo(InsertEanAction, this.LinkOptions);
            this.eanBlock.Completion.ContinueWith(delegate 
            { 
                InsertEanAction.Complete(); 
                InsertEanAction.Completion.Wait(); 
            });
            this.fbaFeesBlock.LinkTo(InsertFbaFeesAction, this.LinkOptions);
            this.fbaFeesBlock.Completion.ContinueWith(delegate 
            { 
                InsertFbaFeesAction.Complete(); 
                InsertFbaFeesAction.Completion.Wait(); 
            });
            this.featuresBlock.LinkTo(InsertFeatureAction, this.LinkOptions);
            this.featuresBlock.Completion.ContinueWith(delegate 
            { 
                InsertFeatureAction.Complete(); 
                InsertFeatureAction.Completion.Wait(); 
            });
            this.freqBoughtBlock.LinkTo(InsertFreqBoughtAction, this.LinkOptions);
            this.freqBoughtBlock.Completion.ContinueWith(delegate 
            { 
                InsertFreqBoughtAction.Complete(); 
                InsertFreqBoughtAction.Completion.Wait(); 
            });
            this.languagesBlock.LinkTo(InsertLanguageAction, this.LinkOptions);
            this.languagesBlock.Completion.ContinueWith(delegate 
            { 
                InsertLanguageAction.Complete(); 
                InsertLanguageAction.Completion.Wait(); 
            });
            this.mostRatedSellerBlock.LinkTo(InsertMostRatedSellersAction, this.LinkOptions);
            this.mostRatedSellerBlock.Completion.ContinueWith(delegate 
            { 
                InsertMostRatedSellersAction.Complete(); 
                InsertMostRatedSellersAction.Completion.Wait(); 
            });
            this.priceHistoryBlock.LinkTo(InsertPriceHistoryAction, this.LinkOptions);
            this.priceHistoryBlock.Completion.ContinueWith(delegate 
            { 
                InsertPriceHistoryAction.Complete(); 
                InsertPriceHistoryAction.Completion.Wait(); 
            });
            this.productBlock.LinkTo(InsertProductAction, this.LinkOptions);
            this.productBlock.Completion.ContinueWith(delegate 
            { 
                InsertProductAction.Complete(); 
                InsertProductAction.Completion.Wait(); 
            });
            this.sellerItemBlock.LinkTo(InsertSellersListedItemsAction, this.LinkOptions);
            this.sellerItemBlock.Completion.ContinueWith(delegate 
            { 
                InsertSellersListedItemsAction.Complete(); 
                InsertSellersListedItemsAction.Completion.Wait(); 
            });
            this.sellerBlock.LinkTo(InsertSellerAction, this.LinkOptions);
            this.sellerBlock.Completion.ContinueWith(delegate 
            { 
                InsertSellerAction.Complete(); 
                InsertSellerAction.Completion.Wait(); 
            });
            this.statisticsBlock.LinkTo(InsertStatisticAction, this.LinkOptions);
            this.statisticsBlock.Completion.ContinueWith(delegate 
            { 
                InsertStatisticAction.Complete(); 
                InsertStatisticAction.Completion.Wait(); 
            });
            this.upcBlock.LinkTo(InsertUpcAction, this.LinkOptions);
            this.upcBlock.Completion.ContinueWith(delegate 
            { 
                InsertUpcAction.Complete(); 
                InsertUpcAction.Completion.Wait(); 
            });
            this.variationBlock.LinkTo(InsertVariationAction, this.LinkOptions);
            this.variationBlock.Completion.ContinueWith(delegate 
            { 
                InsertVariationAction.Complete(); 
                InsertVariationAction.Completion.Wait(); 
            });

            #endregion
            #endregion
        }
        private BufferBlock<IRecord> TopBlock { get; set; }

        private DataflowLinkOptions LinkOptions { get; set; }

        #region InsertBlocks
        private ActionBlock<best_sellers[]> InsertBestSellersAction { get; set; }
        private ActionBlock<category[]> InsertCategoryAction { get; set; }
        private ActionBlock<category_tree[]> InsertCategoryTreeAction { get; set; }
        private ActionBlock<ean[]> InsertEanAction { get; set; }
        private ActionBlock<fba_fees[]> InsertFbaFeesAction { get; set; }
        private ActionBlock<feature[]> InsertFeatureAction { get; set; }
        private ActionBlock<freq_bought_together[]> InsertFreqBoughtAction { get; set; }
        private ActionBlock<language[]> InsertLanguageAction { get; set; }
        private ActionBlock<most_rated_sellers[]> InsertMostRatedSellersAction { get; set; }
        private ActionBlock<price_history[]> InsertPriceHistoryAction { get; set; }
        private ActionBlock<product[]> InsertProductAction { get; set; }
        private ActionBlock<sellers_listed_items[]> InsertSellersListedItemsAction { get; set; }
        private ActionBlock<seller[]> InsertSellerAction { get; set; }
        private ActionBlock<statistic[]> InsertStatisticAction { get; set; }
        private ActionBlock<upc[]> InsertUpcAction { get; set; }
        private ActionBlock<variation[]> InsertVariationAction { get; set; }
        #endregion

        #region BatchBlocks
        public BatchBlock<best_sellers> bestSellerBlock { get; set; }
        public BatchBlock<category> categoryBlock { get; set; }
        public BatchBlock<category_tree> categoryTreeBlock { get; set; }
        public BatchBlock<ean> eanBlock { get; set; }
        public BatchBlock<fba_fees> fbaFeesBlock { get; set; }
        public BatchBlock<feature> featuresBlock { get; set; }
        public BatchBlock<freq_bought_together> freqBoughtBlock { get; set; }
        public BatchBlock<language> languagesBlock { get; set; }
        public BatchBlock<most_rated_sellers> mostRatedSellerBlock { get; set; }
        public BatchBlock<price_history> priceHistoryBlock { get; set; }
        public BatchBlock<product> productBlock { get; set; }
        //public BatchBlock<PromotionRecord> promotionBlock { get; set; }
        public BatchBlock<sellers_listed_items> sellerItemBlock { get; set; }
        public BatchBlock<seller> sellerBlock { get; set; }
        public BatchBlock<statistic> statisticsBlock { get; set; }
        //public BatchBlock<TopSellersRecord> topSellerBlock { get; set; }
        public BatchBlock<upc> upcBlock { get; set; }
        public BatchBlock<variation> variationBlock { get; set; }
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
        public void Filter(IRecord broadcast)
        {

            this.TopBlock.Post(broadcast);

        }


    }
}
