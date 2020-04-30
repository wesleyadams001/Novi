using NtfsModule.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XModule.Constants;
using XModule.Interfaces;
using XModule.Models;
using XModule.Services;
using XModule.Tools;

namespace NtfsModule.Factories
{
    public class NtfsRequestFactory
    {
        /// <summary>
        /// The base URL for Ntfs requests
        /// </summary>
        private static string baseUrl { get; set; }

        /// <summary>
        /// The access key to be used by a request factory
        /// </summary>
        private static string accessKey { get; set; }

        /// <summary>
        /// A Parameter list
        /// </summary>
        private static ObservableCollection<Pair<string, object>> paramList {get;set;}

        /// <summary>
        /// A dictionary that maps strings to create objects
        /// </summary>
        public static Dictionary<string, Func<NtfsRequest>> objects =
        new Dictionary<string, Func<NtfsRequest>>
        {
                    {"getTrackingGetRequest", () => new GetTrackingGetRequest(accessKey, paramList, baseUrl)},
                    {"getTrackingListRequest", () => new GetTrackingListRequest(accessKey, paramList, baseUrl)},
                    {"getTrackingNotificationRequest", () => new GetTrackingNotificationRequest(accessKey, paramList, baseUrl)},
                    {"getTrackingRemoveRequest", () => new GetTrackingRemoveRequest(accessKey, paramList, baseUrl)},
                    {"getTrackingRemoveAllRequest", () => new GetTrackingRemoveAllRequest(accessKey, paramList, baseUrl)},
                    {"getTrackingWebHookRequest", () => new GetTrackingWebHookRequest(accessKey, paramList, baseUrl)},
                    {"getBestSellersRequest", () => new GetBestSellersRequest(accessKey, paramList, baseUrl)},
                    {"getCategoryLookupRequest", () => new GetCategoryLookupRequest(accessKey, paramList, baseUrl)},
                    {"getCategorySearchRequest", () => new GetCategorySearchRequest(accessKey, paramList, baseUrl)},
                    {"getSellerRequest", () => new GetSellerRequest(accessKey, paramList, baseUrl)},
                    {"getTopSellerRequest", () => new GetTopSellerRequest(accessKey, paramList, baseUrl)},
                    {"getProductSearchRequest", () => new GetProductSearchRequest(accessKey, paramList, baseUrl)},
                    {"getProductRequest", () => new GetProductRequest(accessKey, paramList, baseUrl)},
                    {"getProductByCodeRequest", () => new GetProductByCodeRequest(accessKey, paramList, baseUrl)},
        };  

        /// <summary>
        /// Constructs a new Ntfs Request factory
        /// </summary>
        /// <param name="key"></param>
        public NtfsRequestFactory(string url)
        {
            baseUrl = url;
        }

        /// <summary>
        /// Creates a new request based on the name and a list of parameters
        /// </summary>
        /// <param name="name"></param>
        /// <param name="listParams"></param>
        /// <returns></returns>
        public string Create(string name, ObservableCollection<Pair<string, object>> listParams)
        {
            paramList = listParams;
            if (string.IsNullOrWhiteSpace(name))
            {
                return null;
            }

            Func<NtfsRequest> objectCtor = null;
            objects.TryGetValue(name, out objectCtor);

            var x = objectCtor != null ? objectCtor().CreateRequest() : null;
            //System.Windows.MessageBox.Show(x);
            return x;
        }

    }
}
