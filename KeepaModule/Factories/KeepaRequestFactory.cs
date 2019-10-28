using KeepaModule.Models;
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

namespace KeepaModule.Factories
{
    public class KeepaRequestFactory
    {
        /// <summary>
        /// The access key to be used by a request factory
        /// </summary>
        private static string accessKey { get; set; }

        /// <summary>
        /// A Parameter list
        /// </summary>
        private static ObservableCollection<Pair<string, object>> paramList {get;set;}

        /// <summary>
        /// A dictionary that maps strings to fire methods
        /// </summary>
        public static Dictionary<string, Func<KeepaRequest>> objects =
        new Dictionary<string, Func<KeepaRequest>>
        {
                    {"getTrackingGetRequest", () => new GetTrackingGetRequest(accessKey, paramList)},
                    {"getTrackingListRequest", () => new GetTrackingListRequest(accessKey, paramList)},
                    {"getTrackingNotificationRequest", () => new GetTrackingNotificationRequest(accessKey, paramList)},
                    {"getTrackingRemoveRequest", () => new GetTrackingRemoveRequest(accessKey, paramList)},
                    {"getTrackingRemoveAllRequest", () => new GetTrackingRemoveAllRequest(accessKey, paramList)},
                    {"getTrackingWebHookRequest", () => new GetTrackingWebHookRequest(accessKey, paramList)},
                    {"getBestSellersRequest", () => new GetBestSellersRequest(accessKey, paramList)},
                    {"getCategoryLookupRequest", () => new GetCategoryLookupRequest(accessKey, paramList)},
                    {"getCategorySearchRequest", () => new GetCategorySearchRequest(accessKey, paramList)},
                    {"getSellerRequest", () => new GetSellerRequest(accessKey, paramList)},
                    {"getTopSellerRequest", () => new GetTopSellerRequest(accessKey, paramList)},
                    {"getProductSearchRequest", () => new GetProductSearchRequest(accessKey, paramList)},
                    {"getProductRequest", () => new GetProductRequest(accessKey, paramList)},
                    {"getProductByCodeRequest", () => new GetProductByCodeRequest(accessKey, paramList)},
        };  

        /// <summary>
        /// Constructs a new Keepa Request factory
        /// </summary>
        /// <param name="key"></param>
        public KeepaRequestFactory(string key)
        {
            accessKey = key;
            System.Windows.MessageBox.Show(accessKey);
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

            Func<KeepaRequest> objectCtor = null;
            objects.TryGetValue(name, out objectCtor);

            var x = objectCtor != null ? objectCtor().CreateRequest() : null;
            System.Windows.MessageBox.Show(x);
            return x;
        }

    }
}
