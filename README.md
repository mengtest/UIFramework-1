# UIFramework

------

## 解析JSON
> * `序列化` 对象 -> 文本信息（JSON、XML等）
> * `反序列化` 文本信息（JSON、XML等） -> 对象
```
[Serializable]
public class UIModel : ISerializationCallbackReceiver
{
    [NonSerialized]
    public UIType Type;  // 枚举类型的本身不序列化

    public string PanelType;  // 枚举类型的字符串序列化
    public string Path;

    public void OnBeforeSerialize()
    {
        // NONE
    }

    public void OnAfterDeserialize()
    {
        Type = (UIType)Enum.Parse(typeof(UIType), PanelType);
    }
}
```
```
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
```

## UIManager(UI管理类)
> 单例模式
> * `Dictionary<UIType, string>` PathDict 保存面板路径
> * `Dictionary<UIType, UIBase>` PanelDict 保存面板组件
> * `Stack<UIBase>` PanelStack 面板栈
> * PushPanel 面板入栈
> * PopPanel 面板出栈

## UIBase(UI公共基类)
> 生命周期
> * OnEnter 面板开启
> * OnPause 面板暂停
> * OnResume 面板恢复
> * OnExit 面板退出

## UIRoot(UI启动类)
> * 负责启动主面板

## CanvasGroup和DOTween
> * CanvasGroup负责控制交互与否
> * DOTween负责控制显示和隐藏
