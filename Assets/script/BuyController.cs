using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuyController : MonoBehaviour {

    Globalvariable gv;

    //public string StrName;
    public float cost;
    //public string strInfo;

    public int type;

    //public Text ButtonText;
    public Text CostText;
    //public Text InfoText;


    private void Awake()
    {
        gv = Globalvariable.Instance;
    }
    private void OnEnable()
    {    
        gv.BuyCost[type - 1] = cost;
        InitData();
    }
    void Start () {
        InitData();
        //ButtonText.text = StrName;
        CostText.text = "$ " + gv.ChangeFormat(gv.shortNotation, cost, "N0",0);
        //InfoText.text = strInfo;
        
    }

    bool bCheck = false;
    public void InitData()
    {
        if (gv != null)
        {         
            if(type ==1)
            {          
                if (cost <= gv.TotalMoney)
                {
                    //if (bCheck == false)
                    {
                        this.transform.Find("ButtonBuy/TextBuy").gameObject.SetActive(true);
                        this.transform.Find("ButtonBuy").gameObject.GetComponent<Button>().interactable = true;
                        this.transform.Find("ButtonBuy/FacilityLock").gameObject.SetActive(false);
                        this.transform.Find("TextCost").gameObject.SetActive(true);
                        this.transform.Find("TextInfo").gameObject.SetActive(true);
                        this.transform.Find("FrameBuy").gameObject.SetActive(true);
                        GameObject.Find("GameManager").GetComponent<BottomUIController>().SetNotice(2);
                        bCheck = true;
                    }
                }
                else
                {                   
                    this.transform.Find("ButtonBuy/TextBuy").gameObject.SetActive(true);
                    this.transform.Find("ButtonBuy").gameObject.GetComponent<Button>().interactable = false;
                    this.transform.Find("ButtonBuy/FacilityLock").gameObject.SetActive(false);
                    this.transform.Find("FrameBuy").gameObject.SetActive(true);
                    this.transform.Find("TextCost").gameObject.SetActive(true);
                    this.transform.Find("TextInfo").gameObject.SetActive(true);
                    bCheck = false;                                       
                }
            }
            else
            {
                if (cost <= gv.TotalMoney )
                {
                    //if (bCheck == false)
                    {
                        this.transform.Find("ButtonBuy/TextBuy").gameObject.SetActive(true);
                        this.transform.Find("ButtonBuy").gameObject.GetComponent<Button>().interactable = true;
                        this.transform.Find("ButtonBuy/FacilityLock").gameObject.SetActive(false);
                        this.transform.Find("TextCost").gameObject.SetActive(true);
                        this.transform.Find("TextInfo").gameObject.SetActive(true);
                        this.transform.Find("FrameBuy").gameObject.SetActive(true);
                        GameObject.Find("GameManager").GetComponent<BottomUIController>().SetNotice(2);
                        bCheck = true;
                    }
                    
                }
                else if (cost <= gv.TotalMoney * 10 || gv.BuyViewStatus[type-1] ==1)
                {
                    this.transform.Find("ButtonBuy/TextBuy").gameObject.SetActive(true);
                    this.transform.Find("ButtonBuy").gameObject.GetComponent<Button>().interactable = false;
                    this.transform.Find("ButtonBuy/FacilityLock").gameObject.SetActive(false);
                    this.transform.Find("FrameBuy").gameObject.SetActive(true);
                    this.transform.Find("TextCost").gameObject.SetActive(true);
                    this.transform.Find("TextInfo").gameObject.SetActive(true);
                    gv.BuyViewStatus[type - 1] = 1;
                    gv.SaveBuyViewStatus(type - 1);
                }
                else if(gv.BuyViewStatus[type-1] ==0)
                {
                    this.transform.Find("ButtonBuy/TextBuy").gameObject.SetActive(false);
                    this.transform.Find("ButtonBuy").gameObject.GetComponent<Button>().interactable = false;
                    this.transform.Find("ButtonBuy/FacilityLock").gameObject.SetActive(true);
                    this.transform.Find("FrameBuy").gameObject.SetActive(false);
                    this.transform.Find("TextCost").gameObject.SetActive(false);
                    this.transform.Find("TextInfo").gameObject.SetActive(false);
                    bCheck = false;
                }
            }           
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
    public void Buy()
    {
        bool bOwn = false;
        int FacilityIndex = gv.CheckFacilities(type);
        if(FacilityIndex ==-3)
        {
            bOwn = true;
        }
       
        if (FacilityIndex != -1)
        {
            if (gv.TotalMoney >= this.cost)
            {
                gv.TotalMoney -= this.cost;
                gv.SaveTotalMoney();
                GameObject.Find("GameManager").GetComponent<GameManagerSrc>().ViewNotifiction("BUY");
                GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetText();
                switch (type)
                {
                    case 1:
                        if(FacilityIndex >=0)
                        {
                            gv.Facilities[FacilityIndex] = 1;
                            gv.SaveFacilities(FacilityIndex);
                        }
                        if (gv.googleAchivementList[1] == 0)
                            GameObject.Find("GPGSManager").GetComponent<GPGSManager>().AddAchive(2);
                        break;
                    case 2:
                        if (FacilityIndex >= 0)
                        {
                            gv.Facilities[FacilityIndex] = 2;
                            gv.SaveFacilities(FacilityIndex);
                        }
                        break;
                    case 3:
                        if (FacilityIndex >= 0)
                        {
                            gv.Facilities[FacilityIndex] = 3;
                            gv.SaveFacilities(FacilityIndex);
                        }
                        if (gv.googleAchivementList[3] == 0)
                            GameObject.Find("GPGSManager").GetComponent<GPGSManager>().AddAchive(4);
                        break;
                    case 4:
                        if (FacilityIndex >= 0)
                        {
                            gv.Facilities[FacilityIndex] = 4;
                            gv.SaveFacilities(FacilityIndex);
                        }
                        break;
                    case 5:
                        if (FacilityIndex >= 0)
                        {
                            gv.Facilities[FacilityIndex] = 5;
                            gv.SaveFacilities(FacilityIndex);
                        }
                        if (gv.googleAchivementList[2] == 0)
                            GameObject.Find("GPGSManager").GetComponent<GPGSManager>().AddAchive(3);
                        break;
                    case 6:
                        if (FacilityIndex >= 0)
                        {
                            gv.Facilities[FacilityIndex] = 6;
                            gv.SaveFacilities(FacilityIndex);
                        }
                        GameObject.Find("GPGSManager").GetComponent<GPGSManager>().AddAchive(7);
                        break;
                    case 7:
                        if (FacilityIndex >= 0)
                        {
                            gv.Facilities[FacilityIndex] = 7;
                            gv.SaveFacilities(FacilityIndex);
                        }
                        break;
                    case 8:
                        if (FacilityIndex >= 0)
                        {
                            gv.Facilities[FacilityIndex] = 8;
                            gv.SaveFacilities(FacilityIndex);
                        }
                        if (gv.googleAchivementList[8] == 0)
                            GameObject.Find("GPGSManager").GetComponent<GPGSManager>().AddAchive(9);
                        break;
                    case 9:
                        if (FacilityIndex >= 0)
                        {
                            gv.Facilities[FacilityIndex] = 9;
                            gv.SaveFacilities(FacilityIndex);
                        }
                        break;
                    case 10:
                        if (FacilityIndex >= 0)
                        {
                            gv.Facilities[FacilityIndex] = 10;
                            gv.SaveFacilities(FacilityIndex);
                        }
                        if (gv.googleAchivementList[9] == 0)
                            GameObject.Find("GPGSManager").GetComponent<GPGSManager>().AddAchive(10);
                        break;
                    case 11:
                        if (FacilityIndex >= 0)
                        {
                            gv.Facilities[FacilityIndex] = 11;
                            gv.SaveFacilities(FacilityIndex);
                        }
                        break;
                    case 12:
                        if (FacilityIndex >= 0)
                        {
                            gv.Facilities[FacilityIndex] = 12;
                            gv.SaveFacilities(FacilityIndex);
                        }
                        if (gv.googleAchivementList[11] == 0)
                            GameObject.Find("GPGSManager").GetComponent<GPGSManager>().AddAchive(12);
                        break;
                    case 13:
                        //if (FacilityIndex >= 0)
                        //{
                        //    gv.Facilities[FacilityIndex] = 12;
                        //    gv.SaveFacilities(FacilityIndex);
                        //}
                        //GameObject.Find("GPGSManager").GetComponent<GPGSManager>().AddAchive(13);
                        break;
                }
                gv.FacilityCount[type - 1]++;
                gv.SaveFacilityCount(type - 1);
                gv.BuyStatus[type-1] = 1;
                gv.SaveBuyStatus(type - 1);                
                    
                GameObject.Find("GameManager").GetComponent<BottomUIController>().SetNotice(1);
                GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetFacility(type-1);

                Debug.Log("add");
                Debug.Log("1 = " + gv.Facilities[0] + "   2 = " + gv.Facilities[1] + "   3 = " + gv.Facilities[2] + "   4 = " + gv.Facilities[3]);
            }
            else
            {
                GameObject.Find("GameManager").GetComponent<GameManagerSrc>().ViewNotifiction("Money");
            }
        }
        else
        {
            GameObject.Find("GameManager").GetComponent<GameManagerSrc>().ViewNotifiction("Facility");
        }
    }
}

