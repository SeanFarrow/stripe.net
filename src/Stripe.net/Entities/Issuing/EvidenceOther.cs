namespace Stripe
{
    using Newtonsoft.Json;
    using Stripe.Infrastructure;

    public class EvidenceOther : StripeEntity
    {
        [JsonProperty("dispute_explanation")]
        public string DisputeExplanation { get; set; }

        #region Expandable UncategorizedFile
        public string UncategorizedFileId { get; set; }

        [JsonIgnore]
        public StripeFileUpload UncategorizedFile { get; set; }

        [JsonProperty("uncategorized_file")]
        internal object InternalUncategorizedFile
        {
            set
            {
                StringOrObject<StripeFileUpload>.Map(value, s => this.UncategorizedFileId = s, o => this.UncategorizedFile = o);
            }
        }
        #endregion
    }
}