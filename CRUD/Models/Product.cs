using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Product
    {
        [Key]
        public int Product_Id { get; set; }
        [Required]
        public string? Product_Name { get; set; }

    }
}
