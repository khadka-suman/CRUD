using CRUD.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Models
{
    public class Customer
    {


        [Key]
        public int  Customer_Id { get; set; }
        [Required]
        public string? Customer_Name { get; set; }
        [Required]
        public string? Customer_Address { get; set; }

    }
}
