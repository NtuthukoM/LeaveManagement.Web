using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models
{
    public class LeaveRequestVM
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime DateRequested { get; set; }
        public int LeaveTypeId { get; set; }
        public LeaveTypeVM LeaveType { get; set; }
        public bool? Approved { get; set; }
        public bool Canceled { get; set; }
        public string? RequestComments { get; set; }
        public string? RequestingEmployeeId { get; set; }
        public EmployeeListVM Employee { get; set; }

        public string HeadingText 
        { 
            get 
            {
                switch(Approved)
                {
                    case true: return "Approved";
                    case false: return "Rejected";
                    default: return "Pending Approval";
                }
            } 
        }

        public string HeadingCssClass
        {
            get
            {
                switch (Approved)
                {
                    case true: return "success";
                    case false: return "danger";
                    default: return "warning";
                }
            }
        }
        
        public int NumberOfDays { get { return (int)Math.Ceiling((EndDate - StartDate).TotalDays); } }
    }
}
