namespace PryAnezNatalia.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Test
    {
        [Required]
        public int id { get; set; }
        [Key]
        [Required]
        [StringLength(100, ErrorMessage = "El nombre debe estar entre 5 y 100 caracteres", MinimumLength = 5)]
        public string name { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public Address address { get; set; }
        [Phone]
        [Required]
        public string phone { get; set; }        
        public string website { get; set; }        
        public Company company { get; set; }
    }
}
