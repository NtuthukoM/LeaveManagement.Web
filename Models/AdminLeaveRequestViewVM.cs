using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models
{
    public class AdminLeaveRequestViewVM
    {
        [Display(Name ="Total number of Requests")]
        public int TotalRequests { get; set; }
        [Display(Name = "Approved Requests")]
        public int ApprovedRequests { get; set; }
        [Display(Name = "Pending Requests")]
        public int PendingRequests { get; set; }
        [Display(Name = "Rejected Requests")]
        public int RejectedRequests { get; set; }
        public List<LeaveRequestVM> LeaveRequests { get; set; }

        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; } = null;
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; } = null;
        [Display(Name = "Leave Type")]
        public int LeaveTypeId { get; set; }
        [Display(Name = "Date Requested")]
        public DateTime? DateRequested { get; set; } = null;
        [Display(Name = "Requested By")]

        public string RequestingEmployeeId { get; set; }
        public bool Approved { get; set; }
        public bool Canceled { get; set; }

    }
}
