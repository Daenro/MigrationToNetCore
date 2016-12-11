using System.Collections.Generic;
using Tweetinvi.Credentials.Models;
using Tweetinvi.Models;

namespace TwitterClient.DataAccess.ExternalServices
{
    public interface ITwitterProxy
    {
        IAuthenticationContext GetAuthorizationContext(string redirectUrl);

        IAuthenticatedUser Authenticate(string verifyerCode, string authId);

        IEnumerable<ITweet> GetTimelineTimelineForUser(string userId);

        IEnumerable<ITweet> SearchTweets(string key);
    }
}