using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesApi.Models
{
    public class CategoryEnum
    {
        public enum Categories
        {
            Name1 = 1,
            [Description("Here is another")]
            HereIsAnother = 2,
            [Description("Last one")]
            LastOne = 3

        }

    }
}
