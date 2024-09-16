using System.ComponentModel.DataAnnotations;

namespace IDFXML.Domain
{
    public class Order
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(100)]
        public required string No { get; set; }
        public required DateOnly RegDate { get; set; }
        public required decimal Sum { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
