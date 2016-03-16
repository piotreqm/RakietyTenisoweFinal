using System.Web.Mvc;
using RakietyTenisowe.Models.Questions;

namespace RakietyTenisowe.Controllers
{
    public class QuestionsStringController : Controller
    {
        //
        // GET: /Questions/
        public ActionResult StartStringQuestion(string start)
        {
            //Rozpocznij
            return start == "Rozpocznij" ? View("Question9") : View();
        }

        //Pytania do wyboru naciągu ---------------------------------------------------------
        public ActionResult Question9(string answer)
        {
            //Od naciągu oczekujesz:
            DataStorageRacquets.questionsAnswers[9] = answer;
            switch (answer)
            {
                case "Power":
                case "Spin":
                case "Control":
                case "Comfort":
                case "Durability":
                    return View("Question10");
                default:
                    return View();
            }
        }

        public ActionResult Question10(string answer)
        {
            //Naciąg powinien:
            DataStorageRacquets.questionsAnswers[10] = answer;
            switch (answer)
            {
                case ">":
                case "<":
                    return RedirectToAction("AnswerString","AnswerString");
                default:
                    return View();
            }
        }
    }
}
