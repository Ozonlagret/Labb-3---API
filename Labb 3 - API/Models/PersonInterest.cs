﻿namespace Labb_3___API.Models
{
    public class PersonInterest
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int InterestId { get; set; }
        public Interest Interest { get; set; }
    }
}
