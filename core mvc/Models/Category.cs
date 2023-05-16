using System.ComponentModel.DataAnnotations;
//System.ComponentModel.DataAnnotations" namespace provides classes and attributes that
//are used to perform data validation in .NET applications.

//RequiredAttribute
//RangeAttribute
//RegularExpressionAttribute
//StringLengthAttribute
//CompareAttribute
//CreditCardAttribute
//EmailAddressAttribute
//UrlAttribute
//PhoneAttribute


namespace BulkyBookWeb.Models
{
    public class Category
    {

        [Key]                                               //primary key
        public int Id { get; set; }

        [Required]                                            //required
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CraeatedDateTime { get; set; }=DateTime.Now;


    }
}
