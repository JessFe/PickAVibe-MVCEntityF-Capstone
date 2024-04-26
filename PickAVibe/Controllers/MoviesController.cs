using PickAVibe.Helpers;
using PickAVibe.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace PickAVibe.Controllers
{
    public class MoviesController : Controller
    {
        // Inizializza il DbContext e il generatore di numeri casuali
        private readonly ModelDbContext db = new ModelDbContext();
        private readonly Random random = new Random();

        // GET: Movies/SelectMood
        // Metodo per visualizzare la pagina iniziale dove si seleziona l'umore
        public ActionResult SelectMood()
        {
            // Recupera le frasi casuali per l'introduzione dell'umore
            var moodPhrases = new string[] { "How do you feel?", "How’s your day going?", "What’s your mood?" };
            var randomPhrase = moodPhrases[random.Next(moodPhrases.Length)];
            ViewBag.MoodPhrase = randomPhrase;

            return View();
        }

        // GET: Movies/SelectVibe
        // Metodo per recuperare i vibes basati sull'umore selezionato e mostrarne 4 casuali
        public ActionResult SelectVibe(string mood)
        {
            // Recupera l'ID dell'umore selezionato
            var moodId = db.Moods.Where(m => m.MoodName == mood).Select(m => m.MoodID).FirstOrDefault();
            if (moodId == 0) return new HttpNotFoundResult("Mood not found");

            // Recupera i vibes basati sull'umore selezionato
            // Ordina i vibes in modo casuale (Guid.NewGuid()) e ne prende solo 4
            var vibes = db.MoodsVibes
                .Where(mv => mv.FK_MoodID == moodId)
                .Select(mv => mv.Vibes)
                .OrderBy(r => Guid.NewGuid())
                .Take(4)
                .ToList();

            // Recupera le frasi casuali per l'introduzione dei vibe
            var vibePhrases = new string[] { "Looking for..", "Drawn to...", "Ready for..." };
            var randomVibePhrase = vibePhrases[random.Next(vibePhrases.Length)];
            ViewBag.VibePhrase = randomVibePhrase;

            // Passa i vibes alla view per la selezione
            return View(vibes);
        }

        // GET: Movies/ShowMovies
        // Metodo per visualizzare i film basati sul vibe selezionato, escludendo quelli già guardati
        public ActionResult ShowMovies(int vibeId)
        {
            // Recupera l'ID dell'utente loggato
            var userID = Convert.ToInt32(Session["UserID"]);

            // Recupera gli ID dei film nella watchlist dell'utente
            var moviesIdsWatchlist = db.Watchlist
                           .Where(wl => wl.FK_UserID == userID && wl.FK_MovieID.HasValue)
                           .Select(wl => wl.FK_MovieID.Value)  // Utilizza .Value per ottenere un int non nullable
                           .ToList();

            // Recupera gli ID dei film già guardati dall'utente
            var moviesIdsWatched = db.Watched
                         .Where(w => w.FK_UserID == userID)
                         .Select(w => w.FK_MovieID)
                         .ToList();

            // Filtra i film basandosi su vibeId e esclude quelli già guardati
            // Ordina i film in modo casuale (Guid.NewGuid()) e ne prende solo 4
            var movies = db.MoviesVibes
                           .Where(mv => mv.FK_VibeID == vibeId &&
                                        !moviesIdsWatched.Contains(mv.FK_MovieID))
                           .Select(mv => mv.Movies)
                           .OrderBy(r => Guid.NewGuid())
                           .Take(4)
                           .ToList();

            // Recupera le valutazioni IMDb e Rotten Tomatoes per i film
            OMDbApiHelper apiHelper = new OMDbApiHelper();
            foreach (var movie in movies)
            {
                var rating = apiHelper.GetMovieRating(movie.Title);
                if (rating != null)
                {
                    movie.IMDbRating = rating.IMDbRating;
                    movie.RottenTomatoesRating = rating.RottenTomatoesRating;
                }
            }

            ViewBag.MoviesIdsWatchlist = moviesIdsWatchlist;

            return View(movies);
        }

        // POST: Movies/AddToWatchlist
        // Metodo per aggiungere un film alla watchlist dell'utente
        [HttpPost]
        public ActionResult AddToWatchlist(int movieId)
        {
            if (!Request.IsAuthenticated)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.Unauthorized);
            }

            // Recupera l'ID dell'utente loggato
            var userID = Convert.ToInt32(Session["UserID"]);

            // Controlla se il film è già presente nella watchlist
            var inWatchlist = db.Watchlist.Any(wl => wl.FK_MovieID == movieId && wl.FK_UserID == userID);
            if (!inWatchlist)
            {
                // Il film non è nella watchlist, quindi lo aggiunge
                var watchlistEntry = new Watchlist
                {
                    FK_UserID = userID,
                    FK_MovieID = movieId
                };
                db.Watchlist.Add(watchlistEntry);
                db.SaveChanges();

                return Json(new { success = true, message = "Movie added to Watchlist" });
            }

            // Se il film è già presente nella watchlist
            return Json(new { success = false, message = "Movie already in Watchlist" });
        }

        // POST: Movies/RemoveFromWatchlist
        // Metodo per rimuovere un film dalla watchlist dell'utente
        [HttpPost]
        public ActionResult RemoveFromWatchlist(int movieId)
        {
            if (!Request.IsAuthenticated)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.Unauthorized);
            }

            // Recupera l'ID dell'utente loggato
            var userId = Convert.ToInt32(Session["UserID"]);
            // Recupera l'entry della watchlist per il film e l'utente
            var watchlistEntry = db.Watchlist.FirstOrDefault(wl => wl.FK_MovieID == movieId && wl.FK_UserID == userId);

            // Se l'entry esiste, rimuove il film dalla watchlist
            if (watchlistEntry != null)
            {
                db.Watchlist.Remove(watchlistEntry);
                db.SaveChanges();
                return Json(new { success = true, message = "Movie removed from Watchlist" });
            }

            // Se l'entry non esiste, restituisce un messaggio di errore
            return Json(new { success = false, message = "Movie not found in Watchlist" });
        }

        // Metodo per rilasciare le risorse utilizzate dal DbContext
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}