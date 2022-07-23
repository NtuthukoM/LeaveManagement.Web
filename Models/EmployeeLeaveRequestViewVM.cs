using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models
{
    public class EmployeeLeaveRequestViewVM
    {
        public List<LeaveAllocationVM> LeaveAllocations { get; set; }
        public List<LeaveRequestVM> LeaveRequests { get; set; }

        [Display(Name="Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Display(Name = "Date Requested")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime DateRequested { get; set; }
        [Display(Name = "Leave Type")]
        public int LeaveTypeId { get; set; }
        public bool? Approved { get; set; }
        public bool Canceled { get; set; }
    }
}
