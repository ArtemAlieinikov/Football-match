using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_match.Interfaces
{
    interface IPlayable
    {
        string Name { get; }
        string TeamName { get; }

        event EventHandler ResultOfTheKick;

        int KickTheBall(int minForkState, int maxForkState);
    }
}
