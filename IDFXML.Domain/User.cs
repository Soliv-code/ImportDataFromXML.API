using System.ComponentModel.DataAnnotations;

namespace IDFXML.Domain
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(255)]
        public required string FullName { get; set; }
        [MaxLength(255)]
        public required string Email { get; set; }
    }
}
