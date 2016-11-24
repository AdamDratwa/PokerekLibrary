using System.Collections.Generic;

namespace PokerekLibrary.Domain.Extensions
{
    public static class ListExtensions
    {
        public static T Pop<T>(this List<T> list, int index)
        {
            var item = list[index];
            list.RemoveAt(index);
            return item;
        }

        public static void AddIfNotExists<T>(this List<T> list, T obj)
        {
            var exists = list.Contains(obj);
            if (!exists)
            {
                list.Add(obj);
            }
        }
    }
}
