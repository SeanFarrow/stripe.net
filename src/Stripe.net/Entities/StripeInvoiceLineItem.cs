﻿namespace Stripe
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Stripe.Infrastructure;

    public class StripeInvoiceLineItem : StripeEntityWithId, ISupportMetadata
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        #region Expandable Customer
        public string CustomerId { get; set; }

        [JsonIgnore]
        public StripeCustomer Customer { get; set; }

        [JsonProperty("customer")]
        internal object InternalCustomer
        {
            set
            {
                StringOrObject<StripeCustomer>.Map(value, s => this.CustomerId = s, o => this.Customer = o);
            }
        }
        #endregion

        [JsonProperty("date")]
        [JsonConverter(typeof(StripeDateTimeConverter))]
        public DateTime Date { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("discountable")]
        public bool Discountable { get; set; }

        #region Expandable Invoice
        public string InvoiceId { get; set; }

        [JsonIgnore]
        public StripeInvoice Invoice { get; set; }

        [JsonProperty("invoice")]
        internal object InternalInvoice
        {
            set
            {
                StringOrObject<StripeInvoice>.Map(value, s => this.InvoiceId = s, o => this.Invoice = o);
            }
        }
        #endregion

        [JsonProperty("livemode")]
        public bool LiveMode { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        [JsonProperty("period")]
        public StripePeriod StripePeriod { get; set; }

        [JsonProperty("plan")]
        public StripePlan Plan { get; set; }

        [JsonProperty("proration")]
        public bool Proration { get; set; }

        [JsonProperty("quantity")]
        public int? Quantity { get; set; }

        #region Expandable Subscription
        public string SubscriptionId { get; set; }

        [JsonIgnore]
        public StripeSubscription Subscription { get; set; }

        [JsonProperty("subscription")]
        internal object InternalSubscription
        {
            set
            {
                StringOrObject<StripeSubscription>.Map(value, s => this.SubscriptionId = s, o => this.Subscription = o);
            }
        }
        #endregion

        [JsonProperty("subscription_item")]
        public string SubscriptionItem { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("unit_amount")]
        public int? UnitAmount { get; set; }
    }
}