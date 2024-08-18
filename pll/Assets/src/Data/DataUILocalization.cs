using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataUILocalization{

    // 파일을 읽어보자
	const string path = "Assets\\Resources\\Localization\\";

    static Dictionary<string, string> localization = new Dictionary<string, string>();

    public void Init()
    {
        // 추후 언어 변경 기능 넣을것.
        string language = "kor";
        string file = string.Format("{0}{1}.txt", path, language);

        StreamReader sr = new StreamReader(file, System.Text.Encoding.Default);
        string uiLocalization = "";

        while ((uiLocalization = sr.ReadLine()) != null)
        {
            Debug.LogError(uiLocalization);
            SetDictionaryByFile(uiLocalization);
        }

        sr.Close();
    }

    void SetDictionaryByFile(string uiLocalization)
    {
        string[] str = uiLocalization.Split('=');

        if (str.Length != 2)
            return;

        if(str[0] != null && str[1] != null)
        {
            string key = str[0].Trim();
            string value = str[1].Trim();

            localization.Add(key, value);
        }
    }

    public string GetDictionaryValueByKey(string key)
    {
        string value = null;

		if (localization.ContainsKey (key))
			value = localization [key];
		else
			value = key;

        return value;
    }
}
