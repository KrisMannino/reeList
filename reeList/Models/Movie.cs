using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace reeList.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string Title { get; set; }

        [Required]
        [MaxLength(4)]
        [Column(TypeName = "varchar")]
        public string Year { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(5)]
        public string Rated { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(200)]
        public string Image { get; set; }
    }
}
