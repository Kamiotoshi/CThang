﻿using System;
using System.Collections.Generic;

namespace ConsoleApp5 {
    class Program
    {
        static Medicine InputNewMedicine()
        {
            Console.WriteLine("Nhap thong tin cho thuoc moi:");
            Console.Write("Ten thuoc: ");
            string name = Console.ReadLine();

            Console.Write("So luong: ");
            int quantity;
            while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
            {
                Console.WriteLine("So luong phai la mot so nguyen khong am. Vui long nhap lai.");
                Console.Write("So luong: ");
            }

            Console.Write("Gia ban: ");
            decimal price;
            while (!decimal.TryParse(Console.ReadLine(), out price) || price < 0)
            {
                Console.WriteLine("Gia ban phai la mot so khong am. Vui long nhap lai.");
                Console.Write("Gia ban: ");
            }

            Console.Write("Danh muc thuoc: ");
            string category = Console.ReadLine();

            Console.WriteLine("Nhap thong tin cac duoc pham ben trong:");
            Dictionary<string, int> ingredients = new Dictionary<string, int>();
            bool addingIngredients = true;
            while (addingIngredients)
            {
                Console.Write("Ten duoc pham: ");
                string ingredientName = Console.ReadLine();

                int ingredientAmount;
                while (!int.TryParse(Console.ReadLine(), out ingredientAmount) || ingredientAmount < 0)
                {
                    Console.WriteLine("So luong phai la mot so nguyen khong am. Vui long nhap lai.");
                    Console.Write("So luong: ");
                }

                ingredients.Add(ingredientName, ingredientAmount);

                Console.Write("Ban muon nhap them duoc pham khong? (yes/no): ");
                string userInput = Console.ReadLine().ToLower();
                addingIngredients = userInput == "yes";
            }

            return new Medicine
            {
                Name = name,
                Quantity = quantity,
                Price = price,
                Category = category,
                Ingredients = ingredients
            };
        }

        static void Main(string[] args)
        {
            MedicineManager manager = new MedicineManager();

            Console.WriteLine("---- Quan ly danh sach thuoc trong benh vien ----");

            while (true)
            {
                Console.WriteLine("\nChon chuc nang:");
                Console.WriteLine("1. Them thuoc moi");
                Console.WriteLine("2. Hien thi danh sach thuoc theo danh muc");
                Console.WriteLine("3. Hien thi chi tiet thuoc");
                Console.WriteLine("4. Tim kiem thuoc");
                Console.WriteLine("5. Cap nhat thong tin thuoc");
                Console.WriteLine("6. Xoa thuoc");
                Console.WriteLine("7. Thoat");

                Console.Write("Nhap lua chon cua ban: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Medicine newMedicine = InputNewMedicine();
                        manager.AddMedicine(newMedicine.Name, newMedicine.Quantity, newMedicine.Price, newMedicine.Category, newMedicine.Ingredients);
                        break;
                    case "2":
                        Console.Write("Nhap danh muc thuoc can hien thi: ");
                        string category = Console.ReadLine();
                        manager.DisplayMedicinesByCategory(category);
                        break;
                    case "3":
                        Console.Write("Nhap ten thuoc can hien thi chi tiet: ");
                        string medicineName = Console.ReadLine();
                        manager.DisplayMedicineDetails(medicineName);
                        break;
                    case "4":
                        Console.Write("Nhap ten thuoc can tim kiem: ");
                        string searchName = Console.ReadLine();
                        manager.SearchMedicine(searchName);
                        break;
                    case "5":
                        Console.Write("Nhap ten thuoc can cap nhat: ");
                        string updateName = Console.ReadLine();
                        Console.Write("Nhap so luong moi: ");
                        int newQuantity = int.Parse(Console.ReadLine());
                        Console.Write("Nhap gia moi: ");
                        decimal newPrice = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("Nhap thong tin cac duoc pham ben trong:");
                        Dictionary<string, int> newIngredients = new Dictionary<string, int>();
                        bool addingNewIngredients = true;
                        while (addingNewIngredients)
                        {
                            Console.Write("Ten duoc pham: ");
                            string newIngredientName = Console.ReadLine();

                            int newIngredientAmount;
                            while (!int.TryParse(Console.ReadLine(), out newIngredientAmount) || newIngredientAmount < 0)
                            {
                                Console.WriteLine("So luong phai la mot so nguyen khong am. Vui long nhap lai.");
                                Console.Write("So luong: ");
                            }

                            newIngredients.Add(newIngredientName, newIngredientAmount);

                            Console.Write("Ban muon nhap them duoc pham khong? (yes/no): ");
                            string userInput = Console.ReadLine().ToLower();
                            addingNewIngredients = userInput == "yes";
                        }
                        manager.UpdateMedicine(updateName, newQuantity, newPrice, newIngredients);
                        break;
                    case "6":
                        Console.Write("Nhap ten thuoc can xoa: ");
                        string deleteName = Console.ReadLine();
                        manager.DeleteMedicine(deleteName);
                        break;
                    case "7":
                        Console.WriteLine("Ung dung da ket thuc.");
                        return;
                    default:
                        Console.WriteLine("Lua chon khong hop le. Vui long chon lai.");
                        break;
                }
            }
        }
    }
}



