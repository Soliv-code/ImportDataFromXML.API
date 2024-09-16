using System.ComponentModel.DataAnnotations;

namespace IDFXML.Domain
{
    public class Product
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(255)]
        public required string Name { get; set; }
        public required decimal Price{ get; set; }
    }
}
