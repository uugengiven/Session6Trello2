using Session6Trello2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Session6Trello2.Controllers
{
    public class TrelloController : Controller
    {
        private TrelloDbContext database = new TrelloDbContext();
        // GET: Trello
        public ActionResult Index()
        {
            return View(database.Cards.ToList());
        }

        public ActionResult AddCard(string Title)
        {
            var temp_card = new Card();
            temp_card.Title = Title;
            database.Cards.Add(temp_card);
            database.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteCard(int id)
        {
            var card = database.Cards.Find(id);
            database.Cards.Remove(card);
            database.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}