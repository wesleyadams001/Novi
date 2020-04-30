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
    /// The category Tree Record inside of the product object
    /// </summary>
    public class CategoryTreeRecord : Record
    {
        /// <summary>
        /// Category tree default constructor
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="categoryName"></param>
        public CategoryTreeRecord(int? categoryId, string categoryName)
        {
            this.RecordType = RecordType.Ntfs;
            this.NtfsRecordType = NtfsRecordType.CategoryRecord;
            this.CategoryId = categoryId;
            this.CategoryName = categoryName;
            this.TimeStamp = Utilities.GetUnixTime();
        }

        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
