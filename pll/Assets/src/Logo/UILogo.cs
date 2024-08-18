using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILogo : MonoBehaviour {

    public GameObject[] logo;
    public GameObject[] platformType;

	public GameObject networkConnecting;
	private bool callNetworkConnecting = false;

    private int index = 0;

    // Use this for initialization
    void Start () {

        Debug.Log("[UILogo] Start");

#if UNITY_EDITOR
        ServerProperty.SetPlatformType((int)EPLATFORM_TYPE.DEVICE);
#elif UNITY_ANDROID
        ServerProperty.SetPlatformType((int)EPLATFORM_TYPE.DEVICE);
#endif

        platformType[ServerProperty.GetPlatformType()].SetActive(true);

    }

    // Update is called once per frame
    void Update () {

        // logo 순서대로 SetActive(true)
        if (index != logo.Length)
        {
            if (logo[index].activeInHierarchy == false)
            {
                ++index;
				if (index != logo.Length) {
					logo [index].SetActive (true);
					Debug.Log(logo.Length);
				}

                Debug.Log("[UILogo] Update::logo change(logo[" + (index - 1) + "] >> logo[" + index + "]" + ")");


            }
        }
        // scene 전환 
        else
        {
            // 로그인 여부 확인
			if (CheckLogin ()) {
				// 10.Intro scene에서 아이디, 이름 기반으로 네트워크 연결.
				SceneManager.LoadScene ("10.Intro");
			} else if (!callNetworkConnecting) {
				networkConnecting.SetActive (true);
				callNetworkConnecting = true;
				
			}
            
        }
    }

    bool CheckLogin()
    {
        bool isLogin = ServerProperty.isLogin;

        return isLogin;
    }
}
