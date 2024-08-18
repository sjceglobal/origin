using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkConnecting : MonoBehaviour {

	public GameObject goNetworkLoadingImage;
	public GameObject goNetworkConnectingBox;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetActiveNetworkLoadingImage(bool value)
	{
		goNetworkLoadingImage.SetActive (value);
	}

	public void SetActiveNetworkConnectingBox(bool value)
	{
		goNetworkConnectingBox.SetActive (value);
	}
}
