using System.Collections;
using System.Collections.Generic;
using Tweetinvi;
using Tweetinvi.Models;
using TwitterClient.Entity.Setting;

namespace TwitterClient.DataAccess.ExternalServices
{
    public class TwitterProxy : ITwitterProxy
    {
        private IConsumerCredentials _appCreds;

        public TwitterProxy(TwitterSettings twitterSettings)
        {

            _appCreds = Auth.SetUserCredentials(
                twitterSettings.ConsumerKey, 
                twitterSettings.ConsumerSecret,
                twitterSettings.UserToken, 
                twitterSettings.UserSecret);
        }

        public IAuthenticationContext GetAuthorizationContext(string redirectUrl)
        {
            var authenticationContext = AuthFlow.InitAuthentication(_appCreds, redirectUrl);
            return authenticationContext;
        }

        public IAuthenticatedUser Authenticate(string verifyerCode, string authId)
        {
            var userCreds = AuthFlow.CreateCredentialsFromVerifierCode(verifyerCode, authId);
            return User.GetAuthenticatedUser(userCreds);
        }

        public IEnumerable<ITweet> GetTimelineTimelineForUser(string userId)
        {
            return Timeline.GetUserTimeline(userId);
        }

        public IEnumerable<ITweet> SearchTweets(string key)
        {
            return Search.SearchTweets(key);
        }
    }
}