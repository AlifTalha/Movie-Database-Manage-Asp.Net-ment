﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ICollection<ReviewDTO> Reviews { get; set; }
        public ICollection<RatingDTO> Ratings { get; set; }
        public ICollection<WatchlistDTO> Watchlists { get; set; }
    }
}
