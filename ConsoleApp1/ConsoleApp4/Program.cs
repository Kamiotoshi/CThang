using System;
using System.Collections.Generic;
using System.Linq;




namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentManager studentManager = new StudentManager();
            string choice;
            do
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Them sinh vien");
                Console.WriteLine("2. Cap nhat thong tin sinh vien");
                Console.WriteLine("3. Xoa sinh vien");
                Console.WriteLine("4. Tim kiem sinh vien theo ten");
                Console.WriteLine("5. Sap xep sinh vien theo GPA");
                Console.WriteLine("6. Sap xep sinh vien theo ten");
                Console.WriteLine("7. Sap xep sinh vien theo ID");
                Console.WriteLine("8. Hien thi danh sach sinh vien");
                Console.WriteLine("9. Thoat");
                Console.Write("Nhap lua chon cua ban: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Nhap ten sinh vien: ");
                        string name = Console.ReadLine();
                        Console.Write("Nhap gioi tinh sinh vien: ");
                        string gender = Console.ReadLine();
                        Console.Write("Nhap tuoi sinh vien: ");
                        int age = int.Parse(Console.ReadLine());
                        Console.Write("Nhap diem toan: ");
                        double mathScore = double.Parse(Console.ReadLine());
                        Console.Write("Nhap diem ly: ");
                        double physicsScore = double.Parse(Console.ReadLine());
                        Console.Write("Nhap diem hoa: ");
                        double chemistryScore = double.Parse(Console.ReadLine());
                        studentManager.AddStudent(name, gender, age, mathScore, physicsScore, chemistryScore);
                        Console.WriteLine("Them sinh vien thanh cong!");
                        break;
                    case "2":
                        Console.Write("Nhap ID cua sinh vien can cap nhat: ");
                        int updateId = int.Parse(Console.ReadLine());
                        Console.Write("Nhap ten moi: ");
                        string updateName = Console.ReadLine();
                        Console.Write("Nhap gioi tinh moi: ");
                        string updateGender = Console.ReadLine();
                        Console.Write("Nhap tuoi moi: ");
                        int updateAge = int.Parse(Console.ReadLine());
                        Console.Write("Nhap diem toan moi: ");
                        double updateMathScore = double.Parse(Console.ReadLine());
                        Console.Write("Nhap diem ly moi: ");
                        double updatePhysicsScore = double.Parse(Console.ReadLine());
                        Console.Write("Nhap diem hoa moi: ");
                        double updateChemistryScore = double.Parse(Console.ReadLine());
                        studentManager.UpdateStudent(updateId, updateName, updateGender, updateAge, updateMathScore, updatePhysicsScore, updateChemistryScore);
                        break;
                    case "3":
                        Console.Write("Nhap ID cua sinh vien can xoa: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        studentManager.DeleteStudent(deleteId);
                        break;
                    case "4":
                        Console.Write("Nhap ten sinh vien can tim: ");
                        string searchName = Console.ReadLine();
                        studentManager.SearchStudent(searchName);
                        break;
                    case "5":
                        studentManager.SortStudentsByGPA();
                        break;
                    case "6":
                        studentManager.SortStudentsByName();
                        break;
                    case "7":
                        studentManager.SortStudentsById();
                        break;
                    case "8":
                        studentManager.DisplayAllStudents();
                        break;
                    case "9":
                        Console.WriteLine("Thoat chuong trinh.");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le. Vui long chon lai.");
                        break;
                }
            } while (choice != "9");
        }
    }
}

