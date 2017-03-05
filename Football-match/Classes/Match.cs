using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Football_match.Interfaces;
using Football_match.Enums;

namespace Football_match.Classes
{
    class Match
    {
        private ICommand firstTeam;
        private ICommand secondTeam;
        private int numberOfGoalsForTheEnd;
        private int delayTime;

        public event EventHandler EventForFuns;
        public event EventHandler EventForCommentator;


        public Match(ICommand firstTeam, ICommand secondTeam, int numberOfGoalsForTheEnd, int delay)
        {
            this.firstTeam = firstTeam;
            this.secondTeam = secondTeam;
            this.numberOfGoalsForTheEnd = numberOfGoalsForTheEnd;
            delayTime = delay;
        }

        public void StartTheMatch()
        {
            if (EventForCommentator != null)
            {
                string message = String.Format("МАТЧ {0} ПРОТИВ {1} НАЧАЛСЯ\n", firstTeam.TeamName, secondTeam.TeamName);
                EventMessage eventMessageForCommentator = new EventMessage(PositiveOrNegativeEvent.positive, message, "");
                EventForCommentator(this, eventMessageForCommentator);
            }

            Thread.Sleep(delayTime);

            StartTheGame();
        }

        private void StartTheGame()
        {
            ICommand teamWithBall = firstTeam;
            BallState ballState = teamWithBall.DoAnAct(0);
            ballState.ResultNumber = ballState.ResultNumber > firstTeam.NumbersOfPlayers - 1 ? 0 : ballState.ResultNumber;

            while (numberOfGoalsForTheEnd > firstTeam.Score & numberOfGoalsForTheEnd > secondTeam.Score)
            {
                Thread.Sleep(delayTime);
                ballState = teamWithBall.DoAnAct(ballState.ResultNumber);

                if (ballState.BallStateProperty == BallStateEnum.lost)
                {
                    teamWithBall = teamWithBall != firstTeam ? firstTeam : secondTeam;

                    if (EventForCommentator != null)
                    {
                        EventMessage eventMessageForCommentator = new EventMessage(PositiveOrNegativeEvent.positive, "ПОТЕРЯЛА МЯЧ", teamWithBall.TeamName);
                        EventForCommentator(this, eventMessageForCommentator);
                    }

                    ballState.ResultNumber = 0;
                }
                else if (ballState.BallStateProperty == BallStateEnum.goal)
                {
                    teamWithBall = teamWithBall != firstTeam ? firstTeam : secondTeam;
                    Thread.Sleep(delayTime);
                    teamWithBall.AddScore();
                    Thread.Sleep(delayTime);

                    if (EventForCommentator != null)
                    {
                        string message = String.Format("счет = {0}", teamWithBall.Score);
                        EventMessage eventMessageForCommentator = new EventMessage(PositiveOrNegativeEvent.positive, message, teamWithBall.TeamName);
                        EventForCommentator(this, eventMessageForCommentator);
                    }

                    Thread.Sleep(delayTime);

                    if (EventForFuns != null)
                    {
                        EventForFuns(this, new EventMessage(PositiveOrNegativeEvent.positive, "", teamWithBall.TeamName));
                    }

                    Thread.Sleep(delayTime);
                    ballState.ResultNumber = 0;

                    ICommand loseTeam = teamWithBall != firstTeam ? firstTeam : secondTeam;

                    if (EventForFuns != null)
                    {
                        EventForFuns(this, new EventMessage(PositiveOrNegativeEvent.negative, "", loseTeam.TeamName));
                    }
                }
            }

            Thread.Sleep(delayTime);

            if (EventForCommentator != null)
            {
                string message = String.Format("с счетом {0} - {1} победил {2}", firstTeam.Score, secondTeam.Score, "");
                EventMessage eventMessageForCommentator = new EventMessage(PositiveOrNegativeEvent.positive, message, teamWithBall.TeamName);
                EventForCommentator(this, eventMessageForCommentator);
            }
        }
    }
}
