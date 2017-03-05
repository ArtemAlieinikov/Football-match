using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Football_match.Classes;

namespace Football_match.Interfaces
{
    interface ICommand
    {
        int Score { get; }
        string TeamName { get; }
        int NumbersOfPlayers { get; }

        event EventHandler ResultOfTheAct;

        BallState DoAnAct(int numberOfPlayer);
        void AddScore();
    }
}
