using Vending_Machine.Models;

namespace Vending_Machine.Interfaces
{
    internal interface IVending
    {
        void Purchase(Product.Soda soda);
        List<dynamic> ShowAll();
        void Details();
        void InsertMoney(char money);
        void EndTransaction();
    }
}