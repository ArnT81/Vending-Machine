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
            
        }

        public class Snack : Product
        {

        }

        public class Nicotine : Product
        {

        }
    }
}
