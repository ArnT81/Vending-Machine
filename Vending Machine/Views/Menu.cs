using Vending_Machine.Controllers;

namespace Vending_Machine.Views
{
    public static class Menu
    {
        public static void MainMenu()
        {
            string[] alternatives = { "1. View all products", "2. Insert Money", "3. Purchase", "4. Details", "5. End transation" };
            char choice = GetUserInput("Main menu", alternatives);
            VendingMachineController vendingMachineController = new VendingMachineController();

            if (choice == '1') vendingMachineController.ViewAllProducts();
            if (choice == '2') vendingMachineController.InsertMoney();
            if (choice == '3') vendingMachineController.Purchase();
            if (choice == '4') vendingMachineController.Details();
            if (choice == '5') vendingMachineController.EndTransaction();
            else return;
        }

        public static char ChooseProductMenu(string[] alternatives) => GetUserInput("\n\n\nProducts alternative", alternatives);
        public static int ChooseProductOfTypeMenu(string header, string[] alternatives) => GetUserInputDblDigit($"\n\n\n{header}", alternatives);
        public static char InsertMoneyMenu(string[] alternatives) => GetUserInput("\n\n\nAccepted denomination", alternatives);





        public static char GetUserInput(string header, string[] alternatives)
        {
            char key = 'a';
            int[] condition = new int[alternatives.Length];

            Console.WriteLine($"{header}\n");

            for (int i = 0; i < alternatives.Length; i++) condition[i] = i + 1;

            while (!condition.Contains(key - '0'))
            {
                foreach (var item in alternatives) Console.WriteLine(item);
                key = Console.ReadKey().KeyChar;
            }
            return key;
        }

        public static int GetUserInputDblDigit(string header, string[] alternatives)
        {
            int result = -1;
            int[] condition = new int[alternatives.Length];

            Console.WriteLine($"{header}\n");

            for (int i = 0; i < alternatives.Length; i++) condition[i] = i + 1;

            while (!condition.Contains(result))
            {
                foreach (var item in alternatives) Console.WriteLine(item);

                string DblDigit = Console.ReadLine();

                try
                {
                    result = int.Parse(DblDigit);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return result;
        }
    }
}