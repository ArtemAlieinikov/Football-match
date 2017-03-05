using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Football_match.Classes;

namespace Football_match.Classes
{
    class GameBuilder
    {
        public void Run()
        {
            List<Player> players = new List<Player>();
            players.Add(new Player("Pablo", "Uventus"));
            players.Add(new Player("Mario", "Uventus"));
            players.Add(new Player("Lochiano", "Uventus"));

            players.Add(new Player("Петя", "ЗЕНИТ"));
            players.Add(new Player("Люся", "ЗЕНИТ"));
            players.Add(new Player("Витя", "ЗЕНИТ"));

            Team zenit = new Team("ЗЕНИТ", players.Take(3).ToArray());
            Team uventus = new Team("Uventus", players.Skip(3).ToArray());

            Commentator commentator = new Commentator();
            Fans fans = new Fans();

            foreach(Player item in players)
            {
                item.ResultOfTheKick += commentator.GetCommentaries;
            }

            zenit.ResultOfTheAct += commentator.GetCommentaries;
            uventus.ResultOfTheAct += commentator.GetCommentaries;

            //Играем до 5 голов
            Match ligaOfTheCampions = new Match(zenit, uventus, 5, 950);

            ligaOfTheCampions.EventForCommentator += commentator.GetCommentaries;
            ligaOfTheCampions.EventForFuns += fans.GetAVoice;

            ligaOfTheCampions.StartTheMatch();

            Console.ReadLine();
        }
    }
}
