using UnityEngine;
using System.Collections;

public class KnapsackPanel : UIBase
{

    public void OnKnapsackCloseBtnClick()
    {
        UIManager.Instance.PopPanel();
    }

    public void OnPushTips()
    {
        UIManager.Instance.PushPanel(UIType.Tips);
    }
}
