using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CL.Domain.Models.Customers
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CustomerDetail CustomerDetailsModel { get; set; }
        public bool isSubscribeToNewsletter { get; set; }
      
        public MembershipType MembershipTypeModel { get; set; }

    }
}
