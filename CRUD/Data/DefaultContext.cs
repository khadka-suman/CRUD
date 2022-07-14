using System.Data.SqlClient;
using System;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CRUD.Models;

namespace CRUD.Data
{
    public class DefaultContext : DbContext
    {
        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderList> OrderLists { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }


        /*    public class DefaultContext1
        */   /* {*/
        public string DbCon()
        {
            string joinpath = " ";
            string txtpath = @"C:\Users\97798\source\repos\CRUD\CRUD\DbConnection.txt";
            try
            {
                if (File.Exists(txtpath))
                {
                    using StreamReader sr = new(txtpath);
                    {
                        while (sr.Peek() >= 0)
                        {
                            //txtpath = sr.ReadToEnd();
                            string ss = sr.ReadLine();
                            string[] txtsplit = ss.Split(';');
                            string DataSource = txtsplit[0].ToString();
                            string Catalog = txtsplit[1].ToString();
                            string IntegratedSecurity = txtsplit[2].ToString();
                            string ConnectTimeout = txtsplit[3].ToString();
                            string Encrypt = txtsplit[4].ToString();
                            string TrustServerCertifucate = txtsplit[5].ToString();
                            string ApplictaionIntent = txtsplit[6].ToString();
                            string MultiSubnetFailover = txtsplit[7].ToString();
                            joinpath = DataSource + ";" + Catalog + ";" + IntegratedSecurity + ";" + ConnectTimeout + ";" + ConnectTimeout + ";" + Encrypt + ";" + TrustServerCertifucate + ";" + ApplictaionIntent + ";" + MultiSubnetFailover;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return joinpath;


        }

    
    }
}




