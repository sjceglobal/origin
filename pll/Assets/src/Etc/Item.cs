using System;
public class Item
{
	//ItemStandardProperties.cs 에서 알맞은 아이템 데이터 선택하여 만들어지는 실제 아이템 클래스
	public readonly string itemName;         //이름
	public readonly    int itemPrice;        //가격
	public readonly    int itemMainType;     //주 능력치 타입
    public readonly    int itemMainFeature;  //주 능력치 값
    public readonly    int itemSubType;      //부 능력치 타입
	public readonly    int itemSubFeature;   //부 능력치 값
	public readonly    int itemMaxDurability;//기본 내구도


	private Item(){	}
	public Item(string itemName,    int itemPrice,
                   int itemMainType,int itemMainFeature,
                   int itemSubType, int itemSubFeature,
	    	       int itemMaxDurability){

		this.itemName  = itemName;
		this.itemPrice = itemPrice;

		this.itemMainType    = itemMainType;
		this.itemMainFeature = itemMainFeature;

		this.itemSubType    = itemSubType;
		this.itemSubFeature = itemSubFeature;

		this.itemMaxDurability = itemMaxDurability;
	}
}