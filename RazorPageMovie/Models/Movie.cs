using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPageMovie.Models
{
    public class Movie
    {
        public int Id { get; set; }


        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string? Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime RekeaseDate { get; set; }


        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string? Gender { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        [DataType(DataType.Currency)]
        [Range(1 , 100)]
        public decimal price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        public string? Raiting { get; set; }
    }
}


//El simbolo de ? -> Se usa para decir que una propiedad no es obligatoria o que acepta nulos