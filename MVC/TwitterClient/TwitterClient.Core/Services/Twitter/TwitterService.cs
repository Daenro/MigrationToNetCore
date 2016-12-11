using System;
using System.Collections.Generic;
using System.Linq;
using Tweetinvi.Credentials.Models;
using Tweetinvi.Models;
using TwitterClient.Core.Services.User;
using TwitterClient.DataAccess.ExternalServices;
using TwitterClient.Entity.Model;

namespace TwitterClient.Core.Services.Twitter
{
    public class TwitterService : ITwitterService
    {
        private readonly ITwitterProxy _twitterProxy;
        private readonly IUserService _userService;

        public TwitterService(ITwitterProxy twitterProxy, IUserService userService)
        {
            _twitterProxy = twitterProxy;
            _userService = userService;
        }

        public IAuthenticationContext GetAuthorizationContext(string redirectUrl)
        {
            return _twitterProxy.GetAuthorizationContext(redirectUrl);
        }

        public TwitterUser Authenticate(string verifyerCode, string authId)
        {
            var externalUser = _twitterProxy.Authenticate(verifyerCode, authId);

            var internalUser = new TwitterUser
            {
                FullName = externalUser.ScreenName,
                Id = externalUser.IdStr
            };
            _userService.SetCurrentUser(internalUser);
            return internalUser;
        }

        public IEnumerable<Tweet> SearchTweets(string key)
        {
            var tweets = _twitterProxy.SearchTweets(key).Select(tweet => new Tweet
            {
                Id = tweet.IdStr,
                Content = tweet.FullText,
                Author = tweet.CreatedBy.Name
            });

            return tweets;
        }

        public IEnumerable<Tweet> GetTimelineForCurrentUser()
        {
            var user = _userService.GetCurrentUser();
            var tweets = _twitterProxy.GetTimelineTimelineForUser(user.Id).Select(tweet => new Tweet
            {
                Id = tweet.IdStr,
                Content = tweet.FullText,
                Author = tweet.CreatedBy.Name
            });

            return tweets;
        }
    }
}