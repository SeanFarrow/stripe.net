namespace StripeTests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Stripe;
    using Xunit;

    public class StripeEphemeralKeyServiceTest : BaseStripeTest
    {
        private const string EphemeralKeyId = "ephkey_123";

        private StripeEphemeralKeyService service;
        private StripeEphemeralKeyCreateOptions createOptions;

        public StripeEphemeralKeyServiceTest()
        {
            this.service = new StripeEphemeralKeyService();

            this.createOptions = new StripeEphemeralKeyCreateOptions
            {
                CustomerId = "cus_123",
                StripeVersion = "2017-05-25",
            };
        }

        [Fact]
        public void Create()
        {
            var ephemeralKey = this.service.Create(this.createOptions);
            Assert.NotNull(ephemeralKey);
            Assert.Equal("ephemeral_key", ephemeralKey.Object);
            Assert.NotNull(ephemeralKey.RawJson);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var ephemeralKey = await this.service.CreateAsync(this.createOptions);
            Assert.NotNull(ephemeralKey);
            Assert.Equal("ephemeral_key", ephemeralKey.Object);
        }

        [Fact]
        public void Delete()
        {
            var deleted = this.service.Delete(EphemeralKeyId);
            Assert.NotNull(deleted);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var deleted = await this.service.DeleteAsync(EphemeralKeyId);
            Assert.NotNull(deleted);
        }
    }
}
