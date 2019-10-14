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
    public class KeepaFilter
    {
        public KeepaFilter()
        {
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
        }

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

        public void Allocate(BufferBlock<IRecord> broadcast)
        {
            DataflowLinkOptions opts = new DataflowLinkOptions
            {
                PropagateCompletion = true
            };

            //Create filters for each type
            Predicate<IRecord> BestSellerFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.BestSellerRecord; };
            Predicate<IRecord> CategoryFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.CategoryRecord; };
            Predicate<IRecord> CategoryTreeFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.CategoryTreeRecord; };
            Predicate<IRecord> DealFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.DealRecord; };
            Predicate<IRecord> EanFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.EanRecord; };
            Predicate<IRecord> FbaFeesFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.FbaFeesRecord; };
            Predicate<IRecord> FeatureFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.FeaturesRecord; };
            Predicate<IRecord> FreqBoughtTogetherFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.FrequentlyBoughtTogetherRecord; };
            Predicate<IRecord> LanguageFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.LanguagesRecord; };
            Predicate<IRecord> MRSFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.TopSellerRecord; };
            Predicate<IRecord> PriceHistoryFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.PriceHistoryRecord; };
            Predicate<IRecord> ProductFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.ProductRecord; };
            Predicate<IRecord> SellerFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.SellerRecord; };
            Predicate<IRecord> SLIFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.SellerItemRecord; };
            Predicate<IRecord> StatisticsFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.StatisitcsRecord; };
            Predicate<IRecord> UpcFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.UpcRecord; };
            Predicate<IRecord> VariationFilter = (IRecord r) => { return r.KeepaRecordType == KeepaRecordType.VariationsRecord; };

            //Create recieving buffers for each record type
            var bestSellerBlock = new TransformBlock<IRecord, best_sellers>(x => {

                var dobj = (BestSellerRecord)x;
                var val = new best_sellers(dobj.DomainId, dobj.LastUpdate, dobj.CategoryId, dobj.Asin, dobj.TimeStamp);
                return val;
            });
            var categoryBlock = new TransformBlock<IRecord, category>(x => {

                var dobj = (CategoryRecord)x;
                var val = new category(dobj.ProductId, dobj.AmznCategoryId, dobj.TimeStamp);
                return val;
            });
            var eanBlock = new TransformBlock<IRecord, ean>(x => {

                var dobj = (EanRecord)x;
                var val = new ean(dobj.ProductId, dobj.EanNumber, dobj.TimeStamp);
                return val;
            });
            var fbaFeesBlock = new TransformBlock<IRecord, fba_fees>(x => {

                var dobj = (FbaFeesRecord)x;
                var val = new fba_fees(dobj.ProductId, dobj.PickPackFee, dobj.PickPackFeeTax, dobj.StorageFee, dobj.StorageFeeTax, dobj.TimeStamp);
                return val;
            });
            var featuresBlock = new TransformBlock<IRecord, feature>(x => {

                var dobj = (FeaturesRecord)x;
                var val = new feature(dobj.ProductId, dobj.Features, dobj.TimeStamp);
                return val;
            });
            var freqBoughtBlock = new TransformBlock<IRecord, freq_bought_together>(x => {

                var dobj = (FreqBoughtTogetherRecord)x;
                var val = new freq_bought_together(dobj.ProductId, dobj.AssociatedAsin, dobj.TimeStamp);
                return val;
            });
            var languagesBlock = new TransformBlock<IRecord, language>(x => {

                var dobj = (LanguagesRecord)x;
                var val = new language(dobj.ProductId, dobj.LanguageName, dobj.LanguageType, dobj.AudioFormat, dobj.TimeStamp);
                return val;
            });
            var mostRatedSellerBlock = new TransformBlock<IRecord, most_rated_sellers>(x => {

                var dobj = (MostRatedSellersRecord)x;
                var val = new most_rated_sellers(dobj.AmznSellerIdentifier, dobj.TimeStamp);
                return val;
            });
            var priceHistoryBlock = new TransformBlock<IRecord, price_history>(x => {

                var dobj = (PriceHistoryRecord)x;
                var val = new price_history(dobj.ProductId, dobj.obHistoryType, dobj.obDate, dobj.obPrice, dobj.obShipping, dobj.TimeStamp);
                return val;
            });
            var productBlock = new TransformBlock<IRecord, product>(x =>
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
            var sellerBlock = new TransformBlock<IRecord, seller>(x => {

                var dobj = (SellerRecord)x;
                var val = new seller(dobj.SellerUid, dobj.DomainId, dobj.TrackingSince, dobj.LastUpdate, dobj.SellerId, dobj.SellerName, dobj.IsScammer, dobj.HasFba,
                    dobj.TotalStoreFrontAsinRecTime, dobj.TotalStoreFrontAsins, dobj.Rating, dobj.RatingTime, dobj.RatingCount, dobj.RatingCountTime, dobj.TimeStamp);
                return val;
            });
            var sellerItemBlock = new TransformBlock<IRecord, sellers_listed_items>(x => {

                var dobj = (SellerItemRecord)x;
                var val = new sellers_listed_items(dobj.AssociatedSeller, dobj.Asin, dobj.AsinLastSeen, dobj.TimeStamp);
                return val;
            });
            var statisticsBlock = new TransformBlock<IRecord, statistic>(x => {

                var dobj = (StatisticsRecord)x;
                var val = new statistic(dobj.ProductId, dobj.StatType, dobj.Current, dobj.Avg, dobj.Avg30, dobj.Avg90, dobj.Avg180, dobj.AtIntervalStart, dobj.MinPriceType, dobj.MinPriceRecTime,
                    dobj.MinPriceValue, dobj.MaxPriceType, dobj.MaxPriceRecTime, dobj.MaxPriceValue, dobj.IntervalMinPriceType, dobj.IntervalMinPriceRecTime, dobj.IntervalMinPriceValue,
                    dobj.IntervalMaxPriceType, dobj.IntervalMaxPriceRecTime, dobj.IntervalMaxPriceValue, dobj.OutOfStockPercentageInInterval, dobj.OutOfStockPercentage30, dobj.OutOfStockPercentage90,
                    dobj.LastOffersUpdate, dobj.TotalOffersCount, dobj.LightningDealInfo, dobj.RetrievedOfferCount, dobj.BuyBoxPrice, dobj.BuyBoxShipping, dobj.BuyBoxIsUnqualified,
                    dobj.BuyBoxIsShippable, dobj.BuyBoxIsPreorder, dobj.BuyBoxIsFba, dobj.BuyBoxIsAmazon, dobj.BuyBoxIsMap, dobj.BuyBoxIsUsed, dobj.SellerIdsLowestFba, dobj.SellerIdsLowestFbm,
                    dobj.OfferCountFba, dobj.OfferCountFbm, dobj.TimeStamp);
                return val;
            });
            var upcBlock = new TransformBlock<IRecord, upc>(x => {

                var dobj = (UpcRecord)x;
                var val = new upc(dobj.ProductId, dobj.UpcNumber, dobj.TimeStamp);
                return val;
            });
            var variationBlock = new TransformBlock<IRecord, variation>(x => {

                var dobj = (VariationRecord)x;
                var val = new variation(dobj.productId, dobj.Variation, dobj.vDimension, dobj.vValue, dobj.TimeStamp);
                return val;
            });

            //set up links using propogate oncompletion and appropriate filters
            broadcast.LinkTo(bestSellerBlock, opts, BestSellerFilter);
            broadcast.LinkTo(categoryBlock, opts, CategoryFilter);
            broadcast.LinkTo(eanBlock, opts, EanFilter);
            broadcast.LinkTo(fbaFeesBlock, opts, FbaFeesFilter);
            broadcast.LinkTo(featuresBlock, opts, FeatureFilter);
            broadcast.LinkTo(freqBoughtBlock, opts, FreqBoughtTogetherFilter);
            broadcast.LinkTo(languagesBlock, opts, LanguageFilter);
            broadcast.LinkTo(mostRatedSellerBlock, opts, MRSFilter);
            broadcast.LinkTo(priceHistoryBlock, opts, PriceHistoryFilter);
            broadcast.LinkTo(productBlock, opts, ProductFilter);
            broadcast.LinkTo(sellerBlock, opts, SellerFilter);
            broadcast.LinkTo(sellerItemBlock, opts, SLIFilter);
            broadcast.LinkTo(statisticsBlock, opts, StatisticsFilter);
            broadcast.LinkTo(upcBlock, opts, UpcFilter);
            broadcast.LinkTo(variationBlock, opts, VariationFilter);

            //attach transforms to buffer
            bestSellerBlock.LinkTo(this.bestSellerBlock, opts);
            categoryBlock.LinkTo(this.categoryBlock, opts);
            eanBlock.LinkTo(this.eanBlock, opts);
            fbaFeesBlock.LinkTo(this.fbaFeesBlock, opts);
            featuresBlock.LinkTo(this.featuresBlock, opts);
            freqBoughtBlock.LinkTo(this.freqBoughtBlock, opts);
            languagesBlock.LinkTo(this.languagesBlock, opts);
            mostRatedSellerBlock.LinkTo(this.mostRatedSellerBlock, opts);
            priceHistoryBlock.LinkTo(this.priceHistoryBlock, opts);
            productBlock.LinkTo(this.productBlock, opts);
            sellerBlock.LinkTo(this.sellerBlock, opts);
            sellerItemBlock.LinkTo(this.sellerItemBlock, opts);
            statisticsBlock.LinkTo(this.statisticsBlock, opts);
            upcBlock.LinkTo(this.upcBlock, opts);
            variationBlock.LinkTo(this.variationBlock, opts);
        }

    }
}
