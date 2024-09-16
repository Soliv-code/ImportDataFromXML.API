using System.ComponentModel.DataAnnotations;

namespace IDFXML.Domain
{
    public class OrderDetail
    {
        [Key]
        public long Id { get; set; }
        public required long UserId { get; set; }
        public User User{ get; set; }
        public required long OrderId { get; set; }
        public Order Order { get; set; }
        public required long ProductId { get; set; }
        public Product Product { get; set; }
        public required int Quantity { get; set; }
    }
}
