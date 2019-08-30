using System;
using System.Linq;

namespace DynamicPredicate
{
    class Program
    {
        static void Main(string[] args)
        {
            var pd = new QueryPredicateDemo();
            Console.WriteLine();
            pd.PredicateBuilderMethod();
            Console.ReadKey();
        }

    }

    public class QueryPredicateDemo
    {

        private QueryString _queryString;
        public QueryPredicateDemo()
        {
            InitTestData();
        }

        private void InitTestData()
        {
            _queryString = new QueryString
            {
                Age = 13,
                Status = 1
            };
        }

        public void PredicateBuilderMethod()
        {
            Console.WriteLine("***********Predicate builder***********");

            var predicate = PredicateBuilder.True<Customer>();
            if (_queryString.Age > 0)
            {
                predicate = predicate.And(x => x.Age < _queryString.Age);
            }
            if (_queryString.Status > 0)
            {
                predicate = predicate.And(x => x.Status == _queryString.Status);
            }
            var customerService = new CustomerService();
            var result = customerService.FindCustomerList(predicate);
            Console.WriteLine(string.Join(",", result.Select(x => x.Name)));
        }


    }

    public class Customer
    {
        public Customer()
        {
            CreatedAt = DateTime.Now;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class QueryString
    {
        public int Status { get; set; }
        public int Age { get; set; }
    }
}
