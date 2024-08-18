using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserManager : MonoBehaviour {

    #region Singleton
	private static UserManager _instance;
	public static UserManager instance
    {
        get
        {
            if(_instance == null)
            {
				_instance = UnityEngine.Object.FindObjectOfType(typeof(UserManager)) as UserManager;

				GameObject go = new GameObject("UserManager");
                DontDestroyOnLoad(go);
				_instance = go.AddComponent<UserManager>();
                
            }

            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    #endregion
    
	#region 활용 데이터
    private string _userNickName = "testUserNickName";
    public  string userNickName { get { return _userNickName; } }

    private uint _userGold = 2222;
    public  uint userGold { get { return _userGold; } }

    private uint _characterAttack = 1;
    public  uint characterAttack { get { return _characterAttack; } }

    private uint _characterLevel = 99;
    public  uint characterLevel { get { return _characterLevel; } }

    //private UserItem userItemWeapon = null;
    #endregion


    //test
    public UILabel itemLabel;
    //test

    public void makeUserItem(string itemName,  int itemPrice,
        int itemMainType, int itemMainFeature,
        int itemSubType, int itemSubFeature,
		int itemCurrentDurability, int itemMaxDurability){

        /*
		Debug.Log ("makeUserItem");
		userItemWeapon = new UserItem (itemName,itemPrice,
			itemMainType,itemMainFeature,
			itemSubType,itemSubFeature,
			itemCurrentDurability,itemMaxDurability);

		Debug.Log (userItemWeapon.itemName);
        itemLabel.text = userItemWeapon.itemName;
*/

    }


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
