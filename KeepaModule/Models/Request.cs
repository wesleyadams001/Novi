using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule;
using XModule.Interfaces;
using KeepaModule.Tools;
using static XModule.Constants.Enums;
using System.ComponentModel;
using System.Collections.ObjectModel;
using XModule.Tools;

namespace KeepaModule.Models
{
    /// <summary>
    /// Keepa request class inherits from IKeepaRequest 
    /// </summary>
    public class KeepaRequest : IKeepaRequest
    {
        protected string accessKey;
        protected string baseUrl;
        protected string postData;
        protected string path;
        public Dictionary<string, string> parameter;
        protected ObservableCollection<Pair<string, object>> list { get; set; }
        protected KeepaRequest request { get; set; }
        protected string requestString { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public KeepaRequest()
        {
            parameter = new Dictionary<string, string>(20);
        }

        public ApiSpecificRequestTypes KeepaRequestType { get; set; }
        public RequestTypes RequestType { get; set; }

        /// <summary>
        /// The base of the Request class
        /// </summary>
        /// <param name="reqType"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        protected KeepaRequest GetBaseRequest(ApiSpecificRequestTypes reqType, string path)
        {
            KeepaRequest r = new KeepaRequest();
            r.RequestType = RequestTypes.Keepa;
            r.KeepaRequestType = reqType;
            r.path = path;
            return r;
        }

        /// <summary>
        /// Adds Parameters to a request
        /// </summary>
        /// <param name="paramsList"></param>
        protected void AddParams(ObservableCollection<Pair<string,object>> paramsList)
        {
            this.list = paramsList;
        }

        /// <summary>
        /// Creates a request 
        /// </summary>
        /// <returns></returns>
        public virtual string CreateRequest()
        {
            return null;
        }

        /// <summary>
        /// Gets the string builder 
        /// </summary>
        /// <returns></returns>
        protected virtual StringBuilder GetStringBuilder()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.baseUrl);
            sb.Append(this.path);
            sb.Append("?key=");
            sb.Append(this.accessKey);
            sb.Append("&"); 
            return sb;
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

    /// <summary>
    /// A Get Tracking Get Request Object
    /// </summary>
    public class GetTrackingGetRequest : KeepaRequest
    {
        public GetTrackingGetRequest(string accessKey, ObservableCollection<Pair<string, object>> listParams)
        {
            this.accessKey = accessKey;
            this.list = listParams;
        }

        public override string CreateRequest()
        {
            var numValues = this.list.Count;
            this.request = getTrackingGetRequest(this.list.ElementAt(numValues-1));
            var sb = GetStringBuilder();
            this.requestString = sb.ToString();
            return this.requestString;
        }

        [Tag]
        private KeepaRequest getTrackingGetRequest(object p1)
        {
            var asin = (string)p1;

            KeepaRequest r = base.GetBaseRequest(ApiSpecificRequestTypes.KEEPA_TRACKING_GET, "tracking");
            r.parameter.Add("type", "get");
            r.parameter.Add("asin", asin);
            return r;
        }

        protected override StringBuilder GetStringBuilder()
        {
            StringBuilder sb = base.GetStringBuilder();
            sb.Append(Tools.Utilities.getQueryString(this.parameter));
            return sb;
        }
    }

    /// <summary>
    /// A Get Tracking List Request Object
    /// </summary>
    public class GetTrackingListRequest : KeepaRequest
    {
        public GetTrackingListRequest(string accessKey, ObservableCollection<Pair<string, object>> listParams)
        {
            this.accessKey = accessKey;
            this.list = listParams;
        }

        public override string CreateRequest()
        {
            var numValues = this.list.Count;
            this.request = getTrackingListRequest(this.list.ElementAt(numValues - 1));
            var sb = GetStringBuilder();
            this.requestString = sb.ToString();
            return this.requestString;
        }

        [Tag]
        private KeepaRequest getTrackingListRequest(object p1)
        {
            var asinsOnly = (bool)p1;

            KeepaRequest r = base.GetBaseRequest(ApiSpecificRequestTypes.KEEPA_TRACKING_LIST, "tracking");
            r.parameter.Add("type", "list");
            if (asinsOnly)
                r.parameter.Add("asins-only", "1");
            return r;
        }

        protected override StringBuilder GetStringBuilder()
        {
            StringBuilder sb = base.GetStringBuilder();
            sb.Append(Tools.Utilities.getQueryString(this.parameter));
            return sb;
        }

    }

    /// <summary>
    /// A Get Tracking Notification Request Object
    /// </summary>
    public class GetTrackingNotificationRequest : KeepaRequest
    {
        public GetTrackingNotificationRequest(string accessKey, ObservableCollection<Pair<string, object>> listParams)
        {
            this.accessKey = accessKey;
            this.list = listParams;
        }

        public override string CreateRequest()
        {
            var numValues = this.list.Count;
            this.request = getTrackingNotificationRequest(this.list.ElementAt(numValues - 1), this.list.ElementAt(numValues -2));
            var sb = GetStringBuilder();
            this.requestString = sb.ToString();
            return this.requestString;
        }

        [Tag]
        private KeepaRequest getTrackingNotificationRequest(object p1, object p2)
        {
            var since = (int)p1;
            var revise = (bool)p2;

            KeepaRequest r = base.GetBaseRequest(ApiSpecificRequestTypes.KEEPA_TRACKING_NOTIFICATION, "tracking");
            r.parameter.Add("since", since.ToString());
            r.parameter.Add("revise", revise ? "1" : "0");
            r.parameter.Add("type", "notification");
            return r;
        }

        protected override StringBuilder GetStringBuilder()
        {
            StringBuilder sb = base.GetStringBuilder();
            sb.Append(Tools.Utilities.getQueryString(this.parameter));
            return sb;
        }
    }

    /// <summary>
    /// A Get Tracking Remove Request object
    /// </summary>
    public class GetTrackingRemoveRequest : KeepaRequest
    {
        public GetTrackingRemoveRequest(string accessKey, ObservableCollection<Pair<string, object>> listParams)
        {
            this.accessKey = accessKey;
            this.list = listParams;
        }

        public override string CreateRequest()
        {
            var numValues = this.list.Count;
            this.request = getTrackingRemoveRequest(this.list.ElementAt(numValues - 1));
            var sb = GetStringBuilder();
            this.requestString = sb.ToString();
            return this.requestString;
        }

        [Tag]
        private KeepaRequest getTrackingRemoveRequest(object p1)
        {
            var asin = (string)p1;

            KeepaRequest r = base.GetBaseRequest(ApiSpecificRequestTypes.KEEPA_TRACKING_REMOVE, "tracking");
            r.parameter.Add("type", "remove");
            r.parameter.Add("asin", asin);
            return r;
        }

        protected override StringBuilder GetStringBuilder()
        {
            StringBuilder sb = base.GetStringBuilder();
            sb.Append(Tools.Utilities.getQueryString(this.parameter));
            return sb;
        }
    }

    /// <summary>
    /// A Get Tracking Remove all Request object
    /// </summary>
    public class GetTrackingRemoveAllRequest : KeepaRequest
    {
        public GetTrackingRemoveAllRequest(string accessKey, ObservableCollection<Pair<string, object>> listParams)
        {
            this.accessKey = accessKey;
            this.list = listParams;
        }

        public override string CreateRequest()
        {
            var numValues = this.list.Count;
            this.request = getTrackingRemoveAllRequest();
            var sb = GetStringBuilder();
            this.requestString = sb.ToString();
            return this.requestString;
        }

        [Tag]
        private KeepaRequest getTrackingRemoveAllRequest()
        {
            KeepaRequest r = base.GetBaseRequest(ApiSpecificRequestTypes.KEEPA_TRACKING_REMOVE_ALL, "tracking");
            r.parameter.Add("type", "removeAll");
            return r;
        }

        protected override StringBuilder GetStringBuilder()
        {
            StringBuilder sb = base.GetStringBuilder();
            sb.Append(Tools.Utilities.getQueryString(this.parameter));
            return sb;
        }
    }

    /// <summary>
    /// A Get Tracking WebHook Request object
    /// </summary>
    public class GetTrackingWebHookRequest : KeepaRequest
    {
        public GetTrackingWebHookRequest(string accessKey, ObservableCollection<Pair<string, object>> listParams)
        {
            this.accessKey = accessKey;
            this.list = listParams;
        }

        public override string CreateRequest()
        {
            var numValues = this.list.Count;
            this.request = getTrackingWebHookRequest(this.list.ElementAt(numValues - 1));
            var sb = GetStringBuilder();
            this.requestString = sb.ToString();
            return this.requestString;
        }

        [Tag]
        private KeepaRequest getTrackingWebHookRequest(object p1)
        {
            var url = (string)p1;

            KeepaRequest r = base.GetBaseRequest(ApiSpecificRequestTypes.KEEPA_TRACKING_WEB_HOOK, "tracking");
            r.parameter.Add("type", "webhook");
            r.parameter.Add("url", url);
            return r;
        }

        protected override StringBuilder GetStringBuilder()
        {
            StringBuilder sb = base.GetStringBuilder();
            sb.Append(Tools.Utilities.getQueryString(this.parameter));
            return sb;
        }
    }

    /// <summary>
    /// A Get best sellers request object
    /// </summary>
    public class GetBestSellersRequest : KeepaRequest
    {
        public GetBestSellersRequest(string accessKey, ObservableCollection<Pair<string, object>> listParams)
        {
            this.accessKey = accessKey;
            this.list = listParams;
        }

        public override string CreateRequest()
        {
            var numValues = this.list.Count;
            this.request = getBestSellersRequest(this.list.ElementAt(numValues - 1), this.list.ElementAt(numValues - 2));
            var sb = GetStringBuilder();
            this.requestString = sb.ToString();
            return this.requestString;
        }

        [Tag]
        private KeepaRequest getBestSellersRequest(object p1, object p2)
        {
            var domainId = (AmazonLocale)p1;
            var productGroup = (string)p2;

            KeepaRequest r = base.GetBaseRequest(ApiSpecificRequestTypes.KEEPA_BEST_SELLERS, "bestsellers");
            r.parameter.Add("category", productGroup);
            r.parameter.Add("domain", domainId.ToString("D"));
            return r;
        }

        protected override StringBuilder GetStringBuilder()
        {
            StringBuilder sb = base.GetStringBuilder();
            sb.Append(Tools.Utilities.getQueryString(this.parameter));
            return sb;
        }
    }

    /// <summary>
    /// A get category lookup request object
    /// </summary>
    public class GetCategoryLookupRequest : KeepaRequest
    {
        public GetCategoryLookupRequest(string accessKey, ObservableCollection<Pair<string, object>> listParams)
        {
            this.accessKey = accessKey;
            this.list = listParams;
        }

        public override string CreateRequest()
        {
            var numValues = this.list.Count;
            this.request = getCategoryLookupRequest(this.list.ElementAt(numValues - 1), this.list.ElementAt(numValues - 2), this.list.ElementAt(numValues - 3));
            var sb = GetStringBuilder();
            this.requestString = sb.ToString();
            return this.requestString;
        }

        [Tag]
        private KeepaRequest getCategoryLookupRequest(object p1, object p2, object p3)
        {
            var domainId = (AmazonLocale)p1;
            var parents = (bool)p2;
            var category = (long)p3;

            KeepaRequest r = base.GetBaseRequest(ApiSpecificRequestTypes.KEEPA_CATEGORY_LOOKUP, "category");
            r.parameter.Add("category", category.ToString());
            r.parameter.Add("domain", domainId.ToString("D"));

            if (parents)
                r.parameter.Add("parents", "1");
            return r;
        }

        protected override StringBuilder GetStringBuilder()
        {
            StringBuilder sb = base.GetStringBuilder();
            sb.Append(Tools.Utilities.getQueryString(this.parameter));
            return sb;
        }
    }


    /// <summary>
    /// A get category search request object
    /// </summary>
    public class GetCategorySearchRequest : KeepaRequest
    {
        public GetCategorySearchRequest(string accessKey, ObservableCollection<Pair<string, object>> listParams)
        {
            this.accessKey = accessKey;
            this.list = listParams;
        }

        public override string CreateRequest()
        {
            var numValues = this.list.Count;
            this.request = getCategorySearchRequest(this.list.ElementAt(numValues - 1), this.list.ElementAt(numValues - 2), this.list.ElementAt(numValues - 3));
            var sb = GetStringBuilder();
            this.requestString = sb.ToString();
            return this.requestString;
        }

        [Tag]
        private KeepaRequest getCategorySearchRequest(object p1, object p2, object p3)
        {
            var domainId = (AmazonLocale)p1;
            var term = (string)p2;
            var parents = (bool)p3;

            KeepaRequest r = base.GetBaseRequest(ApiSpecificRequestTypes.KEEPA_CATEGORY_SEARCH, "search");
            r.parameter.Add("domain", domainId.ToString("D"));
            r.parameter.Add("type", "category");
            r.parameter.Add("term", term);

            if (parents)
                r.parameter.Add("parents", "1");
            return r;
        }

        protected override StringBuilder GetStringBuilder()
        {
            StringBuilder sb = base.GetStringBuilder();
            sb.Append(Tools.Utilities.getQueryString(this.parameter));
            return sb;
        }
    }

    /// <summary>
    /// A get seller request object
    /// </summary>
    public class GetSellerRequest : KeepaRequest
    {
        public GetSellerRequest(string accessKey, ObservableCollection<Pair<string, object>> listParams)
        {
            this.accessKey = accessKey;
            this.list = listParams;
        }

        public override string CreateRequest()
        {
            var numValues = this.list.Count;
            switch (numValues)
            {
                case 2:
                    this.request = getSellerRequest(this.list.ElementAt(numValues - 1), this.list.ElementAt(numValues - 2));
                    break;
                case 3:
                    this.request = getSellerRequest(this.list.ElementAt(numValues - 1), this.list.ElementAt(numValues - 2), this.list.ElementAt(numValues - 3));
                    break;
                case 4:
                    this.request = getSellerRequest(this.list.ElementAt(numValues - 1), this.list.ElementAt(numValues - 2), this.list.ElementAt(numValues - 3), this.list.ElementAt(numValues - 4));

                    break;
            }
            
            var sb = GetStringBuilder();
            this.requestString = sb.ToString();
            return this.requestString;
        }

        [Tag]
        private KeepaRequest getSellerRequest(object p1, object p2)
        {
            var domainId = (AmazonLocale)p1;
            var seller = (string[])p2;

            KeepaRequest r = base.GetBaseRequest(ApiSpecificRequestTypes.KEEPA_SELLER, "seller");
            r.parameter.Add("domain", domainId.ToString("D"));
            r.parameter.Add("seller", Tools.Utilities.arrayToCsv(seller));
            return r;
        }

        
        [Tag]
        private KeepaRequest getSellerRequest(object p1, object p2, object p3)
        {
            var domainId = (AmazonLocale)p1;
            var seller = (string)p2;
            var storefront = (bool)p3;

            KeepaRequest r = base.GetBaseRequest(ApiSpecificRequestTypes.KEEPA_SELLER, "seller");
            r.parameter.Add("domain", domainId.ToString("D"));
            r.parameter.Add("seller", seller);

            if (storefront)
                r.parameter.Add("storefront", "1");
            return r;
        }

        [Tag]
        private KeepaRequest getSellerRequest(object p1, object p2, object p3, object p4)
        {
            var domainId = (AmazonLocale)p1;
            var seller = (string)p2;
            var storefront = (bool)p3;
            var update = (int)p4;

            KeepaRequest r = base.GetBaseRequest(ApiSpecificRequestTypes.KEEPA_SELLER, "seller");
            r.parameter.Add("domain", domainId.ToString("D"));
            r.parameter.Add("seller", seller);
            if (update >= 0)
                r.parameter.Add("update", update.ToString());

            if (storefront || update >= 0)
                r.parameter.Add("storefront", "1");
            return r;
        }

        protected override StringBuilder GetStringBuilder()
        {
            StringBuilder sb = base.GetStringBuilder();
            sb.Append(Tools.Utilities.getQueryString(this.parameter));
            return sb;
        }
    }

    /// <summary>
    /// A get top seller request object
    /// </summary>
    public class GetTopSellerRequest : KeepaRequest
    {
        public GetTopSellerRequest(string accessKey, ObservableCollection<Pair<string, object>> listParams)
        {
            this.accessKey = accessKey;
            this.list = listParams;
        }

        public override string CreateRequest()
        {
            var numValues = this.list.Count;
            switch (numValues)
            {
                case 1:
                    this.request = getTopSellerRequest(this.list.ElementAt(numValues - 1));
                    break;
               
            }

            var sb = GetStringBuilder();
            this.requestString = sb.ToString();
            return this.requestString;
        }

        [Tag]
        private KeepaRequest getTopSellerRequest(object p1)
        {
            var domainId = (AmazonLocale)p1;

            KeepaRequest r = base.GetBaseRequest(ApiSpecificRequestTypes.KEEPA_TOP_SELLER, "topseller");
            r.parameter.Add("domain", domainId.ToString("D"));
            return r;
        }

        protected override StringBuilder GetStringBuilder()
        {
            StringBuilder sb = base.GetStringBuilder();
            sb.Append(Tools.Utilities.getQueryString(this.parameter));
            return sb;
        }
    }

    /// <summary>
    /// A Get Product search request 
    /// </summary>
    public class GetProductSearchRequest : KeepaRequest
    {
        public GetProductSearchRequest(string accessKey, ObservableCollection<Pair<string, object>> listParams)
        {
            this.accessKey = accessKey;
            this.list = listParams;
        }

        public override string CreateRequest()
        {
            var numValues = this.list.Count;
            switch (numValues)
            {
                case 3:
                    this.request = getProductSearchRequest(this.list.ElementAt(numValues - 1), this.list.ElementAt(numValues - 2), this.list.ElementAt(numValues - 3));
                    break;
                case 6:
                    this.request = getProductSearchRequest(this.list.ElementAt(numValues - 1), this.list.ElementAt(numValues - 2), this.list.ElementAt(numValues - 3), this.list.ElementAt(numValues - 4), this.list.ElementAt(numValues - 5), this.list.ElementAt(numValues - 6));
                    break;

            }

            var sb = GetStringBuilder();
            this.requestString = sb.ToString();
            return this.requestString;
        }

        [Tag]
        private KeepaRequest getProductSearchRequest(object p1, object p2, object p3)
        {
            var domainId = (AmazonLocale)p1;
            var term = (string)p2;
            var stats = (int?)p3;

            KeepaRequest r = base.GetBaseRequest(ApiSpecificRequestTypes.KEEPA_PRODUCT_SEARCH, "search");
            r.parameter.Add("domain", domainId.ToString("D"));
            r.parameter.Add("type", "product");
            r.parameter.Add("term", term);

            if (stats != null && stats > 0)
                r.parameter.Add("stats", stats.ToString());
            return r;
        }

        [Tag]
        private KeepaRequest getProductSearchRequest(object p1, object p2, object p3, object p4, object p5, object p6)
        {
            var domainId = (AmazonLocale)p1;
            var term = (string)p2;
            var stats = (int?)p3;
            var update = (int?)p4;
            var history = (bool)p5;
            var asinsOnly = (bool)p6;

            KeepaRequest r = base.GetBaseRequest(ApiSpecificRequestTypes.KEEPA_PRODUCT_SEARCH, "search");
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

        protected override StringBuilder GetStringBuilder()
        {
            StringBuilder sb = base.GetStringBuilder();
            sb.Append(Tools.Utilities.getQueryString(this.parameter));
            return sb;
        }
    }

    /// <summary>
    /// A Get product request 
    /// </summary>
    public class GetProductRequest : KeepaRequest
    {
        public GetProductRequest(string accessKey, ObservableCollection<Pair<string, object>> listParams)
        {
            this.accessKey = accessKey;
            this.list = listParams;
        }

        public override string CreateRequest()
        {
            var numValues = this.list.Count;
            switch (numValues)
            {
                case 4:
                    this.request = getProductRequest(this.list.ElementAt(numValues - 1), this.list.ElementAt(numValues - 2), this.list.ElementAt(numValues - 3), this.list.ElementAt(numValues - 4));
                    break;
                case 7:
                    this.request = getProductRequest(this.list.ElementAt(numValues - 1), this.list.ElementAt(numValues - 2), this.list.ElementAt(numValues - 3), this.list.ElementAt(numValues - 4), this.list.ElementAt(numValues - 5), this.list.ElementAt(numValues - 6), this.list.ElementAt(numValues - 7));
                    break;

            }

            var sb = GetStringBuilder();
            this.requestString = sb.ToString();
            return this.requestString;
        }

        [Tag]
        private KeepaRequest getProductRequest(object p1, object p2, object p3, object p4)
        {
            var domainId = (AmazonLocale)p1;
            var stats = (int?)p2;
            var offers = (int?)p3;
            var asins = (string[])p4;

            KeepaRequest r = base.GetBaseRequest(ApiSpecificRequestTypes.KEEPA_PRODUCT, "product");
            r.parameter.Add("domain", domainId.ToString("D"));
            r.parameter.Add("asin", Tools.Utilities.arrayToCsv(asins));
            if (stats != null && stats > 0)
                r.parameter.Add("stats", stats.ToString());

            if (offers != null && offers > 0)
                r.parameter.Add("offers", offers.ToString());
            return r;
        }

        [Tag]
        private KeepaRequest getProductRequest(object p1, object p2, object p3, object p4, object p5, object p6, object p7)
        {
            var domainId = (AmazonLocale)p1;
            var offers = (int?)p2;
            var statsStartDate = (string)p3;
            var statsEndDate = (string)p4;
            var update = (int)p5;
            var history = (bool)p6;
            var asins = (string[])p7;

            KeepaRequest r = base.GetBaseRequest(ApiSpecificRequestTypes.KEEPA_PRODUCT, "product");
            r.parameter.Add("asin", Tools.Utilities.arrayToCsv(asins));
            r.parameter.Add("domain", domainId.ToString("D"));
            r.parameter.Add("update", update.ToString());
            r.parameter.Add("history", history ? "1" : "0");

            if (statsStartDate != null && statsEndDate != null)
                r.parameter.Add("stats", statsStartDate + "," + statsEndDate);

            if (offers != null && offers > 0)
                r.parameter.Add("offers", offers.ToString());
            return r;
        }

        protected override StringBuilder GetStringBuilder()
        {
            StringBuilder sb = base.GetStringBuilder();
            sb.Append(Tools.Utilities.getQueryString(this.parameter));
            return sb;
        }
    }

    /// <summary>
    /// A Get Product by Code Request
    /// </summary>
    public class GetProductByCodeRequest : KeepaRequest
    {
        public GetProductByCodeRequest(string accessKey, ObservableCollection<Pair<string, object>> listParams)
        {
            this.accessKey = accessKey;
            this.list = listParams;
        }

        public override string CreateRequest()
        {
            var numValues = this.list.Count;
            switch (numValues)
            {
                case 4:
                    this.request = getProductByCodeRequest(this.list.ElementAt(numValues - 1), this.list.ElementAt(numValues - 2), this.list.ElementAt(numValues - 3), this.list.ElementAt(numValues - 4));
                    break;
                case 7:
                    this.request = getProductByCodeRequest(this.list.ElementAt(numValues - 1), this.list.ElementAt(numValues - 2), this.list.ElementAt(numValues - 3), this.list.ElementAt(numValues - 4), this.list.ElementAt(numValues - 5), this.list.ElementAt(numValues - 6), this.list.ElementAt(numValues - 7));
                    break;
                case 11:
                    this.request = getProductByCodeRequest(this.list.ElementAt(numValues - 1), this.list.ElementAt(numValues - 2), this.list.ElementAt(numValues - 3), this.list.ElementAt(numValues - 4), this.list.ElementAt(numValues - 5), this.list.ElementAt(numValues - 6), this.list.ElementAt(numValues - 7), this.list.ElementAt(numValues - 8), this.list.ElementAt(numValues - 9), this.list.ElementAt(numValues - 9), this.list.ElementAt(numValues - 10));
                    break;

            }

            var sb = GetStringBuilder();
            this.requestString = sb.ToString();
            return this.requestString;
        }

        [Tag]
        private KeepaRequest getProductByCodeRequest(object p1, object p2, object p3, object p4)
        {
            var domainId = (AmazonLocale)p1;
            var stats = (int?)p2;
            var offers = (int?)p3;
            var codes = (string[])p4;

            KeepaRequest r = base.GetBaseRequest(ApiSpecificRequestTypes.KEEPA_PRODUCT_BY_CODE, "product");
            r.parameter.Add("code", Tools.Utilities.arrayToCsv(codes));
            r.parameter.Add("domain", domainId.ToString("D"));
            if (stats != null && stats > 0)
                r.parameter.Add("stats", stats.ToString());

            if (offers != null && offers > 0)
                r.parameter.Add("offers", offers.ToString());
            return r;
        }

        [Tag]
        private KeepaRequest getProductByCodeRequest(object p1, object p2, object p3, object p4, object p5, object p6, object p7)
        {
            var domainId = (AmazonLocale)p1;
            var offers = (int?)p2;
            var statsStartDate = (string)p3;
            var statsEndDate = (string)p4;
            var update = (int)p5;
            var history = (bool)p6;
            var codes = (string[])p7;

            KeepaRequest r = base.GetBaseRequest(ApiSpecificRequestTypes.KEEPA_PRODUCT_BY_CODE, "product");
            r.parameter.Add("code", Tools.Utilities.arrayToCsv(codes));
            r.parameter.Add("domain", domainId.ToString("D"));
            r.parameter.Add("update", update.ToString());
            r.parameter.Add("history", history ? "1" : "0");

            if (statsStartDate != null && statsEndDate != null)
                r.parameter.Add("stats", statsStartDate + "," + statsEndDate);

            if (offers != null && offers > 0)
                r.parameter.Add("offers", offers.ToString());
            return r;
        }

        [Tag]
        private KeepaRequest getProductByCodeRequest(object p1, object p2, object p3, object p4, object p5, object p6, object p7, object p8, object p9, object p10, object p11)
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

            KeepaRequest r = base.GetBaseRequest(ApiSpecificRequestTypes.KEEPA_PRODUCT_BY_CODE, "product");
            r.parameter.Add("code", Tools.Utilities.arrayToCsv(codes));
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

        /// <summary>
        /// Gets the String builder
        /// </summary>
        /// <returns></returns>
        protected override StringBuilder GetStringBuilder()
        {
            StringBuilder sb = base.GetStringBuilder();
            sb.Append(Tools.Utilities.getQueryString(this.parameter));
            return sb;
        }
    }
}
