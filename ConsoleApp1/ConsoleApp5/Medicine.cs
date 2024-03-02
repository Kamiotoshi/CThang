using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Medicine
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public Dictionary<string, int> Ingredients { get; set; }
    }

    class MedicineManager
    {
        private List<Medicine> medicines;

        public MedicineManager()
        {
            medicines = new List<Medicine>();
        }

        public void AddMedicine(string name, int quantity, decimal price, string category, Dictionary<string, int> ingredients)
        {
            Medicine medicine = new Medicine
            {
                Name = name,
                Quantity = quantity,
                Price = price,
                Category = category,
                Ingredients = ingredients
            };
            medicines.Add(medicine);
        }

        public void DisplayMedicinesByCategory(string category)
        {
            Console.WriteLine($"Danh sach thuoc trong danh muc '{category}':");
            foreach (var medicine in medicines)
            {
                if (medicine.Category == category)
                {
                    Console.WriteLine($"- Ten: {medicine.Name}, So luong: {medicine.Quantity}, Gia: {medicine.Price}");
                }
            }
        }

        public void DisplayMedicineDetails(string name)
        {
            Medicine medicine = medicines.Find(m => m.Name == name);
            if (medicine != null)
            {
                Console.WriteLine($"Thong tin chi tiet cua thuoc '{name}':");
                Console.WriteLine($"- So luong: {medicine.Quantity}");
                Console.WriteLine($"- Gia: {medicine.Price}");
                Console.WriteLine("Danh sach cac duoc pham ben trong:");
                foreach (var ingredient in medicine.Ingredients)
                {
                    Console.WriteLine($"- {ingredient.Key}: {ingredient.Value} mg");
                }
            }
            else
            {
                Console.WriteLine($"Khong tim thay thuoc '{name}'.");
            }
        }

        public void SearchMedicine(string name)
        {
            Medicine medicine = medicines.Find(m => m.Name == name);
            if (medicine != null)
            {
                DisplayMedicineDetails(name);
            }
            else
            {
                Console.WriteLine($"Khong tim thay thuoc '{name}'.");
            }
        }

        public void UpdateMedicine(string name, int quantity, decimal price, Dictionary<string, int> ingredients)
        {
            Medicine medicine = medicines.Find(m => m.Name == name);
            if (medicine != null)
            {
                medicine.Quantity = quantity;
                medicine.Price = price;
                medicine.Ingredients = ingredients;
                Console.WriteLine($"Da cap nhat thong tin cho thuoc '{name}'.");
            }
            else
            {
                Console.WriteLine($"Khong tim thay thuoc '{name}'.");
            }
        }

        public void DeleteMedicine(string name)
        {
            Medicine medicine = medicines.Find(m => m.Name == name);
            if (medicine != null)
            {
                medicines.Remove(medicine);
                Console.WriteLine($"Da xoa thuoc '{name}'.");
            }
            else
            {
                Console.WriteLine($"Khong tim thay thuoc '{name}'.");
            }
        }
    }
}
