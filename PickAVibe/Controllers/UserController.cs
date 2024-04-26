using PickAVibe.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PickAVibe.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        // Inizializza il DbContext
        private ModelDbContext db = new ModelDbContext();

        // GET: User/LoginPartial
        // Metodo per visualizzare il form di login
        public ActionResult LoginPartial()
        {
            return PartialView("_LoginPartial", new LoginVM());
        }

        // GET: User/RegisterPartial
        // Metodo per visualizzare il form di registrazione
        public ActionResult RegisterPartial()
        {
            return PartialView("_RegisterPartial", new RegisterVM());
        }

        // GET: User/Login
        // Metodo per visualizzare la pagina di login
        public ActionResult Login()
        {
            // Nasconde navbar e footer
            ViewBag.HideLayout = true;
            return View();
        }

        // POST: User/Login
        // Metodo per effettuare il login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                // Cerca l'utente nel database per username o email
                var user = db.Users.FirstOrDefault(u => u.Username == model.UsernameOrEmail || u.Email == model.UsernameOrEmail);
                // Verifica la password
                if (user != null && user.Password == model.Password)
                {
                    // Determina il ruolo dell'utente
                    string userData = user.IsAdmin.GetValueOrDefault() ? "Admin" : "User";

                    // Crea un ticket di autenticazione personalizzato
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                        1,
                        user.Username,
                        DateTime.Now,
                        DateTime.Now.AddMinutes(2880),
                        false,
                        userData);

                    // Crea un cookie di autenticazione con il ticket criptato
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);

                    // Imposta i valori della sessione
                    Session["UserID"] = user.UserID.ToString();
                    Session["Username"] = user.Username;
                    Session["IsAdmin"] = user.IsAdmin;

                    // Utilizza FormsAuthentication per gestire il reindirizzamento
                    FormsAuthentication.SetAuthCookie(user.Username, false);

                    // Reindirizza l'utente alla pagina corretta in base al ruolo
                    if (user.IsAdmin.GetValueOrDefault())
                    {
                        return RedirectToAction("Index", "Backoffice");
                    }
                    else
                    {
                        return RedirectToAction("SelectMood", "Movies");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Username or password is incorrect.");
                }
            }

            // Se ci sono errori di validazione, ritorna il Partial View con il modello per mostrare gli errori
            return PartialView("_LoginPartial", model);
        }

        // GET: User/Register
        // Metodo per gestire la registrazione
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                // Verifica se esiste già un utente con lo stesso username o email
                var userExists = db.Users.Any(u => u.Username == model.Username || u.Email == model.Email);

                if (!userExists)
                {
                    // Crea il nuovo utente come utente normale
                    var newUser = new Users
                    {
                        Username = model.Username,
                        Email = model.Email,
                        Password = model.Password,
                        IsAdmin = false
                    };

                    db.Users.Add(newUser);
                    db.SaveChanges();

                    // Restituisce il Partial View di login
                    return PartialView("_LoginPartial", new LoginVM());
                }
                else
                {
                    ModelState.AddModelError("", "Username or email provided is already taken.");
                }
            }

            // Se ci sono errori di validazione, ritorna il Partial View con il modello per mostrare gli errori
            return PartialView("_RegisterPartial", model);
        }

        // POST: User/Logout
        // Metodo per effettuare il logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut(); // Rimuove cookie di autenticazione
            Session.Clear(); // Pulisce i dati di sessione
            return RedirectToAction("Index", "Home");
        }
    }
}
