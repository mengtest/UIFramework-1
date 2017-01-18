using UnityEngine;
using System.Collections;

public class SystemPanel : UIBase
{

    public void OnSystemCloseBtnClick()
    {
        UIManager.Instance.PopPanel();
    }
}
