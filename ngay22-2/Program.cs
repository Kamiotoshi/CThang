using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Customer
    {
        public String CustomerID { get; set; }
        public String CustomerName { get; set; }
        public DateTime BillDate { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public Customer(string customerID, string customerName, DateTime billDate, int quantity, double unitPrice)
        {
            CustomerID = customerID;
            CustomerName = customerName;
            BillDate = billDate;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
        public Customer() { }
        public virtual double CalculateTotal()
        {
            return Quantity * UnitPrice;
        }
    }
    class VietnameseCustomer : Customer
    {
        public enum CustomerType
        {
            SinhHoat,
            KinhDoanh,
            SanXuat
        }
        public CustomerType Type { get; set; }

        public override double CalculateTotal()
        {
            
            double newUnitPrice = 0;
            int threshold1 = 50;
            int threshold2 = 100;
            int threshold3 = 200;
           
            if (Quantity <= threshold1)
            {
                return Quantity * UnitPrice;
            }
            else if (Quantity > threshold1 && Quantity <= threshold2)
            {
                newUnitPrice = 1200;
                return UnitPrice * threshold1 + newUnitPrice * (Quantity - threshold1);
            }
            else if (Quantity > threshold2 && Quantity <= threshold3)
            {
                newUnitPrice = 1500;
                return UnitPrice * threshold1 + UnitPrice*threshold2  + newUnitPrice * (Quantity - threshold2);
            }
            else
            {
                newUnitPrice = 2000;
                return UnitPrice * threshold1 + UnitPrice * threshold2 + UnitPrice*threshold3 + newUnitPrice * (Quantity - threshold3);
            }
        }
    }
    class ForeignCustomer : Customer
    {
        public string Nationality { get; set; }
        public ForeignCustomer(string customerID, string customerName, DateTime billDate, int quantity, double unitPrice, string nationality)
        : base(customerID, customerName, billDate, quantity, unitPrice)
        {
            Nationality = nationality;
        }

        public ForeignCustomer()
        {
        }

        public override double CalculateTotal()
        {
            return Quantity * 2000;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            VietnameseCustomer vietnameseCustomer = new VietnameseCustomer()
            {
                CustomerID = "VN001",
                CustomerName = "Nguyễn Văn A",
                BillDate = new DateTime(2024, 2, 22),
                Type = VietnameseCustomer.CustomerType.SinhHoat,
                Quantity = 150,
                UnitPrice = 2000
            };


            ForeignCustomer foreignCustomer = new ForeignCustomer()
            {
                CustomerID = "FN001",
                CustomerName = "John Smith",
                BillDate = new DateTime(2024, 2, 22),
                Nationality = "US",
                Quantity = 100,
                UnitPrice = 2000
            };
            
            Console.WriteLine("Thông tin hoá đơn của Khách hàng Việt Nam:");
            Console.WriteLine($"Mã KH: {vietnameseCustomer.CustomerID}");
            Console.WriteLine($"Họ tên: {vietnameseCustomer.CustomerName}");
            Console.WriteLine($"Ngày ra hoá đơn: {vietnameseCustomer.BillDate.ToShortDateString()}");
            Console.WriteLine($"Đối tượng khách hàng: {vietnameseCustomer.Type}");
            Console.WriteLine($"Thành tiền: {vietnameseCustomer.CalculateTotal()}");

            
            Console.WriteLine("\nThông tin hoá đơn của Khách hàng Nước ngoài:");
            Console.WriteLine($"Mã KH: {foreignCustomer.CustomerID}");
            Console.WriteLine($"Họ tên: {foreignCustomer.CustomerName}");
            Console.WriteLine($"Ngày ra hoá đơn: {foreignCustomer.BillDate.ToShortDateString()}");
            Console.WriteLine($"Quốc tịch: {foreignCustomer.Nationality}");
            Console.WriteLine($"Thành tiền: {foreignCustomer.CalculateTotal()}");

            Console.ReadKey();
        }
    }
}
