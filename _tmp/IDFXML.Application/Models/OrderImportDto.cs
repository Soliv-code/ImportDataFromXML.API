using System.Xml.Serialization;

namespace IDFXML.Application.Models
{
    [XmlRoot("orders")]
    public class OrdersImportDto
    {
        [XmlElement("order")]
        public List<OrderImportDto> Orders { get; set; }
    }

    public class OrderImportDto
    {
        [XmlElement("no")]
        public string No { get; set; }

        [XmlElement("reg_date")]
        public string RegDate { get; set; }

        [XmlElement("sum")]
        public decimal Sum { get; set; }

        [XmlElement("product")]
        public List<ProductImportDto> Products { get; set; }

        [XmlElement("user")]
        public UserImportDto User { get; set; }
    }

    public class ProductImportDto
    {
        [XmlElement("quantity")]
        public int Quantity { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }

    public class UserImportDto
    {
        [XmlElement("fio")]
        public string FullName { get; set; }

        [XmlElement("email")]
        public string Email { get; set; }
    }
}
