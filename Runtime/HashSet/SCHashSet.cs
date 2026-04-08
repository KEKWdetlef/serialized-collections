using System;
using System.Collections.Generic;

namespace KekwDetlef.SerializedCollections
{
    [Serializable]
    public class SCHashSet<T, Comparer> : SHashSet<T> where Comparer : IEqualityComparer<T>, new()
    {

#region SCollection
        protected sealed override void ConstructRaw(T[] source) => Raw = new HashSet<T>(source ?? Array.Empty<T>(), new Comparer());
#endregion // SCollection

        public SCHashSet() : base() { }
        public SCHashSet(IEnumerable<T> collection) : base(collection) { }

    }
}
