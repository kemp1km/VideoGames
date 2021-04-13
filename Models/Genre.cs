using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VideoGames.Data;
using System.Threading.Tasks;

namespace VideoGames.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        [Required]
        [RegularExpression(@"^\S*$", ErrorMessage = "No White spaces allowed")]
        [Display(Name = "Genre")]
        public string GameGenre { get; set; }
        [Display(Name = "Create Date")]
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }
        [Display(Name = "Edit Date")]
        [DataType(DataType.Date)]
        public DateTime EditDate { get; set; }

        public bool GenreExistsName(VideoGamesContext _context, string GenreName)
        {
            var GenreExists = _context.Genre.FirstOrDefault(x => x.GameGenre == GenreName);
            if (GenreExists == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
