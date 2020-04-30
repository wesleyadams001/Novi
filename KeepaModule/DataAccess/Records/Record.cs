using System;
using System.Collections.Generic;
using System.Text;
using NtfsModule.DataAccess.Records;
using Newtonsoft.Json;
using static XModule.Constants.Enums;
using XModule.Interfaces;

namespace NtfsModule.DataAccess.Records
{
    public abstract class Record : IRecord
    {
        /// <summary>
        /// Record type that represents the API from which this
        /// record originated
        /// </summary>
        public RecordType RecordType { get; set; }

        /// <summary>
        /// Record type that represents the API specific record type
        /// </summary>
        public NtfsRecordType NtfsRecordType { get; set; }

        /// <summary>
        /// Time stamp using unix time
        /// </summary>
        public long TimeStamp { get; set; }

        /// <summary>
        /// to string method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            
            return "INSERT INTO ";
        }
    }
}
