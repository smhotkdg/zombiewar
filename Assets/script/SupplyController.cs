using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyController : MonoBehaviour {

    // Use this for initialization
    public GameObject Supply1;
    public GameObject Supply2;
    Globalvariable gv;

    private void Awake()
    {
        gv = Globalvariable.Instance;
    }
    void Start () {
        gv.adsRewardMoeny = 0;
        gv.adsRewardMeth = 0;
        StartCoroutine(SupplyCorutine());
	}
    bool bStart = false;
    IEnumerator SupplyCorutine()
    {
        yield return new WaitForSeconds(5);
        int rand = Random.Range(0, 20);
        if(rand==1)
        //if (rand <= 20)
        {
            int pos = Random.Range(0, 3);
            switch (pos)
            {
                case 0:
                    Supply1.SetActive(true);
                    break;
                case 1:
                    Supply1.SetActive(true);
                    break;
                case 2:
                    Supply2.SetActive(true);
                    break;
            }

        }
        else
        {
            gv.adsRewardType = 0;
            StartCoroutine(SupplyCorutine());
        }
    }
    public void PressSupply(int i)
    {
        switch(i)
        {
            case 1:
                int rand = Random.Range(0, 2);
                if(rand ==1)
                {
                    SetSupplyMeth();
                }
                else
                {
                    SetSupplyMoney();
                }
                Supply1.SetActive(false);
                break;
            case 2:
                SetSupplyBuff();
                Supply2.SetActive(false);
                break;
        }
        StartCoroutine(SupplyCorutine());
    }
    void SetSupplyMeth()
    {
        gv.adsRewardType = 1;
        gv.adsRewardMoeny = gv.MoneyPerSec * 50;
        string money = gv.ChangeFormat(gv.shortNotation, gv.adsRewardMoeny, "N0");
        string money2 = gv.ChangeFormat(gv.shortNotation, gv.adsRewardMoeny*20, "N0");
        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().PressPanelNotification("Supply1",1, money,money2);
    }
    void SetSupplyMoney()
    {
        gv.adsRewardType = 2;
        gv.adsRewardMeth = gv.MethPerSec * 50;
        string money = gv.ChangeFormat(gv.shortNotation, gv.adsRewardMeth, "N0");
        string money2 = gv.ChangeFormat(gv.shortNotation, gv.adsRewardMeth * 20, "N0");
        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().PressPanelNotification("Supply1", 2, money, money2);
    }
    void SetSupplyBuff()
    {
        gv.adsRewardType = 3;
        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().PressPanelNotification("Supply2");
    }
}
