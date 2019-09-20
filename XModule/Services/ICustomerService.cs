using XModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XModule.Services
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();
    }
}
