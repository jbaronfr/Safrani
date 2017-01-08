using System;
using System.Collections.Generic;
using System.Text;

namespace Safran.Scoring.Model
{
    public class Table
    {
        public Seat Bow { get; set; }
        public List<Tuple<Seat,Seat>> FacingPirates { get; set;}
        public Seat Stern { get; set; }
    }
}
