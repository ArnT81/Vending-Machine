using Vending_Machine.Models;

namespace Vending_Machine.Views.Products
{
    public class ShowProducts
    {
        public static void All(List<dynamic> products)
        {
            Console.WriteLine("\n\n\nAvailable Products\n");
            foreach (var product in products)
            {
                Console.WriteLine("Brand: " + product.Brand);
                Console.WriteLine("Type: " + product.Type);
                Console.WriteLine($"Price: {product.Price}kr");
                Console.WriteLine();
            }
        }

        public static void One(Product product)
        {
            Console.WriteLine("\n\n\nProduct Information\n");

            Console.WriteLine("Id: " + product.Id);
            Console.WriteLine("Brand: " + product.Brand);
            Console.WriteLine("Carbohydrate: " + product.Carbohydrate);
            Console.WriteLine("Fat: " + product.Fat);
            Console.WriteLine("Sugars: " + product.Sugars);
            Console.WriteLine("Possible allergens: " + product.PossibleAllergen);
            Console.WriteLine($"Price: {product.Price}kr");
            Console.WriteLine();
        }
    }
}