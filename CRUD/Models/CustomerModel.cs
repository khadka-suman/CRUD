using CRUD.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Models
{
    public class CustomerModel
    {


        [Key]
        public int  Customer_Id { get; set; }
        [Required]
        public string? Customer_Name { get; set; }
        [Required]
        public string? Customer_Address { get; set; }
        [Required]
        public DateTime TimeStamp { get; set; }
       
    }
    /*public class CalcModel
    {
        public int a { get; set; }
        public int b { get; set; }
    }*/
}
