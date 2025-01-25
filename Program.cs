// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodBankInventory
{
    public class FoodItem
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }

        public FoodItem(string name, string category, int quantity, DateTime expirationDate)
        {
            if (quantity < 0)
                throw new ArgumentException("Quantity cannot be negative.");

            Name = name;
            Category = category;
            Quantity = quantity;
            ExpirationDate = expirationDate;
        }

        public override string ToString()
        {
            return $"{Name} ({Category}) - {Quantity} units - Expires on {ExpirationDate:yyyy-MM-dd}";
        }
    }

    public class Program
    {
        private static List<FoodItem> inventory = new List<FoodItem>();

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Food Bank Inventory System");
                Console.WriteLine("1. Add Food Item");
                Console.WriteLine("2. Delete Food Item");
                Console.WriteLine("3. Print List of Current Food Items");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddFoodItem();
                        break;
                    case "2":
                        DeleteFoodItem();
                        break;
                    case "3":
                        PrintInventory();
                        break;
                    case "4":
                        Console.WriteLine("Exiting program. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void AddFoodItem()
        {
            Console.Clear();
            Console.WriteLine("Add Food Item");
            try
            {
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Category: ");
                string category = Console.ReadLine();

                Console.Write("Enter Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Console.Write("Enter Expiration Date (yyyy-MM-dd): ");
                DateTime expirationDate = DateTime.Parse(Console.ReadLine());

                inventory.Add(new FoodItem(name, category, quantity, expirationDate));
                Console.WriteLine("Food item added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }

        private static void DeleteFoodItem()
        {
            Console.Clear();
            Console.WriteLine("Delete Food Item");
            PrintInventory();

            if (inventory.Count == 0)
            {
                Console.WriteLine("No items to delete. Press any key to return to the menu.");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter the number of the item to delete: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= inventory.Count)
            {
                inventory.RemoveAt(index - 1);
                Console.WriteLine("Food item deleted successfully!");
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }

            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }

        private static void PrintInventory()
        {
            Console.Clear();
            Console.WriteLine("Current Food Items:");
            if (inventory.Count == 0)
            {
                Console.WriteLine("No food items in inventory.");
            }
            else
            {
                for (int i = 0; i < inventory.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {inventory[i]}");
                }
            }

            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }
    }
}
