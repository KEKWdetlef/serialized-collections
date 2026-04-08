using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KekwDetlef.SerializedCollections
{
    [Serializable]
    public abstract class SCollection<T, BT> : ISerializationCallbackReceiver, IEnumerable<T>
    {
        
#if UNITY_EDITOR
        public const string Editor_NewValueProperty = nameof(editor_newValue);
        [SerializeField] private BT editor_newValue;
        public BT Editor_NewValue => editor_newValue;
#endif // UNITY_EDITOR

        public const string SerializedDataProperty = nameof(serializedData);
        [SerializeField] private BT[] serializedData;

        public void OnAfterDeserialize()
        {
            ConstructRaw(serializedData);
            serializedData = null;
        } 

        public void OnBeforeSerialize() => serializedData = DestructRaw();

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


        public abstract void Add(T item);
        protected abstract IEnumerator<T> GetEnumerator();
        protected abstract void ConstructRaw(BT[] source);
        protected abstract BT[] DestructRaw();
    }
}
