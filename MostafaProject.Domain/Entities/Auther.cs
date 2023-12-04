using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostafaProject.Domain.Entities
{
    public class Auther : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public List<Book>? Books { get; set; }
    }
}
