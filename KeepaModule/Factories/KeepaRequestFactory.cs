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
        private static string accessKey { get; set; }
        private static ObservableCollection<Pair<string, object>> paramList {get;set;}

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

        public KeepaRequestFactory(string key)
        {
            accessKey = key;
        }

        public string Create(string name, ObservableCollection<Pair<string, object>> listParams)
        {
            paramList = listParams;
            if (string.IsNullOrWhiteSpace(name))
            {
                return null;
            }

            Func<KeepaRequest> objectCtor = null;
            objects.TryGetValue(name, out objectCtor);

            return objectCtor != null ? objectCtor().CreateRequest() : null;
        }

    }
}
