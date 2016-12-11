using Microsoft.AspNetCore.Mvc;
using TwitterClient.Core.Services.Twitter;
using TwitterClient.Core.Services.User;

namespace TwitterClient.Web.Controllers
{
    public class TwitterController : Controller
    {
        private readonly ITwitterService _twitterService;
        private readonly IUserService _userService;

        public TwitterController(ITwitterService twitterService, IUserService userService)
        {
            _twitterService = twitterService;
            _userService = userService;
        }

        // GET: Twitter
        public ActionResult Index()
        {
            return RedirectToAction("Tweets");
        }

        public ActionResult Tweets(string query = "aspnetcore")
        {
            if (!_userService.IsAuthenticated)
            {
                return RedirectToAction("TwitterAuth");
            }

            var userTweets = _twitterService.SearchTweets(query);
            ViewBag.Query = query;
            return View(userTweets);
        }

        public ActionResult TwitterAuth()
        {
            var redirectUrl = "http://" + Request.Host + "/Twitter/ValidateTwitterAuth";
            var auth = _twitterService.GetAuthorizationContext(redirectUrl);

            return new RedirectResult(auth.AuthorizationURL);
        }


        public ActionResult ValidateTwitterAuth(string oauth_verifier, string authorization_id)
        {
            _twitterService.Authenticate(oauth_verifier, authorization_id);

            return RedirectToAction("Tweets");
        }
    }
}