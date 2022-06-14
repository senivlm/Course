using System;
namespace Course.Task8
{
    static class ProductUserInterface
    {
        static public void AddProductsToStorage(Subtask3 storage)
        {
            while (true)
            {
                Console.Write("Введiть номер продукту якого хочете додати(1 - м'ясний вирiб, а 2 - молочний продукт): ");
                int number = int.Parse(Console.ReadLine());
                switch (number)
                {
                    case 1:
                        storage.AddProduct(CreateMeat());
                        break;
                    case 2:
                        storage.AddProduct(CreateDairyProducts());
                        break;
                    default:
                        Console.WriteLine("Продукту не iснує");
                        break;
                }
                Console.WriteLine("Для виходу введiть 1: ");
                number = int.Parse(Console.ReadLine());
                if (number == 1) break;
            }
        }

        static public Meat CreateMeat()
        {
            Console.Write("Введiть назву продукту: ");
            string name = Console.ReadLine();
            Console.Write("Введiть цiну продукту: ");
            int price = int.Parse(Console.ReadLine());
            Console.Write("Введiть вагу продукта: ");
            int weight = int.Parse(Console.ReadLine());
            Console.Write("Введiть номер категорiї продукту(1 або 2): ");
            Category category = (Category)Enum.GetValues(typeof(Category)).GetValue(int.Parse(Console.ReadLine()) - 1);
            Console.Write("Введiть номер сорту(1 - баранина, 2 - телятина, 3 - курятина, 4 - свинина) продукту: ");
            Sort sort = (Sort)Enum.GetValues(typeof(Sort)).GetValue(int.Parse(Console.ReadLine()) - 1);
            try
            {
                Meat result = new Meat(name, price, weight, category, sort);
                return result;
            }
            catch (ArgumentException e)
            {
                throw e;
            }
        }

        static public DairyProducts CreateDairyProducts()
        {
            Console.Write("Введiть назву продукту: ");
            string name = Console.ReadLine();
            Console.Write("Введiть цiну продукту: ");
            int price = int.Parse(Console.ReadLine());
            Console.Write("Введiть вагу продукта: ");
            int weight = int.Parse(Console.ReadLine());
            Console.Write("Введiть термiн придатностi продукту: ");
            int date = int.Parse(Console.ReadLine());

            try
            {
                DairyProducts result = new DairyProducts(name, price, weight, date);
                return result;
            }
            catch (ArgumentException e)
            {
                throw e;
            }
        }
    }
}
