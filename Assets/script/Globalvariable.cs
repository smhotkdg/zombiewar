using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DataInfo
{
    public int iMapPrograss;
    public int AdsType;
    public double TimeMoney;
    public List<int> isiapp = new List<int>();
    public int DayRewardTime;
    public int Potion10;
    public int Potion100;
    public double TotalClickCount;
    public int iBGM;
    public int iFx;
    public int iGoogle;
    public int iLanguage;
    public double endingMeht;
    public int DayRewardCount;
    public int IapType;
    public bool bStartPotion;
    public int potiontype;
    public double UpgradePurity;
    public List<double> UpgradeCost = new List<double>();
    public List<double> BuyCost = new List<double>();
    public List<double> HireCost = new List<double>();

    public static int Highscore { get; set; }
    public double MethPerDeSec;
    public int MasterDealerCount;
    public List<int> SlaveCount = new List<int>();
    public List<int> FacilityCount = new List<int>();
    public List<int> HireStatus = new List<int>();
    public List<int> BuyStatus = new List<int>();
    public List<int> UpgradeStatus = new List<int>();
    public List<int> AchivementStatus = new List<int>();

    public List<int> HireViewStatus = new List<int>();
    public List<int> BuyViewStatus = new List<int>();
    public List<int> UpgradeViewStatus = new List<int>();

    public double TotalMoney;
    public double TotalMeth;
    public double MoneyPerSec;
    public double MethPerSec;
    public double Purity;
    public double DealerPower;
    public double MethPerSec_Dealer;
    public double MethPerSec_Worker;

    public float DealerCost;
    public float TotalDealer;
    public double MaxDealer;
    public float DealrHirePerSec;
    public float scaleFactor = 0.000000000000000001f;
    public int[] Facilities;
    public double totalpalyTime;
}
public class Globalvariable : MonoBehaviour {


    private static Globalvariable _instance = null;

    public static Globalvariable Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("cSingleton == null");
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;        
        InitData();
        CheckTime();
    }
    void CheckTime()
    {
        if(AchivementStatus[3] ==1 && AchivementStatus[4] == 1 && AchivementStatus[5] == 1 && AchivementStatus[6] == 1 )
        {

        }
        else
        {
            LoadTotalPlayTime();
            StartCoroutine(PlayTime());
        }
    }
    IEnumerator PlayTime()
    {
        totalpalyTime++;
        //여기 3600 으로 변경해야함
        if(totalpalyTime > 3600 && AchivementStatus[3] ==0)
        {
            AchivementStatus[3] = 1;
            this.GetComponent<BottomUIController>().SetNotice(5);
        }
        if (totalpalyTime > 21600 && AchivementStatus[4] == 0)
        {
            AchivementStatus[4] = 1;
            GameObject.Find("GameManager").GetComponent<BottomUIController>().SetNotice(5);
        }
        if (totalpalyTime > 259200 && AchivementStatus[5] == 0)
        {
            AchivementStatus[5] = 1;
            GameObject.Find("GameManager").GetComponent<BottomUIController>().SetNotice(5);
        }
        if (totalpalyTime > 6220800 && AchivementStatus[6] == 0)
        {
            AchivementStatus[6] = 1;
            GameObject.Find("GameManager").GetComponent<BottomUIController>().SetNotice(5);
        }
        if (AchivementStatus[3] == 1 && AchivementStatus[4] == 1 && AchivementStatus[5] == 1 && AchivementStatus[6] == 1)
        {
            StopCoroutine(PlayTime());
        }
        else
        {
            yield return new WaitForSeconds(1);
            StartCoroutine(PlayTime());
        }
        SaveTotalPlayTime();
    }
    public void LoadTotalPlayTime()
    {
        totalpalyTime = PlayerPrefs.GetFloat("totalpalyTime");        
    }
    public void SaveTotalPlayTime(int type = 0)
    {
        if(type ==-1)
        {
            PlayerPrefs.SetFloat("totalpalyTime", 0);
            LoadTotalPlayTime();
        }            
        else
            PlayerPrefs.SetFloat("totalpalyTime", (float)totalpalyTime);        
        PlayerPrefs.Save();
    }

    public void SaveTotalMoney(int type = 0)
    {
        if (type == -1)
        {
            TotalMoney = 0;
            PlayerPrefs.SetFloat("TotalMoney", (float)TotalMoney);
        }            
        else
            PlayerPrefs.SetFloat("TotalMoney", (float)TotalMoney);
        PlayerPrefs.Save();
    }
    public void LoadTotalMoney()
    {
        TotalMoney = PlayerPrefs.GetFloat("TotalMoney");        
    }
    public void SaveTotalMeth(int type =0)
    {
        if (type == -1)
        {
            TotalMeth = 0;
            PlayerPrefs.SetFloat("TotalMeth", (float)TotalMeth);
        }            
        else
            PlayerPrefs.SetFloat("TotalMeth", (float)TotalMeth);
        PlayerPrefs.Save();
    }
    public void LoadTotalMeth()
    {
        TotalMeth = PlayerPrefs.GetFloat("TotalMeth");
    }
    public double GetPurity()
    {
        if(Purity + UpgradePurity  < 1)
        {
            SavePurity();
            return Purity + UpgradePurity;
        }
        else
        {
            return 1;
        }
    }
  
    public void SaveTotalDealer(int type=0)
    {
        if (type == -1)
            PlayerPrefs.SetFloat("TotalDealer", 0);
        else
            PlayerPrefs.SetFloat("TotalDealer", TotalDealer);
        PlayerPrefs.Save();
    }
    public void LoadTotalDealer()
    {
        TotalDealer = PlayerPrefs.GetFloat("TotalDealer");
    }
    public void SaveHireStatus(int i, int type = 0)
    {
        string strHireStatus = "HireStatus" + i;
        if (type == -1)
            PlayerPrefs.SetFloat(strHireStatus, 0);
        else
            PlayerPrefs.SetInt(strHireStatus, HireStatus[i]);
        PlayerPrefs.Save();
    }
    public void LoadHireStatus(int i, int type = 0)
    {
        string strHireStatus = "HireStatus" + i;
        HireStatus[i] = PlayerPrefs.GetInt(strHireStatus);        
    }
    public void SaveBuyStatus(int i, int type =0)
    {
        string strBuyStatus = "BuyStatus" + i;
        if (type == -1)
            PlayerPrefs.SetFloat(strBuyStatus, 0);
        else
            PlayerPrefs.SetInt(strBuyStatus, BuyStatus[i]);
        PlayerPrefs.Save();
    }
    public void LoadBuyStatus(int i,int type =0)
    {
        string strBuyStatus = "BuyStatus" + i;
        BuyStatus[i] = PlayerPrefs.GetInt(strBuyStatus);
    }
    public void SaveUpgradeStatus(int i,int type=0)
    {
        string strUpgradeStatus = "UpgradeStatus" + i;
        if (type == -1)
            PlayerPrefs.SetFloat(strUpgradeStatus, 0);
        else
            PlayerPrefs.SetInt(strUpgradeStatus, UpgradeStatus[i]);
        PlayerPrefs.Save();
    }
    public void LoadUpgradeStatus(int i, int type = 0)
    {
        string strUpgradeStatus = "UpgradeStatus" + i;
        UpgradeStatus[i] = PlayerPrefs.GetInt(strUpgradeStatus);
    }

    //View Status
    public void SaveHireViewStatus(int i, int type = 0)
    {
        string strHireViewStatus = "HireViewStatus" + i;
        if (type == -1)
            PlayerPrefs.SetFloat(strHireViewStatus, 0);
        else
            PlayerPrefs.SetInt(strHireViewStatus, HireViewStatus[i]);
        PlayerPrefs.Save();
    }
    public void LoadHireViewStatus(int i, int type = 0)
    {
        string strHireViewStatus = "HireViewStatus" + i;
        HireViewStatus[i] = PlayerPrefs.GetInt(strHireViewStatus);
    }
    public void SaveBuyViewStatus(int i, int type = 0)
    {
        string strBuyViewStatus = "BuyViewStatus" + i;
        if (type == -1)
            PlayerPrefs.SetFloat(strBuyViewStatus, 0);
        else
            PlayerPrefs.SetInt(strBuyViewStatus, BuyViewStatus[i]);
        PlayerPrefs.Save();
    }
    public void LoadBuyViewStatus(int i, int type = 0)
    {
        string strBuyViewStatus = "BuyViewStatus" + i;
        BuyViewStatus[i] = PlayerPrefs.GetInt(strBuyViewStatus);
    }
    public void SaveUpgradeViewStatus(int i, int type = 0)
    {
        string strUpgradeViewStatus = "UpgradeViewStatus" + i;
        if (type == -1)
            PlayerPrefs.SetFloat(strUpgradeViewStatus, 0);
        else
            PlayerPrefs.SetInt(strUpgradeViewStatus, UpgradeViewStatus[i]);
        PlayerPrefs.Save();
    }
    public void LoadUpgradeViewStatus(int i, int type = 0)
    {
        string strUpgradeViewStatus = "UpgradeViewStatus" + i;
        UpgradeViewStatus[i] = PlayerPrefs.GetInt(strUpgradeViewStatus);
    }





    public void SaveAchivementStatus(int i, int type = 0)
    {
        string strAchivementStatus = "AchivementStatus" + i;
        if (type == -1)
            PlayerPrefs.SetFloat(strAchivementStatus, 0);
        else
            PlayerPrefs.SetInt(strAchivementStatus, AchivementStatus[i]);
        PlayerPrefs.Save();
    }
    public void LoadAchivementStatus(int i, int type = 0)
    {
        string strAchivementStatus = "AchivementStatus" + i;
        AchivementStatus[i] = PlayerPrefs.GetInt(strAchivementStatus);
    }
    public void SaveSlaveCount(int i, int type = 0)
    {
        string strSlaveCount = "SlaveCount" + i;
        if (type == -1)
            PlayerPrefs.SetFloat(strSlaveCount, 0);
        else
            PlayerPrefs.SetInt(strSlaveCount, SlaveCount[i]);
        PlayerPrefs.Save();
    }
    public void LoadSlaveCount(int i, int type = 0)
    {
        string strSlaveCount = "SlaveCount" + i;
        SlaveCount[i] = PlayerPrefs.GetInt(strSlaveCount);
    }

    public void SaveIapp(int i, int type = 0)
    {
        string strInapp = "isiapp" + i;
        if (type == -1)
            PlayerPrefs.SetFloat(strInapp, 0);
        else
            PlayerPrefs.SetInt(strInapp, isiapp[i]);
        PlayerPrefs.Save();
    }
    public void LoadInapp(int i, int type = 0)
    {
        string strInapp = "isiapp" + i;
        isiapp[i] = PlayerPrefs.GetInt(strInapp);
    }

    public void SaveFacilityCount(int i, int type = 0)
    {
        string strFacilityCount = "FacilityCount" + i;
        if (type == -1)
            PlayerPrefs.SetFloat(strFacilityCount, 0);
        else
            PlayerPrefs.SetInt(strFacilityCount, FacilityCount[i]);
        PlayerPrefs.Save();
    }
    public void LoadFacilityCount(int i, int type = 0)
    {
        string strFacilityCount = "FacilityCount" + i;
        FacilityCount[i] = PlayerPrefs.GetInt(strFacilityCount);
    }
    public void SaveFacilities(int i, int type = 0)
    {
        string strFacilities = "Facilities" + i;
        if (type == -1)
            PlayerPrefs.SetFloat(strFacilities, 0);
        else
            PlayerPrefs.SetInt(strFacilities, Facilities[i]);
        PlayerPrefs.Save();
    }
    public void LoadFacilities(int i, int type = 0)
    {
        string strFacilities = "Facilities" + i;
        Facilities[i] = PlayerPrefs.GetInt(strFacilities);
    }


    public void SaveGoogleAchivement(int i, int type = 0)
    {
        string strGoogleAchivements= "googleAchivementList" + i;
        if (type == -1)
            PlayerPrefs.SetFloat(strGoogleAchivements, 0);
        else
            PlayerPrefs.SetInt(strGoogleAchivements, googleAchivementList[i]);
        PlayerPrefs.Save();
    }
    public void LoadGoogleAchivement(int i, int type = 0)
    {
        string strGoogleAchivements = "googleAchivementList" + i;
        googleAchivementList[i] = PlayerPrefs.GetInt(strGoogleAchivements);
    }

    public void SaveTotalClickCount(int type = 0)
    {
        if (type == -1)
            PlayerPrefs.SetFloat("TotalClickCount", 0);
        else
            PlayerPrefs.SetFloat("TotalClickCount", (float)TotalClickCount);
        PlayerPrefs.Save();
    }
    public void LoadTotalClickCount(int type = 0)
    {
        TotalClickCount = PlayerPrefs.GetFloat("TotalClickCount");        
    }
    public void SetAchivement(int i, int type = 0)
    {
        AchivementStatus[i] = 1;
        SaveAchivementStatus(i);        
    }
    public void SaveMoneyPerSec(int type = 0)
    {
        if (type == -1)
            PlayerPrefs.SetFloat("MoneyPerSec", 0);
        else
            PlayerPrefs.SetFloat("MoneyPerSec", (float)MoneyPerSec);
        PlayerPrefs.Save();
    }
    public void LoadMoneyPerSec(int type = 0)
    {
        MoneyPerSec = PlayerPrefs.GetFloat("MoneyPerSec");
    }
    public void SaveMethPerSec(int type = 0)
    {
        if (type == -1)
            PlayerPrefs.SetFloat("MethPerSec", 0);
        else
            PlayerPrefs.SetFloat("MethPerSec", (float)MethPerSec);
        PlayerPrefs.Save();
    }
    public void LoadMethPerSec(int type = 0)
    {
        MethPerSec = PlayerPrefs.GetFloat("MethPerSec");
    }
    public void SavePurity(int type = 0)
    {
        if (type == -1)
            PlayerPrefs.SetFloat("Purity", 0.2f);
        else
            PlayerPrefs.SetFloat("Purity", (float)Purity);
        PlayerPrefs.Save();
    }
    public void LoadPurity(int type = 0)
    {
        Purity = PlayerPrefs.GetFloat("Purity");
    }

    public void SaveDayReward(int type = 0)
    {
        if (type == -1)
            PlayerPrefs.SetInt("DayRewardCount", 0);
        else
            PlayerPrefs.SetInt("DayRewardCount", DayRewardCount);
        PlayerPrefs.Save();
    }
    public void LoadDayReward(int type = 0)
    {
        DayRewardCount = PlayerPrefs.GetInt("DayRewardCount");
    }

    public void SaveMasterDealerCount(int type =0)
    {
        if (type == -1)
            PlayerPrefs.SetFloat("MasterDealerCount", 0);
        else
            PlayerPrefs.SetInt("MasterDealerCount", MasterDealerCount);
        PlayerPrefs.Save();
    }
    public void LoadMasterDealerCount()
    {
        MasterDealerCount = PlayerPrefs.GetInt("MasterDealerCount");
    }
    public void SavePotion10(int type = 0)
    {
        if (type == -1)
            PlayerPrefs.SetFloat("Potion10", 0);
        else
            PlayerPrefs.SetInt("Potion10", Potion10);
        PlayerPrefs.Save();
    }
    public void LoadPotion10()
    {
        Potion10 = PlayerPrefs.GetInt("Potion10");
    }
    public void SavePotion100(int type = 0)
    {
        if (type == -1)
            PlayerPrefs.SetFloat("Potion100", 0);
        else
            PlayerPrefs.SetInt("Potion100", Potion100);
        PlayerPrefs.Save();
    }
    public void LoadPotion100()
    {
        Potion100 = PlayerPrefs.GetInt("Potion100");
    }
    public void AllReset()
    {
        PlayerPrefs.SetInt("bStart", 0);
        PlayerPrefs.Save();
        ResetData();
    }

    public void SaveiBGM(int type = 0)
    {
        if (type == -1)
            PlayerPrefs.SetInt("iBGM", 0);
        else
            PlayerPrefs.SetInt("iBGM", iBGM);
        PlayerPrefs.Save();
    }
    public void LoadiBGM()
    {
        iBGM = PlayerPrefs.GetInt("iBGM");
    }

    public void SaveEndingMeth(int type = 0)
    {
        if (type == -1)
            PlayerPrefs.SetFloat("endingMeht", 0);
        else
            PlayerPrefs.SetFloat("endingMeht", (float)endingMeht);
        PlayerPrefs.Save();
    }
    public void LoadiEndingMethM()
    {
        endingMeht = PlayerPrefs.GetFloat("endingMeht");
    }

    public void SaveiFx(int type = 0)
    {
        if (type == -1)
            PlayerPrefs.SetFloat("iFx", 0);
        else
            PlayerPrefs.SetInt("iFx", iFx);
        PlayerPrefs.Save();
    }
    public void LoadiFx()
    {
        iFx = PlayerPrefs.GetInt("iFx");
    }


    public void SaveiLanguage(int type = 0)
    {
        if (type == -1)
            PlayerPrefs.SetFloat("iLanguage", 0);
        else
            PlayerPrefs.SetInt("iLanguage", iLanguage);
        PlayerPrefs.Save();
    }
    public void LoadiLanguage()
    {
        iLanguage = PlayerPrefs.GetInt("iLanguage");
    }


    public void SaveiMapPrograss(int type = 0)
    {
        if (type == -1)
            PlayerPrefs.SetInt("iMapPrograss", 0);
        else
            PlayerPrefs.SetInt("iMapPrograss", iMapPrograss);
        PlayerPrefs.Save();
    }
    public void LoadiMapPrograss()
    {
        iMapPrograss = PlayerPrefs.GetInt("iMapPrograss");
    }

    public void ResetData()
    {     
        SaveTotalPlayTime(-1);
        for (int i = 0; i < 5; i++)
        {
            SaveHireStatus(i, -1);
            SaveHireViewStatus(i, -1);
        }
        for (int i = 0; i < 15; i++)
        {
            SaveBuyStatus(i, -1);
            SaveBuyViewStatus(i, -1);
            SaveIapp(i,-1);
        }
        for (int i = 0; i < 20; i++)
        {
            SaveUpgradeStatus(i, -1);
            SaveUpgradeViewStatus(i, -1);
        }
        for (int i = 0; i < 24; i++)
        {
            SaveAchivementStatus(i, -1);
            SaveSlaveCount(i, -1);
            SaveFacilityCount(i, -1);
            SaveGoogleAchivement(i, -1);
        }
        for (int i = 0; i < 4; i++)
        {
            SaveFacilities(i, -1);
        }
        SaveEndingMeth(-1);
        SaveTotalMoney(-1);
        SaveTotalMeth(-1);
        SaveTotalDealer(-1);
        SaveTotalClickCount(-1);
        SaveMoneyPerSec(-1);
        SaveMethPerSec(-1);
        SavePurity(-1);
        SaveMasterDealerCount(-1);
        SavePotion10(-1);
        SavePotion100(-1);
        SaveiBGM(-1);
        SaveiFx(-1);
        SaveiLanguage(-1);
        SaveDayReward(-1);
        SaveiMapPrograss(-1);


        Potion10 = 2;
        Potion100 = 1;
        SavePotion10();
        SavePotion100();
    }
    void LoadData()
    {     
        LoadTotalPlayTime();
        for (int i = 0; i < 5; i++)
        {            
            LoadHireStatus(i);
            LoadHireViewStatus(i);
        }
        for (int i = 0; i < 15; i++)
        {            
            LoadBuyStatus(i);
            LoadBuyViewStatus(i);
            LoadInapp(i);
        }
        for (int i = 0; i < 20; i++)
        {
            LoadUpgradeStatus(i);
            LoadUpgradeViewStatus(i);
        }
        for (int i = 0; i < 24; i++)
        {
            LoadAchivementStatus(i);
            LoadSlaveCount(i);
            LoadFacilityCount(i);
            LoadGoogleAchivement(i);
        }
        for(int i=0; i< 4; i++)
        {
            LoadFacilities(i);
        }
        LoadiEndingMethM();
        LoadTotalMoney();
        LoadTotalMeth();
        LoadTotalDealer();
        LoadTotalClickCount();
        LoadMoneyPerSec();
        LoadMethPerSec();
        LoadPurity();
        LoadMasterDealerCount();
        LoadPotion10();
        LoadPotion100();
        LoadiBGM();
        LoadiFx();
        LoadiLanguage();
        LoadDayReward();
        LoadiMapPrograss();
        if (AchivementStatus[16] == 0 && 1== PlayerPrefs.GetInt("bStart"))
        {
            SetAchivement(16);
            GameObject.Find("GameManager").GetComponent<BottomUIController>().SetNotice(5);
        }
    }

    void InitData()
    {
        DayRewardTime = 43200;
        endingMeht =0;
        adsTime = 300;
        iMapPrograss = 0;
        TimeMoney = 0;
        AdsType = 0;
        bStartPotion = false;
        DayRewardCount = 0;
        iBGM = 0;
        iFx = 0;
        iGoogle = 0;
        iLanguage = 0;
        IapType = 0;
        potiontype = 0;
        TotalMoney = 0;
        TotalMeth = 0;
        MoneyPerSec = 0;
        MethPerSec = 0;
        Purity = 0;
        Potion10 = 0;
        Potion100 = 100;
        DealerCost = 1000 * scaleFactor;
        TotalDealer = 0;
        MaxDealer = 1000;
        DealrHirePerSec = 0;
        for(int i=0; i< 5; i++)
        {
            HireStatus.Add(0);
            HireCost.Add(0);
            HireViewStatus.Add(0);
        }
        for(int i=0; i<15;i++)
        {
            BuyStatus.Add(0);
            BuyCost.Add(0);
            BuyViewStatus.Add(0);
            isiapp.Add(0);
        }        
        for(int i=0; i< 20; i++)
        {
            UpgradeStatus.Add(0);
            UpgradeCost.Add(0);
            UpgradeViewStatus.Add(0);
        }        
        for (int i=0; i< 24; i++)
        {
            AchivementStatus.Add(0);
            SlaveCount.Add(0);
            FacilityCount.Add(0);
            googleAchivementList.Add(0);
        }   

        MasterDealerCount = 0;

        UpgradePurity = 0;
        Purity = 0.2f;
        DealerPower = 1;
        TotalClickCount = 0;
        totalpalyTime = 0;
        //shortNotation = new string[12] { "", " k", " Million", " Billion", " Trillion", " Quadrillion", " Quintillion", " Sextillion", " Septillion", " Octillion", " Nonillion", " Decillion" };
        shortNotation = new string[12] { "", "", "", " Billion", " Trillion", " Quadrillion", " Quintillion", " Sextillion", " Septillion", " Octillion", " Nonillion", " Decillion" };
        Facilities = new int[4] { 0, 0, 0, 0 };


        if (PlayerPrefs.GetInt("bStart") == 0)
        {            
            Potion10 = 2;
            Potion100 = 1;
            SavePotion10();
            SavePotion100();
            ResetData();
        }
        else
            LoadData();

    }
    public List<int> googleAchivementList = new List<int>();
    public bool bClickArmy = false;
    public int iMapPrograss;
    public double TimeTotalMoney;
    public double TimeTotalMeth;
    public int adsTime;
    public byte[] saveByte;
    public int AdsType;
    public double TimeMoney;
    public List<int> isiapp = new List<int>();
    public int DayRewardTime;
    public int Potion10;
    public int Potion100;
    public double TotalClickCount;
    public int GetAchivementCount()
    {
        int count = 0;
        for(int i=0; i < AchivementStatus.Count; i++)
        {
            if(AchivementStatus[i] ==1)
            {
                count++;
            }
        }
        return count;
    }
    public int CheckFacilities(int type)
    {        
        for(int i=0; i< 4; i++)
        {           
            if(Facilities[i] == type)
            {
                return -3;
            }            
        }
        for (int i = 0; i < 4; i++)
        {
            if (Facilities[i] == 0)
            {
                return i;
            }
        }       
        return -1;
    }
    public int adsRewardType;
    public double adsRewardMoeny;
    public double adsRewardMeth;
    ~Globalvariable() { }
    public double endingMeht;
    public int iBGM;
    public int iFx;
    public int iGoogle;
    public int iLanguage;

    public int DayRewardCount;
    public int IapType;
    public bool bStartPotion;
    public int potiontype;
    public double UpgradePurity;
    public List<double> UpgradeCost = new List<double>();
    public List<double> BuyCost = new List<double>();
    public List<double> HireCost = new List<double>();

    public static int Highscore { get; set; }
    public double MethPerDeSec;
    public int MasterDealerCount;
    public List<int> SlaveCount = new List<int>();
    public List<int> FacilityCount = new List<int>();
    public List<int> HireStatus = new List<int>();
    public List<int> BuyStatus = new List<int>();
    public List<int> UpgradeStatus = new List<int>();
    public List<int> AchivementStatus = new List<int>();

    public List<int> HireViewStatus = new List<int>();
    public List<int> BuyViewStatus = new List<int>();
    public List<int> UpgradeViewStatus = new List<int>();
    public int SelectFacilityindex = -1;
    public double TotalMoney;
    public double TotalMeth;
    public double MoneyPerSec;
    public double MethPerSec;
    public double Purity;
    public double DealerPower;
    public double MethPerSec_Dealer;
    public double MethPerSec_Worker;

    public float DealerCost;
    public float TotalDealer;
    public double MaxDealer;
    public float DealrHirePerSec;
    public float scaleFactor = 0.000000000000000001f;
    public int[] Facilities;
    public double totalpalyTime;
    //public string[] shortNotation = new string[12] { "", "k", "M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc", "No", "Dc" };
    public string[] shortNotation;
    public string ChangeFormat(string[] notations, double target, string lowDecimalFormat, int round = 1)
    {
        if (target >= 1000000000000)
            return string.Format("{0:#.###} Nonillion", (double)target / 1000000000000);
        else if (target >= 1000000000)
            return string.Format("{0:#.###} Octillion", (double)target / 1000000000);
        else if (target >= 1000000)
            return string.Format("{0:#.###} Septillion", (double)target / 1000000);
        else if (target >= 1000)
            return string.Format("{0:#.###} Sextillion", (double)target / 1000);
        else if (target >= 1)
            return string.Format("{0:#.###} Quintillion", (double)target / 1);
        else if (target >= 0.001)
            return string.Format("{0:#.###} Quadrillion", (double)target / 0.001);
        else if (target >= 0.000001)        
            return string.Format("{0:#.###} Trillion", (double)target / 0.000001);     
        else if (target == 0)
            return target.ToString();
        else
        {
            //int a = Mathf.CeilToInt((float)target);            
            target = target * 1000000000000000000f;            
            target = Mathf.Round((float)target * 10) * 0.1f;
            if(round ==0)
            {                
                if(target > 1000000)
                {
                    double temp = target;
                    temp = temp / 1000000;
                    temp = Mathf.Round((float)temp);
                    temp = temp * 1000000;
                    target = temp;
                    return string.Format("{0:#.##}", target.ToString(lowDecimalFormat));
                }
                target = Mathf.Round((float)target);
            }
            return string.Format("{0:#.##}", target.ToString(lowDecimalFormat));
        }
    }

    private void Start()
    {
        if (iLanguage == 0)
        {
            if (Application.systemLanguage == SystemLanguage.Korean)
            {
                I2.Loc.SetLanguage setLanguague = new I2.Loc.SetLanguage();
                setLanguague._Language = "Korean";                
                setLanguague.ApplyLanguage();
            }
            //Otherwise, if the system is English, output the message in the console
            else if (Application.systemLanguage == SystemLanguage.English)
            {
                I2.Loc.SetLanguage setLanguague = new I2.Loc.SetLanguage();
                setLanguague._Language = "English";
                setLanguague.ApplyLanguage();
            }
            else if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                I2.Loc.SetLanguage setLanguague = new I2.Loc.SetLanguage();
                setLanguague._Language = "Japanese";
                setLanguague.ApplyLanguage();
            }
            else if (Application.systemLanguage == SystemLanguage.Spanish)
            {
                I2.Loc.SetLanguage setLanguague = new I2.Loc.SetLanguage();
                setLanguague._Language = "Spanish";
                setLanguague.ApplyLanguage();
            }
            else if (Application.systemLanguage == SystemLanguage.Chinese || Application.systemLanguage == SystemLanguage.ChineseSimplified ||
                Application.systemLanguage == SystemLanguage.ChineseTraditional)
            {
                I2.Loc.SetLanguage setLanguague = new I2.Loc.SetLanguage();
                setLanguague._Language = "Chinese (Taiwan)";
                setLanguague.ApplyLanguage();
            }
            else if (Application.systemLanguage == SystemLanguage.Russian)
            {
                I2.Loc.SetLanguage setLanguague = new I2.Loc.SetLanguage();
                setLanguague._Language = "Russian";
                setLanguague.ApplyLanguage();
            }
            else
            {
                I2.Loc.SetLanguage setLanguague = new I2.Loc.SetLanguage();
                setLanguague._Language = "English";
                setLanguague.ApplyLanguage();
            }
        }
    }
    public void SetAdsTime()
    {
        GameObject.Find("GameManager").GetComponent<TimerManager>().StartTimer("AdsRewardTime_Potion", adsTime);
    }
    public int GetAdsTime()
    {
        if(GameObject.Find("GameManager").GetComponent<TimerManager>().SetTimerText("AdsRewardTime_Potion", adsTime) ==-1)
        {
            //성공
            return -1;
        }
        else
        {
            return 0;
        }
    }
}

