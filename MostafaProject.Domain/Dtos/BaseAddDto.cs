using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostafaProject.Domain.Dtos
{
    public class BaseAddDto
    {
        public DateTime Created_At { get; set; }
        public Guid Created_by { get; set; }
    }
}
