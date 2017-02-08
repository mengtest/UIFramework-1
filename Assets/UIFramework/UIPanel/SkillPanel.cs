using UnityEngine;
using System.Collections;

public class SkillPanel : UIBase
{

    public void OnSkillCloseBtnClick()
    {
        UIManager.Instance.PopPanel();
    }
}
