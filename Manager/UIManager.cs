using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class UIManager
{
    // 单例模式 内部构造 外部访问
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UIManager();
            }
            return _instance;
        }
    }

    // 画布的transform
    private Transform _canvasTransform;
    private Transform CanvasTransform
    {
        get
        {
            if (_canvasTransform == null)
            {
                _canvasTransform = GameObject.Find("Canvas").transform;
            }
            return _canvasTransform;
        }
    }
    private Dictionary<UIType, string> PathDict = new Dictionary<UIType, string>();  // 保存面板路径
    private Dictionary<UIType, UIBase> PanelDict = new Dictionary<UIType, UIBase>();  // 保存面板组件
    private Stack<UIBase> PanelStack = new Stack<UIBase>();  // 面板栈

    private UIManager()
    {
        ParseJson();
    }

    // 获取面板（内部调用）
    private UIBase GetPanel(UIType Type)
    {
        // UIBase Panel;
        // PanelDict.TryGetValue(Type, out Panel);
        UIBase Panel = Util.GetValue<UIType, UIBase>(PanelDict, Type);

        if (Panel == null)  // 不存在面板就实例化面板
        {
            // string Path;
            // PathDict.TryGetValue(Type, out Path);
            string Path = Util.GetValue<UIType, string>(PathDict, Type);
            GameObject GO = GameObject.Instantiate(Resources.Load(Path)) as GameObject;
            GO.transform.SetParent(CanvasTransform, false);

            Panel = GO.GetComponent<UIBase>();
            PanelDict.Add(Type, Panel);
        }

        return Panel;
    }

    // 面板入栈（外部调用）
    public void PushPanel(UIType Type)
    {
        if (PanelStack.Count > 0)  // 当前栈顶的面板暂停
        {
            PanelStack.Peek().OnPause();
        }
        UIBase Panel = GetPanel(Type);
        PanelStack.Push(Panel);  // 新面板入栈
        Panel.OnEnter();
    }

    // 面板出栈（外部调用）
    public void PopPanel()
    {
        UIBase TopPanel = PanelStack.Pop();
        TopPanel.OnExit();  // 当前栈顶的面板出栈

        if (PanelStack.Count > 0)
        {
            PanelStack.Peek().OnResume();  //旧面板恢复
        }
    }

    [Serializable]
    class UIJson
    {
        public List<UIModel> ModelList;
    }

    void ParseJson()  // 解析json
    {
        TextAsset Json = Resources.Load<TextAsset>("UIInfo");
        UIJson JsonObject = JsonUtility.FromJson<UIJson>(Json.text);

        foreach (UIModel Model in JsonObject.ModelList)
        {
            // Debug.Log(Model.Type + "  " + Model.Path);
            PathDict.Add(Model.Type, Model.Path);
        }
    }
}
