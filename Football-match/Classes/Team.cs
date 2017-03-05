using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Football_match.Interfaces;
using Football_match.Enums;

namespace Football_match.Classes
{
    class Team : ICommand
    {
        private string teamName;
        private int score;
        private int holdingProbability;
        private int lostProbability;
        private int goalProbability;
        private IPlayable[] commandStructure; 

        public event EventHandler ResultOfTheAct;

        public string TeamName
        {
            get
            {
                return teamName;
            }
            set
            {
                teamName = value;
            }
        }
        public int Score
        {
            get
            {
                return score;
            }
            private set
            {
                score = value;
            }
        }
        public int NumbersOfPlayers
        {
            get
            {
                return commandStructure.Length;
            }
        }

        public Team(string teamName, params IPlayable[] players)
        {
            TeamName = teamName;
            commandStructure = players;
            holdingProbability = commandStructure.Length - 1;
            lostProbability = holdingProbability > 2 ? holdingProbability / 2 : 1;
            goalProbability = lostProbability > 2 ? lostProbability / 2 : 1;
        }

        public BallState DoAnAct(int numberOfPlayer)
        {
            int summaOfVariants = holdingProbability + lostProbability + goalProbability;
            BallState result = new BallState(0, BallStateEnum.holding);

            int resultOfKick = commandStructure[numberOfPlayer].KickTheBall(0, summaOfVariants + 1);

            if (resultOfKick >= 0 && resultOfKick <= holdingProbability)
            {
                result = new BallState(resultOfKick, BallStateEnum.holding);
            }
            else if (resultOfKick > holdingProbability && resultOfKick <= (lostProbability + holdingProbability))
            {
                result = new BallState(resultOfKick, BallStateEnum.lost);
            }
            else if (resultOfKick > (lostProbability + holdingProbability) && resultOfKick <= summaOfVariants)
            {
                result = new BallState(resultOfKick, BallStateEnum.goal);
            }

            return result;
        }
        public void AddScore()
        {
            Score += 1;

            if (ResultOfTheAct != null)
            {
                ResultOfTheAct(this, new EventMessage(PositiveOrNegativeEvent.positive, "ЗАБИВАЕТ ГОЛ", TeamName));
            }
        }
    }
}
