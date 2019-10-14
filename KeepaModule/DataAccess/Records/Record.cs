using System;
using System.Collections.Generic;
using System.Text;
using KeepaModule.DataAccess.Records;
using Newtonsoft.Json;
using static XModule.Constants.Enums;
using XModule.Interfaces;

namespace KeepaModule.DataAccess.Records
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
        public KeepaRecordType KeepaRecordType { get; set; }

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
