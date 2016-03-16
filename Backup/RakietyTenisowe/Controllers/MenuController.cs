using System.Web.Mvc;

namespace RakietyTenisowe.Controllers
{
    public class MenuController : Controller
    {
        public ActionResult RacquetQuestions()
        {

            return View("~/Views/QuestionsRacquet/StartRacquetQuestion.cshtml");
        }
        
        public ActionResult StringQuestions()
        {

            return View("~/Views/QuestionsString/StartStringQuestion.cshtml");
        }

        public ActionResult GripQuestions()
        {

            return View("~/Views/QuestionsGrip/StartGripQuestion.cshtml");
        }

       
    }
}
