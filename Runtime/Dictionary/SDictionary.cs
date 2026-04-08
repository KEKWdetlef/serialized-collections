using System;
using System.Collections.Generic;

namespace KekwDetlef.SerializedCollections
{
    [Serializable]
    public class SDictionary<TKey, TValue> : SCollection<KeyValuePair<TKey, TValue>, SKeyValuePair<TKey, TValue>>
    {

#if UNITY_EDITOR
        protected virtual Type Editor_GetBackingType => typeof(KeyValuePair<TKey, TValue>);
#endif // UNITY_EDITOR
        
#region SCollection
        public sealed override void Add(KeyValuePair<TKey, TValue> item) => Raw.Add(item.Key, item.Value);
        protected sealed override IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => Raw.GetEnumerator();

        protected sealed override void ConstructRaw(SKeyValuePair<TKey, TValue>[] source)
        {
            if (source == null)
            {
                Raw = Construct(0);
                return;
            }

            Dictionary<TKey, TValue> result = Construct(source.Length);
            foreach (SKeyValuePair<TKey, TValue> pair in source)
            {
                result.TryAdd(pair.Key, pair.Value);
            }

            Raw = result;
        }

        protected sealed override SKeyValuePair<TKey, TValue>[] DestructRaw()
        {
            if (Raw == null)
            { return new SKeyValuePair<TKey, TValue>[0]; }

            SKeyValuePair<TKey, TValue>[] result = new SKeyValuePair<TKey, TValue>[Raw.Count];

            int i = 0;
            foreach (KeyValuePair<TKey, TValue> pair in Raw)
            {
                result[i] = new SKeyValuePair<TKey, TValue>(pair);
                i++;
            }

            return result;
        }
#endregion // SCollection

        public Dictionary<TKey, TValue> Raw { get; private set; }

        public SDictionary() => Raw = new Dictionary<TKey, TValue>();
        public SDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection) => Raw = new Dictionary<TKey, TValue>(collection); 

        public static implicit operator Dictionary<TKey, TValue>(SDictionary<TKey, TValue> sDictionary) => sDictionary?.Raw;

        public void Add(TKey key, TValue value) => Raw.Add(key, value);

        protected virtual Dictionary<TKey, TValue> Construct(int capacity) => new Dictionary<TKey, TValue>(capacity);
    }
}
