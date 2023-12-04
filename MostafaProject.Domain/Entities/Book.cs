using System.ComponentModel;

namespace MostafaProject.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public Auther? Auther { get; set; }
        public Guid? AutherId { get; set; }
        public List<Category>? Categories { get; set; }
    }
}
