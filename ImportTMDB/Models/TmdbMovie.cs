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
        public DateTime ReleaseDate { get; set; }
        public List<string> Genres { get; set; } 
        public int Runtime { get; set; }     //Duration
        public double VoteAverage { get; set; }
        public string Overview { get; set; } //Description
        public string PosterPath { get; set; }
    }
}
