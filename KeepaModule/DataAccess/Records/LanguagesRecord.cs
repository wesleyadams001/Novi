using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static XModule.Constants.Enums;
using XModule.Tools;

namespace NtfsModule.DataAccess.Records
{
    /// <summary>
    /// A language record derived from the product record
    /// </summary>
    public class LanguagesRecord : Record
    {
        /// <summary>
        /// Default constructor for languages record
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="languageName"></param>
        /// <param name="languageType"></param>
        /// <param name="audioFormat"></param>
        public LanguagesRecord(ulong productId, string languageName, string languageType, string audioFormat)
        {
            this.RecordType =RecordType.Ntfs;
            this.NtfsRecordType = NtfsRecordType.LanguagesRecord;
            this.ProductId = productId;
            this.LanguageName = languageName;
            this.LanguageType = languageType;
            this.AudioFormat = audioFormat;
            this.TimeStamp = Utilities.GetUnixTime();
        }

        public ulong ProductId {get;set;}
        public string LanguageName { get; set; }
        public string LanguageType { get; set; }
        public string AudioFormat { get; set; }
    }
}
