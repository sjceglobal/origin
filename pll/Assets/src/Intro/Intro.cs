using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

    enum EINTRO_STATE
    {
        NONE = 0,
        USER_LOAD = 1,
        USER_EXIST = 2,
        JOIN = 3,
        NEXT_SCENE = 4,
        WAIT = 5,
        END = 6,
    }

    float time = 0.0f;
    const float timeReference = 2.0f;

    public float sizeReference = 0.00005f;
    bool isSizeUp = true;
    bool isSizeDown = false;

    public UIButton nextSceneBtn;
    public UILabel nextSceneBtnLabel;
    bool isNextBtnActive = false;

    public UIButton joinBtn;
    public GameObject goJoinBox;
    public UILabel testLabel;

    EINTRO_STATE state = EINTRO_STATE.NONE;

    // Use this for initialization
    void Start () {
        testLabel.text = "start";
    }
	
	// Update is called once per frame
	void Update () {

        //// intro fsm
        switch (state)
        {
            // 첫 상태
            case EINTRO_STATE.NONE:
                {
                    testLabel.text = "NONE";
                    ChangeState(EINTRO_STATE.USER_EXIST);
                    
                }
                break;
            // 유저 있는지 없는지.
            case EINTRO_STATE.USER_EXIST:
                {
                    testLabel.text = "USER_EXIST";
                    // user가 존재할때
                    if (CheckExistUser())
                    {
                        Debug.Log("[Intro] Update::Exist User");
                        ChangeState(EINTRO_STATE.USER_LOAD);
                    }
                    // user가 없을때
                    else
                    {
                        Debug.Log("[Intro] Update::Not Exist User");
                        ChangeState(EINTRO_STATE.JOIN);
                    }
                }
                break;
            // 유저 있으면 DB에서 정보 다 읽어왔는지
            case EINTRO_STATE.USER_LOAD:
                {
                    testLabel.text = "USER_LOAD";
                    ChangeState(EINTRO_STATE.WAIT);
                    UserLoad();
                }
                break;
            // 유저 없으면 회원가입.
            case EINTRO_STATE.JOIN:
                {
                    testLabel.text = "JOIN";
                    ChangeState(EINTRO_STATE.WAIT);
                    joinBtn.gameObject.SetActive(true);
                }
                break;

            case EINTRO_STATE.NEXT_SCENE:
                {
                    testLabel.text = "NEXT_SCENE";
                    if (!isNextBtnActive)
                    {
                        nextSceneBtn.gameObject.SetActive(true);
                        isNextBtnActive = true;
                    }

                    TextLabelSizing(0.8f, 1.5f);
                }
                break;

            case EINTRO_STATE.WAIT:
                {
                    testLabel.text = "WAIT";
                    Debug.Log("[Intro] Update::FSM WAIT");
                }
                break;

            case EINTRO_STATE.END:
                {
                    testLabel.text = "END";
                    Debug.Log("[Intro] Update::FSM END");
                }
                break;
        }

    }

    void ChangeState(EINTRO_STATE index)
    {
        if (state != index)
            state = index;
    }

    void UserLoad()
    {
        string id = ServerProperty.userId;
        string name = ServerProperty.userName;

        //string id = "ID_siburung";
        //string name = "NAME_siburung";

        NetworkManager.instance.Call("UserService.loginUser", CallBackUserLoad, ServerProperty.userId, ServerProperty.userId, ServerProperty.userName);
    }

    void JoinUser()
    {
        NetworkManager.instance.Call("UserService.createUser", CallBackJoinUserSuccess, ServerProperty.userId, ServerProperty.userId, ServerProperty.userName);
    }

	void CallBackJoinUserSuccess(Dictionary<string, object> dic)
    {
        Debug.LogError("CallBackJoinUser");
        SetActiveUserJoinBox(false);
        testLabel.text = "intro succesee";
        ChangeState(EINTRO_STATE.NEXT_SCENE);
    }

	void CallBackJoinUserFail(Dictionary<string, object> dic)
    {
        testLabel.text = "intro fail";
        Debug.LogError("CallBackJoinUser");
    }

	void CallBackUserLoad(Dictionary<string, object> dic)
    {
        Debug.LogError("CallBackUserLoad");
        ChangeState(EINTRO_STATE.NEXT_SCENE);
    }

    void SetActiveUserJoinBox(bool value)
    {
        if (goJoinBox.activeInHierarchy != value)
            goJoinBox.SetActive(value);
    }


    bool CheckExistUser()
    {

        bool isExistUser = ServerProperty.userExist;

        return isExistUser;
    }

    void TextLabelSizing(float labelMinSize, float labelMaxSize)
    {
        if (isSizeUp && time >= timeReference)
        {

            nextSceneBtnLabel.transform.localScale += new Vector3(sizeReference, sizeReference, 0.0f);

            float size = nextSceneBtnLabel.transform.localScale.x;

            if (size >= labelMaxSize)
            {
                isSizeUp = false;
                isSizeDown = true;
            }

        }
        else if (isSizeDown && time >= timeReference)
        {

            nextSceneBtnLabel.transform.localScale -= new Vector3(sizeReference, sizeReference, 0.0f);

            float size = nextSceneBtnLabel.transform.localScale.x;

            if (size <= labelMinSize)
            {
                isSizeUp = true;
                isSizeDown = false;
            }

        }
        else
        {
            time += Time.deltaTime;
        }
    }
    

    #region Event

    public void OnClickNextScene()
    {
        SceneManager.LoadScene("2.MainView");
        
        //Destroy(this.gameObject);
    }

    public void OnClickJoin()
    {
        Debug.Log("OnClickJoin");
        SetActiveUserJoinBox(true);
        joinBtn.gameObject.SetActive(false);
    }

    public void OnClickJoinNetwork()
    {
        Debug.Log("OnClickJoinNetwork");
        string inputText = GetComponentInChildren<UIInput>().value;
        string testid = ServerProperty.userId;
        Debug.Log(inputText);
        ServerProperty.SetLoginInformation(testid, inputText);
        JoinUser();
    }


    #endregion
}
