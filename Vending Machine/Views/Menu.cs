using Vending_Machine.Controllers;

namespace Vending_Machine.Views
{
    public static class Menu
    {
        public static void MainMenu()
        {
            string[] alternatives = { "1. Purchase", "2. Details", "3. Insert money", "4. End transaction", "5. Use" };
            char choice = GetUserInput("Main menu", alternatives);
            VendingMachineController vendingMachineController = new VendingMachineController();

            if (choice == '1') vendingMachineController.Purchase();
            if (choice == '2') vendingMachineController.Details();
            if (choice == '3') vendingMachineController.InsertMoney();
            if (choice == '4') vendingMachineController.EndTransaction();
            if (choice == '5') vendingMachineController.Consume();
            else return;
        }



        public static char ChooseProductMenu(string[] alternatives) => GetUserInput("\n\n\nProducts alternative", alternatives);
        public static int ChooseProductOfTypeMenu(string[] alternatives) => GetUserInputDblDigit("\n\n\nProducts alternative", alternatives);

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