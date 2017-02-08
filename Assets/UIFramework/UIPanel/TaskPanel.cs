using UnityEngine;
using System.Collections;

public class TaskPanel : UIBase
{

    public void OnTaskCloseBtnClick()
    {
        UIManager.Instance.PopPanel();
    }
}
