using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerSrc : MonoBehaviour
{

    // Use this for initialization
    public GameObject Fever20Image;
    public Text TextTimeMoney;
    public Text TextTimeMeth;
    public GameObject TutorialCanvas;
    public GameObject CartoonObj;
    public GameObject DayRewardBtn;
    public GameObject PanelNotification;
    public List<GameObject> PanelNotifiList;
    public GameObject FeverObj;
    public GameObject Fever10Image;
    public GameObject Fever100Image;

    public GameObject NotificationObj;
    public List<GameObject> NotifiTextList;
    public GameObject settingObj;
    public Image ClickPrograss;
    public GameObject FeverImage;
    public Text PotionText10;
    public Text PotionText100;
    public GameObject MethEffect;
    public GameObject MoneyEffect;
    public GameObject MethCheck;
    public GameObject MoneyCheck;
    public Text TextTotalMeth;
    public Text TextMethPerSec;
    public Text TextTotalMoney;
    public Text TextMoneyPerSec;
    public Text TextPurity;

    int clickType = 0;
    Globalvariable gv;
    public GameObject DealerObj;
    public List<GameObject> FacilitiesLIst = new List<GameObject>();
    public List<GameObject> BuyLIst = new List<GameObject>();
    public List<GameObject> UpgradeList = new List<GameObject>();
    public List<GameObject> HireObjectList = new List<GameObject>();
    public List<GameObject> HireList = new List<GameObject>();
    public GameObject ShopObj;
    float clickPrograssindex = 0;
    bool bStartBuff = false;
    private bool isBtnDown = false;
 
    public void PressCartoonObj(int i)
    {
        if(i==1)
        {
            CartoonObj.SetActive(true);
        }
        else
        {
            CartoonObj.SetActive(false);
            TutorialCanvas.SetActive(true);
        }
    }
    public void PressTutorialFalse()
    {
        TutorialCanvas.SetActive(false);
    }
    public double GetTimeMoney()
    {
        double i = gv.MethPerSec;

        double temp = 0;
        if(i /gv.scaleFactor <500)
        {
           temp = i / (500 * gv.scaleFactor);
        }
        //default 10,000,000
        double defaultMoney = 0.00000000001;
        if (temp <1)
        {
            return defaultMoney *10;
        }
        else
        {
            return defaultMoney * (int)temp*40;
        }
    }
    public void AppQuit()
    {
        Application.Quit();
    }
    bool bStartApp = false;
    private void OnApplicationPause(bool pause)
    {
        if (pause == true)
        {
            AddRewardTime();
            bStartApp = true;
        }
        if (pause == false)
        {
            if (bStartApp == true)
            {
                CheckTimeManager();
                bStartApp = false;
            }
        }
    }
    public static void Add(string key)
    {
        string timerKeyStr = key;
        string now = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        PlayerPrefs.SetString(timerKeyStr, now);
        PlayerPrefs.Save();
    }
    void AddRewardTime()
    {
        Add("RewardTime");
    }
    private void OnDestroy()
    {
        AddRewardTime();
    }
    
    void CheckTimeManager()
    {
        string timerKeyStr = "RewardTime";
        string startTimeStr = PlayerPrefs.GetString(timerKeyStr);
        if (string.IsNullOrEmpty(startTimeStr) == true)
        {
            //_txt.text = "미접속 수익 없음";
        }
        else
        {
            System.DateTime start = System.DateTime.Parse(startTimeStr);
            System.DateTime now = System.DateTime.Now;

            System.TimeSpan AAA = now - start;
            int times = (int)AAA.TotalSeconds;
            //time 이 몇초 이상이면 미접속 수익 주자 ->
            //
            //SetTextTime(times, _text);
            //if (times > 600)
            
            if (times > 120)
            {
                CheckReward(times);
                StartCoroutine(StartReward());
            }
        }
    }
    IEnumerator StartReward()
    {
        yield return new WaitForSeconds(2);
        PressPanelNotification("TimeReward");
    }
    void CheckReward(int times)
    {
        if (times > 1200)
        {
            times = 1200;      
        }
        double timeMoney = gv.MoneyPerSec * (times);
        double timeMeth = gv.MethPerSec * (times);

        TextTimeMoney.text = gv.ChangeFormat(gv.shortNotation, timeMoney, "N0");
        TextTimeMeth.text = gv.ChangeFormat(gv.shortNotation, timeMeth, "N0");

        gv.TimeTotalMoney = timeMoney;
        gv.TimeTotalMeth = timeMeth;
    }

    public void PresssettingObj(int i)
    {
        if(i==1)
        {
            settingObj.SetActive(true);
        }
        else
        {
            settingObj.SetActive(false);
        }
    }
    public void PressPanelNotification(int i)
    {
        if(i ==1)
        {
            PanelNotification.SetActive(true);
        }
        else
        {
            if(PanelNotifiList[7].activeSelf == true)
            {
                PanelNotifiList[7].SetActive(false);
                return;
            }
            if(PanelNotifiList[6].activeSelf == true)
            {
                PanelNotifiList[6].SetActive(false);
                return;
            }
            
            for (int k=0; k < PanelNotifiList.Count; k++)
            {
                PanelNotifiList[k].SetActive(false);
            }
            PanelNotification.SetActive(false);
        }
    }
    public void SetShopVIew()
    {
        if(ShopObj.activeSelf == true)
        {
            ShopObj.GetComponent<ShopScrollManager>().InitData();
        }

    }
    public void EndNotificationPane(string name)
    {
        switch (name)
        {
            case "IAP":
                PanelNotifiList[0].GetComponent<Animator>().SetBool("isBack", true);
                break;
            case "DayReward":
                PanelNotifiList[1].GetComponent<Animator>().SetBool("isBack", true);
                DayRewardBtn.SetActive(false);
                if(bStartCheckDayReward == false)
                    StartCoroutine(CheckDayReward());
                break;
            case "ADS":
                PanelNotifiList[2].GetComponent<Animator>().SetBool("isBack", true);
                break;
            case "QUIT":
                PanelNotifiList[3].GetComponent<Animator>().SetBool("isBack", true);
                break;
            case "Save":
                PanelNotifiList[4].GetComponent<Animator>().SetBool("isBack", true);
                break;
            case "Load":
                PanelNotifiList[5].GetComponent<Animator>().SetBool("isBack", true);
                Application.Quit();
                break;
            case "Saving":
                PanelNotifiList[6].GetComponent<Animator>().SetBool("isBack", true);
                break;
            case "Loading":
                PanelNotifiList[7].GetComponent<Animator>().SetBool("isBack", true);                
                break;
            case "Worldmap":
                PanelNotifiList[8].GetComponent<Animator>().SetBool("isBack", true);
                break;
            case "TimeReward":
                PanelNotifiList[9].GetComponent<Animator>().SetBool("isBack", true);
                gv.TotalMoney += (gv.TimeTotalMoney);
                gv.TotalMeth += (gv.TimeTotalMeth);
                gv.endingMeht += (gv.TimeTotalMeth);
                gv.SaveTotalMoney();
                gv.SaveTotalMeth();
                gv.SaveEndingMeth();
                break;
            case "StatusSell":
                PanelNotifiList[10].GetComponent<Animator>().SetBool("isBack", true);
                break;
            case "Supply1":
                PanelNotifiList[11].GetComponent<Animator>().SetBool("isBack", true);
                
                if (gv.adsRewardMoeny > 0 && gv.AdsType !=3)
                {
                    gv.TotalMoney += gv.adsRewardMoeny;
                    gv.adsRewardMoeny = 0;
                }
                if (gv.adsRewardMeth > 0 && gv.AdsType != 3)
                {
                    gv.TotalMeth += gv.adsRewardMeth;
                    gv.adsRewardMeth = 0;
                }

                SetText();
                break;
            case "Supply2":
                PanelNotifiList[12].GetComponent<Animator>().SetBool("isBack", true);
                break;
            case "ADS2":
                PanelNotifiList[13].GetComponent<Animator>().SetBool("isBack", true);
                if (gv.adsRewardMoeny > 0)
                {
                    gv.TotalMoney += gv.adsRewardMoeny;
                    gv.adsRewardMoeny = 0;
                }
                if (gv.adsRewardMeth > 0)
                {
                    gv.TotalMeth += gv.adsRewardMeth;
                    gv.adsRewardMeth = 0;
                }
                if(gv.adsRewardType==3)
                {
                    if (gv.bStartPotion == false)
                    {                        
                        gv.potiontype = 3;
                        StartCoroutine(startPotionRoutine());
                        FeverObj.SetActive(true);                                                
                        Fever20Image.SetActive(true);
                        if (FeverImage.activeSelf == true)
                            FeverImage.SetActive(false);
                    }
                }
                break;
        }
    }

    public void DisablePanel(string name)
    {
        switch (name)
        {
            case "IAP":
                PanelNotifiList[0].SetActive(false);
                break;
            case "DayReward":
                PanelNotifiList[1].SetActive(false);
                break;
            case "ADS":
                PanelNotifiList[2].SetActive(false);
                break;
            case "QUIT":
                PanelNotifiList[3].SetActive(false);
                break;
            case "Save":
                PanelNotifiList[4].SetActive(false);
                break;
            case "Load":
                PanelNotifiList[5].SetActive(false);
                Application.Quit();
                break;
            case "Saving":
                PanelNotifiList[6].SetActive(false);
                break;
            case "Loading":
                PanelNotifiList[7].SetActive(false);
                break;
            case "Worldmap":
                PanelNotifiList[8].SetActive(false);
                break;
            case "TimeReward":
                PanelNotifiList[9].SetActive(false);
                gv.TotalMoney += (gv.TimeTotalMoney);
                gv.TotalMeth += (gv.TimeTotalMeth);
                gv.endingMeht += (gv.TimeTotalMeth);
                gv.SaveTotalMoney();
                gv.SaveTotalMeth();
                gv.SaveEndingMeth();
                break;
            case "StatusSell":
                PanelNotifiList[10].SetActive(false);
                break;
            case "Supply1":
                PanelNotifiList[11].SetActive(false);

                if (gv.adsRewardMoeny > 0 && gv.AdsType != 3)
                {
                    gv.TotalMoney += gv.adsRewardMoeny;
                    gv.adsRewardMoeny = 0;
                }
                if (gv.adsRewardMeth > 0 && gv.AdsType != 3)
                {
                    gv.TotalMeth += gv.adsRewardMeth;
                    gv.adsRewardMeth = 0;
                }

                SetText();
                break;
            case "Supply2":
                PanelNotifiList[12].SetActive(false);
                break;
            case "ADS2":
                PanelNotifiList[13].SetActive(false);
                if (gv.adsRewardMoeny > 0)
                {
                    gv.TotalMoney += gv.adsRewardMoeny;
                    gv.adsRewardMoeny = 0;
                }
                if (gv.adsRewardMeth > 0)
                {
                    gv.TotalMeth += gv.adsRewardMeth;
                    gv.adsRewardMeth = 0;
                }
                if (gv.adsRewardType == 3)
                {
                    if (gv.bStartPotion == false)
                    {
                        gv.potiontype = 3;
                        StartCoroutine(startPotionRoutine());
                        FeverObj.SetActive(true);
                        Fever20Image.SetActive(true);
                        if (FeverImage.activeSelf == true)
                            FeverImage.SetActive(false);
                    }
                }
                break;
        }
    }
    // Update is called once per frame
    string GetPanelStr(int i)
    {
        switch(i)
        {
            case 0:
                return "IAP";
                break;
            case 1:
                return "DayReward";
                break;
            case 2:
                return "ADS";
                break;
            case 3:
                return "QUIT";
                break;
            case 4:
                return "Save";                
                break;
            case 5:
                return "Load";                
                break;
            case 6:
                return "Saving";                
                break;
            case 7:
                return "Loading";                
                break;
            case 8:
                return "Worldmap";                
                break;
            case 9:
                return "TimeReward";                
                break;
            case 10:
                return "StatusSell";                
                break;
            case 11:
                return "Supply1";
                break;
            case 12:
                return "Supply2";
                break;
            case 13:
                return "ADS2";
                break;
        }
        return "QUIT";
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            int indexcount = 0;
            if(settingObj.activeSelf == true)
            {
                settingObj.SetActive(false);
                return;
            }
            for(int i=0; i< PanelNotifiList.Count; i++)
            {
                string strType = GetPanelStr(i);

                if (PanelNotifiList[6].activeSelf == true || PanelNotifiList[7].activeSelf == true)
                    return;
                if (PanelNotifiList[i].activeSelf == true)
                {
                    EndNotificationPane(strType);
                    indexcount++;
                }
            }
            if(indexcount ==0)
            {
                PressPanelNotification("QUIT");
            }
        }
    }
    public void SellFacility()
    {
        if(gv.SelectFacilityindex >-1)
        {
            FacilitiesLIst[gv.SelectFacilityindex].GetComponent<MethWorkersController>().CompleteSell();
        }
        EndNotificationPane("StatusSell");
        gv.SelectFacilityindex = -1;
    }
    public void PressPanelNotification(string name,int supplytype =0, string supplymoney ="",string supplymoney5 = "")
    {
        PanelNotification.SetActive(true);
        switch (name)
        {
            case "IAP":
                PanelNotifiList[0].SetActive(true);
                break;
            case "DayReward":
                PanelNotifiList[1].SetActive(true);
                break;
            case "ADS":
                PanelNotifiList[2].SetActive(true);
                break;
            case "QUIT":
                PanelNotifiList[3].SetActive(true);
                break;
            case "Save":
                PanelNotifiList[4].SetActive(true);
                break;
            case "Load":
                PanelNotifiList[5].SetActive(true);
                break;
            case "Saving":
                PanelNotifiList[6].SetActive(true);
                break;
            case "Loading":
                PanelNotifiList[7].SetActive(true);
                break;
            case "Worldmap":
                PanelNotifiList[8].SetActive(true);
                break;
            case "TimeReward":
                PanelNotifiList[9].SetActive(true);
                break;
            case "StatusSell":
                PanelNotifiList[10].SetActive(true);
                break;
            case "Supply1":            
                PanelNotifiList[11].SetActive(true);
                PanelNotifiList[11].transform.Find("Money").gameObject.SetActive(false);
                PanelNotifiList[11].transform.Find("Meth").gameObject.SetActive(false);
                if (supplytype == 1)
                {
                    PanelNotifiList[11].transform.Find("Money").gameObject.SetActive(true);
                    PanelNotifiList[11].transform.Find("Money/TextMoney").gameObject.GetComponent<Text>().text = supplymoney;
                    PanelNotifiList[11].transform.Find("AdsBtn/TextMoney").gameObject.GetComponent<Text>().text = supplymoney5;
                }
                if (supplytype == 2)
                {
                    PanelNotifiList[11].transform.Find("Meth").gameObject.SetActive(true);
                    PanelNotifiList[11].transform.Find("Meth/TextMeth").gameObject.GetComponent<Text>().text = supplymoney;
                    PanelNotifiList[11].transform.Find("AdsBtn/TextMoney").gameObject.GetComponent<Text>().text = supplymoney5;
                }
                break;
            case "Supply2":
                PanelNotifiList[12].SetActive(true);
                break;
            case "ADS2":
                PanelNotifiList[13].SetActive(true);
                PanelNotifiList[13].transform.Find("Money").gameObject.SetActive(false);
                PanelNotifiList[13].transform.Find("Meth").gameObject.SetActive(false);
                PanelNotifiList[13].transform.Find("Potion").gameObject.SetActive(false);
                if (supplytype ==1)
                {
                    PanelNotifiList[13].transform.Find("Money").gameObject.SetActive(true);
                    PanelNotifiList[13].transform.Find("Money/TextMoney").gameObject.GetComponent<Text>().text = gv.ChangeFormat(gv.shortNotation,gv.adsRewardMoeny,"N0");                    
                }
                if (supplytype == 2)
                {
                    PanelNotifiList[13].transform.Find("Meth").gameObject.SetActive(true);
                    PanelNotifiList[13].transform.Find("Meth/TextMeth").gameObject.GetComponent<Text>().text = gv.ChangeFormat(gv.shortNotation, gv.adsRewardMeth, "N0"); ;                    
                }
                if (supplytype == 3)
                {
                    PanelNotifiList[13].transform.Find("Potion").gameObject.SetActive(true);                    
                }
                break;
        }
    }

    public void PressPanelNotification(string name)
    {
        PanelNotification.SetActive(true);
        switch (name)
        {
            case "IAP":
                PanelNotifiList[0].SetActive(true);
                break;
            case "DayReward":
                PanelNotifiList[1].SetActive(true);
                break;
            case "ADS":
                PanelNotifiList[2].SetActive(true);
                break;
            case "QUIT":
                PanelNotifiList[3].SetActive(true);
                break;
            case "Save":
                PanelNotifiList[4].SetActive(true);
                break;
            case "Load":
                PanelNotifiList[5].SetActive(true);
                break;
            case "Saving":
                PanelNotifiList[6].SetActive(true);
                break;
            case "Loading":
                PanelNotifiList[7].SetActive(true);
                break;
            case "Worldmap":
                PanelNotifiList[8].SetActive(true);
                break;
            case "TimeReward":
                PanelNotifiList[9].SetActive(true);
                break;
            case "StatusSell":
                PanelNotifiList[10].SetActive(true);
                break;
            case "Supply1":
                PanelNotifiList[11].SetActive(true);
                PanelNotifiList[11].transform.Find("Money").gameObject.SetActive(false);
                PanelNotifiList[11].transform.Find("Meth").gameObject.SetActive(false);
             
                break;
            case "Supply2":
                PanelNotifiList[12].SetActive(true);
                break;
            case "ADS2":
                PanelNotifiList[13].SetActive(true);
                PanelNotifiList[13].transform.Find("Money").gameObject.SetActive(false);
                PanelNotifiList[13].transform.Find("Meth").gameObject.SetActive(false);
                PanelNotifiList[13].transform.Find("Potion").gameObject.SetActive(false);
              
                break;
        }
    }
    bool bStartNotification = true;
    public void ViewNotifiction(string name)
    {
        if(bStartNotification ==true)
        {
            for (int i = 0; i < NotifiTextList.Count; i++)
            {
                NotifiTextList[i].SetActive(false);
            }
            switch (name)
            {
                case "Money":
                    NotifiTextList[0].SetActive(true);
                    break;
                case "Meth":
                    NotifiTextList[1].SetActive(true);
                    break;
                case "Upgradefailure":
                    NotifiTextList[2].SetActive(true);
                    break;
                case "UpgradeSuccess":
                    NotifiTextList[3].SetActive(true);
                    break;
                case "Facility":
                    NotifiTextList[4].SetActive(true);
                    break;
                case "Potion":
                    NotifiTextList[5].SetActive(true);
                    break;
                case "Full":
                    NotifiTextList[6].SetActive(true);
                    break;
                case "BUY":
                    NotifiTextList[7].SetActive(true);
                    break;
                case "NeedFacility":
                    NotifiTextList[8].SetActive(true);
                    break;            

            }
            NotificationObj.SetActive(true);
            StartCoroutine(NotificationRoutine());
            bStartNotification = false;
        }
      
    }
    IEnumerator NotificationRoutine()
    {
        yield return new WaitForSeconds(0.7f);
        NotificationObj.GetComponent<Animator>().SetBool("isBack", true);
        yield return new WaitForSeconds(0.7f);
        NotificationObj.GetComponent<Animator>().SetBool("isBack", false);        
        NotificationObj.SetActive(false);
        bStartNotification = true;
    }    
    private void Awake()
    {
        gv = Globalvariable.Instance;
        LoadData();
        SetText();
        InitHireView();
        InitView();
    }
    public void UsePotion(int i)
    {
        if(i ==1)
        {
            //normal
            if(gv.Potion10 >0)
            {
                if(gv.bStartPotion == false)
                {
                    gv.Potion10--;
                    gv.SavePotion10();
                    gv.potiontype = 1;
                    StartCoroutine(startPotionRoutine());                    
                    FeverObj.SetActive(true);
                    if (gv.googleAchivementList[15] == 0)
                        GameObject.Find("GPGSManager").GetComponent<GPGSManager>().AddAchive(16);
                    SetPotionText();
                    Fever10Image.SetActive(true);
                    if (FeverImage.activeSelf == true)
                        FeverImage.SetActive(false);
                }
                
            }
            else
            {
                ViewNotifiction("Potion");
            }
            
        }
        if(i==2)
        {
            //100
            if(gv.Potion100 >0)
            {
                if(gv.bStartPotion == false)
                {                    
                    gv.Potion100--;
                    gv.SavePotion100();
                    gv.potiontype = 2;
                    StartCoroutine(startPotionRoutine());
                    FeverObj.SetActive(true);
                    if (gv.googleAchivementList[16] == 0)
                        GameObject.Find("GPGSManager").GetComponent<GPGSManager>().AddAchive(17);
                    SetPotionText();
                    Fever100Image.SetActive(true);
                    if (FeverImage.activeSelf == true)
                        FeverImage.SetActive(false);
                }
                
            }
            else
            {
                ViewNotifiction("Potion");
            }
        }
    }
    IEnumerator startPotionRoutine()
    {
        gv.bStartPotion = true;
        yield return new WaitForSeconds(10);
        Fever100Image.SetActive(false);
        Fever10Image.SetActive(false);
        Fever20Image.SetActive(false);
        FeverObj.SetActive(false);
        gv.potiontype = 0;
        gv.bStartPotion = false;
    }
    void Start()
    {
        Check();
        StartCoroutine(CheckUpgradeRoutine());
        CheckPurity();
        AddPurity();
        SetPotionText();
        ClickPrograss.fillAmount = 0;
        StartCoroutine(feverEnd());
        if(gv.DayRewardCount ==0 || GetComponent<TimerManager>().SetTimerText("DayRewardTime_Time",gv.DayRewardTime) == -1)
        {
            DayRewardBtn.SetActive(true);
        }
        else
        {            
            StartCoroutine(CheckDayReward());
            bStartCheckDayReward = true;
        }
        if(PlayerPrefs.GetInt("bStart") == 0)
        {
            startTutorial();
            PlayerPrefs.SetInt("bStart", 1);
            PlayerPrefs.Save();
        }
        else
        {
            CheckTimeManager();
        }
       
    }
    void startTutorial()
    {
        PressCartoonObj(1);
    }
    bool bStartCheckDayReward = false;
    IEnumerator CheckDayReward()
    {        
        yield return new WaitForSeconds(5f);
        if (gv.DayRewardCount == 0 || GetComponent<TimerManager>().SetTimerText("DayRewardTime_Time", gv.DayRewardTime) == -1)
        {
            DayRewardBtn.SetActive(true);
        }     
        StartCoroutine(CheckDayReward());
    }
    void ClickPrograssCheck()
    {
        clickPrograssindex++;
        float fillamount = (float)clickPrograssindex / 100;
        ClickPrograss.fillAmount = fillamount;
        if(fillamount >=1)
        {
            //start Fever
            bStartBuff = true;
            StartCoroutine(feverExit());
            if(Fever10Image.activeSelf == false && Fever100Image.activeSelf ==false && Fever20Image.activeSelf ==false)
                FeverImage.SetActive(true);
        }
    }
    IEnumerator feverExit()
    {
        for (int i = 0; i < 10; i++)
        {
            clickPrograssindex-=0.1f;
            float fillamount = (float)clickPrograssindex / 100;
            ClickPrograss.fillAmount = fillamount;
            yield return new WaitForSeconds(0.0001f);
        }
        if (ClickPrograss.fillAmount > 0)
        {
            StartCoroutine(feverExit());
        }
        else
        {
            bStartBuff = false;
            FeverImage.SetActive(false);
        }
    }
    IEnumerator feverEnd()
    {
        yield return new WaitForSeconds(0.01f);
        {
            if(bStartBuff == false)
            {
                clickPrograssindex-= 0.01f;
                if (clickPrograssindex < 0)
                    clickPrograssindex = 0;
                float fillamount = (float)clickPrograssindex / 100;
                ClickPrograss.fillAmount = fillamount;
            }          
            StartCoroutine(feverEnd());
        }
    }
    void InitView()
    {
        for(int i=0; i< 4; i++)
        {
            if(gv.Facilities[i] !=0)
            {
                FacilitiesLIst[gv.Facilities[i] - 1].SetActive(true);
                FacilitiesLIst[gv.Facilities[i] - 1].GetComponent<MethWorkersController>().LoadData();
            }
        }
        if(gv.HireStatus[4] ==1)
        {
            for(int i=0; i <FacilitiesLIst.Count;i++)
            {
                FacilitiesLIst[i].transform.Find("BtnBuyAll").gameObject.SetActive(true);
            }
        }
    }
    public void SetChef()
    {
        if (gv.HireStatus[4] == 1)
        {
            for (int i = 0; i < FacilitiesLIst.Count; i++)
            {
                FacilitiesLIst[i].transform.Find("BtnBuyAll").gameObject.SetActive(true);
            }
        }
    }
    public void SetPotionText()
    {
        PotionText10.text = gv.Potion10.ToString();
        PotionText100.text = gv.Potion100.ToString();
    }
    void LoadData()
    {
       
    }
    public void SetMasterDealerPower()
    {
        DealerObj.GetComponent<DelaerManager>().SetMasterDealerPower();
    }
    public void SetMaxDealer()
    {
        DealerObj.GetComponent<DelaerManager>().SetMaxDealer();
    }
    public void SetDealerPower()
    {
        DealerObj.GetComponent<DelaerManager>().SetDealerPower();
    }
    public void TestAddMoney()
    {
        //double temp = 100000000000000000 * gv.scaleFactor;
        double temp = 0.001;
        gv.TotalMoney += temp;
        SetTextMoney();
    }
    public void TestAddMeth()
    {
        double temp = 100000 * gv.scaleFactor;
        gv.TotalMeth += temp;
        SetTextMeth();
    }
    void InitHireView()
    {
        for(int i=0; i<gv.HireStatus.Count; i++)
        { 
            if(gv.HireStatus[i] >=1)
            {
                HireObjectList[i].SetActive(true);
            }
        }
    }
    public void AddMoneyBaker(int percent)
    {
        gv.TotalMoney += (gv.TotalMoney * (0.01 * percent));
        SetTextMoney();
    }
    public void AddPurity()
    {
        gv.UpgradePurity = 0;
        if (gv.UpgradeStatus[5] ==1)
        {
            gv.UpgradePurity += 0.05f;
        }
        if (gv.UpgradeStatus[6] == 1)
        {
            gv.UpgradePurity += 0.05f;
        }
        if (gv.UpgradeStatus[7] == 1)
        {
            gv.UpgradePurity += 0.05f;
        }
        if (gv.UpgradeStatus[14] == 1)
        {
            gv.UpgradePurity += 1f;
        }
        SetTextPurity();
    }
    public void SetHireView(int index)
    {
        if(index ==0)
        {
            DealerObj.GetComponent<DelaerManager>().AutoHireStart();
        }
        if (gv.HireStatus[index] == 1)
        {
            HireObjectList[index].SetActive(true);
        }
    }
    public void SetHireArmy()
    {
        DealerObj.GetComponent<DelaerManager>().SetPurityData();
        SetText();
    }
    public void CheckPurity()
    {
        List<double> puList = new List<double>();
        for (int i=0; i< 4; i++)
        {
            if(gv.Facilities[i] !=0 && gv.SlaveCount[gv.Facilities[i]-1] >0)
            {
                puList.Add(FacilitiesLIst[gv.Facilities[i] - 1].GetComponent<MethWorkersController>().MaxPurity);
            }
        }
        if(puList.Count >0)
        {
            puList.Sort();
            gv.Purity =puList[puList.Count - 1];
            SetTextPurity();
            DealerObj.GetComponent<DelaerManager>().SetPurityData();
        }        
    }

    IEnumerator CheckUpgradeRoutine()
    {
        //Check();
        yield return new WaitForSeconds(2f);             
        //StartCoroutine(CheckUpgradeRoutine());
    }
    public int GetUpgrade()
    {
        for (int i = 0; i < gv.UpgradeStatus.Count; i++)
        {
            if (gv.UpgradeStatus[i] == 0)
            {
                return i;
            }
        }
        return -1;
    }
    public void Check()
    {
        int index = 0;
        for (int i = 0; i < gv.UpgradeCost.Count; i++)
        {
            if (gv.TotalMeth >= gv.UpgradeCost[i] && gv.UpgradeCost[i] != 0 && gv.UpgradeStatus[i] ==0)
            {                
                GameObject.Find("GameManager").GetComponent<BottomUIController>().SetNotice(4);              
                index++;
            }
            if (UpgradeList.Count > i)
            {
                if (UpgradeList[i].activeSelf)
                {
                    UpgradeList[i].GetComponent<Upgradecontroller>().InitData();
                }
            }
        }
        if(index ==0)
        {
            GameObject.Find("GameManager").GetComponent<BottomUIController>().UnSetNotice(4);
        }
        index = 0;
        for (int i = 0; i < gv.BuyCost.Count; i++)
        {
            if (gv.TotalMoney >= gv.BuyCost[i] && gv.BuyCost[i] !=0)
            {                
                GameObject.Find("GameManager").GetComponent<BottomUIController>().SetNotice(2);
                index++;
            }
            if(BuyLIst.Count > i)
            {
                if (BuyLIst[i].activeSelf)
                {
                    BuyLIst[i].GetComponent<BuyController>().InitData();
                }
            }
          
        }
        if (index == 0)
        {
            GameObject.Find("GameManager").GetComponent<BottomUIController>().UnSetNotice(2);
        }
        index = 0;
        for (int i = 0; i < gv.HireCost.Count; i++)
        {
            if (gv.TotalMoney >= gv.HireCost[i] && gv.HireCost[i] != 0)
            {
                GameObject.Find("GameManager").GetComponent<BottomUIController>().SetNotice(3);
                index++;
            }
            if (HireList.Count > i)
            {
                if (HireList[i].activeSelf )
                {
                    HireList[i].GetComponent<HireContoller>().InitData();
                }
            }
        }
        if (index == 0)
        {
            GameObject.Find("GameManager").GetComponent<BottomUIController>().UnSetNotice(3);
        }
    }
 
    public void SetFacility(int index)
    {
        FacilitiesLIst[index].SetActive(true);
        FacilitiesLIst[index].GetComponent<MethWorkersController>().SetAddFacility();
        for(int i=0; i< BuyLIst.Count; i++)
        {
            if(BuyLIst[i].activeSelf == true)
            BuyLIst[i].GetComponent<BuyController>().InitData();
        }
    }
    public void SellFacility(int index)
    {
        FacilitiesLIst[index].SetActive(false);
        for (int i = 0; i < BuyLIst.Count; i++)
        {
            if(BuyLIst[i].activeSelf == true)
                BuyLIst[i].GetComponent<BuyController>().InitData();
        }
    }
    public void SetTextMeth()
    {
        string temp = "";
        if (gv.MethPerSec == 0 && gv.MoneyPerSec == 0)
        {
            temp = string.Empty;
        }
        else if (gv.MethPerSec > gv.MethPerSec_Dealer)
        {
            temp = "↑ ";
        }
        else
        {
            temp = "↓ ";
        }
        if(gv.bClickArmy == true)
        {
            temp = "↑ ";
        }
        if (temp != string.Empty)
            TextTotalMeth.text =temp+ gv.ChangeFormat(gv.shortNotation, gv.TotalMeth, "N0");        
        else
            TextTotalMeth.text = gv.ChangeFormat(gv.shortNotation, gv.TotalMeth, "N0");
        Check();
        CheckMethAchivements();
    }
    public void SetTextMoney()
    {
        TextTotalMoney.text = gv.ChangeFormat(gv.shortNotation, gv.TotalMoney, "N0");
        Check();
        MoenyAchivements();
    }
    public void SetTextPurity()
    {
        TextPurity.text = (gv.GetPurity ()* 100).ToString("N0") + " %";
    }
    public void SetText()
    {
        string temp = "";
        if (gv.MethPerSec == 0 && gv.MoneyPerSec == 0)
        {
            temp = string.Empty;
        }
        else if (gv.MethPerSec > gv.MethPerSec_Dealer)
        {
            temp = "↑ ";
        }
        else
        {
            temp = "↓ ";
        }
        if (gv.bClickArmy == true)
        {
            temp = "↑ ";
        }
        if (temp != string.Empty)
            TextTotalMeth.text = temp+ gv.ChangeFormat(gv.shortNotation, gv.TotalMeth, "N0");
        else
            TextTotalMeth.text = gv.ChangeFormat(gv.shortNotation, gv.TotalMeth, "N0");
        TextMethPerSec.text = gv.ChangeFormat(gv.shortNotation, gv.MethPerSec, "N1") + "/ Sec";

        TextTotalMoney.text = gv.ChangeFormat(gv.shortNotation, gv.TotalMoney, "N0");
        TextMoneyPerSec.text = gv.ChangeFormat(gv.shortNotation, gv.MoneyPerSec, "N1") + "/ Sec";

        TextPurity.text = (gv.GetPurity ()* 100).ToString("N0") + " %";
        Check();
        MoenyAchivements();
        CheckMethAchivements();
    }
    void CheckMethAchivements()
    {
        if (gv.TotalMeth > 1000000000000 * gv.scaleFactor && gv.AchivementStatus[17] == 0)
        {
            gv.SetAchivement(17);
            GameObject.Find("GameManager").GetComponent<BottomUIController>().SetNotice(5);
        }
    }
    void MoenyAchivements()
    {
        if (gv.TotalMoney > 1000000 * gv.scaleFactor && gv.AchivementStatus[8] == 0)
        {
            gv.SetAchivement(8);
            GameObject.Find("GameManager").GetComponent<BottomUIController>().SetNotice(5);
        }
        if (gv.TotalMoney > 1000000000 * gv.scaleFactor && gv.AchivementStatus[9] == 0)
        {
            gv.SetAchivement(9);
            GameObject.Find("GameManager").GetComponent<BottomUIController>().SetNotice(5);
        }
        if (gv.TotalMoney > 1000000000000 * gv.scaleFactor && gv.AchivementStatus[10] == 0)
        {
            gv.SetAchivement(10);
            GameObject.Find("GameManager").GetComponent<BottomUIController>().SetNotice(5);
        }

        if (gv.MoneyPerSec > 1000000*gv.scaleFactor && gv.AchivementStatus[11] == 0)
        {
            gv.SetAchivement(11);
            GameObject.Find("GameManager").GetComponent<BottomUIController>().SetNotice(5);
        }
        if (gv.MoneyPerSec > 1000000000 * gv.scaleFactor && gv.AchivementStatus[12] == 0)
        {
            gv.SetAchivement(12);
            GameObject.Find("GameManager").GetComponent<BottomUIController>().SetNotice(5);
        }

    }
    public void IncreaseMoney(double money)
    {
        StartCoroutine(MoneyCountroutine(money));
    }
    public void IncreaseMeth(double Meth)
    {
        StartCoroutine(MethCountroutine(Meth));
    }
    public void DecreaseMeth(double Meth)
    {
        StartCoroutine(DeMethCountroutine(Meth));
    }
    IEnumerator MoneyCountroutine(double money)
    {
        yield return new WaitForSeconds(0.1f);        
        for (double i = gv.TotalMoney; i < gv.TotalMoney +money; i+= money / 50)
        {                        
            TextTotalMoney.text = gv.ChangeFormat(gv.shortNotation, i, "N0");
            yield return new WaitForSeconds(0.001f); //스코어 올라가는 시간 조절             
        }
    }
    IEnumerator MethCountroutine(double money)
    {
        yield return new WaitForSeconds(0.1f);
        string temp = "";
        if (gv.MethPerSec == 0 && gv.MoneyPerSec == 0)
        {
            temp = string.Empty;
        }
        else if (gv.MethPerSec > gv.MethPerSec_Dealer)
        {
            temp = "↑ ";
        }
        else
        {
            temp = "↓ ";
        }
        if (gv.bClickArmy == true)
        {
            temp = "↑ ";
        }
        for (double i = gv.TotalMeth; i < gv.TotalMeth + money; i+= money/50)
        {
            if(temp != string.Empty)
                TextTotalMeth.text = temp +gv.ChangeFormat(gv.shortNotation, i, "N0");
            else
                TextTotalMeth.text = gv.ChangeFormat(gv.shortNotation, i, "N0");
            yield return new WaitForSeconds(.001f); //스코어 올라가는 시간 조절 
        }
    }
    IEnumerator DeMethCountroutine(double money)
    {
        yield return new WaitForSeconds(0.1f);
        string temp = string.Empty;
        if (gv.MethPerSec ==0 && gv.MoneyPerSec ==0)
        {
            temp = string.Empty;
        }
        else if (gv.MethPerSec > gv.MethPerSec_Dealer)
        {
            temp = "↑ ";
        }
        else
        {
            temp = "↓ ";
        }
        if (gv.bClickArmy == true)
        {
            temp = "↑ ";
        }
        for (double i =gv.TotalMeth+money; i > gv.TotalMeth; i-= money /50)
        {
            if (temp != string.Empty)
                TextTotalMeth.text = temp+ gv.ChangeFormat(gv.shortNotation, i, "N0");
            else
                TextTotalMeth.text = gv.ChangeFormat(gv.shortNotation, i, "N0");
            yield return new WaitForSeconds(.001f); //스코어 올라가는 시간 조절 
        }
    }



  
    List<GameObject> MethList = new List<GameObject>();
    List<GameObject> MoneyList = new List<GameObject>();
    void CheckClickAchivement()
    {
        if (gv.TotalClickCount > 1000 && gv.AchivementStatus[0] == 0)
        {
            gv.SetAchivement(0);
            GameObject.Find("GameManager").GetComponent<BottomUIController>().SetNotice(5);
        }
        if (gv.TotalClickCount > 5000 && gv.AchivementStatus[1] == 0)
        {
            gv.SetAchivement(1);
            GameObject.Find("GameManager").GetComponent<BottomUIController>().SetNotice(5);
        }
        if (gv.TotalClickCount > 10000 && gv.AchivementStatus[2] == 0)
        {
            gv.SetAchivement(2);
            GameObject.Find("GameManager").GetComponent<BottomUIController>().SetNotice(5);
        }
    }
    public void ClickMeth()
    {
        GameObject.Find("GameManager").GetComponent<SoundManagerSrc>().StartFx("Meth");
        if (bStartBuff == false)
        {
            ClickPrograssCheck();
        }
        gv.TotalClickCount++;
        PowerClickCount++;
        CheckClickAchivement();
        CheckPowerClickAchivement();
        gv.SaveTotalClickCount();
        clickType = 1;
        MethCheck.SetActive(true);
        MoneyCheck.SetActive(false);
        if (bStartBuff == true)
        {
            gv.TotalMeth += (1 * gv.scaleFactor + (gv.UpgradeStatus[0] * 1 * gv.scaleFactor)) *2;
            gv.endingMeht += (1 * gv.scaleFactor + (gv.UpgradeStatus[0] * 1 * gv.scaleFactor)) * 2;
        }
        else
        {
            gv.TotalMeth += 1 * gv.scaleFactor + (gv.UpgradeStatus[0] * 1 * gv.scaleFactor);
            gv.endingMeht += 1 * gv.scaleFactor + (gv.UpgradeStatus[0] * 1 * gv.scaleFactor);
        }
        if (gv.bStartPotion == true)
        {
            if (gv.potiontype == 1)
            {
                gv.TotalMeth += (1 * gv.scaleFactor + (gv.UpgradeStatus[0] * 1 * gv.scaleFactor))*10;
                gv.endingMeht += (1 * gv.scaleFactor + (gv.UpgradeStatus[0] * 1 * gv.scaleFactor)) * 10;
            }
            if (gv.potiontype == 2)
            {
                gv.TotalMeth += (1 * gv.scaleFactor + (gv.UpgradeStatus[0] * 1 * gv.scaleFactor))*100;
                gv.endingMeht += (1 * gv.scaleFactor + (gv.UpgradeStatus[0] * 1 * gv.scaleFactor)) * 100;
            }
            //x 20
            if (gv.potiontype == 3)
            {
                gv.TotalMeth += (1 * gv.scaleFactor + (gv.UpgradeStatus[0] * 1 * gv.scaleFactor)) * 20;
                gv.endingMeht += (1 * gv.scaleFactor + (gv.UpgradeStatus[0] * 1 * gv.scaleFactor)) * 20;
            }
        }
        gv.SaveEndingMeth();
        gv.SaveTotalMeth();
        SetText();

        Vector3 spawnPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spawnPostion.z = 0;

        GameObject temp = Instantiate(MethEffect, spawnPostion, Quaternion.Euler(new Vector3(0, 0, 0)));
        temp.transform.SetParent(MethEffect.transform.parent);
        temp.transform.localScale = MethEffect.transform.localScale;
        Vector2 pos = new Vector2();
        pos = temp.transform.localPosition;
        pos.x = Random.Range(pos.x - 50, pos.x + 50);
        pos.y = Random.Range(pos.y - 50, pos.y + 50);
        temp.transform.localPosition = pos;
        MethList.Add(temp);
        if(MethList.Count >0)
        {
            MethList[MethList.Count - 1].SetActive(true);
            StartCoroutine(DeleteMethEffect());
        }
    }
    bool bPowerClick = false;
    void CheckPowerClickAchivement()
    {
        if(gv.AchivementStatus[7] ==0 && bPowerClick == false)
        {
            bPowerClick = true;
            PowerClickCount = 0;
            StartCoroutine(PowerClickRoutine());
        }
    }
    IEnumerator PowerClickRoutine()
    {
        yield return new WaitForSeconds(1f);
        if(PowerClickCount >=7)
        {
            gv.SetAchivement(7);
            GameObject.Find("GameManager").GetComponent<BottomUIController>().SetNotice(5);
        }
        bPowerClick = false;
    }
    int PowerClickCount = 0;
    public void ClickMoney()
    {       
        clickType = 2;
        MethCheck.SetActive(false);
        MoneyCheck.SetActive(true);
        if (gv.TotalMeth >0)
        {
            if (bStartBuff == false)
            {
                ClickPrograssCheck();
            }
            gv.TotalClickCount++;
            PowerClickCount++;
            gv.SaveTotalClickCount();
            CheckClickAchivement();
            CheckPowerClickAchivement();
            GameObject.Find("GameManager").GetComponent<SoundManagerSrc>().StartFx("Money");
            gv.TotalMeth -= 1 * gv.scaleFactor;            
            if(gv.TotalMeth <0)
            {
                gv.TotalMeth = 0;
            }
            if(bStartBuff == true)
            {
                gv.TotalMoney += ((gv.GetPurity() * 100) * gv.scaleFactor) * 2 ;
            }
            else
            {
                gv.TotalMoney += (gv.GetPurity() * 100) * gv.scaleFactor;
            }
            if (gv.bStartPotion == true)
            {
                if (gv.potiontype == 1)
                {
                    gv.TotalMoney += ((gv.GetPurity() * 100) * gv.scaleFactor) *10;
                }
                if (gv.potiontype == 2)
                {
                    gv.TotalMoney += ((gv.GetPurity() * 100) * gv.scaleFactor)*100;
                }
                if (gv.potiontype == 3)
                {
                    gv.TotalMoney += ((gv.GetPurity() * 100) * gv.scaleFactor) * 20;
                }
            }            

            gv.SaveTotalMeth();
            gv.SaveTotalMoney();
            //SetTextMoney();
            SetText();
            //IncreaseMoney(2);
            Vector3 spawnPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spawnPostion.z = 0;

            GameObject temp = Instantiate(MoneyEffect, spawnPostion, Quaternion.Euler(new Vector3(0, 0, 0)));
            temp.transform.SetParent(MoneyEffect.transform.parent);
            temp.transform.localScale = MoneyEffect.transform.localScale;

            Vector2 pos = new Vector2();
            pos = temp.transform.localPosition;
            pos.x = Random.Range(pos.x - 50, pos.x + 50);
            pos.y = Random.Range(pos.y - 50, pos.y + 50);
            temp.transform.localPosition = pos;
            MoneyList.Add(temp);
            if(MoneyList.Count >0)
            {
                MoneyList[MoneyList.Count - 1].SetActive(true);
                StartCoroutine(DeleteMoneyEffect());
            }
        }
    }

    IEnumerator DeleteMethEffect()
    {
        yield return new WaitForSeconds(0.5f);
        if (MethList.Count > 0)
        {
            Destroy(MethList[0]);
            MethList.RemoveAt(0);
        }
    }
    IEnumerator DeleteMoneyEffect()
    {
        yield return new WaitForSeconds(0.5f);
        if (MoneyList.Count > 0)
        {
            Destroy(MoneyList[0]);
            MoneyList.RemoveAt(0);
        }
    }
    bool bClick = false;

    public void NoramlClickTop()
    {
        if(bClick ==false)
        {
            if (clickType == 1)
            {
                ClickMeth();
            }
            if (clickType == 2)
            {
                ClickMoney();
            }
            CheckAutoSlave();
            bClick = true;
            StartCoroutine(bClickChage());
        }
    }
    IEnumerator bClickChage()
    {
        yield return new WaitForSeconds(0.05f);
        bClick = false;
    }
    public void CheckAutoSlave()
    {
        List<int> Listcnt = new List<int>();
        if (gv.UpgradeStatus[11] == 1)
        {
            int rand = Random.Range(0, 100);
            if (rand == 1)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (gv.Facilities[i] != 0)
                    {
                        Listcnt.Add(gv.Facilities[i]-1);                        
                    }
                }
                int randf = Random.Range(0, Listcnt.Count);
                this.FacilitiesLIst[Listcnt[randf]].GetComponent<MethWorkersController>().BuySlaveFree();
            }
        }
        Listcnt.Clear();
    }
    public void ClickTop()
    {
        if (clickType == 1)
        {
            ClickMeth();
        }
        if (clickType == 2)
        {
            ClickMoney();
        }
        CheckAutoSlave();
    }

}
