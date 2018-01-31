using System;
using System.ComponentModel.DataAnnotations;

namespace CoursesManipulator.ViewModels
{
    public class CourseViewModel
    {
        public int? CourseId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(250)]    
        public string Name { get; set; }

        public int? Day { get; set; }

        [Required]
        [RegularExpression(@"^\(?([0-1][0-9])\)?[:. ]?([0]{2})$", ErrorMessage = "Example 10:00")]
        public string StartDate { get; set; }

        [Required]
        [RegularExpression(@"^\(?([0-1][0-9])\)?[:. ]?([0]{2})$", ErrorMessage = "Example 12:00")]
        public string EndDate { get; set; }

        [Display(Name="Day")]
        [Required]
        public string DayString { get; set; }
    }
}
