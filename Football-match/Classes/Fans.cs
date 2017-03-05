using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Football_match.Classes;
using Football_match.Enums;

namespace Football_match.Classes
{
    class Fans
    {
        public void GetAVoice(object sender, EventArgs message)
        {
            EventMessage info = (EventMessage)message;

            if (info.color == PositiveOrNegativeEvent.negative)
            {
                Console.WriteLine("{0} {1} : - какая досада, ужас...", ToString(), info.nameOfTheSubject);
            }
            else
            {
                Console.WriteLine("{0} {1} : - УРРРРАААааа!!!!...", ToString(), info.nameOfTheSubject);
            }
        }

        public override string ToString()
        {
            return "ФАНАТЫ";
        }
    }
}
