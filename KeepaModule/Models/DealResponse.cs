using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepaModule.Models
{
    /// <summary>
    /// The response of a browse deals request.
    /// <p>Each deal product is listed in one root category. The three fields categoryIds, categoryNames and categoryCount contain information about those categories. The values of the same index in those arrays belong together, so the first category entry would have the id categoryIds[0], the name categoryNames[0] and the deals count categoryCount[0]. If the root category of a product could not be determined it will be listed in the category with the name "?" with the id 9223372036854775807.</p>
    /// </summary>
    public class DealResponse
    {

        /// <summary>
        /// Ordered array of all deal objects matching your query.
        /// </summary>
        public Deal[] dr = null;

        /// <summary>
        /// Not yet used / placeholder
        /// </summary>
        public byte[] drDateIndex = null;

        /// <summary>
        /// Contains all root categoryIds of the matched deal products.
        /// </summary>
        public long[] categoryIds = null;

        /// <summary>
        /// Contains all root category names of the matched deal products.
        /// </summary>
        public string[] categoryNames = null;

        /// <summary>
        /// Contains how many deal products in the respective root category are found.
        /// </summary>
        public int[] categoryCount = null;

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
