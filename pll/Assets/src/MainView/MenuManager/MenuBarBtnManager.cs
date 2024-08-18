using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBarBtnManager : MonoBehaviour {

	private static UnityEngine.GameObject previousPanel=null;
	// Use this for initialization
	void Start () {
        ItemStandardProperties.Read();
        ItemStandardProperties.Write();
    }	
	// Update is called once per frame
	void Update () {
		
	}

	public void eventTest(UnityEngine.GameObject curPanel){
		//아이템, 미션 등의 메뉴 바 클릭 시, 판넬 변경
		Debug.Log("show panel");
		if (previousPanel == null) {//첫 메뉴 클릭
			curPanel.SetActive (true);		
			previousPanel = curPanel;
		}
		else if (previousPanel == curPanel) {//활성화 되어 있는 메뉴 클릭
			curPanel.SetActive (false);
			previousPanel=null;	
		} 
		else {//다른 메뉴 클릭
			previousPanel.SetActive(false);
			curPanel.SetActive (true);
			previousPanel=curPanel;				
		}

	}
}
