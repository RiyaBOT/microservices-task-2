using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Models
{
    public class MovieItem
    {
        public long Id { get; set; }
        public string Name { get; set; }/*Name of the Movie*/
        public string Date { get; set; }
        public string Time { get; set; }
        public string Venue { get; set;  }
        public long NumberOfTickets { get; set; } /* can choose other data types such as int but chose long to be on the safe side*/

        public long Amount { get; set; }


    }
}
