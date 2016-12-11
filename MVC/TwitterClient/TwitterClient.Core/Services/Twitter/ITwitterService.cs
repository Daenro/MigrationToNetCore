using System.Collections;
using System.Collections.Generic;
using Tweetinvi.Credentials.Models;
using Tweetinvi.Models;
using TwitterClient.Entity.Model;

namespace TwitterClient.Core.Services.Twitter
{
    public interface ITwitterService
    {
        IAuthenticationContext GetAuthorizationContext(string redirectUrl);

        TwitterUser Authenticate(string verifyerCode, string authId);

        IEnumerable<Tweet> SearchTweets(string key);
    }
}