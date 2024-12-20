namespace FileIO_JSON_Serialize.Desrialize
{
    public class Program
    {
        static void Main(string[] args)
        {
            string message = @"Write inputs in correct format and carefully
1. All Products 
2. Get product 
3. Create product 
4. Delete product 
5.Clear Console
0.Exit";
            try
            {
                ProductService productService = new ProductService();
                if (!File.Exists(ProductService.PATH))
                {
                    Console.WriteLine("Name of Product:");
                    string name = Console.ReadLine();

                    Console.WriteLine("Cost Price of Product:");
                    double costPrice = double.Parse(Console.ReadLine());

                    Console.WriteLine("Sale Price of Product:");
                    double salePrice = double.Parse(Console.ReadLine());

                    Product product = new Product(name, costPrice, salePrice);
                    productService.CreateProduct(product);
                }
                Console.WriteLine($"Your example.txt path is here:{ProductService.PATH}\n");
                Console.WriteLine(message);
                int input;
                do
                {
                    input = int.Parse(Console.ReadLine());
                    switch (input)
                    {
                        case 0:
                            Console.WriteLine("Quiting..");
                            break;
                        case 1:
                            string txt = File.ReadAllText(ProductService.PATH);
                            Console.WriteLine(txt + "------------------------------------------------------------");
                            break;
                        case 2:
                            Console.WriteLine("ID:");
                            int id = int.Parse(Console.ReadLine());
                            Product prod = productService.GetProduct(id);
                            Console.WriteLine($"ID:{prod.Index} Name:{prod.Name} Cost Price:{prod.CostPrice} Sale Price:{prod.SalePrice} ");
                            break;
                        case 3:
                            Console.WriteLine("Name of Product:");
                            string name = Console.ReadLine();

                            Console.WriteLine("Cost Price of Product:");
                            double costPrice = double.Parse(Console.ReadLine());

                            Console.WriteLine("Sale Price of Product:");
                            double salePrice = double.Parse(Console.ReadLine());

                            Product product = new Product(name, costPrice, salePrice);
                            productService.CreateProduct(product);
                            break;
                        case 4:
                            Console.WriteLine("ID:");
                            int id2 = int.Parse(Console.ReadLine());
                            productService.Delete(id2);
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine(message);
                            break;
                        default:
                            Console.WriteLine("Write valid number in the shown list");
                            break;
                    }
                } while (input != 0);
            } catch (BelowSalePriceException e) {
                Console.WriteLine(e.Message);
            }
            catch (Exception e) { Console.WriteLine(e.Message); 
            }

        }
    }
}
