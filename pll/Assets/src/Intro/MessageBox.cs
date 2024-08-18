using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageBox : MonoBehaviour {

    public UILabel labelText;
    public GameObject goOneButton;
    public GameObject goTwoButton;

	System.Action<object[]> oneBtnCallBack;// = null;
	System.Action<object[]> twoBtnLeftCallBack;// = null;
	System.Action<object[]> twoBtnRightCallBack;// = null;

	object[] callBackParam;// = null;

    // Use this for initialization

	private void Awake()
	{
		oneBtnCallBack = null;
		twoBtnLeftCallBack = null;
		twoBtnRightCallBack = null;
		callBackParam = null;
	}
    void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}


	public void SetActiveOneButton(string msgLocalization, string buttonLocalization, System.Action<object[]> callBack = null, params object[] param)
    {
        goOneButton.SetActive(true);

		labelText.text = msgLocalization;

        UIButton btn = goOneButton.GetComponent<UIButton>();
        SetBtnlabelByButton(btn, buttonLocalization);

		if (callBack != null)
			oneBtnCallBack = callBack;

		if (param != null)
			callBackParam = param;
    }

	public void SetActiveTwoButton(string msgLocalization, string leftButtonLocalization, string rightButtonLocalization, System.Action<object[]> leftCallBack = null, System.Action<object[]> rightCallBack = null, params object[] param)
    {
        goTwoButton.SetActive(true);

		labelText.text = msgLocalization;

		UIButton[] btn = goTwoButton.GetComponentsInChildren<UIButton>();

		SetBtnlabelByButton(btn[0], leftButtonLocalization);
		SetBtnlabelByButton(btn[1], rightButtonLocalization);

		if (leftCallBack != null)
			twoBtnLeftCallBack = leftCallBack;

		if (rightCallBack != null)
			twoBtnRightCallBack = rightCallBack;

		if (param != null)
			callBackParam = param;
    }

    void SetBtnlabelByButton(UIButton btn, string buttonLocalization)
    {
		UILabel btnLabel = btn.GetComponentInChildren<UILabel>();

		Debug.LogWarning(btn.name + buttonLocalization);

		btnLabel.text = buttonLocalization;
    }


    #region Event

    public void OnClickOneButton()
    {
		goOneButton.SetActive (false);
		CommonUI.instance.SetActiveFalseMessageBox ();

		if (oneBtnCallBack == null)
			return;
		oneBtnCallBack (callBackParam);
    }

    public void OnClickTwoButtonLeft()
    {
		goTwoButton.SetActive(false);
		CommonUI.instance.SetActiveFalseMessageBox ();

		if (twoBtnLeftCallBack == null) {
			Debug.LogError ("twoBtnLeftCallBack null");
			return;
		}
			
		twoBtnLeftCallBack (callBackParam);
    }

    public void OnClickTwoButtonRight()
    {
		goTwoButton.SetActive(false);
		CommonUI.instance.SetActiveFalseMessageBox ();

		if (twoBtnRightCallBack == null) {
			Debug.LogError ("twoBtnRightCallBack null");
			return;
		}
			
		twoBtnRightCallBack(callBackParam);
    }

    #endregion
}
