using TwitterClient.Entity.Model;

namespace TwitterClient.Core.Services.User
{
    public interface IUserService
    {
        bool IsAuthenticated { get; }

        void SetCurrentUser(TwitterUser user);

        void SetCurrentUser(string userId);

        TwitterUser GetCurrentUser();
    }
}