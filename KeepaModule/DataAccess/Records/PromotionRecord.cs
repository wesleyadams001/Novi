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
    /// A Promotion Record
    /// </summary>
    public class PromotionRecord : Record
    {
        /// <summary>
        /// Default constructor for a promotion record
        /// </summary>
        /// <param name="promotionType"></param>
        /// <param name="elgibilityRequirementDescription"></param>
        /// <param name="benefitDescription"></param>
        /// <param name="NtfsPromotionId"></param>
        public PromotionRecord(ulong productId, string promotionType, string elgibilityRequirementDescription, string benefitDescription, string NtfsPromotionId)
        {
            this.RecordType = RecordType.Ntfs;
            this.NtfsRecordType = NtfsRecordType.PromotionsRecord;
            this.ProductId = productId;
            this.PromotionType = promotionType;
            this.ElgibilityRequirementDescription = elgibilityRequirementDescription;
            this.BenefitDescription = benefitDescription;
            this.NtfsPromotionId = NtfsPromotionId;
            this.TimeStamp = Utilities.GetUnixTime();
        }

        public ulong ProductId { get; set; }
        public string PromotionType { get; set; }
        public string ElgibilityRequirementDescription { get; set; }
        public string BenefitDescription { get; set; }
        public string NtfsPromotionId { get; set; }
    }
}
