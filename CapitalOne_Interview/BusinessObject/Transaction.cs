using System;
using Newtonsoft.Json;

/// <summary>
/// CapitalOne_Interview business object namespace
/// </summary>
namespace CapitalOne_Interview.BusinessObject
{
    /// <summary>
    /// Transaction object
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Gets or Sets the amount
        /// </summary>
        [JsonProperty(PropertyName = "amount")]        
        public long Amount { get; set; }

        /// <summary>
        /// Gets or sets the value for IsPending
        /// </summary>
        [JsonProperty(PropertyName = "is-pending")]
        public bool IsPending { get; set; }

        /// <summary>
        /// Gets or sets the value for AggreationTime
        /// </summary>
        [JsonProperty(PropertyName = "aggregation-time")]
        public string AggregationTime { get; set; }


        /// <summary>
        /// Gets or sets the value for Account Id
        /// </summary>
        [JsonProperty(PropertyName = "account-id")]
        public string AccountId { get; set; }

        /// <summary>
        /// Gets or sets the value for ClearDate
        /// </summary>
        [JsonProperty(PropertyName = "clear-date")]
        public long ClearDate { get; set; }


        /// <summary>
        /// Gets or sets the value for TransactionId
        /// </summary>
        [JsonProperty(PropertyName = "transaction-id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the value for RawMerchant
        /// </summary>
        [JsonProperty(PropertyName = "raw-merchant")]
        public string RawMerchant { get; set; }

        /// <summary>
        /// Gets or sets the value for Categorization
        /// </summary>
        [JsonProperty(PropertyName = "categorization")]
        public string Categorization { get; set; }

        /// <summary>
        /// Gets or sets the value for Merchant
        /// </summary>
        [JsonProperty(PropertyName = "merchant")]
        public string Merchant { get; set; }

        /// <summary>
        /// Gets or sets the value for TransactionTime
        /// </summary>
        [JsonProperty(PropertyName = "transaction-time")]
        public DateTime TransactionTime { get; set; }
    }
}
