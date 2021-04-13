using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGames.Models
{
    public class MyGames
    {
        public int MyGamesId { get; set; }
        public int GameID { get; set; }
        [Display(Name = "Review Grade")]
        public int ReviewGrade { get; set; }
        public string Review { get; set; }
        [Display(Name = "Review Date")]
        [DataType(DataType.Date)]
        public DateTime ReviewDate { get; set; }

        public Game Game { get; set; }
    }
}
