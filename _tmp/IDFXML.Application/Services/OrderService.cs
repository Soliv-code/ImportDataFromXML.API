using IDFXML.Application.Interfaces;
using IDFXML.Application.Models;
using IDFXML.Domain;
using IDFXML.Infrastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Xml.Serialization;

namespace IDFXML.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task ImportOrdersFromXmlAsync(IFormFile xmlFile)
        {
            if (xmlFile == null || xmlFile.Length == 0)
            {
                throw new ArgumentException("XML file is empty.");
            }

            OrdersImportDto ordersDto;

            using (var stream = xmlFile.OpenReadStream())
            {
                var serializer = new XmlSerializer(typeof(OrdersImportDto));
                ordersDto = (OrdersImportDto)serializer.Deserialize(stream);
            }

            if (ordersDto?.Orders == null || ordersDto.Orders.Count == 0)
            {
                throw new ArgumentException("No orders found in XML.");
            }

            foreach (var orderDto in ordersDto.Orders)
            {
                // Validate required fields
                if (string.IsNullOrWhiteSpace(orderDto.No))
                    throw new ArgumentException("Order No is required.");

                if (!DateOnly.TryParseExact(orderDto.RegDate, "yyyy.MM.dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var regDate))
                    throw new ArgumentException($"Invalid date format for Order No {orderDto.No}.");

                if (orderDto.Sum <= 0)
                    throw new ArgumentException($"Order Sum must be greater than zero for Order No {orderDto.No}.");

                if (orderDto.User == null)
                    throw new ArgumentException($"User information is missing for Order No {orderDto.No}.");

                if (string.IsNullOrWhiteSpace(orderDto.User.FullName) || string.IsNullOrWhiteSpace(orderDto.User.Email))
                    throw new ArgumentException($"User FullName and Email are required for Order No {orderDto.No}.");

                // Check if User exists, else create
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == orderDto.User.Email);
                if (user == null)
                {
                    user = new User
                    {
                        FullName = orderDto.User.FullName,
                        Email = orderDto.User.Email
                    };
                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();
                }

                // Create Order
                var order = new Order
                {
                    No = orderDto.No,
                    RegDate = regDate,
                    Sum = orderDto.Sum,
                    OrderDetails = new List<OrderDetail>()
                };

                foreach (var productDto in orderDto.Products)
                {
                    if (string.IsNullOrWhiteSpace(productDto.Name))
                        throw new ArgumentException($"Product Name is required in Order No {orderDto.No}.");

                    if (productDto.Price <= 0)
                        throw new ArgumentException($"Product Price must be greater than zero in Order No {orderDto.No}.");

                    if (productDto.Quantity <= 0)
                        throw new ArgumentException($"Product Quantity must be greater than zero in Order No {orderDto.No}.");

                    // Check if Product exists, else create
                    var product = await _context.Products.FirstOrDefaultAsync(p => p.Name == productDto.Name);
                    if (product == null)
                    {
                        product = new Product
                        {
                            Name = productDto.Name,
                            Price = productDto.Price
                        };
                        _context.Products.Add(product);
                        await _context.SaveChangesAsync();
                    }

                    var orderDetail = new OrderDetail
                    {
                        OrderId = order.Id,
                        ProductId = product.Id,
                        Quantity = productDto.Quantity,
                        UserId = user.Id
                    };

                    order.OrderDetails.Add(orderDetail);
                }

                _context.Orders.Add(order);
            }

            await _context.SaveChangesAsync();
        }
    }
}
