namespace wasm.travisback.com.Models
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    sealed class LeagueInfoAttribute : Attribute
    {
        public string Description { get; }
        public string SubURL { get; }

        public LeagueInfoAttribute(string description, string subURL)
        {
            Description = description;
            SubURL = subURL;
        }

        public static string GetLeagueDescription(League league)
        {
            var field = league.GetType().GetField(league.ToString());
            var attribute = (LeagueInfoAttribute)Attribute.GetCustomAttribute(field, typeof(LeagueInfoAttribute));
            return attribute == null ? string.Empty : attribute.Description;
        }

        public static string GetLeagueSubURL(League league)
        {
            var field = league.GetType().GetField(league.ToString());
            var attribute = (LeagueInfoAttribute)Attribute.GetCustomAttribute(field, typeof(LeagueInfoAttribute));
            return attribute == null ? string.Empty : attribute.SubURL;
        }
    }

    public enum League
    {
        [LeagueInfo("Major League Baseball", "/baseball/mlb")]
        MLB,

        [LeagueInfo("Major League Soccer", "/soccer/mls")]
        MLS,

        [LeagueInfo("National Basketball Association", "/basketball/nba")]
        NBA,

        [LeagueInfo("National Football League", "/football/nfl")]
        NFL,

        [LeagueInfo("National Hockey League", "/hockey/nhl")]
        NHL
    }
}
