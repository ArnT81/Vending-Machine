﻿using Vending_Machine.Interfaces;
using Vending_Machine.Repositories;
using static Vending_Machine.Models.Product;

namespace Vending_Machine.Services
{
    internal class VendingMachineService : IVending
    {
        private VendingMachineRepo VendingMachineRepo;
        private MoneyPoolRepo MoneyPoolRepo;
        private ShoppingCartRepo ShoppingCartRepo;
        private decimal MoneyLeft;
        public VendingMachineService()
        {
            VendingMachineRepo = new VendingMachineRepo();
            MoneyPoolRepo = new MoneyPoolRepo();
            ShoppingCartRepo = new ShoppingCartRepo();
            MoneyLeft = MoneyPoolRepo.Read().CurrentCostumerBalance;
        }


        //  PURCHASE
        public void Purchase(Soda soda)
        {
            if (MoneyLeft > soda.Price) VendingMachineRepo.Create(soda);
            else Console.WriteLine("You do not have enough money");
        }
        public void Purchase(Snack snack)
        {
            if (MoneyLeft > snack.Price) VendingMachineRepo.Create(snack);
            else Console.WriteLine("You do not have enough money");
        }
        public void Purchase(Nicotine nicotine)
        {
            if (MoneyLeft > nicotine.Price) VendingMachineRepo.Create(nicotine);
            else Console.WriteLine("You do not have enough money");
        }

        public List<dynamic> ShowAll() => VendingMachineRepo.ReadAll();
        public List<dynamic> GetBoughtProducts() => ShoppingCartRepo.ReadAll();

        public void Details()
        {
            //kallas i conrollern just nu
        }

        public void InsertMoney(char money) => MoneyPoolRepo.Create(money);


        public void EndTransaction()
        {
            Console.WriteLine($"\nThank you for your purchase, here is your remaining {MoneyPoolRepo.Read().CurrentCostumerBalance}kr\n");
            
            MoneyPoolRepo.Delete();
            ShoppingCartRepo.Delete();
        }

        public decimal ShowMeTheMoney() => MoneyPoolRepo.Read().CurrentCostumerBalance;
    }
}