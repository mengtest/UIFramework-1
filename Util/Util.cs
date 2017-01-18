using System.Collections.Generic;

// dictionary工具类
public static class Util
{
    public static Tvalue GetValue<Tkey, Tvalue>(Dictionary<Tkey, Tvalue> Dict, Tkey key)
    {
        Tvalue value;
        Dict.TryGetValue(key, out value);
        return value;
    }
}
