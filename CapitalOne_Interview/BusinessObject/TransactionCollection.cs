using System.Collections.Generic;
using Newtonsoft.Json;

/// <summary>
/// CapitalOne_Interview business object namespace
/// </summary
namespace CapitalOne_Interview.BusinessObject
{
    /// <summary>
    /// Transaction collection 
    /// </summary>
    public class TransactionCollection
    {
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        [JsonProperty(PropertyName = "transactions")]
        public List<Transaction> Transactions { get; set; }
    }
}
