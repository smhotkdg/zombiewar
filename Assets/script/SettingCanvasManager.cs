using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingCanvasManager : MonoBehaviour {

    // Use this for initialization
    public GameObject BGMOn;
    public GameObject BGMOff;

    public GameObject FxOn;
    public GameObject FxOff;

    public GameObject Login;
    public GameObject LogOut;

    public GameObject Save;
    public GameObject Load;

    public List<GameObject> Flaglist;

    Globalvariable gv;

    private void Awake()
    {
        gv = Globalvariable.Instance;
    }
    //0
    //0.39
    //1

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void SetView()
    {
        Color SelectColor = new Color(0, 0.39f, 1, 1);
        Color UnSelectColor = new Color(1, 1, 1, 1);

        if (gv.iBGM == 0)
        {
            BGMOn.GetComponent<Image>().color = SelectColor;
            BGMOff.GetComponent<Image>().color = UnSelectColor;
        }
        else
        {
            BGMOn.GetComponent<Image>().color = UnSelectColor;
            BGMOff.GetComponent<Image>().color = SelectColor;
        }


        if (gv.iFx == 0)
        {
            FxOn.GetComponent<Image>().color = SelectColor;
            FxOff.GetComponent<Image>().color = UnSelectColor;
        }
        else
        {
            FxOn.GetComponent<Image>().color = UnSelectColor;
            FxOff.GetComponent<Image>().color = SelectColor;
        }

        if(gv.iGoogle ==1)
        {
            Login.GetComponent<Image>().color = SelectColor;
            LogOut.GetComponent<Image>().color = UnSelectColor;
        }
        else
        {
            Login.GetComponent<Image>().color = UnSelectColor;
            LogOut.GetComponent<Image>().color = SelectColor;
        }
        for(int i=0; i< Flaglist.Count; i++)
        {
            Flaglist[i].transform.Find("Check").gameObject.SetActive(false);
        }
        switch(gv.iLanguage)
        {
            case 1:
                Flaglist[0].transform.Find("Check").gameObject.SetActive(true);
                break;
            case 2:
                Flaglist[1].transform.Find("Check").gameObject.SetActive(true);
                break;
            case 3:
                Flaglist[2].transform.Find("Check").gameObject.SetActive(true);
                break;
            case 4:
                Flaglist[3].transform.Find("Check").gameObject.SetActive(true);
                break;
            case 5:
                Flaglist[4].transform.Find("Check").gameObject.SetActive(true);
                break;
            case 6:
                Flaglist[5].transform.Find("Check").gameObject.SetActive(true);
                break;
        }
    }
    private void OnEnable()
    {
        //This checks if your computer's operating system is in the French language
        if(gv.iLanguage ==0)
        {        

            if (Application.systemLanguage == SystemLanguage.Korean)
            {
                gv.iLanguage = 1;
                gv.SaveiLanguage();
            }
            //Otherwise, if the system is English, output the message in the console
            else if (Application.systemLanguage == SystemLanguage.English)
            {
                gv.iLanguage = 2;
                gv.SaveiLanguage();
            }
            else if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                gv.iLanguage = 3;
                gv.SaveiLanguage();
            }
            else if (Application.systemLanguage == SystemLanguage.Spanish)
            {
                gv.iLanguage = 4;
                gv.SaveiLanguage();
            }
            else if (Application.systemLanguage == SystemLanguage.Chinese || Application.systemLanguage == SystemLanguage.ChineseSimplified ||
                Application.systemLanguage == SystemLanguage.ChineseTraditional)
            {
                gv.iLanguage = 5;
                gv.SaveiLanguage();
            }
            else if (Application.systemLanguage == SystemLanguage.Russian)
            {
                gv.iLanguage = 6;
                gv.SaveiLanguage();
            }
            else
            {
                gv.iLanguage = 2;
                gv.SaveiLanguage();
            }
        }       
        SetView();        
    }
    public void CheckFlag(int i)
    {
        gv.iLanguage = i;
        gv.SaveiLanguage();
        SetView(); 
    }
    public void SetBGM(int i)
    {
        gv.iBGM = i;
        gv.SaveiBGM();
        SetView();
        GameObject.Find("GameManager").GetComponent<SoundManagerSrc>().UpdateSound();
    }
    public void SetFx(int i)
    {
        gv.iFx = i;
        gv.SaveiFx();
        SetView();
        GameObject.Find("GameManager").GetComponent<SoundManagerSrc>().UpdateSound();
    }
    public void LogIn()
    {
        GameObject.Find("GPGSManager").GetComponent<GPGSManager>().Login();
        SetView();
    }
    public void Logout()
    {
        GameObject.Find("GPGSManager").GetComponent<GPGSManager>().LogOut();
        SetView();
    }
    public void Rank()
    {
        GameObject.Find("GPGSManager").GetComponent<GPGSManager>().ShowLeaderboard();        
    }
    public void Achive()
    {
        GameObject.Find("GPGSManager").GetComponent<GPGSManager>().ShowAchivementClick();        
    }
    public void Review()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.hoitstudio.zombiewar");
    }
    public void SaveData()
    {
        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().PressPanelNotification("Saving");
        DataInfo dataInfo = new DataInfo();
        for (int i = 0; i < 5; i++)
        {
            dataInfo.HireStatus.Add(0);
            dataInfo.HireCost.Add(0);
            dataInfo.HireViewStatus.Add(0);
        }
        for (int i = 0; i < 15; i++)
        {
            dataInfo.BuyStatus.Add(0);
            dataInfo.BuyCost.Add(0);
            dataInfo.BuyViewStatus.Add(0);
            dataInfo.isiapp.Add(0);
        }
        for (int i = 0; i < 20; i++)
        {
            dataInfo.UpgradeStatus.Add(0);
            dataInfo.UpgradeCost.Add(0);
            dataInfo.UpgradeViewStatus.Add(0);
        }
        for (int i = 0; i < 24; i++)
        {
            dataInfo.AchivementStatus.Add(0);
            dataInfo.SlaveCount.Add(0);
            dataInfo.FacilityCount.Add(0);
        }
        dataInfo.Facilities = new int[4] { 0, 0, 0, 0 };



        dataInfo.TimeMoney = gv.TimeMoney;
        for (int i = 0; i < gv.isiapp.Count; i++)
        {
            dataInfo.isiapp[i] = gv.isiapp[i];
        }
        dataInfo.endingMeht = gv.endingMeht;
        dataInfo.DayRewardTime = gv.DayRewardTime;
        dataInfo.Potion10 = gv.Potion10;
        dataInfo.Potion100 = gv.Potion100;
        dataInfo.TotalClickCount = gv.TotalClickCount;
        dataInfo.iBGM = gv.iBGM;
        dataInfo.iFx = gv.iFx;
        dataInfo.iGoogle = gv.iGoogle;
        dataInfo.iLanguage = gv.iLanguage;
        dataInfo.DayRewardCount = gv.DayRewardCount;
        dataInfo.IapType = gv.IapType;
        dataInfo.bStartPotion = gv.bStartPotion;
        dataInfo.potiontype = gv.potiontype;
        dataInfo.UpgradePurity = gv.UpgradePurity;

        dataInfo.MethPerDeSec = gv.MethPerDeSec;
        dataInfo.MasterDealerCount = gv.MasterDealerCount;
        dataInfo.iMapPrograss = gv.iMapPrograss;

        dataInfo.TotalMoney = gv.TotalMoney;
        dataInfo.TotalMeth = gv.TotalMeth;
        dataInfo.MoneyPerSec = gv.MoneyPerSec;
        dataInfo.MethPerSec = gv.MethPerSec;
        dataInfo.Purity = gv.Purity;
        dataInfo.DealerPower = gv.DealerPower;
        dataInfo.MethPerSec_Dealer = gv.MethPerSec_Dealer;
        dataInfo.MethPerSec_Worker = gv.MethPerSec_Worker;
        dataInfo.DealerCost = gv.DealerCost;
        dataInfo.TotalDealer = gv.TotalDealer;
        dataInfo.MaxDealer = gv.MaxDealer;
        dataInfo.DealrHirePerSec = gv.DealrHirePerSec;
        dataInfo.scaleFactor = gv.scaleFactor;
        dataInfo.totalpalyTime = gv.totalpalyTime;
        for (int i = 0; i < 4; i++)
        {
            dataInfo.Facilities[i] = gv.Facilities[i];
        }
        for (int i = 0; i < gv.SlaveCount.Count; i++)
        {
            dataInfo.SlaveCount[i] = gv.SlaveCount[i];
        }
        for (int i = 0; i < gv.FacilityCount.Count; i++)
        {
            dataInfo.FacilityCount[i] = gv.FacilityCount[i];
        }
        for (int i = 0; i < gv.HireStatus.Count; i++)
        {
            dataInfo.HireStatus[i] = gv.HireStatus[i];
        }
        for (int i = 0; i < gv.BuyStatus.Count; i++)
        {
            dataInfo.BuyStatus[i] = gv.BuyStatus[i];
        }
        for (int i = 0; i < gv.UpgradeStatus.Count; i++)
        {
            dataInfo.UpgradeStatus[i] = gv.UpgradeStatus[i];
        }
        for (int i = 0; i < gv.AchivementStatus.Count; i++)
        {
            dataInfo.AchivementStatus[i] = gv.AchivementStatus[i];
        }
        for (int i = 0; i < gv.HireViewStatus.Count; i++)
        {
            dataInfo.HireViewStatus[i] = gv.HireViewStatus[i];
        }
        for (int i = 0; i < gv.BuyViewStatus.Count; i++)
        {
            dataInfo.BuyViewStatus[i] = gv.BuyViewStatus[i];
        }
        for (int i = 0; i < gv.UpgradeViewStatus.Count; i++)
        {
            dataInfo.UpgradeViewStatus[i] = gv.UpgradeViewStatus[i];
        }

        gv.saveByte = GameObject.Find("GameManager").GetComponent<SaveLoad>().SaveGameInfo(dataInfo);
        GameObject.Find("GPGSManager").GetComponent<GPGSManager>().SaveToCloud();

    }
    public void LoadData()
    {
        gv.saveByte = null;
        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().PressPanelNotification("Loading");
        GameObject.Find("GPGSManager").GetComponent<GPGSManager>().LoadFromCloud();        
    }
}
