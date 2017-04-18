using System;

namespace BookTimeApplication.Entities
{
    public class BookedSession
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PersonUsername { get; set; }
    }
}