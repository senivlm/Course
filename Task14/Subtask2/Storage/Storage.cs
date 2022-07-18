using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Course.Task14.Subtask2
{
    public delegate void ExpirationTimeOut();

    [Serializable]
    public class Storage : ISerializable
    {
        private List<AbstractProduct> products;

        public event ExpirationTimeOut expirationTimeOutEvent;

        public Storage()
        {
            products = new();
        }

        public Storage(List<AbstractProduct> products)
        {
            this.products = new(products);
        }

        public void AddProduct(AbstractProduct product)
        {
            if (product is IExpirationProduct expirationProduct) if (expirationProduct.ExpirationDate < DateTime.Today) expirationTimeOutEvent?.Invoke();
                else products.Add(product);
        }

        public void RemoveProduct(AbstractProduct product)
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("products", products, typeof(List<IProduct>));
        }

        public Storage(SerializationInfo info, StreamingContext context)
        {
            products = (List<AbstractProduct>)info.GetValue("products", typeof(List<AbstractProduct>));
        }
    }
}