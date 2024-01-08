using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MethWorkersController : MonoBehaviour
{

    // Use this for initialization
    public int type;

    public double UpgradeCost;
    public double MaxSlave;
    public double MaxPower;
    public double MaxPurity;
    public int isOneTime;


    public int MaxImageCount;
    //
    public double DefaultSalve;
    Globalvariable gv;
    public Text TotalSlaveCount;
    public Text SellMoney;
    public GameObject SlaveObj;
    public Text BuyButtonText;
    public Text TotalBuyCount;
    double power;
    double TotalPower;
    private void Awake()
    {
        gv = Globalvariable.Instance;
    }
    void Start()
    {
        if (gv.FacilityCount[type - 1] == 1)
        {
        }
        else if (gv.FacilityCount[type - 1] == 0)
        {
            MaxSlave = DefaultSalve;
        }
        else
        {
            MaxSlave = gv.FacilityCount[type - 1] * DefaultSalve;
        }
        SlaveObj.SetActive(false);
        //DefaultSalve = MaxSlave;
        power = (MaxPower * gv.scaleFactor) / (DefaultSalve);
        //Debug.Log(type + "  Power = " + gv.ChangeFormat(gv.shortNotation, power, "N1"));
        TotalPower = (power * gv.SlaveCount[type - 1]);
        //Debug.Log(type + "  Power per sec = " + gv.ChangeFormat(gv.shortNotation, gv.MethPerSec, "N1"));
        //Debug.Log(type + "  Meth Power per Sec= " + gv.ChangeFormat(gv.shortNotation, power * gv.SlaveCount[type - 1], "N1"));
        LoadData();
        InitDealer();

    }
    private void OnEnable()
    {
        StartCoroutine(MethGetRoutine());
        LoadData();
    }
    private void OnDisable()
    {
        StopCoroutine(MethGetRoutine());
    }
    IEnumerator MethGetRoutine()
    {
        yield return new WaitForSeconds(1f);
        if (TotalPower > 0)
        {
            //gv.TotalMeth += TotalPower;
            //double temp = TotalPower  / 10;
            double temp = (power * gv.SlaveCount[type - 1]) / 10;
            for (int i = 0; i < 10; i++)
            {
                if (gv.bStartPotion == true)
                {
                    if (gv.potiontype == 1)
                    {
                        gv.TotalMeth += temp * 10;
                        gv.endingMeht += temp * 10;
                    }
                    if (gv.potiontype == 2)
                    {
                        gv.TotalMeth += temp * 100;
                        gv.endingMeht += temp * 100;
                    }
                    if (gv.potiontype == 3)
                    {
                        gv.TotalMeth += temp * 20;
                        gv.endingMeht += temp * 20;
                    }
                }
                else
                {
                    gv.TotalMeth += temp;
                    gv.endingMeht += temp;
                }

                gv.SaveTotalMeth();
                gv.SaveEndingMeth();
                GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetTextMeth();
                yield return new WaitForSeconds(0.00001f);
            }
        }
        StartCoroutine(MethGetRoutine());
    }
    void InitDealer()
    {
        for (int i = 0; i < gv.SlaveCount[type - 1]; i++)
        {
            if (i < MaxImageCount)
            {
                SetSlave();
            }
        }
    }
    List<GameObject> SlaveImageList = new List<GameObject>();

    void SetSlave()
    {
        GameObject temp = Instantiate(SlaveObj);
        temp.transform.SetParent(SlaveObj.transform.parent);
        temp.transform.localScale = SlaveObj.transform.localScale;
        Vector2 pos = new Vector2();
        pos = temp.transform.localPosition;
        pos.x = Random.Range(-325, 325);
        pos.y = SlaveObj.transform.localPosition.y;

        temp.transform.localPosition = pos;
        SlaveImageList.Add(temp);
        SlaveImageList[SlaveImageList.Count - 1].SetActive(true);
    }
    public void LoadData()
    {
        SellMoney.text = "sell $ " + gv.ChangeFormat(gv.shortNotation, UpgradeCost / 2, "N0",0);
        TotalSlaveCount.text = gv.SlaveCount[type - 1].ToString("N0") + " / " + MaxSlave.ToString("N0");
        TotalBuyCount.text = gv.FacilityCount[type - 1].ToString("N0");
        BuyButtonText.text = "$ " + gv.ChangeFormat(gv.shortNotation, UpgradeCost, "N0",0) + "\nBuy";
        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetText();
    }
    // Update is called once per frame
    void Update()
    {

    }
    bool bSelectSell = false;
    public void SelectFacility()
    {
        if (bSelectSell == false)
        {
            this.transform.Find("BtnSell").gameObject.SetActive(true);
            bSelectSell = true;
        }
        else
        {
            this.transform.Find("BtnSell").gameObject.SetActive(false);
            bSelectSell = false;
        }
    }

    public void BuySlaveFree()
    {
        if (type - 1 < 0)
        {
            return;
        }
        if (gv.SlaveCount[type - 1] < MaxSlave)
        {
            if (type == 5)
            {
                if (gv.SlaveCount[type - 1] >= 50 && gv.AchivementStatus[13] == 0)
                {
                    gv.SetAchivement(13);
                    GameObject.Find("GameManager").GetComponent<BottomUIController>().SetNotice(5);
                }
            }
            gv.SlaveCount[type - 1]++;
            gv.SaveSlaveCount(type - 1);
            if (gv.SlaveCount[type - 1] < MaxImageCount)
            {
                SetSlave();
            }

            TotalSlaveCount.text = gv.SlaveCount[type - 1].ToString("N0") + " / " + MaxSlave.ToString("N0");
            TotalPower += power;
            gv.MethPerSec += power;
            gv.SaveMethPerSec();
            GameObject.Find("GameManager").GetComponent<GameManagerSrc>().CheckPurity();
            GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetText();
            if (type == 3)
                if (gv.googleAchivementList[4] == 0)
                    GameObject.Find("GPGSManager").GetComponent<GPGSManager>().AddAchive(5);
            if (type == 7)
                if (gv.googleAchivementList[5] == 0)
                    GameObject.Find("GPGSManager").GetComponent<GPGSManager>().AddAchive(6);
            if (type == 5)
                if (gv.googleAchivementList[7] == 0)
                    GameObject.Find("GPGSManager").GetComponent<GPGSManager>().AddAchive(8);
        }
    }


    public void BuySlave()
    {
        if(type-1 <0)
        {
            return;
        }
        if (gv.TotalMoney >= UpgradeCost && gv.SlaveCount[type - 1] < MaxSlave)
        {
            if (type == 5)
            {
                if (gv.SlaveCount[type - 1] >= 50 && gv.AchivementStatus[13] == 0)
                {
                    gv.SetAchivement(13);
                    GameObject.Find("GameManager").GetComponent<BottomUIController>().SetNotice(5);
                }
            }
            gv.TotalMoney -= UpgradeCost;
            gv.SaveTotalMoney();
            gv.SlaveCount[type - 1]++;
            gv.SaveSlaveCount(type - 1);
            if (gv.SlaveCount[type - 1] < MaxImageCount)
            {
                SetSlave();
            }

            TotalSlaveCount.text = gv.SlaveCount[type - 1].ToString("N0") + " / " + MaxSlave.ToString("N0");
            TotalPower += power;
            gv.MethPerSec += power;
            gv.SaveMethPerSec();
            GameObject.Find("GameManager").GetComponent<GameManagerSrc>().CheckPurity();
            GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetText();
            if (type == 3)
                if (gv.googleAchivementList[4] == 0)
                    GameObject.Find("GPGSManager").GetComponent<GPGSManager>().AddAchive(5);
            if (type == 7)
                if (gv.googleAchivementList[5] == 0)
                    GameObject.Find("GPGSManager").GetComponent<GPGSManager>().AddAchive(6);
            if (type == 5)
                if (gv.googleAchivementList[7] == 0)
                    GameObject.Find("GPGSManager").GetComponent<GPGSManager>().AddAchive(8);
        }
        else
        {
            if (gv.SlaveCount[type - 1] >= MaxSlave)
                GameObject.Find("GameManager").GetComponent<GameManagerSrc>().ViewNotifiction("NeedFacility");
            if (gv.TotalMoney < UpgradeCost)
                GameObject.Find("GameManager").GetComponent<GameManagerSrc>().ViewNotifiction("Money");

        }
    }
    public void SetAddFacility()
    {
        if (type - 1 < 0)
        {
            return;
        }
        if (gv.FacilityCount[type - 1] == 1)
        {
        }
        else if (gv.FacilityCount[type - 1] == 0)
        {
            MaxSlave = DefaultSalve;
        }
        else
        {
            MaxSlave = gv.FacilityCount[type - 1] * DefaultSalve;
        }
        TotalBuyCount.text = gv.FacilityCount[type - 1].ToString("N0");
        TotalSlaveCount.text = gv.SlaveCount[type - 1].ToString("N0") + " / " + MaxSlave.ToString("N0");
        
    }
    public void SellFacility()
    {
        gv.SelectFacilityindex = type-1;
        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().PressPanelNotification("StatusSell");        
    }
    public void CompleteSell()
    {
        if (type - 1 < 0)
        {
            return;
        }
        for (int i = 0; i < 4; i++)
        {
            if (gv.Facilities[i] == type)
            {
                gv.Facilities[i] = 0;
                gv.SaveFacilities(i);
            }
        }
        Debug.Log("Delete");
        Debug.Log("1 = " + gv.Facilities[0] + "   2 = " + gv.Facilities[1] + "   3 = " + gv.Facilities[2] + "   4 = " + gv.Facilities[3]);


        gv.BuyStatus[type] = 0;
        TotalBuyCount.text = gv.FacilityCount[type - 1].ToString("N0");
        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SellFacility(type - 1);
        DeleteSlave();


        gv.MethPerSec -= TotalPower;
        gv.SaveMethPerSec();
        TotalPower = 0;
        if (gv.MethPerSec < 0)
            gv.MethPerSec = 0;
        gv.FacilityCount[type - 1] = 0;

        gv.SaveFacilityCount(type - 1);
        gv.SlaveCount[type - 1] = 0;
        gv.SaveSlaveCount(type - 1);
        this.transform.Find("BtnSell").gameObject.SetActive(false);
        SetAddFacility();
        gv.TotalMoney += UpgradeCost / 2;
        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetText();

        if (type == 5)
        {
            if (gv.AchivementStatus[14] == 0)
            {
                gv.SetAchivement(14);
                GameObject.Find("GameManager").GetComponent<BottomUIController>().SetNotice(5);
            }
        }
        gv.SaveTotalMoney();

        gv.Purity -= MaxPurity;
        if(gv.Purity <0.2f)
        {
            gv.Purity = 0.2f;
        }
        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().CheckPurity();
        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetTextPurity();
    }
    public void BuyAllSlave()
    {
        if (type - 1 < 0)
        {
            return;
        }
        if (gv.TotalMoney >= (UpgradeCost * (MaxSlave - gv.SlaveCount[type - 1])) && gv.SlaveCount[type - 1] < MaxSlave)
        {
            if (type == 5)
            {
                if (gv.SlaveCount[type - 1] >= 50 && gv.AchivementStatus[13] == 0)
                {
                    gv.SetAchivement(13);
                    GameObject.Find("GameManager").GetComponent<BottomUIController>().SetNotice(5);
                }
            }

            if (SlaveImageList.Count < MaxImageCount)
            {
                for (int i = 0; i < (int)MaxSlave - gv.SlaveCount[type - 1]; i++)
                {
                    if (SlaveImageList.Count < MaxImageCount)
                    {
                        SetSlave();
                    }
                }
            }
            gv.TotalMoney -= (UpgradeCost * (MaxSlave - gv.SlaveCount[type - 1]));
            gv.SaveTotalMoney();
            TotalPower += (power * (MaxSlave - gv.SlaveCount[type - 1]));
            gv.MethPerSec += (power * (MaxSlave - gv.SlaveCount[type - 1]));
            gv.SlaveCount[type - 1] += (int)(MaxSlave - gv.SlaveCount[type - 1]);
            gv.SaveSlaveCount(type - 1);

            TotalSlaveCount.text = gv.SlaveCount[type - 1].ToString("N0") + " / " + MaxSlave.ToString("N0");
         
            gv.SaveMethPerSec();
            GameObject.Find("GameManager").GetComponent<GameManagerSrc>().CheckPurity();
            GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetText();
            if (type == 3)
                if (gv.googleAchivementList[4] == 0)
                    GameObject.Find("GPGSManager").GetComponent<GPGSManager>().AddAchive(5);
            if (type == 7)
                if (gv.googleAchivementList[5] == 0)
                    GameObject.Find("GPGSManager").GetComponent<GPGSManager>().AddAchive(6);
            if (type == 5)
                if (gv.googleAchivementList[7] == 0)
                    GameObject.Find("GPGSManager").GetComponent<GPGSManager>().AddAchive(8);
        }
        else
        {
            if (gv.SlaveCount[type - 1] >= MaxSlave)
                GameObject.Find("GameManager").GetComponent<GameManagerSrc>().ViewNotifiction("NeedFacility");
            if (gv.TotalMoney < (UpgradeCost * (MaxSlave - gv.SlaveCount[type - 1])))
                GameObject.Find("GameManager").GetComponent<GameManagerSrc>().ViewNotifiction("Money");

        }
    }
    public void DeleteSlave()
    {
        for (int i = 0; i < SlaveImageList.Count; i++)
        {
            Destroy(SlaveImageList[i]);
        }
        SlaveImageList.Clear();
    }
}
