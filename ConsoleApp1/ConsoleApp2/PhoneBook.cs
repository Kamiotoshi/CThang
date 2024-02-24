using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp2
{
    class PhoneBook : Phone
    {
        List<string> phoneList = new List<string>();
        public void DisplayPhoneBook()
        {
            Console.WriteLine("Danh ba dien thoai:");
            for (int i = 0; i < phoneList.Count; i += 2)
            {
                Console.WriteLine("Ten: " + phoneList[i] + ", So dien thoai: " + phoneList[i + 1]);
            }
        }

        protected bool IsNameExist(string name)
        {
            return phoneList.Contains(name);
        }

        protected bool IsPhoneExist(string phone)
        {
            return phoneList.Contains(phone);
        }
        public override void InsertPhone(string name, string phone)
        {
            if (!IsNameExist(name))
            {
                phoneList.Add(name);
                phoneList.Add(phone);
            }
            else
            {
                int index = phoneList.IndexOf(name);
                if (!phoneList[index + 1].Equals(phone))
                {
                    phoneList[index + 1] = phone;
                }
            }
        }

        public override void RemovePhone(string name)
        {
            if (IsNameExist(name))
            {
                int index = phoneList.IndexOf(name);
                phoneList.RemoveAt(index + 1);
                phoneList.RemoveAt(index);
            }
        }

        public override void UpdatePhone(string name, string newPhone)
        {
            if (IsNameExist(name))
            {
                int index = phoneList.IndexOf(name);
                phoneList[index + 1] = newPhone;
            }
        }

        public override void SearchPhone(string name)
        {
            bool found = false;
            Console.WriteLine("Ket qua tim kiem:");

            foreach (string entry in phoneList)
            {
                if (entry.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Console.WriteLine("Ten: " + entry + ", So dien thoai: " + phoneList[phoneList.IndexOf(entry) + 1]);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Khong tim thay " + name + " trong danh ba.");
            }
        }

        public override void Sort()
        {
            phoneList.Sort();
        }
    }

}
