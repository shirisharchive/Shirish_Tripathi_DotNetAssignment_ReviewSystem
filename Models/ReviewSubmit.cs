using System.ComponentModel.DataAnnotations;

namespace Shirish_Tripathi_Dot_Net_Assignment.Models
{
    public class ReviewSubmit
    {

        [Key]  // Marks this as the Primary Key
        public int Id { get; set; }

        [Required]  // Ensures the field is not null
        public required string Name { get; set; }

        [Required]
        public required string Feedback { get; set; }  // Added Feedback

        [Range(1, 5, ErrorMessage = "Star rating must be between 1 and 5")]
        public int StarRating { get; set; }  // Added Star Rating

    }
}
