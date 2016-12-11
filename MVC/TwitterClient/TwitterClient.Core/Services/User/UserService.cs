using System.Collections.Generic;
using TwitterClient.Entity.Model;

namespace TwitterClient.Core.Services.User
{
    public class UserService : IUserService
    {
        private static readonly Dictionary<string, TwitterUser> _users = new Dictionary<string, TwitterUser>();

        private TwitterUser _currentUser;

        public UserService()
        {
            _currentUser = null;
        }

        public bool IsAuthenticated => _currentUser != null;

        public void SetCurrentUser(TwitterUser user)
        {
            if (!_users.ContainsKey(user.Id))
            {
                _users.Add(user.Id, user);
            }
            _currentUser = user;
        }

        public void SetCurrentUser(string id)
        {
            if (_users.ContainsKey(id))
            {
                _currentUser = _users[id];
            }
        }

        public TwitterUser GetCurrentUser()
        {
            return _currentUser;
        }
    }
}