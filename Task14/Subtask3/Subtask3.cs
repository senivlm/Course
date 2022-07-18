using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task14
{
    internal static class Subtask3
    {
        public static void Start()
        {
            List<IProduct> products = new List<IProduct>();

            FoodProductsFactory foodProductsFactory = new("../../../Task14/Subtask3/Storage/Texts/DairyProducts.txt",
                "../../../Task14/Subtask3/Storage/Texts/Meat.txt");
            StationeryProductsFactory stationeryProductsFactory = new("../../../Task14/Subtask3/Storage/Texts/WipesInfo.txt",
                "../../../Task14/Subtask3/Storage/Texts/Notebooks.txt");

            products.Add(foodProductsFactory.CreateProductA());
            products.Add(foodProductsFactory.CreateProductA());
            products.Add(foodProductsFactory.CreateProductA());
            products.Add(foodProductsFactory.CreateProductB());
            products.Add(foodProductsFactory.CreateProductB());
            products.Add(foodProductsFactory.CreateProductB());
            products.Add(stationeryProductsFactory.CreateProductB());
            products.Add(stationeryProductsFactory.CreateProductB());
            products.Add(stationeryProductsFactory.CreateProductB());
            products.Add(stationeryProductsFactory.CreateProductA());
            products.Add(stationeryProductsFactory.CreateProductA());
            products.Add(stationeryProductsFactory.CreateProductA());

            Storage storage = Storage.getInstance();

            storage.AddProducts(products);
        }
    }
}
