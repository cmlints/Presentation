using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicAppFinal.Models
{
    public class MusicApp
    {
        public int Id { get; set; }

        [Required]
        public String Genre { get; set; }

        [Required]
        public String ArtistName { get; set; }
        
        [Required]
        [MaxLength(4, ErrorMessage = "The year must be four numbers.")]
        public string Year { get; set; }

        [Required]
        public string NumberOfSongs { get; set; }

        [Required]
        public string Song { get; set; }

        [Required]
        public string AlbumName { get; set; }


    }
}