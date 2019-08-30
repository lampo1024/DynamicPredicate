using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DynamicPredicate
{
    public class CustomerService
    {
        private List<Customer> _customers;
        public CustomerService()
        {
            InitTestData();
        }
        private void InitTestData()
        {
            _customers = new List<Customer>
            {
                new Customer{ Id =1,Name="Customer001",Status =1,Age=11},
                new Customer{ Id =2,Name="Customer002",Status =0,Age=12},
                new Customer{ Id =3,Name="Customer003",Status =1,Age=13},
                new Customer{ Id =4,Name="Customer004",Status =0,Age=14},
                new Customer{ Id =5,Name="Customer005",Status =1,Age=15},
                new Customer{ Id =6,Name="Customer006",Status =1,Age=16}
            };
        }

        public List<Customer> FindCustomerList(Expression<Func<Customer, bool>> where)
        {
            var query = _customers.AsQueryable().Where(where);
            return query.ToList();
        }
    }
}
