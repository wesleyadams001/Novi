using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule;
using XModule.Interfaces;
using NtfsModule.Tools;
using static XModule.Constants.Enums;
using System.ComponentModel;
using System.Collections.ObjectModel;
using XModule.Tools;

namespace NtfsModule.Models
{
    /// <summary>
    /// Ntfs request class inherits from INtfsRequest 
    /// </summary>
    public class NtfsRequest : INtfsRequest
    {
        protected string accessKey;
        protected string baseUrl;
        protected string postData;
        protected string path;
        public Dictionary<string, string> parameter;
        protected List<object> list { get; set; }
        protected NtfsRequest request { get; set; }
        protected string requestString { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public NtfsRequest()
        {
            this.parameter = new Dictionary<string, string>(20);
            
        }

        public ApiSpecificRequestTypes NtfsRequestType { get; set; }
        public RequestTypes RequestType { get; set; }

        /// <summary>
        /// The base of the Request class
        /// </summary>
        /// <param name="reqType"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        protected NtfsRequest GetBaseRequest(ApiSpecificRequestTypes reqType, string path)
        {
            //NtfsRequest r = new NtfsRequest();
            this.RequestType = RequestTypes.Ntfs;
            this.NtfsRequestType = reqType;
            this.path = path;
            return this;
        }

        /// <summary>
        /// Strips out objects from the parameter list into a list of the appropriate parameters
        /// </summary>
        /// <param name="obsList"></param>
        protected void StripObjects(ObservableCollection<Pair<string, object>> obsList)
        {
            this.list = new List<object>();
            for(int x= 0; x< obsList.Count; x++)
            {
                this.list.Add(obsList.ElementAt(x).Second);
            }
        }

        /// <summary>
        /// Adds Parameters to a request
        /// </summary>
        /// <param name="paramsList"></param>
        protected void AddParams(ObservableCollection<Pair<string, object>> paramsList)
        {
            this.list = paramsList.Select(x=>x.Second).ToList();
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

    //public class GetDealsRequest : NtfsRequest
    //{

    //    public IRequest getDealsRequest(object p1)
    //    {
    //        var dealRequest = (DealRequest)p1;

    //        NtfsRequest r = new NtfsRequest();
    //        r.RequestType = RequestTypes.Ntfs;
    //        r.NtfsRequestType = ApiSpecificRequestTypes.Ntfs_DEALS_REQUEST;
    //        r.path = "deal";
    //        r.postData = JsonConvert.SerializeObject(dealRequest);
    //        return r;

    //    }
    //}

    //public class GetProductFinderRequest : NtfsRequest
    //{

    //    public IRequest getProductFinderRequest(object p1, object p2)
    //    {
    //        var domainId = (AmazonLocale)p1;
    //        var finderRequest = (ProductFinderRequest)p1;

    //        NtfsRequest r = new NtfsRequest();
    //        r.RequestType = RequestTypes.Ntfs;
    //        r.NtfsRequestType = ApiSpecificRequestTypes.Ntfs_PRODUCT_FINDER;
    //        r.path = "query";
    //        r.parameter.Add("domain", domainId.ToString());
    //        r.parameter.Add("selection", JsonConvert.SerializeObject(finderRequest));
    //        return r;

    //    }

    //}

    /// <summary>
    /// A Get Tracking Get Request Object
    /// </summary>
    public class GetTrackingGetRequest : NtfsRequest
    {
        public GetTrackingGetRequest(string accessKey, ObservableCollection<Pair<string, object>> listParams, string url)
        {
            this.baseUrl = url;
            this.accessKey = accessKey;
            this.list = listParams.Select(x => x.Second).ToList();
            this.accessKey = Properties.Settings.Default.CurrentKey;
        }

        public override string CreateRequest()
        {
            var numValues = this.list.Count;
            this.request = getTrackingGetRequest(this.list.ElementAt(numValues - 1));
            var sb = GetStringBuilder();
            this.requestString = sb.ToString();
            return this.requestString;
        }

        private NtfsRequest getTrackingGetRequest(object p1)
        {
            var asin = (string)p1;
            var r = getTrackingGetRequest(asin);
            return r;
        }

        private NtfsRequest getTrackingGetRequest(string asin)
        {
            base.GetBaseRequest(ApiSpecificRequestTypes.Ntfs_TRACKING_GET, "tracking");
            this.parameter.Add("type", "get");
            this.parameter.Add("asin", asin);
            return this;
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
    public class GetTrackingListRequest : NtfsRequest
    {
        public GetTrackingListRequest(string accessKey, ObservableCollection<Pair<string, object>> listParams, string url)
        {
            this.baseUrl = url;
            this.accessKey = accessKey;
            this.list = listParams.Select(x => x.Second).ToList();
            this.accessKey = Properties.Settings.Default.CurrentKey;
        }

        public override string CreateRequest()
        {
            var numValues = this.list.Count;
            this.request = getTrackingListRequest(this.list.ElementAt(numValues - 1));
            var sb = GetStringBuilder();
            this.requestString = sb.ToString();
            return this.requestString;
        }


        private NtfsRequest getTrackingListRequest(object p1)
        {
            var asinsOnly = (bool)p1;
            var r = getTrackingListRequest(asinsOnly);
            return r;
        }

        private NtfsRequest getTrackingListRequest(bool asinsOnly)
        {
            base.GetBaseRequest(ApiSpecificRequestTypes.Ntfs_TRACKING_LIST, "tracking");
            this.parameter.Add("type", "list");
            if (asinsOnly)
                this.parameter.Add("asins-only", "1");
            return this;
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
    public class GetTrackingNotificationRequest : NtfsRequest
    {
        public GetTrackingNotificationRequest(string accessKey, ObservableCollection<Pair<string, object>> listParams, string url)
        {
            this.baseUrl = url;
            this.accessKey = accessKey;
            this.list = listParams.Select(x => x.Second).ToList();
            this.accessKey = Properties.Settings.Default.CurrentKey;
        }

        public override string CreateRequest()
        {
            var numValues = this.list.Count;
            this.request = getTrackingNotificationRequest(this.list.ElementAt(numValues - 2), this.list.ElementAt(numValues - 1));
            var sb = GetStringBuilder();
            this.requestString = sb.ToString();
            return this.requestString;
        }

        private NtfsRequest getTrackingNotificationRequest(object p1, object p2)
        {
            var since = (int)p1;
            var revise = (bool)p2;

            var r = getTrackingNotificationRequest(since, revise);
            return r;
        }

        private NtfsRequest getTrackingNotificationRequest(int since, bool revise)
        {

            base.GetBaseRequest(ApiSpecificRequestTypes.Ntfs_TRACKING_NOTIFICATION, "tracking");
            this.parameter.Add("since", since.ToString());
            this.parameter.Add("revise", revise ? "1" : "0");
            this.parameter.Add("type", "notification");
            return this;
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
    public class GetTrackingRemoveRequest : NtfsRequest
    {
        public GetTrackingRemoveRequest(string accessKey, ObservableCollection<Pair<string, object>> listParams, string url)
        {
            this.baseUrl = url;
            this.accessKey = accessKey;
            this.list = listParams.Select(x => x.Second).ToList();
            this.accessKey = Properties.Settings.Default.CurrentKey;
        }

        public override string CreateRequest()
        {
            var numValues = this.list.Count;
            this.request = getTrackingRemoveRequest(this.list.ElementAt(numValues - 1));
            var sb = GetStringBuilder();
            this.requestString = sb.ToString();
            return this.requestString;
        }


        private NtfsRequest getTrackingRemoveRequest(object p1)
        {
            var asin = (string)p1;
            var r = getTrackingRemoveRequest(asin);
            return r;
        }

        private NtfsRequest getTrackingRemoveRequest(string asin)
        {
            base.GetBaseRequest(ApiSpecificRequestTypes.Ntfs_TRACKING_REMOVE, "tracking");
            this.parameter.Add("type", "remove");
            this.parameter.Add("asin", asin);
            return this;
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
    public class GetTrackingRemoveAllRequest : NtfsRequest
    {
        public GetTrackingRemoveAllRequest(string accessKey, ObservableCollection<Pair<string, object>> listParams, string url)
        {
            this.baseUrl = url;
            this.accessKey = accessKey;
            this.list = listParams.Select(x => x.Second).ToList();
            this.accessKey = Properties.Settings.Default.CurrentKey;
        }

        public override string CreateRequest()
        {
            var numValues = this.list.Count;
            this.request = getTrackingRemoveAllRequest();
            var sb = GetStringBuilder();
            this.requestString = sb.ToString();
            return this.requestString;
        }

        private NtfsRequest getTrackingRemoveAllRequest()
        {
            base.GetBaseRequest(ApiSpecificRequestTypes.Ntfs_TRACKING_REMOVE_ALL, "tracking");
            this.parameter.Add("type", "removeAll");
            return this;
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
    public class GetTrackingWebHookRequest : NtfsRequest
    {
        public GetTrackingWebHookRequest(string accessKey, ObservableCollection<Pair<string, object>> listParams, string url)
        {
            this.baseUrl = url;
            this.accessKey = accessKey;
            this.list = listParams.Select(x => x.Second).ToList();
            this.accessKey = Properties.Settings.Default.CurrentKey;
        }

        public override string CreateRequest()
        {
            var numValues = this.list.Count;
            this.request = getTrackingWebHookRequest(this.list.ElementAt(numValues - 1));
            var sb = GetStringBuilder();
            this.requestString = sb.ToString();
            return this.requestString;
        }


        private NtfsRequest getTrackingWebHookRequest(object p1)
        {
            var url = (string)p1;
            var r = getTrackingWebHookRequest(url);
            return r;
        }

    
        private NtfsRequest getTrackingWebHookRequest(string url)
        {

            base.GetBaseRequest(ApiSpecificRequestTypes.Ntfs_TRACKING_WEB_HOOK, "tracking");
            this.parameter.Add("type", "webhook");
            this.parameter.Add("url", url);
            return this;
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
    public class GetBestSellersRequest : NtfsRequest
    {
        public GetBestSellersRequest(string accessKey, ObservableCollection<Pair<string, object>> listParams, string url)
        {
            this.baseUrl = url;
            this.accessKey = accessKey;
            this.list = listParams.Select(x => x.Second).ToList();
            this.accessKey = Properties.Settings.Default.CurrentKey;
        }

        public override string CreateRequest()
        {
            var numValues = this.list.Count;
            this.request = getBestSellersRequest(this.list.ElementAt(numValues - 2), this.list.ElementAt(numValues - 1));
            var sb = GetStringBuilder();
            this.requestString = sb.ToString();
            return this.requestString;
        }

        private NtfsRequest getBestSellersRequest(object p1, object p2)
        {
            Enum.TryParse(p1.ToString(), out AmazonLocale locale);
            var domainId = locale;
            var productGroup = (string)p2;

            var r = getBestSellersRequest(domainId, productGroup);
            return r;
        }

        [Tag]
        private NtfsRequest getBestSellersRequest(AmazonLocale domainId, string productGroup)
        {
            base.GetBaseRequest(ApiSpecificRequestTypes.Ntfs_BEST_SELLERS, "bestsellers");
            this.parameter.Add("category", productGroup);
            this.parameter.Add("domain", domainId.ToString("D"));
            return this;
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
    public class GetCategoryLookupRequest : NtfsRequest
    {
        public GetCategoryLookupRequest(string accessKey, ObservableCollection<Pair<string, object>> listParams, string url)
        {
            this.baseUrl = url;
            this.accessKey = accessKey;
            this.list = listParams.Select(x => x.Second).ToList();
            this.accessKey = Properties.Settings.Default.CurrentKey;
        }

        public override string CreateRequest()
        {
            var numValues = this.list.Count;
            this.request = getCategoryLookupRequest(this.list.ElementAt(numValues - 3), this.list.ElementAt(numValues - 2), this.list.ElementAt(numValues - 1));
            var sb = GetStringBuilder();
            this.requestString = sb.ToString();
            return this.requestString;
        }

        private NtfsRequest getCategoryLookupRequest(object p1, object p2, object p3)
        {
            Enum.TryParse(p1.ToString(), out AmazonLocale locale);
            var domainId = locale;
            var parsedToBool = bool.TryParse(p2.ToString(), out bool result);
            var parents = result;
            var parsedToLong = long.TryParse(p3.ToString(), out long longResult);
            var category = longResult;

            var r = getCategoryLookupRequest(domainId, parents, category);
            return r;
        }

        [Tag]
        private NtfsRequest getCategoryLookupRequest(AmazonLocale domainId, bool parents, long category)
        {

            base.GetBaseRequest(ApiSpecificRequestTypes.Ntfs_CATEGORY_LOOKUP, "category");
            this.parameter.Add("category", category.ToString());
            this.parameter.Add("domain", domainId.ToString("D"));

            if (parents)
                this.parameter.Add("parents", "1");
            return this;
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
    public class GetCategorySearchRequest : NtfsRequest
    {
        public GetCategorySearchRequest(string accessKey, ObservableCollection<Pair<string, object>> listParams, string url)
        {
            this.baseUrl = url;
            this.accessKey = accessKey;
            this.list = listParams.Select(x => x.Second).ToList();
            this.accessKey = Properties.Settings.Default.CurrentKey;
        }

        public override string CreateRequest()
        {
            var numValues = this.list.Count;
            this.request = getCategorySearchRequest(this.list.ElementAt(numValues - 3), this.list.ElementAt(numValues - 2), this.list.ElementAt(numValues - 1));
            var sb = GetStringBuilder();
            this.requestString = sb.ToString();
            return this.requestString;
        }

        private NtfsRequest getCategorySearchRequest(object p1, object p2, object p3)
        {
            Enum.TryParse(p1.ToString(), out AmazonLocale locale);
            var domainId = locale;
            var term = (string)p2;
            var parents = (bool)p3;

            var r = getCategorySearchRequest(domainId, term, parents);
            return r;
        }

        [Tag]
        private NtfsRequest getCategorySearchRequest(AmazonLocale domainId, string term, bool parents)
        {

            base.GetBaseRequest(ApiSpecificRequestTypes.Ntfs_CATEGORY_SEARCH, "search");
            this.parameter.Add("domain", domainId.ToString("D"));
            this.parameter.Add("type", "category");
            this.parameter.Add("term", term);

            if (parents)
                this.parameter.Add("parents", "1");
            return this;
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
    public class GetSellerRequest : NtfsRequest
    {
        public GetSellerRequest(string accessKey, ObservableCollection<Pair<string, object>> listParams, string url)
        {
            this.baseUrl = url;
            this.accessKey = accessKey;
            this.list = listParams.Select(x => x.Second).ToList();
            this.accessKey = Properties.Settings.Default.CurrentKey;
        }

        public override string CreateRequest()
        {
            var numValues = this.list.Count;
            switch (numValues)
            {
                case 2:
                    this.request = getSellerRequest(this.list.ElementAt(numValues - 2), this.list.ElementAt(numValues - 1));
                    break;
                case 3:
                    this.request = getSellerRequest(this.list.ElementAt(numValues - 3), this.list.ElementAt(numValues - 2), this.list.ElementAt(numValues - 1));
                    break;
                case 4:
                    this.request = getSellerRequest(this.list.ElementAt(numValues - 4), this.list.ElementAt(numValues - 3), this.list.ElementAt(numValues - 2), this.list.ElementAt(numValues - 1));

                    break;
            }

            var sb = GetStringBuilder();
            this.requestString = sb.ToString();
            return this.requestString;
        }

        private NtfsRequest getSellerRequest(object p1, object p2)
        {
            Enum.TryParse(p1.ToString(), out AmazonLocale locale);
            var domainId = locale;
            var seller = p2.ToString().Split(',');

            var r = getSellerRequest(domainId, seller);
            return r;
        }

        [Tag]
        private NtfsRequest getSellerRequest(AmazonLocale domainId, string[] seller)
        {
            base.GetBaseRequest(ApiSpecificRequestTypes.Ntfs_SELLER, "seller");
            this.parameter.Add("domain", domainId.ToString("D"));
            this.parameter.Add("seller", Tools.Utilities.arrayToCsv(seller));
            return this;
        }

        private NtfsRequest getSellerRequest(object p1, object p2, object p3)
        {
            Enum.TryParse(p1.ToString(), out AmazonLocale locale);
            var domainId = locale;
            var seller = p2.ToString();
            var storefront = bool.Parse(p3.ToString());

            var r = getSellerRequest(domainId, seller, storefront);
            return r;
        }

        [Tag]
        private NtfsRequest getSellerRequest(AmazonLocale domainId, string seller, bool storefront)
        {

            base.GetBaseRequest(ApiSpecificRequestTypes.Ntfs_SELLER, "seller");
            this.parameter.Add("domain", domainId.ToString("D"));
            this.parameter.Add("seller", seller);

            if (storefront)
                this.parameter.Add("storefront", "1");
            return this;
        }

        private NtfsRequest getSellerRequest(object p1, object p2, object p3, object p4)
        {
            Enum.TryParse(p1.ToString(), out AmazonLocale locale);
            var domainId = locale;
            var seller = p2.ToString();
            var storefront = bool.Parse(p3.ToString());
            var update = (int)p4;

            var r = getSellerRequest(domainId, seller, storefront, update);
            return r;
        }

        [Tag]
        private NtfsRequest getSellerRequest(AmazonLocale domainId, string seller, bool storefront, int update)
        {

            base.GetBaseRequest(ApiSpecificRequestTypes.Ntfs_SELLER, "seller");
            this.parameter.Add("domain", domainId.ToString("D"));
            this.parameter.Add("seller", seller);
            if (update >= 0)
                this.parameter.Add("update", update.ToString());

            if (storefront || update >= 0)
                this.parameter.Add("storefront", "1");
            return this;
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
    public class GetTopSellerRequest : NtfsRequest
    {
        public GetTopSellerRequest(string accessKey, ObservableCollection<Pair<string, object>> listParams, string url)
        {
            this.baseUrl = url;
            this.accessKey = accessKey;
            this.list = listParams.Select(x => x.Second).ToList();
            this.accessKey = Properties.Settings.Default.CurrentKey;
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

        private NtfsRequest getTopSellerRequest(object p1)
        {
            Enum.TryParse(p1.ToString(), out AmazonLocale locale);
            var domainId = locale;

            var r = getTopSellerRequest(domainId);
            return r;
        }

        [Tag]
        private NtfsRequest getTopSellerRequest(AmazonLocale domainId)
        {

            base.GetBaseRequest(ApiSpecificRequestTypes.Ntfs_TOP_SELLER, "topseller");
            this.parameter.Add("domain", domainId.ToString("D"));
            return this;
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
    public class GetProductSearchRequest : NtfsRequest
    {
        public GetProductSearchRequest(string accessKey, ObservableCollection<Pair<string, object>> listParams, string url)
        {
            this.baseUrl = url;
            this.accessKey = accessKey;
            this.list = listParams.Select(x => x.Second).ToList();
            this.accessKey = Properties.Settings.Default.CurrentKey;
        }

        public override string CreateRequest()
        {
            var numValues = this.list.Count;
            switch (numValues)
            {
                case 3:
                    this.request = getProductSearchRequest(this.list.ElementAt(numValues - 3), this.list.ElementAt(numValues - 2), this.list.ElementAt(numValues - 1));
                    break;
                case 6:
                    this.request = getProductSearchRequest(this.list.ElementAt(numValues - 6), this.list.ElementAt(numValues - 5), this.list.ElementAt(numValues - 4), this.list.ElementAt(numValues - 3), this.list.ElementAt(numValues - 2), this.list.ElementAt(numValues - 1));
                    break;

            }

            var sb = GetStringBuilder();
            this.requestString = sb.ToString();
            return this.requestString;
        }


        private NtfsRequest getProductSearchRequest(object p1, object p2, object p3)
        {
            Enum.TryParse(p1.ToString(), out AmazonLocale locale);
            var domainId = locale;
            var term = p2.ToString();
            int stats = 0;
            bool result = int.TryParse(p3.ToString(), out stats);
            

            var r = getProductSearchRequest(domainId, term, stats);
            return r;
        }

        [Tag]
        private NtfsRequest getProductSearchRequest(AmazonLocale domainId, string term, int? stats)
        {

            base.GetBaseRequest(ApiSpecificRequestTypes.Ntfs_PRODUCT_SEARCH, "search");
            this.parameter.Add("domain", domainId.ToString("D"));
            this.parameter.Add("type", "product");
            this.parameter.Add("term", term);

            if (stats != null && stats > 0)
                this.parameter.Add("stats", stats.ToString());
            return this;
        }

        private NtfsRequest getProductSearchRequest(object p1, object p2, object p3, object p4, object p5, object p6)
        {
            Enum.TryParse(p1.ToString(), out AmazonLocale locale);
            var domainId = locale;
            var term = (string)p2;
            var stats = (int?)p3;
            var update = (int?)p4;
            var history = (bool)p5;
            var asinsOnly = (bool)p6;

            var r = getProductSearchRequest(domainId, term, stats, update, history, asinsOnly);
            return r;
        }

        [Tag]
        private NtfsRequest getProductSearchRequest(AmazonLocale domainId, string term, int? stats, int? update, bool history, bool asinsOnly)
        {

            base.GetBaseRequest(ApiSpecificRequestTypes.Ntfs_PRODUCT_SEARCH, "search");
            this.parameter.Add("domain", domainId.ToString("D"));
            this.parameter.Add("type", "product");
            this.parameter.Add("term", term);
            this.parameter.Add("update", update.ToString());
            this.parameter.Add("history", history ? "1" : "0");
            this.parameter.Add("asins-only", asinsOnly ? "1" : "0");

            if (stats != null && stats > 0)
                this.parameter.Add("stats", stats.ToString());
            return this;
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
    public class GetProductRequest : NtfsRequest
    {
        public GetProductRequest(string accessKey, ObservableCollection<Pair<string, object>> listParams, string url)
        {
            this.baseUrl = url;
            this.accessKey = accessKey;
            this.list = listParams.Select(x => x.Second).ToList();
            this.accessKey = Properties.Settings.Default.CurrentKey;
        }

        public override string CreateRequest()
        {
            var numValues = this.list.Count;
            switch (numValues)
            {
                case 4:
                    this.request = getProductRequest(this.list.ElementAt(numValues - 4), this.list.ElementAt(numValues - 3), this.list.ElementAt(numValues - 2), this.list.ElementAt(numValues - 1));
                    break;
                case 7:
                    this.request = getProductRequest(this.list.ElementAt(numValues - 7), this.list.ElementAt(numValues - 6), this.list.ElementAt(numValues - 5), this.list.ElementAt(numValues - 4), this.list.ElementAt(numValues - 3), this.list.ElementAt(numValues - 2), this.list.ElementAt(numValues - 1));
                    break;

            }

            var sb = GetStringBuilder();
            this.requestString = sb.ToString();
            return this.requestString;
        }

        private NtfsRequest getProductRequest(object p1, object p2, object p3, object p4)
        {
            Enum.TryParse(p1.ToString(), out AmazonLocale locale);
            var domainId = locale;
            var statsParsed = int.TryParse(p2.ToString(),out int stats);
            var offersParsed = int.TryParse(p3.ToString(), out int offers);
            var asins = p4.ToString().Split(',');

            var r = getProductRequest(domainId, stats, offers, asins);
            return r;
        }

        [Tag]
        private NtfsRequest getProductRequest(AmazonLocale domainId, int? stats, int? offers, string[] asins)
        {

            base.GetBaseRequest(ApiSpecificRequestTypes.Ntfs_PRODUCT, "product");
            this.parameter.Add("domain", domainId.ToString("D"));
            this.parameter.Add("asin", Tools.Utilities.arrayToCsv(asins));
            if (stats != null && stats > 0)
                this.parameter.Add("stats", stats.ToString());

            if (offers != null && offers > 0)
                this.parameter.Add("offers", offers.ToString());
            return this;
        }

        private NtfsRequest getProductRequest(object p1, object p2, object p3, object p4, object p5, object p6, object p7)
        {
            Enum.TryParse(p1.ToString(), out AmazonLocale locale);
            var domainId = locale;
            var offers = (int?)p2;
            var statsStartDate = (string)p3;
            var statsEndDate = (string)p4;
            var update = (int)p5;
            var history = (bool)p6;
            var asins = (string[])p7;

            var r = getProductRequest(domainId, offers, statsStartDate, statsEndDate, update, history, asins);
            return r;
        }

        [Tag]
        private NtfsRequest getProductRequest(AmazonLocale domainId, int? offers, string statsStartDate, string statsEndDate, int update, bool history, string[] asins)
        {

            base.GetBaseRequest(ApiSpecificRequestTypes.Ntfs_PRODUCT, "product");
            this.parameter.Add("asin", Tools.Utilities.arrayToCsv(asins));
            this.parameter.Add("domain", domainId.ToString("D"));
            this.parameter.Add("update", update.ToString());
            this.parameter.Add("history", history ? "1" : "0");

            if (statsStartDate != null && statsEndDate != null)
                this.parameter.Add("stats", statsStartDate + "," + statsEndDate);

            if (offers != null && offers > 0)
                this.parameter.Add("offers", offers.ToString());
            return this;
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
    public class GetProductByCodeRequest : NtfsRequest
    {
        public GetProductByCodeRequest(string accessKey, ObservableCollection<Pair<string, object>> listParams, string url)
        {
            this.baseUrl = url;
            this.accessKey = accessKey;
            this.list = listParams.Select(x => x.Second).ToList();
            this.accessKey = Properties.Settings.Default.CurrentKey;
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

        private NtfsRequest getProductByCodeRequest(object p1, object p2, object p3, object p4)
        {
            Enum.TryParse(p1.ToString(), out AmazonLocale locale);
            var domainId = locale;
            var stats = (int?)p2;
            var offers = (int?)p3;
            var codes = (string[])p4;

            var r = getProductByCodeRequest(domainId, stats, offers, codes);
            return r;
        }

        [Tag]
        private NtfsRequest getProductByCodeRequest(AmazonLocale domainId, int? stats, int? offers, string[] codes)
        {

            base.GetBaseRequest(ApiSpecificRequestTypes.Ntfs_PRODUCT_BY_CODE, "product");
            this.parameter.Add("code", Tools.Utilities.arrayToCsv(codes));
            this.parameter.Add("domain", domainId.ToString("D"));
            if (stats != null && stats > 0)
                this.parameter.Add("stats", stats.ToString());

            if (offers != null && offers > 0)
                this.parameter.Add("offers", offers.ToString());
            return this;
        }

        private NtfsRequest getProductByCodeRequest(object p1, object p2, object p3, object p4, object p5, object p6, object p7)
        {
            Enum.TryParse(p1.ToString(), out AmazonLocale locale);
            var domainId = locale;
            var offers = (int?)p2;
            var statsStartDate = (string)p3;
            var statsEndDate = (string)p4;
            var update = (int)p5;
            var history = (bool)p6;
            var codes = (string[])p7;

            var r = getProductByCodeRequest(domainId, offers, statsStartDate, statsEndDate, update, history, codes);
            return r;
        }

        [Tag]
        private NtfsRequest getProductByCodeRequest(AmazonLocale domainId, int? offers, string statsStartDate, string statsEndDate, int update, bool history, string[] codes)
        {

            base.GetBaseRequest(ApiSpecificRequestTypes.Ntfs_PRODUCT_BY_CODE, "product");
            this.parameter.Add("code", Tools.Utilities.arrayToCsv(codes));
            this.parameter.Add("domain", domainId.ToString("D"));
            this.parameter.Add("update", update.ToString());
            this.parameter.Add("history", history ? "1" : "0");

            if (statsStartDate != null && statsEndDate != null)
                this.parameter.Add("stats", statsStartDate + "," + statsEndDate);

            if (offers != null && offers > 0)
                this.parameter.Add("offers", offers.ToString());
            return this;
        }

        private NtfsRequest getProductByCodeRequest(object p1, object p2, object p3, object p4, object p5, object p6, object p7, object p8, object p9, object p10, object p11)
        {
            Enum.TryParse(p1.ToString(), out AmazonLocale locale);
            var domainId = locale;
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

            var r = getProductByCodeRequest(domainId, offers, statsStartDate, statsEndDate, update, history, stock, rental, rating, fbafees, codes);
            return r;
        }

        [Tag]
        private NtfsRequest getProductByCodeRequest(AmazonLocale domainId, int? offers, string statsStartDate, string statsEndDate, int update, bool history, bool stock, bool rental, bool rating, bool fbafees, string[] codes)
        {

            base.GetBaseRequest(ApiSpecificRequestTypes.Ntfs_PRODUCT_BY_CODE, "product");
            this.parameter.Add("code", Tools.Utilities.arrayToCsv(codes));
            this.parameter.Add("domain", domainId.ToString("D"));
            this.parameter.Add("update", update.ToString());
            this.parameter.Add("history", history ? "1" : "0");
            this.parameter.Add("stock", stock ? "1" : "0");
            this.parameter.Add("rental", rental ? "1" : "0");
            this.parameter.Add("rating", rating ? "1" : "0");
            this.parameter.Add("fbafees", fbafees ? "1" : "0");

            if (statsStartDate != null && statsEndDate != null)
                this.parameter.Add("stats", statsStartDate + "," + statsEndDate);

            if (offers != null && offers > 0)
                this.parameter.Add("offers", offers.ToString());
            return this;
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