﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMP.Models.Dtos
{
    internal class MovieDTO
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
