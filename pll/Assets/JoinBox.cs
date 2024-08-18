using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinBox : MonoBehaviour {

    public UIInput input;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    #region Event

    public void OnClickJoin()
    {
        Debug.LogError(input.text);
    }


    #endregion
}
