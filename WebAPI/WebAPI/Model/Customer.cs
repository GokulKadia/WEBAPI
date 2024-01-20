using System.ComponentModel.DataAnnotations;

namespace WebAPI.Model
{
    public class Customer
    {
        [Key]
        public int id { get; set; }

        [StringLength(75)]
        public string FirstName { get; set; } = "";

        [StringLength(75)]
        public string LastName { get; set; } = "";

        [StringLength(75)]
        public string PhoneNo { get; set; } = "";
        [StringLength(75)]
        public string EmailId { get; set; } = "";
    }
}
