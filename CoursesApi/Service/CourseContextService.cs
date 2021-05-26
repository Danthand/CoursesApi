using EFCore.Domain;
using EFCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesApi.Service
{
    public interface ICourseValidationService
    {
        public CourseValidation ValidadeEntries(Courses course);

    }
    public class CourseContextService : ICourseValidationService
    {
        public string invalidDateError = "Não é permitido a inclusão de cursos com a data de início menor que a data atual. ";
        public string courseRangeOverlapError = "Existe(m) curso(s) planejados(s) dentro do período informado.";

        public CourseValidation ValidadeEntries(Courses course)
        {
            var result = new CourseValidation();
            result.ErrorMessage = "";
            using (var context = new CoursesContext())
            {
                var validDate = course.StartDate.Date < DateTime.Now.Date;
                bool courseRangeOverlap = context.courses.Where(s => course.StartDate <= s.FinishDate && course.FinishDate >= s.StartDate).Count() > 0;
                 
                if (!validDate)
                    result.ErrorMessage += invalidDateError;

                if (!courseRangeOverlap)
                    result.ErrorMessage += courseRangeOverlapError;

                return result;
            }
        }
    }

    public class CourseValidation
    {
        public CourseValidation()
        {
            this.ErrorMessage = "";
        }
        public bool IsValid;
        public string ErrorMessage;
    }
}
