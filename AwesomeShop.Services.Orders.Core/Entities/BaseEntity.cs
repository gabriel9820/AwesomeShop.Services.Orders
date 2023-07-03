using System;

namespace AwesomeShop.Services.Orders.Core.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }

        protected BaseEntity()
        {
            Id = new Guid();
        }
    }
}
