using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Interfaces;
using XModule.Tools;
using static XModule.Constants.Enums;

namespace KeepaModule.Models
{
    /// <summary>
    /// Keepa request class inherits from IKeepaRequest 
    /// </summary>
    public class KeepaRequest : IKeepaRequest
    {
        public string postData;
        public string path;
        public Dictionary<string, string> parameter;

        /// <summary>
        /// Default constructor
        /// </summary>
        public KeepaRequest()
        {
            parameter = new Dictionary<string, string>(20);
        }

        public ApiSpecificRequestTypes KeepaRequestType { get; set; }
        public RequestTypes RequestType { get; set; }

        public string GetName()
        {
            var type = this.GetType();
            string x = type.Name;
            return x;
        }
        /// <summary>
        /// Request to string method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    //public class GetDealsRequest : KeepaRequest
    //{

    //    public IRequest getDealsRequest(object p1)
    //    {
    //        var dealRequest = (DealRequest)p1;

    //        KeepaRequest r = new KeepaRequest();
    //        r.RequestType = RequestTypes.Keepa;
    //        r.KeepaRequestType = ApiSpecificRequestTypes.KEEPA_DEALS_REQUEST;
    //        r.path = "deal";
    //        r.postData = JsonConvert.SerializeObject(dealRequest);
    //        return r;

    //    }
    //}

    //public class GetProductFinderRequest : KeepaRequest
    //{

    //    public IRequest getProductFinderRequest(object p1, object p2)
    //    {
    //        var domainId = (AmazonLocale)p1;
    //        var finderRequest = (ProductFinderRequest)p1;

    //        KeepaRequest r = new KeepaRequest();
    //        r.RequestType = RequestTypes.Keepa;
    //        r.KeepaRequestType = ApiSpecificRequestTypes.KEEPA_PRODUCT_FINDER;
    //        r.path = "query";
    //        r.parameter.Add("domain", domainId.ToString());
    //        r.parameter.Add("selection", JsonConvert.SerializeObject(finderRequest));
    //        return r;

    //    }

    //}
    public class GetTrackingGetRequest : KeepaRequest
    {

        public IRequest getTrackingGetRequest(object p1)
        {
            var asin = (string)p1;

            KeepaRequest r = new KeepaRequest();
            r.RequestType = RequestTypes.Keepa;
            r.KeepaRequestType = ApiSpecificRequestTypes.KEEPA_TRACKING_GET;
            r.path = "tracking";
            r.parameter.Add("type", "get");
            r.parameter.Add("asin", asin);
            return r;
        }
    }
    public class GetTrackingListRequest : KeepaRequest
    {

        public IRequest getTrackingListRequest(object p1)
        {
            var asinsOnly = (bool)p1;

            KeepaRequest r = new KeepaRequest();
            r.RequestType = RequestTypes.Keepa;
            r.KeepaRequestType = ApiSpecificRequestTypes.KEEPA_TRACKING_LIST;
            r.path = "tracking";
            r.parameter.Add("type", "list");
            if (asinsOnly)
                r.parameter.Add("asins-only", "1");
            return r;
        }

    }
    public class GetTrackingNotificationRequest : KeepaRequest
    {

        public IRequest getTrackingNotificationRequest(object p1, object p2)
        {
            var since = (int)p1;
            var revise = (bool)p2;

            KeepaRequest r = new KeepaRequest();
            r.RequestType = RequestTypes.Keepa;
            r.KeepaRequestType = ApiSpecificRequestTypes.KEEPA_TRACKING_NOTIFICATION;
            r.path = "tracking";
            r.parameter.Add("since", since.ToString());
            r.parameter.Add("revise", revise ? "1" : "0");
            r.parameter.Add("type", "notification");
            return r;
        }
    }
    public class GetTrackingRemoveRequest : KeepaRequest
    {

        public IRequest getTrackingRemoveRequest(object p1)
        {
            var asin = (string)p1;

            KeepaRequest r = new KeepaRequest();
            r.RequestType = RequestTypes.Keepa;
            r.KeepaRequestType = ApiSpecificRequestTypes.KEEPA_TRACKING_REMOVE;
            r.path = "tracking";
            r.parameter.Add("type", "remove");
            r.parameter.Add("asin", asin);
            return r;
        }
    }
    public class GetTrackingRemoveAllRequest : KeepaRequest
    {

        public IRequest getTrackingRemoveAllRequest()
        {
            KeepaRequest r = new KeepaRequest();
            r.RequestType = RequestTypes.Keepa;
            r.KeepaRequestType = ApiSpecificRequestTypes.KEEPA_TRACKING_REMOVE_ALL;
            r.path = "tracking";
            r.parameter.Add("type", "removeAll");
            return r;
        }
    }
    public class GetTrackingWebHookRequest : KeepaRequest
    {

        public IRequest getTrackingWebHookRequest(object p1)
        {
            var url = (string)p1;

            KeepaRequest r = new KeepaRequest();
            r.RequestType = RequestTypes.Keepa;
            r.KeepaRequestType = ApiSpecificRequestTypes.KEEPA_TRACKING_WEB_HOOK;
            r.path = "tracking";
            r.parameter.Add("type", "webhook");
            r.parameter.Add("url", url);
            return r;
        }
    }
    public class GetBestSellersRequest : KeepaRequest
    {

        public IRequest getBestSellersRequest(object p1, object p2)
        {
            var domainId = (AmazonLocale)p1;
            var productGroup = (string)p2;

            KeepaRequest r = new KeepaRequest();
            r.RequestType = RequestTypes.Keepa;
            r.KeepaRequestType = ApiSpecificRequestTypes.KEEPA_BEST_SELLERS;
            r.path = "bestsellers";
            r.parameter.Add("category", productGroup);
            r.parameter.Add("domain", domainId.ToString("D"));
            return r;
        }
    }
    public class GetCategoryLookupRequest : KeepaRequest
    {

        public IRequest getCategoryLookupRequest(object p1, object p2, object p3)
        {
            var domainId = (AmazonLocale)p1;
            var parents = (bool)p2;
            var category = (long)p3;

            KeepaRequest r = new KeepaRequest();
            r.RequestType = RequestTypes.Keepa;
            r.KeepaRequestType = ApiSpecificRequestTypes.KEEPA_CATEGORY_LOOKUP;
            r.path = "category";
            r.parameter.Add("category", category.ToString());
            r.parameter.Add("domain", domainId.ToString("D"));

            if (parents)
                r.parameter.Add("parents", "1");
            return r;
        }
    }
    public class GetCategorySearchRequest : KeepaRequest
    {

        public IRequest getCategorySearchRequest(object p1, object p2, object p3)
        {
            var domainId = (AmazonLocale)p1;
            var term = (string)p2;
            var parents = (bool)p3;

            KeepaRequest r = new KeepaRequest();
            r.RequestType = RequestTypes.Keepa;
            r.KeepaRequestType = ApiSpecificRequestTypes.KEEPA_CATEGORY_SEARCH;
            r.path = "search";
            r.parameter.Add("domain", domainId.ToString("D"));
            r.parameter.Add("type", "category");
            r.parameter.Add("term", term);

            if (parents)
                r.parameter.Add("parents", "1");
            return r;
        }
    }
    public class GetSellerRequest : KeepaRequest
    {

        public IRequest getSellerRequest(object p1, object p2)
        {
            var domainId = (AmazonLocale)p1;
            var seller = (string[])p2;

            KeepaRequest r = new KeepaRequest();
            r.RequestType = RequestTypes.Keepa;
            r.KeepaRequestType = ApiSpecificRequestTypes.KEEPA_SELLER;
            r.path = "seller";
            r.parameter.Add("domain", domainId.ToString("D"));
            r.parameter.Add("seller", Utilities.arrayToCsv(seller));
            return r;
        }
        public IRequest getSellerRequest(object p1, object p2, object p3)
        {
            var domainId = (AmazonLocale)p1;
            var seller = (string)p2;
            var storefront = (bool)p3;

            KeepaRequest r = new KeepaRequest();
            r.RequestType = RequestTypes.Keepa;
            r.KeepaRequestType = ApiSpecificRequestTypes.KEEPA_SELLER;
            r.path = "seller";
            r.parameter.Add("domain", domainId.ToString("D"));
            r.parameter.Add("seller", seller);

            if (storefront)
                r.parameter.Add("storefront", "1");
            return r;
        }
        public IRequest getSellerRequest(object p1, object p2, object p3, object p4)
        {
            var domainId = (AmazonLocale)p1;
            var seller = (string)p2;
            var storefront = (bool)p3;
            var update = (int)p4;

            KeepaRequest r = new KeepaRequest();
            r.RequestType = RequestTypes.Keepa;
            r.KeepaRequestType = ApiSpecificRequestTypes.KEEPA_SELLER;
            r.path = "seller";
            r.parameter.Add("domain", domainId.ToString("D"));
            r.parameter.Add("seller", seller);
            if (update >= 0)
                r.parameter.Add("update", update.ToString());

            if (storefront || update >= 0)
                r.parameter.Add("storefront", "1");
            return r;
        }
    }
    public class GetTopSellerRequest : KeepaRequest
    {

        public IRequest getTopSellerRequest(object p1)
        {
            var domainId = (AmazonLocale)p1;

            KeepaRequest r = new KeepaRequest();
            r.RequestType = RequestTypes.Keepa;
            r.KeepaRequestType = ApiSpecificRequestTypes.KEEPA_TOP_SELLER;
            r.path = "topseller";
            r.parameter.Add("domain", domainId.ToString("D"));
            return r;
        }
    }
    public class GetProductSearchRequest : KeepaRequest
    {

        public IRequest getProductSearchRequest(object p1, object p2, object p3)
        {
            var domainId = (AmazonLocale)p1;
            var term = (string)p2;
            var stats = (int?)p3;

            KeepaRequest r = new KeepaRequest();
            r.RequestType = RequestTypes.Keepa;
            r.KeepaRequestType = ApiSpecificRequestTypes.KEEPA_PRODUCT_SEARCH;
            r.path = "search";
            r.parameter.Add("domain", domainId.ToString("D"));
            r.parameter.Add("type", "product");
            r.parameter.Add("term", term);

            if (stats != null && stats > 0)
                r.parameter.Add("stats", stats.ToString());
            return r;
        }
        public IRequest getProductSearchRequest(object p1, object p2, object p3, object p4, object p5, object p6)
        {
            var domainId = (AmazonLocale)p1;
            var term = (string)p2;
            var stats = (int?)p3;
            var update = (int?)p4;
            var history = (bool)p5;
            var asinsOnly = (bool)p6;

            KeepaRequest r = new KeepaRequest();
            r.RequestType = RequestTypes.Keepa;
            r.KeepaRequestType = ApiSpecificRequestTypes.KEEPA_PRODUCT_SEARCH;
            r.path = "search";
            r.parameter.Add("domain", domainId.ToString("D"));
            r.parameter.Add("type", "product");
            r.parameter.Add("term", term);
            r.parameter.Add("update", update.ToString());
            r.parameter.Add("history", history ? "1" : "0");
            r.parameter.Add("asins-only", asinsOnly ? "1" : "0");

            if (stats != null && stats > 0)
                r.parameter.Add("stats", stats.ToString());
            return r;
        }
    }

    public class GetProductRequest : KeepaRequest
    {

        public IRequest getProductRequest(object p1, object p2, object p3, object p4)
        {
            var domainId = (AmazonLocale)p1;
            var stats = (int?)p2;
            var offers = (int?)p3;
            var asins = (string[])p4;

            KeepaRequest r = new KeepaRequest();
            r.RequestType = RequestTypes.Keepa;
            r.KeepaRequestType = ApiSpecificRequestTypes.KEEPA_PRODUCT;
            r.path = "product";
            r.parameter.Add("domain", domainId.ToString("D"));
            r.parameter.Add("asin", Utilities.arrayToCsv(asins));
            if (stats != null && stats > 0)
                r.parameter.Add("stats", stats.ToString());

            if (offers != null && offers > 0)
                r.parameter.Add("offers", offers.ToString());
            return r;
        }
        public IRequest getProductRequest(object p1, object p2, object p3, object p4, object p5, object p6, object p7)
        {
            var domainId = (AmazonLocale)p1;
            var offers = (int?)p2;
            var statsStartDate = (string)p3;
            var statsEndDate = (string)p4;
            var update = (int)p5;
            var history = (bool)p6;
            var asins = (string[])p7;

            KeepaRequest r = new KeepaRequest();
            r.RequestType = RequestTypes.Keepa;
            r.KeepaRequestType = ApiSpecificRequestTypes.KEEPA_PRODUCT;
            r.path = "product";
            r.parameter.Add("asin", Utilities.arrayToCsv(asins));
            r.parameter.Add("domain", domainId.ToString("D"));
            r.parameter.Add("update", update.ToString());
            r.parameter.Add("history", history ? "1" : "0");

            if (statsStartDate != null && statsEndDate != null)
                r.parameter.Add("stats", statsStartDate + "," + statsEndDate);

            if (offers != null && offers > 0)
                r.parameter.Add("offers", offers.ToString());
            return r;
        }
    }
    public class GetProductByCodeRequest : KeepaRequest
    {

        public IRequest getProductByCodeRequest(object p1, object p2, object p3, object p4)
        {
            var domainId = (AmazonLocale)p1;
            var stats = (int?)p2;
            var offers = (int?)p3;
            var codes = (string[])p4;

            KeepaRequest r = new KeepaRequest();
            r.RequestType = RequestTypes.Keepa;
            r.KeepaRequestType = ApiSpecificRequestTypes.KEEPA_PRODUCT_BY_CODE;
            r.path = "product";
            r.parameter.Add("code", Utilities.arrayToCsv(codes));
            r.parameter.Add("domain", domainId.ToString("D"));
            if (stats != null && stats > 0)
                r.parameter.Add("stats", stats.ToString());

            if (offers != null && offers > 0)
                r.parameter.Add("offers", offers.ToString());
            return r;
        }
        public IRequest getProductByCodeRequest(object p1, object p2, object p3, object p4, object p5, object p6, object p7)
        {
            var domainId = (AmazonLocale)p1;
            var offers = (int?)p2;
            var statsStartDate = (string)p3;
            var statsEndDate = (string)p4;
            var update = (int)p5;
            var history = (bool)p6;
            var codes = (string[])p7;

            KeepaRequest r = new KeepaRequest();
            r.RequestType = RequestTypes.Keepa;
            r.KeepaRequestType = ApiSpecificRequestTypes.KEEPA_PRODUCT_BY_CODE;
            r.path = "product";
            r.parameter.Add("code", Utilities.arrayToCsv(codes));
            r.parameter.Add("domain", domainId.ToString("D"));
            r.parameter.Add("update", update.ToString());
            r.parameter.Add("history", history ? "1" : "0");

            if (statsStartDate != null && statsEndDate != null)
                r.parameter.Add("stats", statsStartDate + "," + statsEndDate);

            if (offers != null && offers > 0)
                r.parameter.Add("offers", offers.ToString());
            return r;
        }
        public IRequest getProductByCodeRequest(object p1, object p2, object p3, object p4, object p5, object p6, object p7, object p8, object p9, object p10, object p11)
        {
            var domainId = (AmazonLocale)p1;
            var offers = (int?)p2;
            var statsStartDate = (string)p3;
            var statsEndDate = (string)p4;
            var update = (int)p5;
            var history = (bool)p6;
            var stock = (bool)p7;
            var rental = (bool)p8;
            var rating = (bool)p9;
            var fbafees = (bool)p10;
            var codes = (string[])p11;

            KeepaRequest r = new KeepaRequest();
            r.RequestType = RequestTypes.Keepa;
            r.KeepaRequestType = ApiSpecificRequestTypes.KEEPA_PRODUCT_BY_CODE;
            r.path = "product";
            r.parameter.Add("code", Utilities.arrayToCsv(codes));
            r.parameter.Add("domain", domainId.ToString("D"));
            r.parameter.Add("update", update.ToString());
            r.parameter.Add("history", history ? "1" : "0");
            r.parameter.Add("stock", stock ? "1" : "0");
            r.parameter.Add("rental", rental ? "1" : "0");
            r.parameter.Add("rating", rating ? "1" : "0");
            r.parameter.Add("fbafees", fbafees ? "1" : "0");

            if (statsStartDate != null && statsEndDate != null)
                r.parameter.Add("stats", statsStartDate + "," + statsEndDate);

            if (offers != null && offers > 0)
                r.parameter.Add("offers", offers.ToString());
            return r;
        }
    }
}
