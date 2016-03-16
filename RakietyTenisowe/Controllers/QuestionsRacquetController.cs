using System.Web.Mvc;
using RakietyTenisowe.Models.Questions;

namespace RakietyTenisowe.Controllers
{
    public class QuestionsRacquetController : Controller
    {
        //
        // GET: /Questions/
        public ActionResult StartRacquetQuestion(string start)
        {
            //Rozpocznij
            return start == "Rozpocznij" ? View("Question3") : View();
        }

        //Pytania do wyboru rakiety ---------------------------------------------------------
        public ActionResult Question1(string answer)
        {
            DataStorageRacquets.questionsAnswers[1] = answer;
            //Jakie jest twoje doświadczenie tenisowe?
            switch (answer)
            {
                case "106":
                    return RedirectToAction("AnswerSeniorNoExp","AnswerRacquet");
                case "101":
                case "96":
                case "91":
                    return View("Question6");
                default:
                    return View();
            }
        }

        public ActionResult Question2(string answer)
        {
            DataStorageRacquets.questionsAnswers[2] = answer;
            //Wybierz swoją płeć:
            return answer == "300" || answer == "400" ? View("Question4") : View();
        }

        public ActionResult Question3(string answer) 
        {
            DataStorageRacquets.questionsAnswers[3] = answer;
            //W jakim jesteś wieku?
            switch (answer)
            {
                case "Do 8 lat":
                    return View("Question7");
                case "Powyżej 8 lat":
                    return View("Question2");
                default:
                    return View();
            }
        }

        public ActionResult Question4(string answer)
        {
            DataStorageRacquets.questionsAnswers[4] = answer;
            //Jaki rozmiar ma twoja dłoń:
            //4", 4 1/8", 4 1/4", 4 3/8", 4 1/2", 4 5/8", 4 3/4".
            return answer != null ? View("Question1") : View(); 
        }

        public ActionResult Question5(string answer)
        {
            DataStorageRacquets.questionsAnswers[5] = answer;
            //Wolisz:
            switch (answer)
            {
                case "250":
                case "270":
                    return RedirectToAction("AnswerSeniorExp","AnswerRacquet");
                case "265":
                case "285":
                    return RedirectToAction("AnswerSeniorExp","AnswerRacquet");
                case "280":
                case "300":
                    return RedirectToAction("AnswerSeniorExp","AnswerRacquet");
                default:
                    return View();
            }
        }

        public ActionResult Question6(string answer)
        {
            DataStorageRacquets.questionsAnswers[6] = answer;
            //Określ długość swojego zamachu:
            switch (answer)
            {
                case ">":
                    return View("Question5");
                case "<":
                    return View("Question5");
                default:
                    return View();
            }
        }

        public ActionResult Question7(string answer)
        {
            DataStorageRacquets.questionsAnswers[7] = answer;
            //Wybierz swój wzrost:
            switch (answer)
            {
                case "26":  //
                case "25":
                case "24":
                case "23":
                case "21":
                case "19":
                    return RedirectToAction("AnswerJunior", "AnswerRacquet");      
                default:
                    return View();
            }
        }
    }
}
