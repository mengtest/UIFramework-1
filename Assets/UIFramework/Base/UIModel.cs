using UnityEngine;
using System;

/*
序列化     对象 -> 文本信息（JSON、XML等）
反序列化    文本信息（JSON、XML等） -> 对象
*/

[Serializable]
public class UIModel : ISerializationCallbackReceiver
{
    [NonSerialized]
    public UIType Type;  // 枚举类型的本身不序列化

    public string PanelType;  // 枚举类型的字符串序列化
    public string Path;

    public void OnBeforeSerialize()
    {
        // NONE
    }

    public void OnAfterDeserialize()
    {
        Type = (UIType)Enum.Parse(typeof(UIType), PanelType);
    }
}
