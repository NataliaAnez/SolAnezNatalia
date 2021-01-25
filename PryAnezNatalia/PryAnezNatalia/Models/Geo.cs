namespace PryAnezNatalia.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Geo
    {
        [Key]
        [Required]
        public string lat { get; set; }
        [Required]
        public string lng { get; set; }
    }
}