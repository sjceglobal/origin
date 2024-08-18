using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoNetworkConnecting : MonoBehaviour {

	public UILabel labelNetworkConnecting;
	float time = 0.0f;
	public float timeReference = 0.15f;

	int labelDotIndex = 0;
	int labelDotIndexReference = 4;

	// Use this for initialization
	void Start () {
		time = 0.0f;
		labelDotIndex = 1;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time >= timeReference) {			
			labelNetworkConnecting.text = "네트워크\n연결중입니다";
			++labelDotIndex;

			if (labelDotIndex > labelDotIndexReference) {
				labelDotIndex = 0;
			}

			for (int i = 0; i < labelDotIndex; ++i) {
				labelNetworkConnecting.text += ".";
			}

			time = 0.0f;
		}
	}
}
