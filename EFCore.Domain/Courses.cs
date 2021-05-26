using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Domain
{

    public class Courses
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public uint? RegisteredStudents { get; set; }
        public CategoryId CategoryId { get; set; } 
    }
}
