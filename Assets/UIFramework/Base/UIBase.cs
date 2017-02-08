using UnityEngine;
using System.Collections;
using DG.Tweening;

public class UIBase : MonoBehaviour
{
    protected CanvasGroup Group;
    private float TweenTime = 0.25f;

    void Awake()
    {
        Group = GetComponent<CanvasGroup>();
    }

    // 面板开启
    public virtual void OnEnter()
    {
        Group.blocksRaycasts = true;
        // Group.alpha = 1;
        Group.DOFade(1.0f, TweenTime);
    }

    // 面板暂停
    public virtual void OnPause()
    {
        Group.blocksRaycasts = false;
    }

    // 面板回复
    public virtual void OnResume()
    {
        Group.blocksRaycasts = true;
    }

    // 面板关闭
    public virtual void OnExit()
    {
        Group.blocksRaycasts = false;
        // Group.alpha = 0;
        Group.DOFade(0f, TweenTime);
    }
}
