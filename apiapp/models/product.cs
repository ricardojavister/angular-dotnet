using System.ComponentModel.DataAnnotations;

namespace apiapp.models
{
    public class product
    {
        [Key]
        public int idproduct { get; set; }
        [Required]
        public string productName { get; set; }
        [Required]
        public decimal price { get; set; }
    }
}