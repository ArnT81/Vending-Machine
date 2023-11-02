namespace Vending_Machine.Views.Money
{
    public class ShowMoney
    {
        public static void Balance(decimal balance)
        {
            Console.WriteLine($"You've got {balance}kr left.");
            Console.WriteLine();
        }
    }
}