using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Storage
{
    static class StorageFinder
    {
        public static List<T> GetListOfSpecificProducts<T>(this Storage storage) where T : IProduct
        {
            List<T> result = new();

            foreach (IProduct product in storage)
            {
                if (product is T item) result.Add(item);
            }

            return result;
        }

        public static IProduct FindProduct<T>(this Storage storage, Predicate<T> predicate) where T : IProduct
        {
            foreach (IProduct product in storage)
            {
                if (product is T item && predicate(item)) return item;
            }

            return null;
        }

        public static List<T> FindProducts<T>(this Storage storage, Predicate<T> predicate) where T : IProduct
        {
            List<T> result = new();

            foreach (IProduct product in storage)
            {
                if (product is T item && predicate(item)) result.Add(item);
            }

            return result;
        }
    }
}