using System;
using System.Collections.Generic;

namespace KekwDetlef.SerializedCollections
{
    [Serializable]
    public class SHashSet<T> : SCollection<T, T>
    {

#region SCollection
        public sealed override void Add(T item) => Raw.Add(item);
        protected override void ConstructRaw(T[] source) => Raw = new HashSet<T>(source ?? Array.Empty<T>());

        protected sealed override T[] DestructRaw()
        {
            if (Raw == null)
            { return new T[0]; }

            T[] result = new T[Raw.Count];

            int i = 0;
            foreach (T value in Raw)
            {
                result[i] = value;
                i++;
            }

            return result;
        }

        protected sealed override IEnumerator<T> GetEnumerator() => Raw.GetEnumerator();
#endregion // SCollection

        public HashSet<T> Raw { get; protected set; }

        public SHashSet() => Raw = new HashSet<T>();
        public SHashSet(IEnumerable<T> collection) => Raw = new HashSet<T>(collection);

        public static implicit operator HashSet<T>(SHashSet<T> sHashSet) => sHashSet?.Raw;

        protected virtual HashSet<T> Construct(int capacity) => new HashSet<T>(capacity);
    }
}
