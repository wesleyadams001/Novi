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
}
