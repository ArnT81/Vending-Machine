using System.Text.Json;
using Vending_Machine.Models;


namespace Vending_Machine.Repositories
{
    internal class VendingMachineRepo
    {
        private string path;
        private MoneyPoolRepo MoneyPoolRepo;

        public VendingMachineRepo()
        {
            MoneyPoolRepo = new MoneyPoolRepo();
            try
            {
                path = Directory.GetCurrentDirectory().Split("\\bin")[0] + "\\Database\\products.json";
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
        public Product Create(Product.Soda product)
        {
            Console.WriteLine("In VendingMachineRepo Create Soda " + product.Price);


            MoneyPoolRepo.Update(product.Price);

            return product;
        }
        public Product Create(Product.Snack product)
        {
            Console.WriteLine("In VendingMachineRepo Create Snack " + product.Price);

            MoneyPoolRepo.Update(product.Price);

            return product;
        }
        public Product Create(Product.Nicotine product)
        {
            Console.WriteLine("In VendingMachineRepo Create Nicotine " + product.Price);
            MoneyPoolRepo.Update(product.Price);

            return product;
        }


        //  READ
        public List<dynamic> ReadAll() => FileRead();


        //  UPDATE
        public Product Update(Product product)
        {
            return product;
        }


        //  DELETE
        public bool Delete(Product product)
        {
            return true;
        }





        public bool FileMutations(List<dynamic> products)
        {
            List<dynamic> sortedRentalList = products.OrderBy(q => q.Id).ToList();
            string value = JsonSerializer.Serialize(sortedRentalList);
            File.WriteAllText(path, value);
            return true;
        }

        public List<dynamic> FileRead()
        {
            string values = File.ReadAllText(path);
            List<dynamic> listOfDynamicObjects = JsonSerializer.Deserialize<List<dynamic>>(values);
            List<dynamic> listOfAccountTypes = new List<dynamic>();


            foreach (var item in listOfDynamicObjects)
            {
                var temporaryObject = JsonSerializer.Deserialize<Product.Temp>(item);

                if (temporaryObject.Type == "soda")
                {
                    Product.Soda sodaProduct = new Product.Soda()
                    {
                        Id = temporaryObject.Id,
                        Brand = temporaryObject.Brand,
                        Carbohydrate = temporaryObject.Carbohydrate,
                        Fat = temporaryObject.Fat,
                        Sugars = temporaryObject.Sugars,
                        Energy = temporaryObject.Energy,
                        PossibleAllergen = temporaryObject.PossibleAllergen,
                        Price = temporaryObject.Price,
                        Type = temporaryObject.Type
                    };

                    listOfAccountTypes.Add(sodaProduct);
                }
                if (temporaryObject.Type == "snack")
                {
                    Product.Snack snackProduct = new Product.Snack()
                    {
                        Id = temporaryObject.Id,
                        Brand = temporaryObject.Brand,
                        Carbohydrate = temporaryObject.Carbohydrate,
                        Fat = temporaryObject.Fat,
                        Sugars = temporaryObject.Sugars,
                        Energy = temporaryObject.Energy,
                        PossibleAllergen = temporaryObject.PossibleAllergen,
                        Price = temporaryObject.Price,
                        Type = temporaryObject.Type

                    };

                    listOfAccountTypes.Add(snackProduct);
                }
                if (temporaryObject.Type == "nicotine")
                {
                    Product.Nicotine nicotineProduct = new Product.Nicotine()
                    {
                        Id = temporaryObject.Id,
                        Brand = temporaryObject.Brand,
                        Carbohydrate = temporaryObject.Carbohydrate,
                        Fat = temporaryObject.Fat,
                        Sugars = temporaryObject.Sugars,
                        Energy = temporaryObject.Energy,
                        PossibleAllergen = temporaryObject.PossibleAllergen,
                        Price = temporaryObject.Price,
                        Type = temporaryObject.Type
                    };

                    listOfAccountTypes.Add(nicotineProduct);
                }
            }

            return listOfAccountTypes;
        }
    }
}