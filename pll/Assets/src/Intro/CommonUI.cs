using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommonUI : MonoBehaviour {
    
    #region Singleton
    private static CommonUI _instance;
    public static CommonUI instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = UnityEngine.Object.FindObjectOfType(typeof(CommonUI)) as CommonUI;

                GameObject go = new GameObject("CommonUI");
                DontDestroyOnLoad(go);
                _instance = go.AddComponent<CommonUI>();

            }

            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else if (_instance != this)
            Destroy(gameObject);
        //DontDestroyOnLoad(_instance);
    }
    #endregion
    

	DataUILocalization data = new DataUILocalization();

	public GameObject goBackground;
    public GameObject goMessageBox;
	public GameObject goNetworkConnecting;
    
    

	// Use this for initialization
	void Start () {
        data.Init();     

        if(goMessageBox != null)
            Debug.Log(goMessageBox);
        else
            Debug.Log("null");
    }

    private void LateUpdate()
    {
        if (goMessageBox == null)
        {
            Debug.Log("[CommonUI] goMessageBox is null");
            return;
        }

        //SceneManager.LoadScene("2.MainView");

    }

	void SetCommonUIBasic(bool value)
	{
		goBackground.SetActive (value);
	}

	public void MessageBoxOneButton(string msgLocalization, string buttonLocalization, System.Action<object[]> callBack = null, params object[] param)
    {
		SetCommonUIBasic (true);
        goMessageBox.SetActive(true);

		string textTitle = data.GetDictionaryValueByKey(msgLocalization);
		string textBtn = data.GetDictionaryValueByKey(buttonLocalization);

		MessageBox msgBox = goMessageBox.GetComponent<MessageBox>();
		msgBox.SetActiveOneButton(textTitle, textBtn, callBack, param);
    }

	public void MessageBoxTwoButton(string msgLocalization, string leftButtonLocalization, string rightButtonLocalization, System.Action<object[]> leftCallBack = null, System.Action<object[]> rightCallBack = null, params object[] param)
    {
		SetCommonUIBasic (true);
        goMessageBox.SetActive(true);

        //MessageBox msgBox = new MessageBox();

		//if()

		string textTitle = data.GetDictionaryValueByKey(msgLocalization);
		string textLeftBtn = data.GetDictionaryValueByKey(leftButtonLocalization);
		string textRightBtn = data.GetDictionaryValueByKey(rightButtonLocalization);

		MessageBox msgBox = goMessageBox.GetComponent<MessageBox>();
		msgBox.SetActiveTwoButton(textTitle, textLeftBtn, textRightBtn, leftCallBack, rightCallBack, param);
    }

	public void NetworkConnectLoading(System.Action retryCallBack = null, System.Action cancelCallBack = null)
	{
		SetCommonUIBasic (true);
		goNetworkConnecting.SetActive (true);

		NetworkConnecting netConnect = new NetworkConnecting ();
		netConnect.SetActiveNetworkLoadingImage (true);

	}

	#region OnClick
	public void OnClickDisable()
	{
		Debug.Log ("onclick disable btn");

	}
	#endregion
    
	#region SetActiveFale

	public void SetActiveFalseMessageBox()
	{
		goMessageBox.SetActive(false);
		SetCommonUIBasic (false);
	}

	public void SetActiveFalseNetworkConnecting()
	{
		goNetworkConnecting.SetActive(false);
		SetCommonUIBasic (false);
	}
	#endregion
}
