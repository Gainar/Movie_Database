using System;

namespace ConsoleApp1
{
    public class Movie
    {
        public Guid Pk_Movie_Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Type { get; set; }
        public int Rating { get; set; }
        public Guid Fk_Creator_Id { get; set; }
    }
}