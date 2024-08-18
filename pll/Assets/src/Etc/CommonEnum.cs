/*

추후 변경X
(현재 ENUM으로 관리)
-DBNETWORK


추후 변경O
(외부 파일로 분리)
-ITEM

*/

enum EPLATFORM_TYPE
{
    DEVICE = 0,
    ANDROID = 1,
    IOS = 2,
}


enum eITEM_TYPE
{
    NONE = 0,
    WEAPON = 1, //무기  
	ACCESSORY = 2, //악세사리
	CONSUMPTION = 3, //소모형 (무기 내구도 보충 등)
	SKILL = 4, //스킬 구매


}

enum eITEM_FEATURE
{
    NONE = 0,
    ATTACKUP = 1,
    ATTACKSPEENDUP = 2,


}

