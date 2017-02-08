using UnityEngine;
using System.Collections;

public class ShopPanel : UIBase
{

    public void OnShopCloseBtnClick()
    {
        UIManager.Instance.PopPanel();
    }
}
