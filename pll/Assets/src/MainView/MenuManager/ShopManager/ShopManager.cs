using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class ShopManager : MonoBehaviour {
	
    //아이템 전체 관리 매니저

	// Use this for initialization
	void Start () {
        ListManager.instance.InitItemList();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
