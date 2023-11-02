using System.Text.Json;
using System.Xml.Linq;
using Vending_Machine.Models;

namespace Vending_Machine.Repositories
{
    public class MoneyPoolRepo
    {
        private string path;

        public MoneyPoolRepo()
        {
            try
            {
                path = Directory.GetCurrentDirectory().Split("\\bin")[0] + "\\Database\\moneyPool.json";
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        //  CREATE
        public MoneyPool Create(char money)
        {
            var moneyPool = FileRead();

            decimal sum = money switch
            {
                '1' => 1,
                '2' => 5,
                '3' => 10,
                '4' => 20,
                '5' => 50,
                '6' => 100,
                '7' => 500,
                '8' => 1000,
                _ => throw new ArgumentOutOfRangeException()
            };

            moneyPool.CurrentCostumerBalance = sum;

            FileMutations(moneyPool);

            return moneyPool;
        }


        //  READ
        public MoneyPool Read() => FileRead();


        //  UPDATE
        public void Update(decimal cost)
        {
            MoneyPool moneyPool = FileRead();
            decimal costumerMoney = moneyPool.CurrentCostumerBalance;
            decimal VendingMachineMoney = moneyPool.Balance;

            //Removes money from the customer 
            moneyPool.CurrentCostumerBalance = costumerMoney - cost;
            //Adds money to the machines balance
            moneyPool.Balance = VendingMachineMoney + cost;

            FileMutations(moneyPool);
        }


        //  DELETE
        public bool Delete()
        {
            MoneyPool moneyPool = FileRead();
            moneyPool.CurrentCostumerBalance = 0;

            FileMutations(moneyPool);

            return true;
        }





        public bool FileMutations(MoneyPool money)
        {
            string value = JsonSerializer.Serialize(money);
            File.WriteAllText(path, value);
            return true;
        }

        public MoneyPool FileRead()
        {
            string values = File.ReadAllText(path);
            MoneyPool moneyPool = JsonSerializer.Deserialize<MoneyPool>(values);
            return moneyPool;
        }
    }
}