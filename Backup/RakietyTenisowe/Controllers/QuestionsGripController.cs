using System.Web.Mvc;
using RakietyTenisowe.Models.Questions;

namespace RakietyTenisowe.Controllers
{
    public class QuestionsGripController : Controller
    {
        //
        // GET: /Questions/
        public ActionResult StartGripQuestion(string start)
        {
            //Rozpocznij
            return start == "Rozpocznij" ? View("Question8") : View();
        }

        //Pytania do wyboru owijki ---------------------------------------------------------
        public ActionResult Question8(string answer)
        {
            //Co jest dla Ciebie ważniejsze?
            DataStorageRacquets.questionsAnswers[8] = answer;
            switch (answer)
            {
                case "Feel":
                case "Comfort":
                case "Absorbent":
                    return RedirectToAction("AnswerGrip","AnswerGrip");
                default:
                    return View();
            }
        }
    }
}
