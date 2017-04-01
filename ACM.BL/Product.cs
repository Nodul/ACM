﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Product : EntityBase
    {
        public Product()
        {

        }
        public Product(int productID)
        {
            this.ProductID = productID;
        }

        // Properties

        public Decimal? CurrentPrice { get; set; }
        public int ProductID { get; private set; }
        public string ProductDescription { get; set; }
        public string ProductName { get; set; }

        //Methods

        protected override bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrWhiteSpace(ProductName)) isValid = false;
            if (CurrentPrice == null) isValid = false;

            return isValid;
        }

        public override string ToString()
        {
            return ProductName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (this.GetType() != obj.GetType()) return false;

            Product rhs = obj as Product;

            return this.CurrentPrice == rhs.CurrentPrice && this.ProductID == rhs.ProductID && this.ProductDescription == rhs.ProductDescription && this.ProductName == rhs.ProductName;

        }
        public override int GetHashCode()
        {
            return this.CurrentPrice.GetHashCode() ^ this.ProductID.GetHashCode() ^ this.ProductDescription.GetHashCode() ^ this.ProductName.GetHashCode();
        }
    }
}
