using System;
using System.Collections.Generic;

namespace KekwDetlef.SerializedCollections
{
    [Serializable]
    public class SCDictionary<TKey, TValue, Comparer> : SDictionary<TKey, TValue> where Comparer : IEqualityComparer<TKey>, new()
    {

#if UNITY_EDITOR
        protected override Type Editor_GetBackingType => base.Editor_GetBackingType;
#endif // UNITY_EDITOR

        public SCDictionary() : base() { }
        public SCDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection) : base(collection) { }

        protected override Dictionary<TKey, TValue> Construct(int capacity) => new Dictionary<TKey, TValue>(capacity, new Comparer());
    }
}
