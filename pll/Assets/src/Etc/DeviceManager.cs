using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class DeviceManager : MonoBehaviour {

	public GameObject networkConnecting;
	public GameObject networkConnectingCheckBox;

    // Use this for initialization
    void Start () {
        Debug.Log("[DeviceManager] start::unity");
        LogIn();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LogIn()
    {
        string deviceId = SystemInfo.deviceUniqueIdentifier;
        string deviceName = SystemInfo.deviceName;

        Debug.Log(string.Format("{0} / {1}", deviceId, deviceName));

        ServerProperty.SetLoginInformation(deviceId, deviceName);

        NetworkManager.instance.Call("LoginService.login", CallBackLoginSuccess, CallBackLoginFail, deviceId, deviceId);
    }

	void CallBackLoginSuccess(Dictionary<string, object> dic)
    {
		Debug.LogError(dic["result"]);
		if (dic["result"].Equals("ok"))
        {
			ServerProperty.SetUserExist(true);
			Debug.LogError("CallBackLoginSuccess >> ok");
        }
        else
        {
			ServerProperty.SetUserExist(false);
			Debug.LogError("CallBackLoginSuccess >> fail");
        }

		ServerProperty.SetIsLogin (true);
    }

    //void CallBackLoginFail(Dictionary<string, string> dic)
    //{
    //    Debug.LogError("CallBackLoginFail");
    //}

	void CallBackLoginFail()
    {		
        Debug.LogError("CallBackLoginFail");

		ServerProperty.SetIsLogin (false);
		networkConnecting.SetActive (false);
		networkConnectingCheckBox.SetActive (true);
    }

	public void OnClickNetworkRetry()
	{
		networkConnecting.SetActive (true);
		networkConnectingCheckBox.SetActive (false);
		NetworkManager.instance.Call("LoginService.login", CallBackLoginSuccess, CallBackLoginFail, ServerProperty.userId, ServerProperty.userId);
	}

	public void OnClickNetworkFail()
	{
		Application.Quit ();
	}
}
