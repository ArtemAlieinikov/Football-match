using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Football_match.Enums;

namespace Football_match.Classes
{
    class EventMessage : EventArgs
    {
        public string message;
        public string nameOfTheSubject;
        public PositiveOrNegativeEvent color;

        public EventMessage(PositiveOrNegativeEvent color, string message, string nameOfTheSubject)
        {
            this.message = message;
            this.nameOfTheSubject = nameOfTheSubject;
            this.color = color;
        }
    }
}
