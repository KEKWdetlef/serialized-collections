using System;
using UnityEditor;

namespace KekwDetlef.SerializedCollections.Editor
{
    [CustomPropertyDrawer(typeof(SUniqueList<>))]
    internal sealed class SUniqueListPropertyDrawer : BaseCollectionPropertyDrawer
    {
        private protected override Type GetItemType(SerializedProperty _) => fieldInfo.FieldType.GetGenericArguments()[0];
        private protected override bool IsLengthEditable() => true;
    }
}
