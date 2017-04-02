using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class CustomerTypeRepository
    {
        public List<CustomerType> Retrieve()
        {
            List<CustomerType> customerTypeList = new List<CustomerType>()
            {
                new CustomerType(CustomerTypes.Residential,2),
                new CustomerType(CustomerTypes.Residential,1),
                new CustomerType(CustomerTypes.Educator,4),
                new CustomerType(CustomerTypes.Government,3)

            };

            return customerTypeList;
        }
    }
}
