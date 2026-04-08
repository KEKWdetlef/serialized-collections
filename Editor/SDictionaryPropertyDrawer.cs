using System;
using System.Reflection;
using UnityEditor;

namespace KekwDetlef.SerializedCollections.Editor
{
    [CustomPropertyDrawer(typeof(SDictionary<,>), true)]
    internal sealed class SDictionaryPropertyDrawer : BaseCollectionPropertyDrawer
    {
        private protected override Type GetItemType(SerializedProperty property) 
        {
            object fieldInstance = fieldInfo.GetValue(property.serializedObject.targetObject);
            var backingFieldProp = fieldInstance.GetType().GetProperty("Editor_GetBackingType", BindingFlags.Instance | BindingFlags.NonPublic);
            Type result = backingFieldProp?.GetValue(fieldInstance) as Type;
            return result;
        }

        private protected override bool IsLengthEditable() => false;
    }
}
