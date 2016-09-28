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
    }
}
