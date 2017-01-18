using UnityEngine;
using System.Collections;

public class TipsPanel : UIBase
{

    public void OnTipsCloseBtnClick()
    {
        UIManager.Instance.PopPanel();
    }
}
