using System;
using UnityEditor;

namespace KekwDetlef.SerializedCollections.Editor
{
    [CustomPropertyDrawer(typeof(SList<>))]
    internal sealed class SListPropertyDrawer : BaseCollectionPropertyDrawer
    {
        private protected override bool IsLengthEditable() => true;
        private protected override Type GetItemType(SerializedProperty _) => fieldInfo.FieldType.GetGenericArguments()[0];
    }
}
