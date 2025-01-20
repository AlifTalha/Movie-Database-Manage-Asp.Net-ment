using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public UserDTO User { get; set; }
        public int MovieId { get; set; }
        public MovieDTO Movie { get; set; }
    }
}
