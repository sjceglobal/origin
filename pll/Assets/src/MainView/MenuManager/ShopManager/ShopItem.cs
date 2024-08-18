using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : Item{

	//private ShopItem(){} // plain 생성자 제한
	public ShopItem (string itemName,  int itemPrice,
		int itemMainType, int itemMainFeature,
		int itemSubType, int itemSubFeature,
		int itemMaxDurability)
		: base (itemName,itemPrice,
			itemMainType,itemMainFeature,
			itemSubType,itemSubFeature,
			itemMaxDurability){
	}

}