using CL.Domain.Models.Customers;
using CL.Domain.Models.Posts;
using EntityFrameworkDemo.DemoContext;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemoOnly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            VidzyContext context = new VidzyContext();
  
            
            try
            {
                context.AddVideo("Updated Test Data", DateTime.Now, 1,((byte)ClassificationEnum.Platinum));
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);

                throw;
            }
            Console.WriteLine("End");
            Console.ReadLine();
        }
    }
}
