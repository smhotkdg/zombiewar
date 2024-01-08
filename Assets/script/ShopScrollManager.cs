using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopScrollManager : MonoBehaviour {

    // Use this for initialization
    public Text AdsText;
    public Button AdsButton;
    public List<Button> InappButtonList;
    public Text NoramlMoney1;
    public Text NoramlMoney_1;
    public Text NormalMoney2;
    public Text NormalMoney_2;

    public Text NormalMeth;
    public Text NormalMeth_1;

    public Text DoubleMeth;
    public Text DoubleMeth_1;

    public Text DoubleMoney1;
    public Text DoubleMoney_1;
    public Text DoubleMoney2;
    public Text DoubleMoney_2;
    Globalvariable gv;
    private void Awake()
    {
        gv = Globalvariable.Instance;
    }
    void Start () {
		
	}
    
    public void InitData()
    {
        for (int i = 0; i < InappButtonList.Count; i++)
        {
            if (gv.isiapp[i] != 0)
            {
                InappButtonList[i].interactable = false;
            }
        }
    }
    void SetMoney()
    {
        double money = GameObject.Find("GameManager").GetComponent<GameManagerSrc>().GetTimeMoney();
        gv.TimeMoney = money;
        NoramlMoney1.text ="+ "+ gv.ChangeFormat(gv.shortNotation, money, "N0",0);
        NoramlMoney_1.text ="<color=red>+</color>\n+ " + gv.ChangeFormat(gv.shortNotation, money, "N0", 0);
        NormalMoney2.text = "+ " + gv.ChangeFormat(gv.shortNotation, money, "N0", 0);
        NormalMoney_2.text = "+ " + gv.ChangeFormat(gv.shortNotation, money, "N0", 0);

        DoubleMoney1.text = "+ " + gv.ChangeFormat(gv.shortNotation, money*2.5, "N0", 0);
        DoubleMoney_1.text = "<color=red>+</color>\n+ " + gv.ChangeFormat(gv.shortNotation, money * 2.5, "N0", 0);
        DoubleMoney2.text = "+ " + gv.ChangeFormat(gv.shortNotation, money * 2.5, "N0", 0);
        DoubleMoney_2.text = "+ " + gv.ChangeFormat(gv.shortNotation, money * 2.5, "N0", 0);


        NormalMeth.text = "+ " + gv.ChangeFormat(gv.shortNotation, money /2, "N0", 0);
        NormalMeth_1.text = "+ " + gv.ChangeFormat(gv.shortNotation, money /2, "N0", 0);

        DoubleMeth.text = "+ " + gv.ChangeFormat(gv.shortNotation, money, "N0", 0);
        DoubleMeth_1.text = "+ " + gv.ChangeFormat(gv.shortNotation, money, "N0", 0);

    }
    private void OnEnable()
    {
        InitData();
        SetMoney();        
    }
    private void FixedUpdate()
    {        
        if(GameObject.Find("GameManager").GetComponent<TimerManager>().SetTimerText("AdsRewardTime_Potion", gv.adsTime) == 1)
        {
            GameObject.Find("GameManager").GetComponent<TimerManager>().SetTimerText("AdsRewardTime_Potion", AdsText, gv.adsTime);
            AdsButton.interactable = false;
        }
        else
        {
            AdsText.text = "Show\nAd";
            AdsButton.interactable = true;
        }  
    }
    

    // Update is called once per frame
    void Update () {
        
	}
}
