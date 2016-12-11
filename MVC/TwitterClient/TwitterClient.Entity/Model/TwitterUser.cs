using System.Collections.Generic;

namespace TwitterClient.Entity.Model
{
    public class TwitterUser
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public List<Tweet> Tweets { get; set; } = new List<Tweet>();
    }
}