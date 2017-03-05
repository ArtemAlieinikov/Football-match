using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Football_match.Enums;

namespace Football_match.Classes
{
    class BallState
    {
        private int resultNumber;
        private BallStateEnum ballState;

        public int ResultNumber 
        {
            get
            {
                return resultNumber;
            }
            set
            {
                resultNumber = value;
            }
        }
        public BallStateEnum BallStateProperty
        {
            get
            {
                return ballState;
            }
            private set
            {
                ballState = value;
            }
        }

        public BallState(int result, BallStateEnum state)
        {
            resultNumber = result;
            ballState = state;
        }
    }
}
