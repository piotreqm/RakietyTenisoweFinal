using System;
using System.Linq;
using System.Web.Mvc;
using RakietyTenisowe.Models;
using RakietyTenisowe.Models.Questions;

namespace RakietyTenisowe.Controllers
{
    public class AnswerRacquetController : Controller
    {
        //
        // GET: /AnswerRacquet/

        public ActionResult AnswerJunior()
        {
            //Odpowiedzi dla rakiet juniorskich
            using (var db = new BazaWiedzyContext())
            {
                int dlugosc = Convert.ToInt32(DataStorageRacquets.questionsAnswers[7]);
                var models = (from p in db.RakietyJuniorskie where p.Dlugosc == dlugosc select p).ToList();
                return View(models);
            }

        }

        public ActionResult AnswerSeniorNoExp()
        {
            //Odpowiedzi dla rakiet seniorskich dla niedoświadczonych
            using (var db = new BazaWiedzyContext())
            {
                object models;
                int plec = Convert.ToInt32(DataStorageRacquets.questionsAnswers[2]);
                int raczka = Convert.ToInt32(DataStorageRacquets.questionsAnswers[4]);
                int doswiadczenie = Convert.ToInt32(DataStorageRacquets.questionsAnswers[1]);
                
                models = (from p in db.RakietySeniorskie where p.Waga < plec && p.RaczkaMin < raczka && raczka < p.RaczkaMax && p.Glowka >= doswiadczenie select p).ToList();
                                                                //waga < 300 && raczka E [RaczkaMin,RaczkaMax] && Glowka > doswiadczenie
                return View(models);
            }
        }

        public ActionResult AnswerSeniorExp()
        {
            //Odpowiedzi dla rakiet seniorskich dla doświadczonych
            using (var db = new BazaWiedzyContext())
            {
                object models;
                int plec = Convert.ToInt32(DataStorageRacquets.questionsAnswers[2]);
                int raczka = Convert.ToInt32(DataStorageRacquets.questionsAnswers[4]);
                int doswiadczenie = Convert.ToInt32(DataStorageRacquets.questionsAnswers[1]);
                string balans = DataStorageRacquets.questionsAnswers[6];
                int waga = Convert.ToInt32(DataStorageRacquets.questionsAnswers[5]);
                int wagaGorna = 0;

                wagaGorna = waga == 300 ? 100 : 315;
                
                models = balans == ">" ? (from p in db.RakietySeniorskie where p.Waga < plec && p.RaczkaMin <= raczka && raczka <= p.RaczkaMax && p.Glowka >= doswiadczenie && p.Balans > 3 && waga < p.Waga && p.Waga < waga+wagaGorna select p).ToList()
                    : (from p in db.RakietySeniorskie where p.RaczkaMin <= raczka && raczka <= p.RaczkaMax && p.Glowka >= doswiadczenie && p.Balans <= 3 && waga < p.Waga && p.Waga < waga + wagaGorna select p).ToList();
                            //(true) waga < 300 && raczka E [RaczkaMin,RaczkaMax] && Glowka > doswiadczenie && (balans > 3 || balans < 3) && waga E [waga,wagaGorna]
                            //(false) raczka E [RaczkaMin,RaczkaMax] && Glowka > doswiadczenie && (balans > 3 || balans < 3) && waga E [waga,wagaGorna]
                return View(models);
            }
        }
    }
}
