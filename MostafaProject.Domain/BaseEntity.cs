using System;
using System.ComponentModel.DataAnnotations;

namespace MostafaProject.Domain
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; } = new Guid();
        public DateTime Created_At { get; set; } = DateTime.Now;
        public Guid Created_by { get; set; } = Guid.Empty;
        public DateTime? Modified_At { get; set; }
        public Guid? Modified_by { get; set; } = null;
        public bool Is_Deleted { get; set; }
    }
}
