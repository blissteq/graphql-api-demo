namespace ZA365Solutions.Platform.Common
{
    using System;
    using System.Runtime.CompilerServices;

    public class RequestContext
    {
        public RequestContext(Guid requestId, string userId, Guid subscriptionId)
        {
            this.UserId = userId;
            this.RequestId = requestId;
            this.SubscriptionId = subscriptionId;
        }

        public Guid SubscriptionId { get; set; }

        public Guid RequestId { get; set; }

        public string UserId { get; set; }

        public string UserEmail { get; set; }

        public string AccessToken { get; set; }
    }
}

