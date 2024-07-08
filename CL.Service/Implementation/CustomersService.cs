using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CL.Data.Context;
using CL.Domain.Models.Customers;
using System.Data.Entity;
namespace CL.Service.Implementation
{
    public class CustomersService : IDisposable
    {
        public CLContext _context;
        public CustomersService()
        {
            _context = new CLContext();
        }



        public Customer GetCustomerModel(int id)
        {
            //get list
            //List<CustomerModel> customer = new List<CustomerModel>()
            //{
            //    new CustomerModel{ Id = 0,Name="Rodolfo",Details="Software Engineer"},
            //    new CustomerModel{ Id=1,Name="Kriz",Details="Advertisement"},
            //};

            return _context.Customer.Where(x => x.Id == id).Include(x => x.MembershipTypeModel).Include(x => x.CustomerDetailsModel).FirstOrDefault();
        }


        public IEnumerable<Customer> GetCustomerModel(string query)
        {
            //get list
            //List<CustomerModel> customer = new List<CustomerModel>()
            //{
            //    new CustomerModel{ Id = 0,Name="Rodolfo",Details="Software Engineer"},
            //    new CustomerModel{ Id=1,Name="Kriz",Details="Advertisement"},
            //};
            if (!String.IsNullOrWhiteSpace(query)) { // eager loading????
                return _context.Customer.Where(x => x.Name.Contains(query))
                    .Include(x => x.MembershipTypeModel)
                    .Include(x => x.CustomerDetailsModel);
            }

            return null;
        }
        public List<Customer> GetCustomerModel()
        {
            //get list 
            //List<CustomerModel> customer = new List<CustomerModel>()
            //{
            //    new CustomerModel{Id = 0, Name="Rodolfo",Details="Software Engineer"},
            //    new CustomerModel{  Id=1,Name="Kriz",Details="Advertisement"},
            //};
            try
            {
                return _context.Customer.Include(c => c.MembershipTypeModel).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        public bool AddCustomer(Customer customer)
        {
            bool status = false;
            try
            {
                _context.Customer.Add(customer);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return status;
        }

        public void Dispose()
        {
            _context.Dispose(); // not working  
        }
    }
}
