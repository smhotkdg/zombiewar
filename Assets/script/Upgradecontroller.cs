using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Upgradecontroller : MonoBehaviour {

    Globalvariable gv;

    //public string StrName;
    public float cost;
    //public string strInfo;
    public int Probablility;
    public int type;

    //public Text ButtonText;
    public Text CostText;
    //public Text InfoText;
    public Text ProbablilityText;

    Color OrColor = new Color();
    Color UnColor = new Color();
    string defaultTouchStr;
    private void Awake()
    {
        gv = Globalvariable.Instance;
    }
    void Start () {

        if (this.cost < gv.TotalMeth)
        {
            InitData();
        }

        InitData();
        //ButtonText.text = StrName;
        CostText.text = gv.ChangeFormat(gv.shortNotation,cost,"N0",0)+ " g";
        //InfoText.text = strInfo;
        ProbablilityText.text = Probablility.ToString("N0") +" %";

    }
    private void OnEnable()
    {
        gv.UpgradeCost[type - 1] = cost;
        InitData();
        if (type == 1)
            this.transform.Find("TextCount").gameObject.GetComponent<Text>().text = "+ 2";

    }
    public void InitData()
    {   
        if(gv !=null)
        {
          
            if (gv.UpgradeStatus[type - 1] > 0)
            {
                OrColor.r = this.transform.Find("ButtonBuy").gameObject.GetComponent<Image>().color.r;
                OrColor.g = this.transform.Find("ButtonBuy").gameObject.GetComponent<Image>().color.g;
                OrColor.b = this.transform.Find("ButtonBuy").gameObject.GetComponent<Image>().color.b;
                OrColor.a = 1;

                this.transform.Find("ButtonBuy/TextBuy").gameObject.SetActive(true);
                this.transform.Find("ButtonBuy").gameObject.GetComponent<Button>().interactable = false;
                this.transform.Find("ButtonBuy").gameObject.GetComponent<Image>().color = OrColor;
                this.transform.Find("ButtonBuy/Lock").gameObject.SetActive(false);
                this.transform.Find("TextCost").gameObject.SetActive(true);
                this.transform.Find("TextInfo").gameObject.SetActive(true);
                this.transform.Find("ButtonBuy/TextProbability").gameObject.SetActive(true);
                this.transform.Find("Icon").gameObject.SetActive(true);
                this.transform.Find("UpgradeStamp").gameObject.SetActive(true);
                if(type ==1)
                    this.transform.Find("TextCount").gameObject.SetActive(true);
                return;
            }
            if (cost <= gv.TotalMeth)
            {
                OrColor.r = this.transform.Find("ButtonBuy").gameObject.GetComponent<Image>().color.r;
                OrColor.g = this.transform.Find("ButtonBuy").gameObject.GetComponent<Image>().color.g;
                OrColor.b = this.transform.Find("ButtonBuy").gameObject.GetComponent<Image>().color.b;
                OrColor.a = 1;

                this.transform.Find("ButtonBuy/TextBuy").gameObject.SetActive(true);
                this.transform.Find("ButtonBuy").gameObject.GetComponent<Button>().interactable = true;
                this.transform.Find("ButtonBuy").gameObject.GetComponent<Image>().color = OrColor;
                this.transform.Find("ButtonBuy/Lock").gameObject.SetActive(false);
                this.transform.Find("TextCost").gameObject.SetActive(true);
                this.transform.Find("TextInfo").gameObject.SetActive(true);
                this.transform.Find("ButtonBuy/TextProbability").gameObject.SetActive(true);
                this.transform.Find("Icon").gameObject.SetActive(true);
                if (type == 1)
                    this.transform.Find("TextCount").gameObject.SetActive(true);
            }
            else if(cost/2 <= gv.TotalMeth || gv.UpgradeViewStatus[type-1] ==1)
            {
                OrColor.r = this.transform.Find("ButtonBuy").gameObject.GetComponent<Image>().color.r;
                OrColor.g = this.transform.Find("ButtonBuy").gameObject.GetComponent<Image>().color.g;
                OrColor.b = this.transform.Find("ButtonBuy").gameObject.GetComponent<Image>().color.b;
                OrColor.a = 1;

                this.transform.Find("ButtonBuy/TextBuy").gameObject.SetActive(true);
                this.transform.Find("ButtonBuy").gameObject.GetComponent<Button>().interactable = false;
                this.transform.Find("ButtonBuy").gameObject.GetComponent<Image>().color = OrColor;
                this.transform.Find("ButtonBuy/Lock").gameObject.SetActive(false);
                this.transform.Find("TextCost").gameObject.SetActive(true);
                this.transform.Find("TextInfo").gameObject.SetActive(true);
                this.transform.Find("ButtonBuy/TextProbability").gameObject.SetActive(true);
                this.transform.Find("Icon").gameObject.SetActive(true);
                if (type == 1)
                    this.transform.Find("TextCount").gameObject.SetActive(true);
                gv.UpgradeViewStatus[type - 1] = 1;
                gv.SaveUpgradeViewStatus(type - 1);
            }
            else if(gv.UpgradeViewStatus[type-1] ==0)
            {

                UnColor.r = this.transform.Find("ButtonBuy").gameObject.GetComponent<Image>().color.r;
                UnColor.g = this.transform.Find("ButtonBuy").gameObject.GetComponent<Image>().color.g;
                UnColor.b = this.transform.Find("ButtonBuy").gameObject.GetComponent<Image>().color.b;

                UnColor.a = 0;

                this.transform.Find("ButtonBuy/TextBuy").gameObject.SetActive(false);
                this.transform.Find("ButtonBuy").gameObject.GetComponent<Button>().interactable = false;
                this.transform.Find("ButtonBuy").gameObject.GetComponent<Image>().color = UnColor;
                this.transform.Find("ButtonBuy/Lock").gameObject.SetActive(true);
                this.transform.Find("TextCost").gameObject.SetActive(false);
                this.transform.Find("TextInfo").gameObject.SetActive(false);
                this.transform.Find("ButtonBuy/TextProbability").gameObject.SetActive(false);
                this.transform.Find("Icon").gameObject.SetActive(false);
                if (type == 1)
                    this.transform.Find("TextCount").gameObject.SetActive(false);
            }            
        }
       
    }

    // Update is called once per frame
    void Update () {
		
	}
    bool CheckUpgrade()
    {
        int random = Random.Range(0, 100);
        if(random < Probablility)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Upgrade()
    {
        if (gv.TotalMeth >= this.cost)
        {
            gv.TotalMeth -= this.cost;
            gv.SaveTotalMeth();
            if (CheckUpgrade())
            {
                gv.UpgradeStatus[type - 1] = 1;
                gv.SaveUpgradeStatus(type - 1);
                switch (type)
                {
                    case 1:
                        //클릭당 백신 *2
                        break;
                    case 2:
                        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetMaxDealer();
                        //최대 딜러수 증가 +4000
                        break;
                    case 3:
                        //딜러 판매 효율 +10%
                        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetDealerPower();
                        break;
                    case 4:
                        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetMaxDealer();
                        //최대 딜러수 증가 500,000
                        break;
                    case 5:
                        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetMaxDealer();
                        //최대 딜러수 증가
                        //500,000,000
                        break;
                    case 6:
                        //백신 순도 +5%
                        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().AddPurity();
                        break;
                    case 7:
                        //백신 순도 +5%
                        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().AddPurity();
                        break;
                    case 8:
                        //백신 순도 +5%
                        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().AddPurity();
                        break;
                    case 9:
                        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetDealerPower();
                        //딜러판매 효율 +10%
                        break;
                    case 10:
                        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetDealerPower();
                        //딜러판매 효율 +10%
                        break;
                    case 11:
                        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetDealerPower();
                        //딜러판매 효율 +20%
                        break;
                    case 12:
                        //????
                        //백신 클릭당 요리 +1%
                        break;
                    case 13:
                        //딜러 판매 효율 +30%
                        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetDealerPower();
                        break;
                    case 14:
                        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetMaxDealer();
                        //최대 딜러수 증가
                        //99,999,999,999,999                    
                        break;
                    case 15:
                        //백신 순도 +100%        
                        gv.Purity = 1;
                        gv.SavePurity();
                        break;
                    case 16:
                        //마스터 딜러 능력 *2                    
                        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetMasterDealerPower();
                        break;
                    case 17:
                        //마스터 딜러 능력 *2
                        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetMasterDealerPower();
                        break;
                    case 18:
                        //마스터 딜러 능력 *2
                        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetMasterDealerPower();
                        break;
                    case 19:
                        //kill
                        break;
                    case 20:
                        //ending
                        break;
                }
                GameObject.Find("GameManager").GetComponent<GameManagerSrc>().ViewNotifiction("UpgradeSuccess");
                GameObject.Find("GameManager").GetComponent<SoundManagerSrc>().StartFx("UpgradeSuccess");
            }
            else
            {
                GameObject.Find("GameManager").GetComponent<GameManagerSrc>().ViewNotifiction("Upgradefailure");
                GameObject.Find("GameManager").GetComponent<SoundManagerSrc>().StartFx("UpgradeFail");
            }
            GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetTextMeth();
        }
        else
        {
            GameObject.Find("GameManager").GetComponent<GameManagerSrc>().ViewNotifiction("Meth");
        }
    }
}
