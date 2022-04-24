using DomainLayer.Common;

namespace DomainLayer.Entities
{
    public class Customer : BaseEntity
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
    }
}
