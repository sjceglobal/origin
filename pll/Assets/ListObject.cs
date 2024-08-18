using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListObject : MonoBehaviour {

    public UILabel itemLabel;
    public UISprite itemImage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickBuyItem()
    {
        Debug.LogError("Click BuyItem");
        CommonUI.instance.MessageBoxTwoButton("Sure?", "Yes", "No" );
    }

    public void OnCallBack_BuyItem()
    {

    }
}
