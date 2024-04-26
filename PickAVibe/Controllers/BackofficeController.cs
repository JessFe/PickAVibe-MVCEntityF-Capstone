using PickAVibe.App_Start.Filters;
using PickAVibe.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PickAVibe.Controllers
{
    [AdminAuthorize]
    public class BackofficeController : Controller
    {
        private readonly ModelDbContext db = new ModelDbContext();

        // GET: Backoffice
        // Mostra la dashboard del backoffice
        public ActionResult Index()
        {
            // Recupera il numero totale di film e il conteggio dei film per ogni vibe
            var viewModel = new BackofficeVM
            {
                TotalMovies = db.Movies.Count(),
                Vibes = db.Vibes.Select(v => new VibeInfo
                {
                    VibeID = v.VibeID,
                    VibeName = v.VibeName,
                    MoviesCount = v.MoviesVibes.Count()
                }).ToList()
            };

            return View(viewModel);
        }

        // Mostra tutti i film, con la possibilità di filtrare per titolo
        public ActionResult AllMovies(string searchString)
        {
            var movies = from m in db.Movies
                         select m;

            // Filtra i film per titolo
            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            return View(movies.OrderBy(m => m.Title).ToList());
        }

        // Mostra i film associati a un vibe specifico, con la possibilità di filtrare per titolo
        public ActionResult MoviesByVibe(int vibeId, string searchString = null)
        {
            var vibe = db.Vibes.Find(vibeId);
            if (vibe == null)
            {
                return HttpNotFound();
            }

            // Recupera i film associati al vibe, ordinati per titolo
            IEnumerable<Movies> movies = vibe.MoviesVibes.Select(mv => mv.Movies).OrderBy(m => m.Title);

            // Filtra i film per titolo
            if (!String.IsNullOrEmpty(searchString))
            {
                var lowerCaseSearchString = searchString.ToLower();
                movies = movies.Where(m => m.Title.ToLower().Contains(lowerCaseSearchString));
            }

            ViewBag.VibeName = vibe.VibeName;
            ViewBag.VibeID = vibeId;

            // Passa la lista di film alla view, riusando la vista AllMovies
            return View("AllMovies", movies.ToList());
        }

        // GET: Backoffice/AddMovie
        public ActionResult AddMovie()
        {

            ViewBag.VibeID = new MultiSelectList(db.Vibes.ToList(), "VibeID", "VibeName");
            return View();
        }

        // POST: Backoffice/AddMovie
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMovie([Bind(Include = "Title,Year,Duration,Description,TrailerURL")] Movies movie, int[] SelectedVibes, HttpPostedFileBase posterFile)
        {
            if (ModelState.IsValid)
            {
                // Gestione del file locandina
                if (posterFile != null && posterFile.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(posterFile.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/assets/posterimg"), fileName);
                    posterFile.SaveAs(path);

                    movie.PosterImg = fileName; // Salva solo il nome del file nel database
                }

                // Salva il film nel database
                db.Movies.Add(movie);
                db.SaveChanges();

                // Associazione dei vibes selezionati al film
                if (SelectedVibes != null && SelectedVibes.Length > 0)
                {
                    // Associazione dei vibes selezionati al film
                    foreach (var vibeId in SelectedVibes)
                    {
                        db.MoviesVibes.Add(new MoviesVibes { FK_MovieID = movie.MovieID, FK_VibeID = vibeId });
                    }
                    db.SaveChanges();
                }

                // Reindirizza alla pagina principale del backoffice
                return RedirectToAction("Index");
            }
            else // Se il modello non è valido o non ci sono SelectedVibes
            {
                // Prepara di nuovo i dati per la view
                ViewBag.VibeID = new MultiSelectList(db.Vibes.ToList(), "VibeID", "VibeName", SelectedVibes);
                return View(movie);
            }
        }

        // GET: Backoffice/DetailsMovie
        // Mostra i dettagli di un film, con l'elenco dei vibes associati
        public ActionResult DetailsMovie(int id)
        {
            // Recupera il film dal database
            var movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            // elenco dei nomi dei Vibes correlati
            ViewBag.Vibes = db.MoviesVibes
                              .Where(mv => mv.FK_MovieID == id)
                              .Select(mv => mv.Vibes.VibeName)
                              .ToList();

            return View(movie);
        }

        // GET: Backoffice/EditMovie
        // Mostra il form per modificare un film, con la possibilità di modificare i vibes associati
        public ActionResult EditMovie(int id)
        {
            // Recupera il film dal database
            var movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            // Recupera l'elenco degli ID dei Vibes associati al film
            var selectedVibes = db.MoviesVibes
                                  .Where(mv => mv.FK_MovieID == id)
                                  .Select(mv => mv.FK_VibeID)
                                  .ToList();

            // Prepara i dati per la view
            ViewBag.VibeID = new MultiSelectList(db.Vibes.ToList(), "VibeID", "VibeName", selectedVibes);
            ViewBag.SelectedVibes = selectedVibes; // Passa gli ID dei Vibes selezionati separati per facilitare il controllo nel frontend

            return View(movie);
        }

        // POST: Backoffice/EditMovie
        // Modifica un film, con la possibilità di modificare i vibes associati
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMovie([Bind(Include = "MovieID,Title,Year,Duration,Description,TrailerURL")] Movies movie, int[] SelectedVibes, HttpPostedFileBase posterFile)
        {
            if (ModelState.IsValid)
            {
                // Recupera il film dal database
                var movieToUpdate = db.Movies.Find(movie.MovieID);
                if (movieToUpdate != null)
                {
                    // Gestione del file locandina
                    if (posterFile != null && posterFile.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(posterFile.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/assets/posterimg"), fileName);
                        posterFile.SaveAs(path);

                        movieToUpdate.PosterImg = fileName;
                    }

                    // Aggiorna i dati del film
                    movieToUpdate.Title = movie.Title;
                    movieToUpdate.Year = movie.Year;
                    movieToUpdate.Duration = movie.Duration;
                    movieToUpdate.Description = movie.Description;
                    movieToUpdate.TrailerURL = movie.TrailerURL;

                    // Logica per aggiornare i vibes associati al film (solo dove ci sono cambiamenti)
                    // Ottiene i VibeID già associati al film, come una lista di int
                    var currentVibes = db.MoviesVibes
                                         .Where(mv => mv.FK_MovieID == movie.MovieID)
                                         .Select(mv => mv.FK_VibeID)
                                         .ToList()
                                         .Select(id => id.Value)
                                         .ToList();

                    // Ottiene i VibeID selezionati, converte in una lista di int
                    var selectedVibesList = SelectedVibes.ToList();

                    // Usa Except per trovare le differenze tra le due liste
                    // Se il vibe selezionato non è già associato al film, aggiunge
                    var vibesToAdd = selectedVibesList.Except(currentVibes).ToList();
                    foreach (var vibeId in vibesToAdd)
                    {
                        db.MoviesVibes.Add(new MoviesVibes { FK_MovieID = movie.MovieID, FK_VibeID = vibeId });
                    }

                    // Usa Except per trovare le differenze tra le due liste
                    // Se il vibe associato al film non è più selezionato, rimuove
                    var vibesToRemove = currentVibes.Except(selectedVibesList).ToList();
                    foreach (var vibeId in vibesToRemove)
                    {
                        var vibeToRemove = db.MoviesVibes.FirstOrDefault(mv => mv.FK_MovieID == movie.MovieID && mv.FK_VibeID == vibeId);
                        if (vibeToRemove != null)
                        {
                            db.MoviesVibes.Remove(vibeToRemove);
                        }
                    }

                    // Salva le modifiche nel database
                    db.SaveChanges();
                    return RedirectToAction("AllMovies");
                }
            }

            // Se ci sono errori, prepara di nuovo i dati per la view
            ViewBag.VibeID = new MultiSelectList(db.Vibes.ToList(), "VibeID", "VibeName", SelectedVibes);
            return View(movie);
        }

    }
}