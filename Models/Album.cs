using System.ComponentModel.DataAnnotations;

namespace ExamMvc.Models
{
    public class Album
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(200)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Artist is required.")]
        [StringLength(100)]
        [Display(Name = "Artist")]
        public string Artist { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        [StringLength(50)]
        [Display(Name = "Genre")]
        public string Genre { get; set; }

        [Range(1900, 2100, ErrorMessage = "Year must be between 1900 and 2100.")]
        [Display(Name = "Year")]
        public int Year { get; set; }

        [Range(0.0, 500.0, ErrorMessage = "Price must be between 0 and 500 BGN.")]
        [Display(Name = "Price (BGN)")]
        public decimal Price { get; set; }
    }
}
