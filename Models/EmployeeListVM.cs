using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models
{
    public class EmployeeListVM
    {
        public string Id { get; set; }
        [Display(Name = "Frist Name")]
        public string FristName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Date Joined")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime DateJoined { get; set; }
        public string Email { get; set; }
    }
}
