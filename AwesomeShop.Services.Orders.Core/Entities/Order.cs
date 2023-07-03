using AwesomeShop.Services.Orders.Core.Enums;
using AwesomeShop.Services.Orders.Core.Events;
using AwesomeShop.Services.Orders.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AwesomeShop.Services.Orders.Core.Entities
{
    public class Order : AggregateRoot
    {
        public decimal TotalPrice { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public OrderStatus Status { get; private set; }

        public Customer Customer { get; private set; }
        public DeliveryAddress DeliveryAddress { get; private set; }
        public PaymentAddress PaymentAddress { get; private set; }
        public PaymentInfo PaymentInfo { get; private set; }
        public List<OrderItem> Items { get; private set; }

        public Order(Customer customer, DeliveryAddress deliveryAddress, PaymentAddress paymentAddress, PaymentInfo paymentInfo, List<OrderItem> items)
        {
            Customer = customer;
            DeliveryAddress = deliveryAddress;
            PaymentAddress = paymentAddress;
            PaymentInfo = paymentInfo;
            Items = items;

            TotalPrice = SumItems();
            CreatedAt = DateTime.UtcNow;
            Status = OrderStatus.Created;

            AddEvent(new OrderCreated(Id, TotalPrice, PaymentInfo, Customer.FullName, Customer.Email));
        }

        private decimal SumItems()
        {
            return Items.Sum(i => i.Quantity * i.Price);
        }

        public void Complete()
        {
            Status = OrderStatus.Completed;
        }

        public void Reject()
        {
            Status = OrderStatus.Rejected;
        }
    }
}
