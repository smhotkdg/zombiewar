using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HireContoller : MonoBehaviour {

    Globalvariable gv;

    //public string StrName;
    public float cost;
    //public string strInfo;

    public int type;

    //public Text ButtonText;
    public Text CostText;
    public int NeedAchivementCount;
    //public Text InfoText;

    Color OrColor = new Color();
    Color UnColor = new Color();


    private void Awake()
    {
        gv = Globalvariable.Instance;
    }
    void Start () {        

    }
    private void OnEnable()
    {
        InitData();
        //ButtonText.text = StrName;
        CostText.text = "$ " + gv.ChangeFormat(gv.shortNotation, cost, "N0",0);
        //InfoText.text = strInfo;

        if (gv.GetAchivementCount() >= NeedAchivementCount)
        {            
            SetEnableView();
        }
        gv.HireCost[type - 1] = cost;

        setHireCount();
    }

    void setHireCount()
    {
        if (type == 1)
        {
            if (type == 1)
                this.transform.Find("TextHireCount").gameObject.GetComponent<Text>().text = gv.MasterDealerCount.ToString("N0");       
        }
    }
    public void SetEnableView()
    {
        if (cost <= gv.TotalMoney)
        {
            if(type >1 && gv.HireStatus[type-1] >0)
            {
                OrColor.r = this.transform.Find("ButtonBuy").gameObject.GetComponent<Image>().color.r;
                OrColor.g = this.transform.Find("ButtonBuy").gameObject.GetComponent<Image>().color.g;
                OrColor.b = this.transform.Find("ButtonBuy").gameObject.GetComponent<Image>().color.b;
                OrColor.a = 1;

                this.transform.Find("ButtonBuy/TextBuy").gameObject.SetActive(true);
                this.transform.Find("ButtonBuy").gameObject.GetComponent<Button>().interactable = false;
                this.transform.Find("ButtonBuy").gameObject.GetComponent<Image>().color = OrColor;
                this.transform.Find("ButtonBuy/Lock").gameObject.SetActive(false);
                this.transform.Find("FrameHire").gameObject.SetActive(true);
                this.transform.Find("TextCost").gameObject.SetActive(true);
                this.transform.Find("TextInfo").gameObject.SetActive(true);
                if (type == 1)
                {
                    this.transform.Find("TextHireCount").gameObject.SetActive(true);
                }
            }
            else
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
                this.transform.Find("FrameHire").gameObject.SetActive(true);
                this.transform.Find("TextInfo").gameObject.SetActive(true);
                GameObject.Find("GameManager").GetComponent<BottomUIController>().SetNotice(3);
                if (type == 1 )
                {
                    this.transform.Find("TextHireCount").gameObject.SetActive(true);
                }
            }  
        }     
        else
        {
            OrColor.r = this.transform.Find("ButtonBuy").gameObject.GetComponent<Image>().color.r;
            OrColor.g = this.transform.Find("ButtonBuy").gameObject.GetComponent<Image>().color.g;
            OrColor.b = this.transform.Find("ButtonBuy").gameObject.GetComponent<Image>().color.b;
            OrColor.a = 1;

            this.transform.Find("ButtonBuy/TextBuy").gameObject.SetActive(true);
            this.transform.Find("ButtonBuy").gameObject.GetComponent<Button>().interactable = false;
            this.transform.Find("ButtonBuy").gameObject.GetComponent<Image>().color = OrColor;
            this.transform.Find("ButtonBuy/Lock").gameObject.SetActive(false);
            this.transform.Find("FrameHire").gameObject.SetActive(true);
            this.transform.Find("TextCost").gameObject.SetActive(true);
            this.transform.Find("TextInfo").gameObject.SetActive(true);
            if (type == 1 )
            {
                this.transform.Find("TextHireCount").gameObject.SetActive(true);
            }
        }
    }
    public void InitData()
    {
        if(gv != null)
        {         
            if (gv.HireStatus[type - 1] == 0)
            {

                UnColor.r = this.transform.Find("ButtonBuy").gameObject.GetComponent<Image>().color.r;
                UnColor.g = this.transform.Find("ButtonBuy").gameObject.GetComponent<Image>().color.g;
                UnColor.b = this.transform.Find("ButtonBuy").gameObject.GetComponent<Image>().color.b;
                UnColor.a = 0;

                this.transform.Find("ButtonBuy/TextBuy").gameObject.SetActive(false);
                this.transform.Find("ButtonBuy").gameObject.GetComponent<Button>().interactable = false;
                this.transform.Find("ButtonBuy").gameObject.GetComponent<Image>().color = UnColor;
                this.transform.Find("ButtonBuy/Lock").gameObject.SetActive(true);
                this.transform.Find("FrameHire").gameObject.SetActive(false);
                this.transform.Find("TextCost").gameObject.SetActive(false);
                this.transform.Find("TextInfo").gameObject.SetActive(false);
                if (type == 1 )
                {
                    this.transform.Find("TextHireCount").gameObject.SetActive(false);
                }
            }
            if (gv.GetAchivementCount() >= NeedAchivementCount)
            {
                SetEnableView();
            }
        }      
    }

    // Update is called once per frame
    void Update () {
		
	}
    public void Hire()
    {
        if(gv.TotalMoney >= this.cost)
        {
            gv.TotalMoney -= this.cost;
            gv.SaveTotalMoney();
            GameObject.Find("GameManager").GetComponent<GameManagerSrc>().ViewNotifiction("BUY");
            switch (type)
            {
                case 1:
                    gv.HireStatus[0] = 1;                    
                    gv.MasterDealerCount++;
                    gv.SaveHireStatus(0);
                    gv.SaveMasterDealerCount();
                    GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetHireView(0);
                    if (gv.googleAchivementList[17] == 0)
                        GameObject.Find("GPGSManager").GetComponent<GPGSManager>().AddAchive(18);
                    setHireCount();
                    break;
                case 2:
                    gv.HireStatus[1] = 1;
                    gv.SaveHireStatus(1);      
                    GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetHireArmy();
                    GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetHireView(1);                    
                    setHireCount();
                    break;
                case 3:
                    gv.HireStatus[2] = 1;
                    gv.SaveHireStatus(2);
                    GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetHireView(2);
                    if (gv.googleAchivementList[18] == 0)
                        GameObject.Find("GPGSManager").GetComponent<GPGSManager>().AddAchive(19);
                    break;
                case 4:
                    gv.HireStatus[3] = 1;
                    gv.SaveHireStatus(3);
                    GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetHireView(3);
                    if (gv.googleAchivementList[19] == 0)
                        GameObject.Find("GPGSManager").GetComponent<GPGSManager>().AddAchive(20);
                    break;
                case 5:
                    gv.HireStatus[4] = 1;
                    gv.SaveHireStatus(4);
                    GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetChef();
                    GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetHireView(4);                    
                    break;
            }
            GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetTextMoney();
        }
        else
        {
            GameObject.Find("GameManager").GetComponent<GameManagerSrc>().ViewNotifiction("Money");
        }
    }
}
