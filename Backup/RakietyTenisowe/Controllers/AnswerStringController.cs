using System.Linq;
using System.Web.Mvc;
using RakietyTenisowe.Models;
using RakietyTenisowe.Models.Questions;

namespace RakietyTenisowe.Controllers
{
    public class AnswerStringController : Controller
    {
        //
        // GET: /AnswerRacquet/

        public ActionResult AnswerString()
        {
            //Odpowiedzi dla naciągów
            using (var db = new BazaWiedzyContext())
            {
                object models;
                string typ = DataStorageRacquets.questionsAnswers[9];
                string durability = DataStorageRacquets.questionsAnswers[10];

                models = durability == ">" ? (from p in db.Naciagi where p.Typ == typ && p.Grubosc >= 1.3 select p).ToList()
                    : (from p in db.Naciagi where p.Typ == typ && p.Grubosc <= 1.3 select p).ToList();
                return View(models);
            }
        }
    }
}
