using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[System.Serializable]
//class data
//{
//    public string accountKey;
//    public string gameDBServerID;
//    public string sessionKey;
//}

//[System.Serializable]
//class toData
//{
//    [SerializeField]
//    public List<string> data;

//    public toData(List<string> data)
//    {
//        this.data = data;
//    }
//    //public string gameDBServerID;
//    //public List<JsonUtility> data;

//    public List<string> GetData()
//    {
//        return data;
//    }
//}

///* Dictionary 직렬화 참고 코드
//[System.Serializable]
//public class Serialization<TKey, TValue> : ISerializationCallbackReceiver
//{
//    [SerializeField]
//    List<TKey> keys;
//    [SerializeField]
//    List<TValue> valuse;

//    Dictionary<TKey, TValue> target;
//    public Dictionary<TKey, TValue> ToDictionary() { return target; }

//    public Serialization(Dictionary<TKey, TValue> target)
//    {
//        this.target = target;
//    }

//    // 직렬화(ToJson) 전에 호출.
//    public void OnBeforeSerialize()
//    {
//        keys = new List<TKey>(target.Keys);
//        valuse = new List<TValue>(target.Values);
//    }

//    // 역직렬화(FromJson) 전에 호출.
//    public void OnAfterDeserialize()
//    {
//        var count = Mathf.Min(keys.Count, valuse.Count);
//        target = new Dictionary<TKey, TValue>(count);

//        for(var i = 0; i < count; ++i)
//        {
//            target.Add(keys[i], valuse[i]);
//        }
//    }
//}
//*/


//[System.Serializable]
//public class Serialization<T>
//{
//    [SerializeField]
//    List<T> data;
//    public List<T> ToList() { return data; }

//    public Serialization(List<T> data)
//    {
//        this.data = data;
//    }
//}


//public static class JsonHelper
//{
//    public static T[] FromJson<T>(string json)
//    {
//        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);

//        return wrapper.Items;
//    }

//    public static string ToJson<T>(T[] array)
//    {
//        Wrapper<T> wrapper = new Wrapper<T>();
//        wrapper.Items = array;
//        return JsonUtility.ToJson(wrapper);
//    }

//    [Serializable]
//    private class Wrapper<T>
//    {
//        public T[] Items;
//    }
//}


public class jsonTestObj : MonoBehaviour {

    //// Use this for initialization
    //void Start()
    //{
    //    /* Dictionary 직렬화 참고 코드
    //    var td = new Dictionary<int, toData>();
    //    td.Add(100, new toData(new List<string> { "accountKey", "sessionKey" }));

    //    string str = JsonUtility.ToJson(new Serialization<int, toData>(td));
    //    Debug.LogError(str);

    //    Dictionary<int, toData> retd = JsonUtility.FromJson<Serialization<int, toData>>(str).ToDictionary();

    //    Debug.LogError(retd[100].data[0]);
    //    */

    //    Dictionary<int, string> dt = new Dictionary<int, string>();

    //    dt.Add(0, "park");
    //    dt.Add(1, "cho");
    //    dt.Add(2, "lyoo");
    //    dt.Add(3, "lim");



    //    //NetworkManager.instance.Call("test", testFunc2, dt, 1, 2.1, "string");

    //    //NetworkManager.instance.Call("test", testFunc, testFunc2);



    //    string jsonStr = "{\"data\":{\"accountKey\":\"2\",\"gameDBServerID\":100,\"sessionKey\":5}}";
    //    Debug.LogError(jsonStr);

    //    string[] str = JsonHelper.FromJson<string>(jsonStr);

    //    Debug.LogError(str);

    //    //List<toData> retd = JsonUtility.FromJson<Serialization<toData>>(jsonStr).ToList();

    //    //    Debug.LogError(retd[100].data[0]);

    //    Debug.LogError("test log error");

    //}

    //void testFunc(string str)
    //{
    //    Debug.LogWarning("good company logo");
    //}

    //void testFunc2()
    //{
    //    Debug.LogWarning("good company logo");
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    /* 기본 class json 파싱
    //    string jsonStr = "{\"data\":{\"accountKey\":\"2\",\"gameDBServerID\":100,\"sessionKey\":5}}";
    //    Debug.LogError(jsonStr);

    //    toData td = new toData();
    //    td = JsonUtility.FromJson<toData>(jsonStr);

    //    //Debug.LogError(td);
    //    //Debug.LogError(td.ToString());
    //    //Debug.LogError(td.data.accountKey);
    //    //Debug.LogError(td.data.gameDBServerID);
    //    //Debug.LogError(td.data.sessionKey);

    //    Debug.LogError(td.data.Count);

    //    for (int i = 0; i < td.data.Count; ++i)
    //        Debug.LogError(td.data);


    //    //Debug.LogError(jsonStr);

    //    string str = JsonUtility.FromJson<string>(jsonStr);
    //    Debug.LogError(str);
    //    */
    //}
	Json json = new Json();

    string jsonStr1 = "{\"result\":{\"accountKey\":\"2\",\"gameDBServerID\":100,\"sessionKey\":5}}";
	string jsonStr2 = "{\"result\":\"fail\"}";
	string jsonStr3 = "{\"user\":{\"userKey\":\"1000010\",\"highestFloor\":\"1\",\"resurrectionCount\":\"0\",\"gold\":\"0\",\"accessoryInfo\":null,\"questInfo\":null,\"weaponInfo\":\"1,1\"}}";

    void Start() {
        //Debug.Log(jsonStr);
        string deviceId = SystemInfo.deviceUniqueIdentifier;
        string deviceName = SystemInfo.deviceName;

        //NetworkManager.instance.Call("LoginService.login", null, deviceId, deviceId);

		//json.Init(jsonStr1);
        //json.Init(jsonStr2);
		json.Init(jsonStr3);
        //Debug.Log("json end");
    }
}
