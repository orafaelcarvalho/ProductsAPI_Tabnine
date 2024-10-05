using System;
using ProductsAPI_Tabnine.Domain.Enums;

namespace ProductsAPI_Tabnine.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public ProductStatus Status { get; private set; }
        public DateTime ManufacturingDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public string SupplierCode { get; private set; }

        public Product(string description, ProductStatus status, DateTime manufacturingDate, DateTime expirationDate, string supplierCode)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be null or empty.", nameof(description));

            if (manufacturingDate >= expirationDate)
                throw new ArgumentException("Manufacturing date must be earlier than expiration date.", nameof(manufacturingDate));

            if (string.IsNullOrWhiteSpace(supplierCode))
                throw new ArgumentException("Supplier code cannot be null or empty.", nameof(supplierCode));

            Id = Guid.NewGuid();
            Description = description;
            Status = status;
            ManufacturingDate = manufacturingDate;
            ExpirationDate = expirationDate;
            SupplierCode = supplierCode;
        }

        public void MarkAsDeleted()
        {
            Status = ProductStatus.Deleted;
        }
    }
}