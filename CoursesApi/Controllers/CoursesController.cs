using EFCore.Domain;
using EFCore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoursesApi.Service;

namespace CoursesApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ILogger<CoursesController> _logger;
        private readonly CoursesContext _coursesContext;
        private readonly ICourseValidationService _courseValidationService;

        public CoursesController(ILogger<CoursesController> logger, CoursesContext CoursesContext, ICourseValidationService courseValidationService)
        {
            _logger = logger;
            _coursesContext = CoursesContext;
            _courseValidationService = courseValidationService;
        }

        [HttpGet]
        public IEnumerable<Courses> Get()
        {
            return _coursesContext.courses.ToList();
        }

        [HttpPost]
        public IActionResult Add(Courses course)
        {
            var courseDateValidation = _courseValidationService.ValidadeEntries(course, _coursesContext);

            if (courseDateValidation.IsValid)
            {
                _coursesContext.Add(course);
                _coursesContext.SaveChanges();

                return Ok();
            }
            else
            {
                return BadRequest(courseDateValidation.ErrorMessage);
            }
        }

        [HttpPut]
        public IActionResult Put(Courses course)
        {
            var courseContext = _coursesContext.courses.Where(x => x.Id == course.Id);
            _coursesContext.Update(course);

            var courseDateValidation = _courseValidationService.ValidadeEntries(course, _coursesContext);

            if (courseDateValidation.IsValid)
            {
                _coursesContext.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest(courseDateValidation.ErrorMessage);
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            var course = _coursesContext.courses.Where(x => x.Id == id).Single();
            _coursesContext.courses.Remove(course);
            _coursesContext.SaveChanges();
            return Ok();
        }
    }
}
