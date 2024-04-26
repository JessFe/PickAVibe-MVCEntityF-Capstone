using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;

namespace PickAVibe.Helpers
{
    // Helper per recuperare le valutazioni di un film da OMDb API
    // (rating IMDb e Rotten Tomatoes)
    public class OMDbApiHelper
    {
        private readonly string apiKey = "a32f801a";

        public MovieRating GetMovieRating(string title)
        {
            string url = $"https://www.omdbapi.com/?t={Uri.EscapeDataString(title)}&apikey={apiKey}";
            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString(url);
                JavaScriptSerializer js = new JavaScriptSerializer();
                OMDbApiResponse response = js.Deserialize<OMDbApiResponse>(json);
                if (response.Response == "True")
                {
                    return new MovieRating
                    {
                        IMDbRating = response.imdbRating,
                        RottenTomatoesRating = response.Ratings.FirstOrDefault(r => r.Source == "Rotten Tomatoes")?.Value
                    };
                }
                return null;
            }
        }

        public class OMDbApiResponse
        {
            public string Title { get; set; }
            public string imdbRating { get; set; }
            public List<Rating> Ratings { get; set; }
            public string Response { get; set; }
        }

        public class Rating
        {
            public string Source { get; set; }
            public string Value { get; set; }
        }

        public class MovieRating
        {
            public string IMDbRating { get; set; }
            public string RottenTomatoesRating { get; set; }
        }
    }
}
