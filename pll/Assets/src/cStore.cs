using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cStore : MonoBehaviour {
    //아이템 전체 관리 매니저
    public UnityEngine.GameObject itemPanel;
    public UILabel cloneTest;
    public UIButton cloneButtonTest;

    private List<cItem> cItemArray = new List<cItem>();

    public UILabel itemLabel;
    public UIButton itemButton;

    private static cStore instance;
	public  static cStore GetInstance(){
		if (!instance) {
			instance = (cStore)GameObject.FindObjectOfType (typeof(cStore));
			if (!instance)
				Debug.LogError ("cStore does not exist");
		}
		return instance;
	}

	public cItem getItem(string itemStr){
		return ItemStandardProperties.cItems [itemStr];			
	}

	// Use this for initialization
	void Start () {
        ItemStandardProperties.Read();
        ItemStandardProperties.Write();

        foreach (KeyValuePair<string, cItem> cItem in ItemStandardProperties.cItems)
        {
            Debug.Log("HERE");
            Debug.Log("Key = " + cItem.Key + " " + "Value = " + cItem.Value.getName());
            cItemArray.Add(cItem.Value);
        }

        for (int i = 0; i < cItemArray.Count; i++)
        {
            itemLabel = (UILabel)Instantiate(cloneTest, cloneTest.transform.position, cloneTest.transform.rotation);
            itemLabel.text = cItemArray[i].getName();
            Debug.Log(itemLabel.text);

            itemLabel.transform.parent = itemPanel.transform;
            itemLabel.transform.localPosition = new Vector3(-405 + i * 130, 150, 0);
            itemLabel.transform.localScale = Vector3.one;
            itemLabel.enabled = true;

            itemButton = (UIButton)Instantiate(cloneButtonTest, cloneButtonTest.transform.position, cloneButtonTest.transform.rotation);
            itemButton.transform.parent = itemPanel.transform;
            itemButton.transform.localPosition = new Vector3(-405 + i * 130, 200, 0);
            itemButton.transform.localScale = Vector3.one;

            //기존 컴포넌트 삭제
            Destroy(cloneTest);
            Destroy(cloneButtonTest);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
