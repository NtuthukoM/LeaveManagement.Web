using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models
{
    public class LeaveRequestCreateVM:IValidatableObject
    {
        [Display(Name = "Start Date")]
        [Required]
        public DateTime? StartDate { get; set; } = null;
        [Display(Name = "End Date")]
        [Required]
        public DateTime? EndDate { get; set; } = null;
        [Display(Name= "Leave Type")]
        [Required]
        public int LeaveTypeId { get; set; }
        public SelectList? LeaveTypes { get; set; }
        [Display(Name ="Comments")]
        public string? RequestComments { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(StartDate > EndDate)
            {
                yield return new ValidationResult("Start date cannot be greater than end date",
                    new [] { nameof(StartDate), nameof(EndDate) });
            }
        }
    }
}
