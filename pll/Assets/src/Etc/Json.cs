using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class Json{

    //JsonReader jr;

	JsonReader jr;
	Dictionary<string, object> dic = new Dictionary<string, object>();
	string jsonKey = null;
	string jsonValue = null;

	public Dictionary<string, object> JsonToDictionaryParsing(string parsingData)
	{
		jr = new JsonReader(parsingData);

		ResetParseValue ();
		dic = parse ();

		jr.Close();

		return dic;
	}

    public void Init(string data)
    {
        jr = new JsonReader(data);

		ResetParseValue ();
		dic = parse ();
        
        jr.Close();
        //////////////////////////////////////////////////////

    }

	Dictionary<string, object> parse()
	{
		Dictionary<string, object> dicTemp = new Dictionary<string, object>();

		//////////////////////////////////////////////////////
		// Token			>>	Value
		//----------------------------------------------------
		// ObjectStart		>>	Null
		// PropertyName		>>	Dictionary(key)
		// String(variable)	>>	Dictionary(value)
		// ObjectEnd		>>	Null

		while (jr.Read())
		{
			//Debug.Log(jr.Token);
			//Debug.Log(jr.Value);

			if (jr.Token == JsonToken.ObjectStart) {
				if (jsonKey == null) {
					jr.Read ();
					jsonKey = jr.Value.ToString ();
				} else {
					string jsonKeyTemp = jsonKey;
					jsonKey = null;

					dicTemp.Add (jsonKeyTemp, parse ());
				}
			} else if (jr.Token == JsonToken.PropertyName) {
				jsonKey = jr.Value.ToString ();
			}
			else if (jr.Token == JsonToken.ObjectEnd) {
				return dicTemp;
			} else {
				if (jr.Value != null) {
					jsonValue = jr.Value.ToString ();
				} else {
					jsonValue = "-1";
				}
					

				dicTemp.Add (jsonKey, jsonValue);
				jsonKey = null;
				jsonValue = null;
			}
		}

		return dicTemp;
	}



	void comfirmTest()
	{
		//if(dic["result"].GetType())
		Debug.Log(dic["user"].GetType().IsGenericType);

		bool isDictionary = dic["user"].GetType().IsGenericType;

		if (isDictionary) {
			Dictionary<string, object> dicTemp = new Dictionary<string, object>();
			dicTemp = (Dictionary<string, object>)dic ["user"];

			Debug.Log("dictionary------------------------");
			Debug.Log("userKey >> " + dicTemp["userKey"]);
			Debug.Log("highestFloor >> " + dicTemp["highestFloor"]);
			Debug.Log("resurrectionCount >> " + dicTemp["resurrectionCount"]);
			Debug.Log("gold >> " + dicTemp["gold"]);
			Debug.Log("accessoryInfo >> " + dicTemp["accessoryInfo"]);
			Debug.Log("questInfo >> " + dicTemp["questInfo"]);
			Debug.Log("weaponInfo >> " + dicTemp["weaponInfo"]);

			//Debug.Log("dictionary------------------------");
		}

	}


	void ResetParseValue()
	{
		dic.Clear ();
		
		jsonKey = null;
		jsonValue = null;
	}


}
