using System;
using System.Collections.Generic;

namespace KekwDetlef.SerializedCollections
{
    [Serializable]
    public class SUniqueList<T> : SCollection<T, T>
    {

#region SCollection
        public override void Add(T item)
        {
            if (Raw.Contains(item))
            { return; }

            Raw.Add(item);
        }

        protected override IEnumerator<T> GetEnumerator() => Raw.GetEnumerator();

        protected override void ConstructRaw(T[] source)
        {
            Raw = new List<T>();

            if (source == null)
            { return; }

            foreach (T value in source)
            {
                Add(value);
            }
        }

        protected override T[] DestructRaw() => Raw == null ? new T[0] : Raw.ToArray();
#endregion // SCollection

        protected List<T> Raw { get; set; }

        public SUniqueList() => Raw = new List<T>();
        public SUniqueList(IEnumerable<T> collection)
        {
            Raw = new List<T>();
            
            foreach (T item in collection)
            {
                Add(item);
            }
        }
    }
}
