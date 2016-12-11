namespace TwitterClient.Entity.Setting
{
    public class TwitterSettings
    {
        public TwitterSettings()
        {
            //ConsumerKey = ConfigurationManager.AppSettings["ConsumerKey"];
            //ConsumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"];
            //UserToken = ConfigurationManager.AppSettings["UserToken"];
            //UserSecret = ConfigurationManager.AppSettings["UserSecret"];
        }

        public string ConsumerKey { get; set; }

        public string ConsumerSecret { get; set; }

        public string UserToken { get; set; }

        public string UserSecret { get; set; }
    }
}