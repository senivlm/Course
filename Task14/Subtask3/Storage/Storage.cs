using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task14
{
    delegate void ExpirationTimeOut();

    class Storage : IEnumerable
    {
        private static readonly Lazy<Storage> lazyInstance =
            new Lazy<Storage>(() => new Storage());
        
        private List<IProduct> products;

        public event ExpirationTimeOut expirationTimeOutEvent;

        // Singleton realisation
        protected Storage()
        {
            products = new();
        }

        public static Storage getInstance()
        {
            return lazyInstance.Value;
        }
        ///////////////////////////////////////////

        public void AddProducts(ICollection<IProduct> products)
        {
            this.products.AddRange(products);
        }

        public void AddProduct(IProduct product)
        {
            if (product is IExpirationProduct expirationProduct) if (expirationProduct.ExpirationDate < DateTime.Today) expirationTimeOutEvent?.Invoke();
            else products.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            products.Remove(product);
        }

        public void ClearStorage()
        {
            products.Clear();
        }

        public void ChangePrice(int percent)
        {
            foreach (IProduct product in products)
            {
                product.ChangePrice(percent);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return products.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder result = new();

            foreach(var product in products)
            {
                result.AppendLine(product.ToString());
            }

            return result.ToString();
        }
    }
}
