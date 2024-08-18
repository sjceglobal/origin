using System.Collections;
using System.Collections.Generic;

public static class ServerProperty {

	public const string url = "http://54.218.72.127/baekban_server/api.php";

    private static bool _userExist = false;
    public static bool userExist { get { return _userExist; } private set { _userExist = value; } }

    private static string _userId = null;
    public static string userId { get { return _userId; } private set { _userId = value; } }

    private static string _userName = null;
    public static string userName { get { return _userName; } private set { _userName = value; } }

    private static bool _isLogin = false;
    public static bool isLogin { get { return _isLogin; } private set { _isLogin = value; } }

	private static bool _isServerConnecting = false;
	public static bool isServerConnecting { get { return _isServerConnecting; } private set { _isServerConnecting = value; } }

    private static EPLATFORM_TYPE ePlatformType = EPLATFORM_TYPE.DEVICE;
    public static void SetPlatformType(int type)
    {
        ePlatformType = (EPLATFORM_TYPE)type;
    }
    public static int GetPlatformType()
    {
        return (int)ePlatformType;
    }

    public static void SetLoginInformation(string id = null, string name = null)
    {
        if(id != null && name != null)
        {
            if (userId != id)
                userId = id;

            if (userName != name)
                userName = name;            
        }
    }

	public static void SetIsLogin(bool login)
	{
		if (isLogin != login)
			isLogin = login;
	}

    public static void SetUserExist(bool value)
    {
        if (userExist != value)
            userExist = value;
    }

	public static void SetServerConnecting(bool value)
	{
		if (_isServerConnecting != value)
			_isServerConnecting = value;
	}
    

}
