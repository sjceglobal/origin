using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class ItemStandardProperties 
{
    static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
    static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
    static char[] TRIM_CHARS = { '\"' };

    //아이템 데이터 읽어들여 enum으로 사용하는 클래스
    public static Dictionary<string,cItem> cItems = new Dictionary<string, cItem>();
    public static List<cItem> cItemArray = new List<cItem>();

    public static Dictionary<string, cItem> Read()
    {
        string fileName = "csv_test";
        var dic = new Dictionary<string, cItem>();
        TextAsset data = Resources.Load(fileName) as TextAsset;
        if (data == null)
            Debug.Log("Fuck");

        var lines = Regex.Split(data.text, LINE_SPLIT_RE);

        if (lines.Length <= 1) return dic;

        var header = Regex.Split(lines[0], SPLIT_RE);
        for (var i = 1; i < lines.Length; i++) /* 행 처리 */
        {
            var values = Regex.Split(lines[i], SPLIT_RE);
            if (values.Length == 0 || values[0] == "") continue;

            var dicProperty = new Dictionary<string, object>();
            for (var j = 0; j < header.Length && j < values.Length; j++) /* 열(헤더) 처리 */
            {
                string value = values[j];
                value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
                object finalvalue = value;

                dicProperty[header[j]] = value;
                
                int n;
                float f;
                if (int.TryParse(value, out n))
                {
                    dicProperty[header[j]] = n;
                }
                else if (float.TryParse(value, out f))
                {
                    dicProperty[header[j]] = n;
                }
              
            }
            cItem item = new cItem(dicProperty);
            dic.Add( dicProperty[header[0]].ToString(), item);
            cItemArray.Add(item);
        }
        cItems = dic;
        return dic;
    }

    public static void Write()
    {
        foreach ( KeyValuePair<string, cItem> cItem in cItems)
        {
            Debug.Log("HERE");
            Debug.Log("Key = " + cItem.Key + " " + "Value = " + cItem.Value.getName());
        }
    }
}