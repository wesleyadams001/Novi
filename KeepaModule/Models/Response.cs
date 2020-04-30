using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Tools;
using static XModule.Constants.Enums;

namespace NtfsModule.Models
{
    /// <summary>
    /// A Ntfs Response object
    /// </summary>
    public class Response
    {
        /// <summary>
	    /// Server time when response was sent.
	    /// </summary>
        public long timestamp = Utilities.GetUnixTime();

        /// <summary>
        /// States how many ASINs may be requested before the assigned API contingent is depleted.
        /// If the contigent is depleted, HTTP status code 503 will be delivered with the message:
        /// "You are submitting requests too quickly and your requests are being throttled."
        /// </summary>
        public int tokensLeft = 0;

        /// <summary>
        /// Milliseconds till new tokens are generated. Use this if your contigent is depleted to wait before you try a new request. Tokens are generated every 5 minutes.
        /// </summary>
        public int refillIn = 0;

        /// <summary>
        /// Token refill rate per minute.
        /// </summary>
        public int refillRate = 0;

        /// <summary>
        /// total time the request took (local, including latencies and connection establishment), in milliseconds
        /// </summary>
        public long requestTime = 0;

        /// <summary>
        /// time the request's processing took (remote), in milliseconds
        /// </summary>
        public int processingTimeInMs = 0;

        /// <summary>
        /// Token flow reduction
        /// </summary>
        public double tokenFlowReduction = 0;

        /// <summary>
        /// Tokens used for call
        /// </summary>
        public int tokensConsumed = 0;

        /// <summary>
        /// Status of the request.
        /// </summary>
        public ResponseStatus status = ResponseStatus.PENDING;

        /// <summary>
        /// Results of the product request
        /// </summary>
        public Product[] products = null;

        /// <summary>
        /// Results of the category lookup and search
        /// </summary>
        public Dictionary<long, Category> categories = null;

        /// <summary>
        /// Results of the category lookup and search includeParents parameter
        /// </summary>
        public Dictionary<long, Category> categoryParents = null;

        /// <summary>
        /// Results of the deals request
        /// </summary>
        public DealResponse deals = null;

        /// <summary>
        /// Results of the best sellers request
        /// </summary>
        public BestSellers bestSellersList = null;

        /// <summary>
        /// Results of the deals request
        /// </summary>
        public Dictionary<string, Seller> sellers = null;

        /// <summary>
        /// Results of get and add tracking operations
        /// </summary>
        public Tracking[] trackings = null;

        /// <summary>
        /// Results of get and add tracking operations
        /// </summary>
        public Notification[] notifications = null;

        /// <summary>
        /// A list of ASINs. Result of, but not limited to, the get tracking list operation
        /// </summary>
        public string[] asinList = null;

        /// <summary>
        /// Estimated count of all matched products.
        /// </summary>
        public int? totalResults = null;

        /// <summary>
        /// A list of sellerIds.
        /// </summary>
        public string[] sellerIdList = null;

        /// <summary>
        /// Contains information about any error that might have occurred.
        /// </summary>
        public RequestError error = null;

        /// <summary>
        /// Contains request specific additional output.
        /// </summary>
        public string additional = null;


        public static Response REQUEST_FAILED = new Response(ResponseStatus.FAIL);
        public static Response REQUEST_REJECTED = new Response(ResponseStatus.REQUEST_REJECTED);
        public static Response NOT_ENOUGH_TOKEN = new Response(ResponseStatus.NOT_ENOUGH_TOKEN);

        /// <summary>
        /// Default constructor for default objects
        /// </summary>
        /// <param name="stat"></param>
        private Response(ResponseStatus stat)
        {
            status = stat;
        }

        public Response(long timestamp, int tokensLeft, int refillIn, int refillRate, long requestTime, int processingTimeInMs, double tokenFlowReduction, int tokensConsumed, ResponseStatus status, Product[] products, Dictionary<long, Category> categories, Dictionary<long, Category> categoryParents, DealResponse deals, BestSellers bestSellersList, Dictionary<string, Seller> sellers, Tracking[] trackings, Notification[] notifications, string[] asinList, int? totalResults, string[] sellerIdList, RequestError error, string additional)
        {
            this.timestamp = timestamp;
            this.tokensLeft = tokensLeft;
            this.refillIn = refillIn;
            this.refillRate = refillRate;
            this.requestTime = requestTime;
            this.processingTimeInMs = processingTimeInMs;
            this.tokenFlowReduction = tokenFlowReduction;
            this.tokensConsumed = tokensConsumed;
            this.status = status;
            this.products = products;
            this.categories = categories ?? null;
            this.categoryParents = categoryParents ?? null;
            this.deals = deals ?? null;
            this.bestSellersList = bestSellersList ?? null;
            this.sellers = sellers ?? null;
            this.trackings = trackings ?? null;
            this.notifications = notifications ?? null;
            this.asinList = asinList ?? null;
            this.totalResults = totalResults ?? null;
            this.sellerIdList = sellerIdList ?? null;
            this.error = error ?? null;
            this.additional = additional ?? null;
        }

        public Response()
        {

        }

        /// <summary>
        /// Override of the To string method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
