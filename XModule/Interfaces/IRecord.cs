using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static XModule.Constants.Enums;

namespace XModule.Interfaces
{
    public interface IRecord
    {
        /// <summary>
        /// Time stamp using unix time
        /// </summary>
        long TimeStamp { get; set; }

        /// <summary>
        /// The Record type that represents the
        /// API that it came from
        /// </summary>
        RecordType RecordType { get; }

        /// <summary>
        /// The record type
        /// </summary>
        NtfsRecordType NtfsRecordType { get; set; }

        /// <summary>
        /// Override of the To string method that each record should have
        /// </summary>
        /// <returns></returns>
        string ToString();
    }
}
