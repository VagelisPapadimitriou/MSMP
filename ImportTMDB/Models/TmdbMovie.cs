using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportTMDB.Models
{
    public class TmdbMovie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        private string releaseDate; // Change Release_Date to string
        public string Release_Date
        {
            get => releaseDate;
            set => releaseDate = DateTime.Parse(value).ToString("dd-MM-yyyy"); // Parse and format date 
        }
        public ICollection<Genre> Genres { get; set; } 
        public int Runtime { get; set; }     //Duration
        public double Vote_Average { get; set; }
        public string Overview { get; set; } //Description
        public string Poster_Path { get; set; }
    }

    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
