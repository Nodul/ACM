using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public enum CustomerTypes
    {
        Business,
        Residential,
        Government,
        Educator
    }

    public class CustomerType
    {
        public CustomerTypes CustomerTypeID
        {
            get;set;
        }
       
        public string TypeName {
            get
            {
                return CustomerTypeID.ToString();
            }
        }
        public int? DisplayOrder { get; set; }

        public CustomerType(CustomerTypes customerType, int? displayOrder)
        {
            CustomerTypeID = customerType;
            DisplayOrder = displayOrder;
        }
    }
}
