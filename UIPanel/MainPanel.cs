using UnityEngine;
using System;
using System.Collections;

public class MainPanel : UIBase
{

    public void OnPushPanel(string PanelType)
    {
        UIType Type = (UIType)Enum.Parse(typeof(UIType), PanelType);
        UIManager.Instance.PushPanel(Type);
    }
}
