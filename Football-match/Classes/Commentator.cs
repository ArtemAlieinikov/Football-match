using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_match.Classes
{
    class Commentator
    {
        public void GetCommentaries(object sender, EventArgs message)
        {
            EventMessage info = (EventMessage)message;
            Console.WriteLine("{0} : {1} - {2}", ToString(), info.nameOfTheSubject, info.message);
        }

        public override string ToString()
        {
            return "Комментатор";
        }
    }
}
