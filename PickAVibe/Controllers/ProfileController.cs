using PickAVibe.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace PickAVibe.Controllers
{

    public class ProfileController : Controller
    {
        // Inizializza il DbContext
        private ModelDbContext db = new ModelDbContext();

        // GET: Profile
        public ActionResult Index()
        {
            if (!Request.IsAuthenticated || Session["UserID"] == null)
            {
                return RedirectToAction(actionName: "Login", controllerName: "User");
            }

            // Recupera l'ID dell'utente loggato
            var userID = Convert.ToInt32(Session["UserID"]);
            // Recupera l'utente dal database
            var user = db.Users.Find(userID);

            // Se non trova l'utente
            if (user == null)
            {
                // Gestisce l'utente non trovato
                return RedirectToAction(actionName: "Login", controllerName: "User");
            }

            // Recupera il film con la valutazione più alta tra quelli visti dall'utente
            var highestRatedMovies = db.Watched
                .Where(w => w.FK_UserID == userID)
                .GroupBy(w => w.Rating)
                .OrderByDescending(g => g.Key)
                .FirstOrDefault();

            // Recupera l'URL dell'immagine del film con la valutazione più alta
            // Randomizza l'ordine per selezionare un film a caso in caso di pari merito
            string imageUrl = null;
            if (highestRatedMovies != null)
            {
                var movie = highestRatedMovies
                    .OrderBy(a => Guid.NewGuid())
                    .Select(w => w.Movies)
                    .FirstOrDefault();

                imageUrl = movie?.PosterImg;
            }

            // Crea il modello per la view
            var model = new ProfileVM
            {
                Username = user.Username,
                WatchlistCount = db.Watchlist.Count(w => w.FK_UserID == userID),
                WatchedCount = db.Watched.Count(w => w.FK_UserID == userID),
                FavoriteMovieImageUrl = imageUrl
            };

            return View(model);
        }


        // WATCHLIST
        // GET: Profile/Watchlist
        // Metodo per visualizzare la watchlist dell'utente
        public ActionResult Watchlist(string searchString)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            // Recupera l'ID dell'utente loggato
            var userID = Convert.ToInt32(Session["UserID"]);
            // Recupera i film nella watchlist dell'utente
            var watchlistQuery = db.Watchlist.Where(w => w.FK_UserID == userID)
                                              .Select(w => w.Movies);

            // Filtra i film in base al titolo
            if (!String.IsNullOrEmpty(searchString))
            {
                watchlistQuery = watchlistQuery.Where(m => m.Title.Contains(searchString));
            }

            // Esegue la query e crea la lista dei film
            var watchlistMovies = watchlistQuery.ToList();

            return View(watchlistMovies);
        }


        // POST: Profile/AddToWatched
        // Aggiunge un film alla lista dei watched inserendo la valutazione e rimuovendolo dalla watchlist
        // Se il film è già presente nella lista dei watched, aggiorna soltanto la valutazione
        [HttpPost]
        public ActionResult AddToWatched(int movieId, int rating)
        {
            if (!Request.IsAuthenticated)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.Unauthorized);
            }

            // Recupera l'ID dell'utente loggato
            var userID = Convert.ToInt32(Session["UserID"]);

            // Rimuove il film dalla watchlist quando viene spostato nei watched
            var watchlistEntry = db.Watchlist.FirstOrDefault(w => w.FK_MovieID == movieId && w.FK_UserID == userID);
            if (watchlistEntry != null)
            {
                db.Watchlist.Remove(watchlistEntry);
            }

            // Controlla se il film esiste già nella lista dei watched            
            var watchedEntry = db.Watched.FirstOrDefault(w => w.FK_MovieID == movieId && w.FK_UserID == userID);

            // Se esiste, aggiorna solo la valutazione
            if (watchedEntry != null)
            {
                watchedEntry.Rating = rating;
            }
            else
            {
                // Se non esiste, aggiunge il film alla lista dei watched con la valutazione
                var newWatched = new Watched
                {
                    FK_UserID = userID,
                    FK_MovieID = movieId,
                    Rating = rating
                };
                db.Watched.Add(newWatched);
            }
            db.SaveChanges();

            return Json(new { success = true });
        }

        // POST: Profile/DeleteFromWatchlist
        // Metodo per rimuovere un film dalla watchlist dell'utente
        [HttpPost]
        public ActionResult DeleteFromWatchlist(int id)
        {
            if (!Request.IsAuthenticated)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.Unauthorized);
            }

            // Recupera l'ID dell'utente loggato
            var userID = Convert.ToInt32(Session["UserID"]);
            // Recupera l'entry della watchlist per il film e l'utente
            var movieToRemove = db.Watchlist.FirstOrDefault(w => w.FK_MovieID == id && w.FK_UserID == userID);

            // Se l'entry esiste, rimuove il film dalla watchlist
            if (movieToRemove != null)
            {
                db.Watchlist.Remove(movieToRemove);
                db.SaveChanges();
            }

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }


        // WATCHED
        // GET: Profile/Watched
        // Metodo per visualizzare i film visti dall'utente
        public ActionResult Watched(string searchString)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            // Recupera l'ID dell'utente loggato
            var userID = Convert.ToInt32(Session["UserID"]);
            // Recupera i film visti dall'utente
            var watchedMoviesQuery = db.Watched.Where(w => w.FK_UserID == userID)
                                                .Select(w => new WatchedMoviesVM
                                                {
                                                    Movie = w.Movies,
                                                    Rating = w.Rating ?? 0
                                                });

            // Filtra i film in base al titolo
            if (!String.IsNullOrEmpty(searchString))
            {
                watchedMoviesQuery = watchedMoviesQuery.Where(vm => vm.Movie.Title.Contains(searchString));
            }

            // Esegue la query e crea la lista dei film
            var watchedMovies = watchedMoviesQuery.OrderByDescending(w => w.Rating).ToList();

            return View(watchedMovies);
        }

        // POST: Profile/MoveBackToWatchlist
        // Metodo per spostare un film dalla lista dei watched alla watchlist
        [HttpPost]
        public ActionResult MoveBackToWatchlist(int movieId)
        {
            if (!Request.IsAuthenticated)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.Unauthorized);
            }

            // Recupera l'ID dell'utente loggato
            var userID = Convert.ToInt32(Session["UserID"]);

            // Rimuovi il film dalla lista Watched
            var watchedEntry = db.Watched.FirstOrDefault(w => w.FK_MovieID == movieId && w.FK_UserID == userID);
            if (watchedEntry != null)
            {
                db.Watched.Remove(watchedEntry);
            }

            // Aggiungi il film alla Watchlist, se non già presente
            var watchlistEntryExists = db.Watchlist.Any(w => w.FK_MovieID == movieId && w.FK_UserID == userID);
            if (!watchlistEntryExists)
            {
                var watchlistEntry = new Watchlist { FK_UserID = userID, FK_MovieID = movieId };
                db.Watchlist.Add(watchlistEntry);
            }

            db.SaveChanges();

            return Json(new { success = true });
        }

        // POST: Profile/DeleteFromWatched
        // Metodo per rimuovere un film dalla lista watched
        [HttpPost]
        public ActionResult DeleteFromWatched(int id)
        {
            if (!Request.IsAuthenticated)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.Unauthorized);
            }

            // Recupera l'ID dell'utente loggato
            var userID = Convert.ToInt32(Session["UserID"]);
            // Recupera l'entry
            var movieToRemove = db.Watched.FirstOrDefault(w => w.FK_MovieID == id && w.FK_UserID == userID);

            // Se l'entry esiste, rimuove il film dalla lista watched
            if (movieToRemove != null)
            {
                db.Watched.Remove(movieToRemove);
                db.SaveChanges();
            }

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }
    }
}