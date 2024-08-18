using System;
using System.Collections;
using System.Collections.Generic;

public class cItem
{
    string m_ItemID;
    string m_Name;
    string m_Attack;

	public cItem ( Dictionary<string, object> itemProperty )
	{
        m_ItemID = itemProperty["ItemID"].ToString();
        m_Name = itemProperty["Name"].ToString();
        m_Attack = itemProperty["Attack"].ToString();
    }

    public string getName()
    {
        return m_Name;
    }
}