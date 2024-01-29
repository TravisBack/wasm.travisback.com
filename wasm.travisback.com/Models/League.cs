//------------------------------------------------------------------------------
// File: Leagues.cs
//
// Description: This file contains the LeagueInfoAttribute class, which is a 
//              custom attribute providing additional information about a sports league.
//              It also includes the League enum representing various sports leagues.
//
// Author: Travis Back
//
// Created: 2024-1-28
//
// Last Modified: 2024-1-28
//
// Notes:
// - LeagueInfoAttribute encapsulates the description and URL information for a league.
// - League enum includes entries for different sports leagues with associated attributes.
//------------------------------------------------------------------------------

using System;

namespace wasm.travisback.com.Models
{
    /// <summary>
    /// Custom attribute to provide additional information about a league.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    sealed class LeagueInfoAttribute : Attribute
    {
        private static string BaseURL = "https://site.api.espn.com/apis/site/v2/sports";

        /// <summary>
        /// Gets the description of the league.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets the relative URL of the league.
        /// </summary>
        public string LeaugeURL { get; }

        /// <summary>
        /// Initializes a new instance of the LeagueInfoAttribute class.
        /// </summary>
        /// <param name="description">The description of the league.</param>
        /// <param name="leaugeURL">The relative URL of the league.</param>
        public LeagueInfoAttribute(string description, string leaugeURL)
        {
            Description = description;
            LeaugeURL = leaugeURL;
        }

        /// <summary>
        /// Gets the description of the specified league.
        /// </summary>
        /// <param name="league">The league for which to retrieve the description.</param>
        /// <returns>The description of the league.</returns>
        public static string GetLeagueDescription(League league)
        {
            var field = league.GetType().GetField(league.ToString());
            var attribute = (LeagueInfoAttribute)Attribute.GetCustomAttribute(field, typeof(LeagueInfoAttribute));
            return attribute == null ? string.Empty : attribute.Description;
        }

        /// <summary>
        /// Gets the full URL of the specified league.
        /// </summary>
        /// <param name="league">The league for which to retrieve the URL.</param>
        /// <returns>The full URL of the league.</returns>
        public static string GetLeagueURL(League league)
        {
            var field = league.GetType().GetField(league.ToString());
            var attribute = (LeagueInfoAttribute)Attribute.GetCustomAttribute(field, typeof(LeagueInfoAttribute));
            return attribute == null ? string.Empty : BaseURL + attribute.LeaugeURL;
        }
    }

    /// <summary>
    /// Enum representing various sports leagues.
    /// </summary>
    public enum League
    {
        [LeagueInfo("English Premier League", "/soccer/eng.1")]
        EPL,

        [LeagueInfo("Major League Baseball", "/baseball/mlb")]
        MLB,

        [LeagueInfo("Major League Soccer", "/soccer/usa.1")]
        MLS,

        [LeagueInfo("National Basketball Association", "/basketball/nba")]
        NBA,

        [LeagueInfo("NCAA Baseball", "/baseball/college-baseball")]
        NCAABaseball,

        [LeagueInfo("NCAA Basketball", "/basketball/mens-college-basketball")]
        NCAABasketball,

        [LeagueInfo("NCAA Football", "/football/college-football")]
        NCAAFootball,

        [LeagueInfo("NCAA Women's Basketball", "/basketball/womens-college-basketball")]
        NCAAWomensBasketball,

        [LeagueInfo("National Football League", "/football/nfl")]
        NFL,

        [LeagueInfo("National Hockey League", "/hockey/nhl")]
        NHL,

        [LeagueInfo("Women's National Basketball Association", "/basketball/wnba")]
        WNBA,
    }
}
