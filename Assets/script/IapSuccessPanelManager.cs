using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IapSuccessPanelManager : MonoBehaviour {

    // Use this for initialization
    public List<GameObject> IapItmelist;
    Globalvariable gv;

    public Text NormalMoney1;
    public Text NormalMoney2;

    public Text doubleMoney1;
    public Text doubleMoney2;

    public Text NormalMeth;
    public Text doubleMeth;
    private void Awake()
    {
        gv = Globalvariable.Instance;
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void SetText()
    {
        NormalMoney1.text = gv.ChangeFormat(gv.shortNotation, gv.TimeMoney, "N0", 0);
        NormalMoney2.text = gv.ChangeFormat(gv.shortNotation, gv.TimeMoney, "N0", 0);
        doubleMoney1.text = gv.ChangeFormat(gv.shortNotation, gv.TimeMoney*2.5, "N0", 0);
        doubleMoney2.text = gv.ChangeFormat(gv.shortNotation, gv.TimeMoney*2.5, "N0", 0);
        NormalMeth.text = gv.ChangeFormat(gv.shortNotation, gv.TimeMoney/2, "N0", 0);
        doubleMeth.text = gv.ChangeFormat(gv.shortNotation, gv.TimeMoney, "N0", 0);
    }
    private void OnEnable()
    {
        if(gv.IapType !=0)
        {
            if(gv.TimeMoney ==0)
            {
                double money = GameObject.Find("GameManager").GetComponent<GameManagerSrc>().GetTimeMoney();
                gv.TimeMoney = money;
            }

            SetText();
            IapItmelist[gv.IapType - 1].SetActive(true);
        }
    }
    private void OnDisable()
    {
        for(int i=0; i< IapItmelist.Count; i++)
        {
            IapItmelist[i].SetActive(false);
        }
        gv.IapType = 0;
    }
}
