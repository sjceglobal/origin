using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour {


    
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	public void printTest(){
		Debug.Log ("item" + name + "button click");
        CommonUI.instance.MessageBoxTwoButton("msg","ok","no");
	}
}
