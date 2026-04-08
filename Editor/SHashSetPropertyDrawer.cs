using System;
using UnityEditor;

namespace KekwDetlef.SerializedCollections.Editor
{
    [CustomPropertyDrawer(typeof(SHashSet<>), true)]
    internal sealed class SHashSetPropertyDrawer : BaseCollectionPropertyDrawer
    {
        private protected override Type GetItemType(SerializedProperty _) => fieldInfo.FieldType.GetGenericArguments()[0];
        private protected override bool IsLengthEditable() => false;
    }
}
