using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace DependentPickers.Utils
{
    public static class ObservableCollectionExtensions
    {
        //public static void Sort<T>(this ObservableCollection<T> collection, Comparison<T> comparison)
        //{
        //    var sortableList = new List<T>(collection);
        //    sortableList.Sort(comparison);

        //    for (int i = 0; i < sortableList.Count; i++)
        //    {
        //        collection.Move(collection.IndexOf(sortableList[i]), i);
        //    }
        //}
        public static void Sort<T>(this ObservableCollection<T> collection)
                where T : IComparable<T>, IEquatable<T>
        {
            List<T> sorted = collection.OrderBy(x => x).ToList();

            int ptr = 0;
            while (ptr < sorted.Count - 1)
            {
                if (!collection[ptr].Equals(sorted[ptr]))
                {
                    int idx = Search(collection, ptr + 1, sorted[ptr]);
                    collection.Move(idx, ptr);
                }

                ptr++;
            }
        }

        public static int Search<T>(ObservableCollection<T> collection, int startIndex, T other)
        {
            for (int i = startIndex; i < collection.Count; i++)
            {
                if (other.Equals(collection[i]))
                    return i;
            }

            return -1; // decide how to handle error case
        }
    }
}
