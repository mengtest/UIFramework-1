using UnityEngine;
using System.Collections;

public class BattlePanel : UIBase
{

    public void OnBattleCloseBtnClick()
    {
        UIManager.Instance.PopPanel();
    }
}
