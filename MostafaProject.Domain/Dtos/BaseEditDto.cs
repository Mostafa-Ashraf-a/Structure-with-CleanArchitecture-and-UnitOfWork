using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostafaProject.Domain.Dtos
{
    public class BaseEditDto
    {
        public DateTime Modify_At { get; set; }
        public Guid Modify_by { get; set; }
    }
}
