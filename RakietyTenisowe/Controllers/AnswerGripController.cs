using System.Linq;
using System.Web.Mvc;
using RakietyTenisowe.Models;
using RakietyTenisowe.Models.Questions;

namespace RakietyTenisowe.Controllers
{
    public class AnswerGripController : Controller
    {
        //
        // GET: /AnswerRacquet/

        public ActionResult AnswerGrip()
        {
            //Odpowiedzi dla owijek
            using (var db = new BazaWiedzyContext())
            {
                string typ = DataStorageRacquets.questionsAnswers[8];
                var models = (from p in db.Owijki where p.Typ == typ select p).ToList();
                return View(models);
            }
        }
    }
}
