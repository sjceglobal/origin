using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cMonster : MonoBehaviour {
	private float   _speed; 
	private int        _hp;
	private int _awardGold;

	public int hp{
		get{      return _hp; }
		set{ _hp = hp; }
	}
	public int awardGold{
		get{      return _awardGold; }
		set{ _awardGold = awardGold; }
	}
	public float speed{
		get{      return _speed; }
		set{ _speed = speed; }
	}

	public cMonster(int hp,int awardGold,float speed){
		this.hp = hp;
		this.awardGold = awardGold;
		this.speed = speed;
	}




	// Use this for initialization
	void Start () {
		_speed=0.01f;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(new Vector3(-1*_speed,0,0));  //이동
	}


	void OnTriggerEnter(Collider other){
		if (other.transform.tag == "Player") {
			Debug.Log("====Monster Trigger start====");
			_speed = 0f;
		}
	}
}