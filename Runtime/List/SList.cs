using System;
using System.Collections.Generic;

namespace KekwDetlef.SerializedCollections
{
    [Serializable]
    public class SList<T> : SCollection<T, T>
    {

#region SCollection
        public sealed override void Add(T item) => Raw.Add(item);
        protected sealed override IEnumerator<T> GetEnumerator() => Raw.GetEnumerator();
        protected sealed override void ConstructRaw(T[] source) => Raw = new List<T>(source ?? Array.Empty<T>());
        protected sealed override T[] DestructRaw() => Raw == null ? new T[0] : Raw.ToArray();
#endregion // SCollection

        public List<T> Raw { get; protected set; }

        public SList() => Raw = new List<T>();
        public SList(IEnumerable<T> collection) => Raw = new List<T>(collection);

        public static implicit operator List<T>(SList<T> sList) => sList?.Raw;
    }
}
