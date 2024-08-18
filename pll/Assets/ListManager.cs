using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListManager : MonoBehaviour {

    #region Singleton
    private static ListManager _instance;
    public static ListManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = UnityEngine.Object.FindObjectOfType(typeof(ListManager)) as ListManager;

                GameObject go = new GameObject("ListManager");
                DontDestroyOnLoad(go);
                _instance = go.AddComponent<ListManager>();

            }

            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else if (_instance != this)
            Destroy(gameObject);
        //DontDestroyOnLoad(_instance);
    }
    #endregion

    public GameObject defaultItem;

    // Use this for initialization
    void Start () {
		
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InitItemList()
    {
        for (int i = 0; i < ItemStandardProperties.cItemArray.Count; ++i)
        {
            //일단 생성합니다. 무조건...
            GameObject obj = Instantiate(defaultItem, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;

            //생성된 GameObject의 부모가 누구인지 명확히 알려줍니다. (내가 니 애비다!!)
            obj.transform.parent = this.transform;

            //NGUI는 자동이 너무많이 짜증나니 수동으로 Scale을 조정해줍니다.
            obj.transform.localScale = new Vector3(1f, 1f, 1f);
            //obj.getCh
            obj.GetComponent<ListObject>().itemLabel.text = ItemStandardProperties.cItemArray[i].getName();
            obj.SetActive(true);
        }
        DestroyObject(defaultItem);
        GetComponent<UIGrid>().Reposition();
    }

    public void InitQuestList()
    {

    }

    public void InitWeaponShopList()
    {

    }
}
