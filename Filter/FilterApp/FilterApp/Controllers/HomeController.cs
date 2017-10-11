using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilterApp.Models;
using System.Data.Entity;

namespace FilterApp.Controllers
{
    public class HomeController : Controller
    {
        SoccerContext db = new SoccerContext();

        public ActionResult Index(int? team, string position)
        {
            IQueryable<Player> players = db.Players.Include(p=>p.Team);
            if(team!=null && team!=0)
            {
                players = players.Where(p => p.TeamId == team);
            }
            if (!String.IsNullOrEmpty(position) && !position.Equals("All"))
            {
                players = players.Where(p => p.Position == position);
            }

            List<Team> teams = db.Teams.ToList();
            // establish start element, whitch pick all
            teams.Insert(0, new Team { Name = "All", Id = 0 });

            PlayersListViewModel plvm = new PlayersListViewModel
            {
                Players = players.ToList(),
                Teams = new SelectList(teams, "Id", "Name"),
                Positions = new SelectList(new List<string>()
                {
                    "All",
                    "Forward",
                    "Defender",
                    "HaveBack",
                    "Goalkeper"
                })
            };

            return View(plvm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}