using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cCharacter : MonoBehaviour {

	private static cCharacter instance;
	public  static cCharacter GetInstance(){
		if (!instance) {
			instance = (cCharacter)GameObject.FindObjectOfType (typeof(cCharacter));
			if (!instance)
				Debug.LogError ("cCharacter does not exist");
		}
		return instance;
	}


	public enum playerState{
		run = 0,
		attack1
	}
	public Animator _anim;

	private float         _speed;
	private int        _fatalBlow;
	private int      _attackSpeed;
	private int _missionSpeedRate;
	private int         _goldRate;
	private int       _limitFloor;
	private int     _rebirthCount;
	private int      _currentGold;
	private int         _animMode;

	private cItem           _item;
	public float speed{
		get{      return _speed; }
		set{ _speed = speed; }
	}
	public int fatalBlow{
		get{      return _fatalBlow; }
		set{ _fatalBlow = fatalBlow; }
	}
	public int attackSpeed{
		get{        return _attackSpeed; }
		set{ _attackSpeed = attackSpeed; }
	}
	public int missionSpeedRate{
		get{             return _missionSpeedRate; }
		set{ _missionSpeedRate = missionSpeedRate; }
	}
	public int goldRate{
		get{     return _goldRate; }
		set{ _goldRate = goldRate; }
	}
	public int limitFloor{
		get{       return _limitFloor; }
		set{ _limitFloor = limitFloor; }
	}
	public int rebirthCount{
		get{         return _rebirthCount; }
		set{ _rebirthCount = rebirthCount; }
	}
	public int currentGold{
		get{        return _currentGold; }
	    set{ _currentGold = currentGold; }
	}
	public cItem item{
		get{      return _item; }
		set{ _item = item; }
	}
	public int animMode{
		get{      return _animMode; }
		set{ _animMode = animMode; }
	}





	public void buyItem(string itemStr){
		cStore cStoreInst = cStore.GetInstance ();
		_item = cStoreInst.getItem (itemStr);
	}

	// Use this for initialization
	void Start () {
		//if (_anim != null)
			//_anim.SetInteger ("playerState",(int)playerState.run);	
		_speed = 0.01f;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(new Vector3(_speed,0,0));  
		if(_speed == 0f)
			_anim.SetInteger ("playerState",(int)playerState.attack1);	
	}

	void OnTriggerEnter(Collider other){
		if (other.transform.tag == "enemy") {
			Debug.Log("====Character Trigger start====");
			_speed = 0f;
			_anim.SetInteger ("playerState",(int)playerState.attack1);
		}
	}
}
