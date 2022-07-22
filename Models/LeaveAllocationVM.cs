﻿using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models
{
    public class LeaveAllocationVM
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name= "Number Of Days")]
        [Range(1, 50, ErrorMessage = "Invalid number entered.")]
        public int NumberOfDays { get; set; }
        public LeaveTypeVM? LeaveType { get; set; }
        [Required]
        [Display(Name = "Allocation Period")]
        public int Period { get; set; }
    }
}