using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static XModule.Constants.Enums;

namespace XModule.Interfaces
{
    public interface IKeepaRequest : IRequest
    {
        /// <summary>
        /// Override of the To string method that each record should have
        /// </summary>
        /// <returns></returns>
        ApiSpecificRequestTypes KeepaRequestType { get; set; }
    }
}
