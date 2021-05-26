using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Domain
{
    public class Category
    {
        public CategoryId Id { get; set; }
        public string Description { get; set; }

    }
}
