using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class AlbumModel
    {
        [Required]
        [Display(Name = "Titre")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Artist")]
        public string Artist { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "ReleaseDate")]
        public DateTime ReleaseDate { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Duration")]
        public TimeSpan Duration { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
    }
}