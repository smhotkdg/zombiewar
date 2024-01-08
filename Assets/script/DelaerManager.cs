using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DelaerManager : MonoBehaviour {

    // Use this for initialization
    //만들어지는 갯수
    public int MaxDealerCount;
    //
    Globalvariable gv;
    public Text TextDealerInfo;
    public Text TotalDealerCount;
    public Text HirePerSec;
    public GameObject DealerObj;
    public Text BuyButtonText;
    public Text TotalBuyCount;
    List<GameObject> DealerList = new List<GameObject>();
    double defaultDealerPower = 1.7f;
    float MasterDealerPower =1;
    private void Awake()
    {
        gv = Globalvariable.Instance;
    }
    bool bStartRoutine = false;
    void Start () {
        DealerObj.SetActive(false);
        LoadData();
        InitDealer();
        StartCoroutine(SellMethByDealer());

        SetDealerPower();
        SetMaxDealer();
        SetMasterDealerPower();

        if (gv.HireStatus[0] == 1 && bStartRoutine ==false)
        {
            AutoHireStart();
            bStartRoutine = true;
        }        
    }
    public void SetMasterDealerPower()
    {
        if (gv.UpgradeStatus[15] == 1)
        {
            MasterDealerPower += MasterDealerPower * 2;
        }
        if (gv.UpgradeStatus[16] == 1)
        {
            MasterDealerPower += MasterDealerPower * 2;
        }
        if (gv.UpgradeStatus[17] == 1)
        {
            MasterDealerPower += MasterDealerPower * 2;
        }
        if (gv.MasterDealerCount > 0)
        {
            gv.DealrHirePerSec = (3 + ((gv.MasterDealerCount - 1) * (0.3f * MasterDealerPower)));
            HirePerSec.text = "AutoHire " + gv.DealrHirePerSec.ToString("N1") + " / 3sec";
            TotalBuyCount.text = gv.MasterDealerCount.ToString("N1");
        }        
    }
    public void SetDealerPower()
    {
        defaultDealerPower = 1.7f;
        if (gv.UpgradeStatus[2] == 1)
        {
            defaultDealerPower += defaultDealerPower * 0.1f;
        }
        if (gv.UpgradeStatus[8] == 1)
        {
            defaultDealerPower += defaultDealerPower * 0.1f;
        }
        if (gv.UpgradeStatus[9] == 1)
        {
            defaultDealerPower += defaultDealerPower * 0.1f;
        }
        if (gv.UpgradeStatus[10] == 1)
        {
            defaultDealerPower += defaultDealerPower * 0.2f;
        }
        if (gv.UpgradeStatus[12] == 1)
        {
            defaultDealerPower += defaultDealerPower * 0.3f;
        }
        double temp = 0;
        temp = gv.TotalDealer * (gv.GetPurity() * 10) * defaultDealerPower * gv.scaleFactor;
        //if(gv.HireStatus[1] >0)
        //{
        //    gv.MoneyPerSec = temp + (temp * (gv.HireStatus[1] * 0.1f));
        //}
        //else
        {
            gv.MoneyPerSec = temp;
        }
        gv.SaveMoneyPerSec();
        
        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetText();
    }
    public void SetMaxDealer()
    {
        if(gv.UpgradeStatus[1] ==1)
        {
            gv.MaxDealer = 4000;
        }
        if (gv.UpgradeStatus[3] == 1)
        {
            gv.MaxDealer = 500000;
        }
        if (gv.UpgradeStatus[4] == 1)
        {
            gv.MaxDealer = 500000000;
        }
        if (gv.UpgradeStatus[13] == 1)
        {
            gv.MaxDealer = 99999999999999;
        }
        TotalDealerCount.text = gv.TotalDealer.ToString("N0") + " / " + gv.MaxDealer.ToString("N0");

    }
    IEnumerator SellMethByDealer()
    {
        yield return new WaitForSeconds(1f);
        if (bClick == false)
        {
            double dealerPower = gv.TotalDealer * gv.scaleFactor;
            if (gv.TotalDealer > 0)
            {
                if (gv.TotalMeth > dealerPower)
                {
                    double tempMeth = (dealerPower / 30) / defaultDealerPower;
                    double tempMeth_Dealer = (dealerPower) / defaultDealerPower;
                    gv.MethPerDeSec = dealerPower / defaultDealerPower;
                    gv.MethPerSec_Dealer = (dealerPower) / defaultDealerPower;
                    double temp = dealerPower * (gv.GetPurity() * 10) * defaultDealerPower / 30;
                    //temp += (temp * (gv.HireStatus[1]*0.1f));
                    for (int i = 0; i < 30; i++)
                    {
                        if (gv.bStartPotion == true)
                        {
                            if (gv.potiontype == 1)
                            {
                                gv.TotalMoney += temp * 10;
                            }
                            if (gv.potiontype == 2)
                            {
                                gv.TotalMoney += temp * 100;
                            }
                            if (gv.potiontype == 3)
                            {
                                gv.TotalMoney += temp * 20;
                            }
                        }
                        else
                        {
                            gv.TotalMoney += temp;
                        }
                        gv.TotalMeth -= tempMeth;
                        gv.SaveTotalMeth();
                        gv.SaveTotalMoney();
                        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetText();
                        yield return new WaitForSeconds(0.00001f);
                    }
                }
                else
                {
                    if (gv.TotalMeth > 0)
                    {
                        double tempMeth = (dealerPower) / defaultDealerPower;
                        double tempMeth_Dealer = (dealerPower) / defaultDealerPower;
                        gv.MethPerDeSec = dealerPower / defaultDealerPower;
                        gv.MethPerSec_Dealer = (dealerPower) / defaultDealerPower;
                        double temp = dealerPower * (gv.GetPurity() * 10) * defaultDealerPower;

                        dealerPower = gv.TotalMeth;
                        gv.TotalMoney += temp;
                        gv.SaveTotalMoney();
                        gv.TotalMeth -= tempMeth;
                        if (gv.TotalMeth < 0)
                            gv.TotalMeth = 0;
                        gv.SaveTotalMeth();
                        gv.SaveTotalMoney();
                        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetText();
                    }
                }
            }
        }
        StartCoroutine(SellMethByDealer());
    }
    void InitDealer()
    {
        for (int i = 0; i < gv.TotalDealer; i++)
        {
            if (i < MaxDealerCount)
            {
                SetDealer();
            }
        }
    }
    void SetDealer()
    {
        GameObject temp = Instantiate(DealerObj);
        temp.transform.SetParent(DealerObj.transform.parent);
        temp.transform.localScale = DealerObj.transform.localScale;
        Vector2 pos = new Vector2();
        pos = temp.transform.localPosition;
        pos.x = Random.Range(-325, 325);
        pos.y = DealerObj.transform.localPosition.y;

        temp.transform.localPosition = pos;
        DealerList.Add(temp);
        DealerList[DealerList.Count - 1].SetActive(true);
    }
    void LoadData()
    {
        TextDealerInfo.text ="$ "+ gv.ChangeFormat(gv.shortNotation, gv.DealerCost, "N0");
     
        HirePerSec.text = "AutoHire "+gv.DealrHirePerSec.ToString("N0") +" / 3sec";        
        TotalDealerCount.text = gv.TotalDealer.ToString("N0") + " / " + gv.MaxDealer.ToString("N0");

        double temp = 0;
        temp = gv.TotalDealer * (gv.GetPurity() * 10) * defaultDealerPower * gv.scaleFactor;
        //if (gv.HireStatus[1] > 0)
        //{
        //    gv.MoneyPerSec = temp + (temp * (gv.HireStatus[1] * 0.1f));
        //}
        //else
        {
            gv.MoneyPerSec = temp;
        }    
        BuyButtonText.text = "$ "+gv.ChangeFormat(gv.shortNotation, gv.DealerCost, "N0") + "\nBuy";
        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetText();
        gv.SaveMoneyPerSec();
    }
	// Update is called once per frame
    public void SetPurityData()
    {

        double temp = 0;
        temp = gv.TotalDealer * (gv.GetPurity() * 10) * defaultDealerPower * gv.scaleFactor;
        //if (gv.HireStatus[1] > 0)
        //{
        //    gv.MoneyPerSec = temp + (temp * (gv.HireStatus[1] * 0.1f));
        //}
        //else
        {
            gv.MoneyPerSec = temp;
        }
     
        gv.SaveMoneyPerSec();        
    }
	void Update () {
		
	}
    public void BuyDealer()
    {
        if(gv.TotalMoney >= gv.DealerCost && gv.TotalDealer < gv.MaxDealer)
        {
            gv.TotalMoney -= gv.DealerCost;
            gv.TotalDealer++;
            gv.SaveTotalDealer();
            CheckAchivements();
            if (gv.TotalDealer < MaxDealerCount)
            {
                SetDealer();              
            }

            TotalDealerCount.text = gv.TotalDealer.ToString("N0") + " / " + gv.MaxDealer.ToString("N0");

            double temp = 0;
            temp = gv.TotalDealer * (gv.GetPurity() * 10) * defaultDealerPower * gv.scaleFactor;
            //if (gv.HireStatus[1] > 0)
            //{
            //    gv.MoneyPerSec = temp + (temp * (gv.HireStatus[1] * 0.1f));
            //}
            //else
            {
                gv.MoneyPerSec = temp;
            }
         
            gv.SaveMoneyPerSec();
            GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetText();
            if(gv.googleAchivementList[0] ==0)
                GameObject.Find("GPGSManager").GetComponent<GPGSManager>().AddAchive(1);
        }
        else
        {
            GameObject.Find("GameManager").GetComponent<GameManagerSrc>().ViewNotifiction("Money");
        }
    }

    public void AutoHireStart()
    {
        gv.DealrHirePerSec = (3 + ((gv.MasterDealerCount - 1) * (0.3f*MasterDealerPower))); 
        HirePerSec.text = "AutoHire " + gv.DealrHirePerSec.ToString("N1") + " / 3sec";
        TotalBuyCount.text = gv.MasterDealerCount.ToString("N1");
        if (bStartRoutine == false)
        {
            StartCoroutine(AutoHireDealer());
            bStartRoutine = true;
        }
    }
    void CheckAchivements()
    {
        if (gv.AchivementStatus[18] == 0 && gv.TotalDealer >=320000000)
        {
            gv.SetAchivement(18);
            GameObject.Find("GameManager").GetComponent<BottomUIController>().SetNotice(5);
        }
    }
    IEnumerator AutoHireDealer()
    {
        yield return new WaitForSeconds(3);
                
        if (gv.TotalMoney >= gv.DealerCost && gv.TotalDealer < gv.MaxDealer)
        {
            gv.TotalDealer += (3 + ((gv.MasterDealerCount - 1) * (0.3f * MasterDealerPower)));
            gv.SaveTotalDealer();
            gv.DealrHirePerSec = (3 + ((gv.MasterDealerCount - 1) * (0.3f * MasterDealerPower)));
            if (DealerList.Count < MaxDealerCount)
            {
                SetDealer();
            }
            if(gv.TotalDealer > gv.MaxDealer)
            {
                gv.TotalDealer = (float)gv.MaxDealer;
            }
            TotalDealerCount.text = gv.TotalDealer.ToString("N0") + " / " + gv.MaxDealer.ToString("N0");

            double temp = 0;
            temp = gv.TotalDealer * (gv.GetPurity() * 10) * defaultDealerPower * gv.scaleFactor;
            //if (gv.HireStatus[1] > 0)
            //{
            //    gv.MoneyPerSec = temp + (temp * (gv.HireStatus[1] * 0.1f));
            //}
            //else
            {
                gv.MoneyPerSec = temp;
            }

            gv.SaveMoneyPerSec();
            GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetText();
            CheckAchivements();
        }
        StartCoroutine(AutoHireDealer());
    }

    bool bClick = false;
    public void ClickStop()
    {
        if(gv.HireStatus[1] >0)
        {
            if(bClick == false)
            {
                //set Stop                
                bClick = true;
                gv.bClickArmy = true;
                this.transform.Find("BGStop").gameObject.SetActive(true);
            }
            else
            {
                //set Play                
                bClick = false;
                gv.bClickArmy = false;
                this.transform.Find("BGStop").gameObject.SetActive(false);
            }
        }
    }  
}
