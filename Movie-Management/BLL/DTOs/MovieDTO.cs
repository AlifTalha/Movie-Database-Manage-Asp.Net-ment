using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }

        //public string Description { get; set; }
        //public double Rating { get; set; }

        //public ICollection<ReviewDTO> Reviews { get; set; }
        //public ICollection<RatingDTO> Ratings { get; set; }
        //public ICollection<WatchlistDTO> Watchlists { get; set; }
    }
}
