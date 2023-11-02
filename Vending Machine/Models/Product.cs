namespace Vending_Machine.Models
{
    public abstract class Product
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public int Carbohydrate { get; set; }
        public int Fat { get; set; }
        public int Sugars { get; set; }
        public int Energy { get; set; }
        public string? PossibleAllergen { get; set; }
        public decimal Price { get; set; }
        public string? Type { get; set; }
        public abstract void Consume();
       


        public class Temp
        {
            public int Id { get; set; }
            public string? Brand { get; set; }
            public int Carbohydrate { get; set; }
            public int Fat { get; set; }
            public int Sugars { get; set; }
            public int Energy { get; set; }
            public string? PossibleAllergen { get; set; }
            public decimal Price { get; set; }
            public string? Type { get; set; }
        }


        public class Soda : Product
        {
            public override void Consume()
            {
                Console.WriteLine("Drinking the beverage");
            }
        }

        public class Snack : Product
        {
            public override void Consume()
            {
                Console.WriteLine("Eating the snack");
            }
        }

        public class Nicotine : Product
        {
           public override void Consume()
            {
                Console.WriteLine("consuming nicotine product");
            }
        }
    }
}
