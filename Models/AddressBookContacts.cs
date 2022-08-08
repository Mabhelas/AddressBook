using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBook.Models
{
    public class AddressBookContacts
    {
        [Key]
        public int ContactId { get; set; }

        [Column(TypeName ="nvarchar(50)")]
        [DisplayName("First Name")]
        [Required(ErrorMessage = "This field is required")]
        public string FirstName { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Surname")]
        [Required(ErrorMessage = "This field is required")]
        public string Surname { get; set; }

        public int Age { get; set; }

        [DisplayName("Date of birth")]
        [Required(ErrorMessage = "This field is required")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yy}")]
        public DateTime Birthday { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [DisplayName("Telephone Number")]
        [Required(ErrorMessage = "This field is required")]
        public string TelephoneNumber { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Country { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string City { get; set; }

    }
}
