using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesApi.Models
{
    public class Courses
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        public uint? StudentsPerClass { get; set; }
        public CategoryEnum Category { get; set; } 
    }
}
