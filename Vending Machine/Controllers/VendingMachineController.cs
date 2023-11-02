using System.ComponentModel.DataAnnotations;
using Vending_Machine.Models;
using Vending_Machine.Services;
using Vending_Machine.Views;
using Vending_Machine.Views.Products;

namespace Vending_Machine.Controllers
{
    internal class VendingMachineController
    {
        private VendingMachineService VendingMachineService;
        public readonly int[] AcceptedCurrency = { 1, 5, 10, 20, 50, 100, 500, 1000 };
        public List<dynamic> AllProducts;

        public VendingMachineController()
        {
            VendingMachineService = new VendingMachineService();
            AllProducts = VendingMachineService.ShowAll();
        }


        public void Purchase()
        {
            //choose which type of product to buy
            string[] alternatives = { "1. Beverage", "2. Snack", "3. Nicotine" };
            char typeOfProduct = Menu.GetUserInput("Type of product", alternatives);


            //Separates Types
            List<dynamic> temp = new List<dynamic>();
            foreach (var item in AllProducts)
            {
                if (typeOfProduct == '1' && item is Product.Soda) temp.Add(item);
                if (typeOfProduct == '2' && item is Product.Snack) temp.Add(item);
                if (typeOfProduct == '3' && item is Product.Nicotine) temp.Add(item);
            }


            //Display list of elected type to choose from
            List<string> listOfProducts = new List<string>();
            for (var i = 0; i < temp.Count; i++) listOfProducts.Add($"{i + 1}. {temp[i].Brand} Price: {temp[i].Price}");
            string[] arrayOfOptions = listOfProducts.Select(i => i.ToString()).ToArray();
            int chosenProduct = Menu.ChooseProductOfTypeMenu(arrayOfOptions);


            //Continue transaction
            var product = temp.Where(a => a.Id == temp[chosenProduct - 1].Id).ToList()[0];
            VendingMachineService.Purchase(product);

            //Visa pengar kvar och välja fortsätt eller avsluta
            //till en wiew först
            Console.WriteLine($"You've got {VendingMachineService.ShowMeTheMoney()}kr left and this product costs {product.Price}kr, please insert more money or select another product.");
            VendingMachineService.ShowMeTheMoney();


        }


        public void ViewAllProducts()
        {
            ShowProducts.All(AllProducts);
        }


        public void Details()
        {
            List<string> listOfProducts = new List<string>();

            foreach (var a in AllProducts) listOfProducts.Add($"{a.Id}. {a.Brand}");

            string[] arrayOfOptions = listOfProducts.Select(i => i.ToString()).ToArray();
            char chosenAccount = Menu.ChooseProductMenu(arrayOfOptions);
            int productId = chosenAccount - '0';

            var product = AllProducts.Where(a => a.Id == productId).ToList()[0];

            ShowProducts.One(product);
        }


        public void InsertMoney()
        {
            List<string> tempList = new List<string>();

            for (int i = 0; i < AcceptedCurrency.Length; i++) tempList.Add($"{i + 1}. {AcceptedCurrency[i]}");
            string[] arrayOfOptions = tempList.Select(i => i.ToString()).ToArray();

            char money = Menu.InsertMoneyMenu(arrayOfOptions);

            VendingMachineService.InsertMoney(money);
        }


        public void EndTransaction()
        {
            VendingMachineService.EndTransaction();
        }



        public void Consume() { Console.WriteLine(""); }
        //public void Consume(Product.Soda soda) { Console.WriteLine(""); }
        //public void Consume(Product.Snack snack) { Console.WriteLine(""); }
        //public void Consume(Product.Nicotine nicotine) { Console.WriteLine(""); }
    }
}
