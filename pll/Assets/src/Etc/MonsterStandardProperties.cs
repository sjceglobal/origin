using System;
using System.Collections;
using System.Collections.Generic;

public class MonsterStandardProperties
{
	//몬스터 데이터 읽어들여 enum으로 사용하는 클래스
	public readonly static Dictionary<string,byte> test = new Dictionary<string, byte>();

	public MonsterStandardProperties ()
	{
		//외부 데이터 추가 테스트 
		test.Add ("A",0);
		test.Add ("B",1);
		test.Add ("C",2);
		test.Add ("D",3);
		test.Add ("E",4);
		test.Add ("F",5);
		test.Add ("G",6);
		test.Add ("H",7);
		test.Add ("I",8);
	}
}
