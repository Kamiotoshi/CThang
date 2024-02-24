using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PhoneBook phoneBook = new PhoneBook();


            phoneBook.InsertPhone("Viet", "0963221456");
            phoneBook.InsertPhone("Vy", "0354220125");
          
            while (true)
            {
                Console.WriteLine("1. Insert Phone");
                Console.WriteLine("2. Remove Phone");
                Console.WriteLine("3. Update Phone");
                Console.WriteLine("4. Search Phone");
                Console.WriteLine("5. Sort");
                Console.WriteLine("6. Display");
                Console.WriteLine("7. Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nThem moi:");

                        // Đọc thông tin từ người dùng để thêm vào danh bạ
                        Console.Write("Nhap ten: ");
                        string newName = Console.ReadLine();
                        Console.Write("Nhap so dien thoai: ");
                        string newPhone = Console.ReadLine();

                        phoneBook.InsertPhone(newName, newPhone); // Them moi vao danh ba

                        phoneBook.DisplayPhoneBook(); // Hien thi danh ba sau khi them moi
                        break;
                    case 2:
                        Console.WriteLine("\nXoa:");

                        // Đọc thông tin từ người dùng để xóa khỏi danh bạ
                        Console.Write("Nhap ten can xoa: ");
                        string removeName = Console.ReadLine();

                        phoneBook.RemovePhone(removeName); // Xoa trong danh ba

                        phoneBook.DisplayPhoneBook(); // Hien thi danh ba sau khi xoa
                        break;
                    case 3:
                        Console.Write("Enter name to update: ");
                        string nameToUpdate = Console.ReadLine();
                        Console.Write("Enter new phone number: ");
                        string phonetoUpdate = Console.ReadLine();
                        phoneBook.UpdatePhone(nameToUpdate, phonetoUpdate);
                        break;
                    case 4:
                        Console.WriteLine("\nTim kiem:");
                        // Đọc chuỗi từ người dùng để tìm kiếm
                        string searchKeyword = Console.ReadLine();

                        phoneBook.SearchPhone(searchKeyword); // Hien thi ket qua tim kiem
                        break;
                    case 5:
                        phoneBook.Sort();
                        phoneBook.DisplayPhoneBook();
                        break;
                    case 6:
                   
                        phoneBook.DisplayPhoneBook();
                        break;
                    case 7:
                        Console.WriteLine("Exiting...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter again.");
                        break;
                }
               
            }
        }
    }
}


