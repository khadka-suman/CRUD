using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Models
{
    public class OrderList
    {
        [Key]
        public int Order_Id { get; set; }
        [Required]
        public string? Order_Name { get; set; }
        
       
    }
    
}
