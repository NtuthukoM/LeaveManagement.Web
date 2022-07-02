using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Data
{
    public class LeaveType: BaseEntity
    {
        public string Name { get; set; }
        [Display(Name = "Default number of days")]
        public int DefaultDays { get; set; }
    }
}
