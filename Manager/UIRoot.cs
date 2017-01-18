using UnityEngine;
using System.Collections;

public class UIRoot : MonoBehaviour
{
    void Start()
    {
        // Debug.Log(UIManager.Instance.GetType());
        UIManager.Instance.PushPanel(UIType.Main);
    }
}
