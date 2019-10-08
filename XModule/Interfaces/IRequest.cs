using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static XModule.Constants.Enums;

namespace XModule.Interfaces
{
    /// <summary>
    /// The interface that must be implemented for a request
    /// </summary>
    public interface IRequest
    {

        /// <summary>
        /// The Record type that represents the
        /// API that it came from
        /// </summary>
        RequestTypes RequestType { get; set; }


    }

    //public interface IRequest
    //{

    //    /// <summary>
    //    /// The Record type that represents the
    //    /// API that it came from
    //    /// </summary>
    //    RequestTypes RequestType { get; set; }

    //    /// <summary>
    //    /// Override of the To string method that each record should have
    //    /// </summary>
    //    /// <returns></returns>
    //    ApiSpecificRequestTypes KeepaRequestType { get; set; }

    //    /// <summary>
    //    /// Create method of an IRequest
    //    /// </summary>
    //    /// <param name="parameters"></param>
    //    /// <returns></returns>
    //    void Create(List<Pair<string, object>> parameters);

    //    /// <summary>
    //    /// Reqeust String
    //    /// </summary>
    //    string RequestString { get; set; }
    //}
}
