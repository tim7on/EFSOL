using System;
using System.Collections.Generic;
/*Задание 2 
Создайте коллекцию, в которую можно добавлять покупателей и категорию приобретенной ими 
продукции. Из коллекции можно получать категории товаров, которые купил покупатель или по 
категории определить покупателей.*/
namespace pro_2_2
{


    enum Category
    {
        Drinks, Vegitable, Fruit, Meat
    }
    class Customer
    {
        public string Name { get; set; }
        public Customer(string name)
        {
            this.Name = name;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Customer, List<Category>> dict = new Dictionary<Customer, List<Category>>();
            dict.Add(new Customer("Jay Jonna"), new List<Category> { Category.Drinks, Category.Meat });
            dict.Add(new Customer("Damien Wong"), new List<Category> { Category.Vegitable, Category.Meat });
            dict.Add(new Customer("Mill Smith"), new List<Category> { Category.Drinks, Category.Meat });
            
            foreach(var item in dict)
            {
                Console.Write(item.Key.Name + ": " );
                foreach (var category in item.Value)
                {
                    Console.Write(category + ", ");
                }
                Console.WriteLine("\n" + new string('-', 5));
            }
            
            var choice = Category.Drinks; // Category for search
            Console.WriteLine("Search Customers by category: {0}", choice);
            
            foreach (var item in dict)
            {
                foreach (var category in item.Value)
                {
                    if (category == choice)
                    {
                        Console.WriteLine(item.Key.Name);
                    }
                }
            }

        }
    }


}
