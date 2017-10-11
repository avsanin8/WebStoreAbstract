using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace FilterApp.Models
{
    public class SoccerContext : DbContext
    {
        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }

    }

    public class SoccerDbInitalizer : DropCreateDatabaseAlways<SoccerContext>
    {
        protected override void Seed(SoccerContext db)
        {
            Team t1 = new Team { Name = "Dinamo" };
            Team t2 = new Team { Name = "Bavariya" };
            db.Teams.Add(t1);
            db.Teams.Add(t2);
            db.SaveChanges();
            Player pl1 = new Player { Name = "Garmash", Age = 28, Position = "Forward", Team = t1 };
            Player pl2 = new Player { Name = "Hacheridi", Age = 29, Position = "Defender", Team = t1 };
            Player pl3 = new Player { Name = "Messi", Age = 19, Position = "Forward", Team = t2 };
            Player pl4 = new Player { Name = "Ronaldo", Age = 33, Position = "HaveBack", Team = t2 };
            Player pl5 = new Player { Name = "Iniesta", Age = 26, Position = "Goalkeper", Team = t2 };
            Player pl6 = new Player { Name = "Pyatov", Age = 31, Position = "Goalkeper", Team = t1 };
            db.Players.AddRange(new List<Player> { pl1, pl2, pl3, pl4, pl5, pl6 });
            db.SaveChanges();
        }
        
        
    }
}