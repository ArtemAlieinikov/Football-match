using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Football_match.Interfaces;
using Football_match.Classes;
using Football_match.Enums;

namespace Football_match.Classes
{
    class Player : IPlayable
    {
        private string name;
        private string teamName;

        public event EventHandler ResultOfTheKick;

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                name = value;
            }
        }
        public string TeamName
        {
            get
            {
                return teamName;
            }
            private set
            {
                teamName = value;
            }
        }

        public Player(string name, string teamName)
        {
            Name = name;
            TeamName = teamName;
        }

        public int KickTheBall(int minForkState, int maxForkState)
        {
            if (ResultOfTheKick != null)
            {
                ResultOfTheKick(this, new EventMessage(PositiveOrNegativeEvent.positive, "бьет по мячу", String.Format("{0} команды {1}", Name, TeamName)));
            }

            Random random = new Random();
            return random.Next(minForkState, maxForkState);
        }

        public override string ToString()
        {
            return String.Format("Player {0}", Name);
        }
    }
}
