using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BottomUIController : MonoBehaviour {

    // Use this for initialization
    Globalvariable gv;
    public GameObject Status;
    public GameObject Buy;
    public GameObject Hire;
    public GameObject Upgrade;
    public GameObject Achivement;
    public GameObject Shop;

    public GameObject ScrollStatus;
    public GameObject ScrollBuy;
    public GameObject ScrollHire;
    public GameObject ScrollUpgrade;
    public GameObject ScrollAchivemnt;
    public GameObject ScrollShop;
    Color DefaultColor = new Color();
    Color UnselectColor = new Color();
    Vector2 StatusVec = new Vector2();

    private void Awake()
    {
        gv = Globalvariable.Instance;
        Color ButtonColor = Status.GetComponent<Image>().color;

        DefaultColor.r = ButtonColor.r; DefaultColor.g = ButtonColor.g; DefaultColor.b = ButtonColor.b; DefaultColor.a = 0.4f;
        UnselectColor.r = ButtonColor.r; UnselectColor.g = ButtonColor.g; UnselectColor.b = ButtonColor.b; UnselectColor.a = 1f;
        StatusVec.x = 900;
        StatusVec.y = 0;
    }
    void Start () {
        Status.GetComponent<Image>().color = DefaultColor;
        Buy.GetComponent<Image>().color = UnselectColor;
        Hire.GetComponent<Image>().color = UnselectColor;
        Upgrade.GetComponent<Image>().color = UnselectColor;
        Achivement.GetComponent<Image>().color = UnselectColor;
        Shop.GetComponent<Image>().color = UnselectColor;


        ScrollStatus.SetActive(true);
        ScrollBuy.SetActive(true);
        ScrollHire.SetActive(true);
        ScrollUpgrade.SetActive(true);
        ScrollAchivemnt.SetActive(true);



        //for (int i = 0; i < gv.UpgradeCost.Count; i++)
        //{
        //    Debug.Log("Upgrade Cost = " + gv.ChangeFormat(gv.shortNotation, gv.UpgradeCost[i], "N0"));
        //}
        //for (int i = 0; i < gv.HireCost.Count; i++)
        //{
        //    Debug.Log("Hire Cost = " + gv.ChangeFormat(gv.shortNotation, gv.HireCost[i], "N0"));
        //}
        //for (int i = 0; i < gv.BuyCost.Count; i++)
        //{
        //    Debug.Log("Buy Cost = " + gv.ChangeFormat(gv.shortNotation, gv.BuyCost[i], "N0"));
        //}



        ScrollBuy.SetActive(false);
        ScrollHire.SetActive(false);
        ScrollUpgrade.SetActive(false);
        ScrollAchivemnt.SetActive(false);
        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().Check();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetNotice(int i)
    {
        switch(i)
        {
            case 1:
                Status.transform.Find("Notice").gameObject.SetActive(true);             
                break;
            case 2:
                Buy.transform.Find("Notice").gameObject.SetActive(true);
                break;
            case 3:
                Hire.transform.Find("Notice").gameObject.SetActive(true);
                break;
            case 4:
                Upgrade.transform.Find("Notice").gameObject.SetActive(true);
                break;
            case 5:
                Achivement.transform.Find("Notice").gameObject.SetActive(true);
                break;
            case 6:
                Shop.transform.Find("Notice").gameObject.SetActive(true);
                break;
        }
    }
    public void UnSetNotice(int i)
    {
        switch (i)
        {
            case 1:
                Status.transform.Find("Notice").gameObject.SetActive(false);
                break;
            case 2:
                Buy.transform.Find("Notice").gameObject.SetActive(false);
                break;
            case 3:
                Hire.transform.Find("Notice").gameObject.SetActive(false);
                break;
            case 4:
                Upgrade.transform.Find("Notice").gameObject.SetActive(false);
                break;
            case 5:
                Achivement.transform.Find("Notice").gameObject.SetActive(false);
                break;
            case 6:
                Shop.transform.Find("Notice").gameObject.SetActive(false);
                break;
        }
    }
    public void SelectButton(int i)
    {
        switch(i)
        {
            case 1:
                Status.GetComponent<Image>().color = DefaultColor;
                Buy.GetComponent<Image>().color = UnselectColor;
                Hire.GetComponent<Image>().color = UnselectColor;
                Upgrade.GetComponent<Image>().color = UnselectColor;
                Achivement.GetComponent<Image>().color = UnselectColor;
                Shop.GetComponent<Image>().color = UnselectColor;
                //ScrollStatus.SetActive(true);
                Vector2 myvec = new Vector2();
                myvec.x = 0; myvec.y = -70;
                ScrollStatus.transform.localPosition= myvec;
                ScrollBuy.SetActive(false);
                ScrollHire.SetActive(false);
                ScrollUpgrade.SetActive(false);
                ScrollAchivemnt.SetActive(false);
                ScrollShop.SetActive(false);

                Status.transform.Find("Notice").gameObject.SetActive(false);
                break;
            case 2:
                Status.GetComponent<Image>().color = UnselectColor;
                Buy.GetComponent<Image>().color = DefaultColor;
                Hire.GetComponent<Image>().color = UnselectColor;
                Upgrade.GetComponent<Image>().color = UnselectColor;
                Achivement.GetComponent<Image>().color = UnselectColor;
                Shop.GetComponent<Image>().color = UnselectColor;
                //ScrollStatus.SetActive(false);
                ScrollStatus.transform.localPosition = StatusVec;
                ScrollBuy.SetActive(true);
                ScrollHire.SetActive(false);
                ScrollUpgrade.SetActive(false);
                ScrollAchivemnt.SetActive(false);
                ScrollShop.SetActive(false);
                break;
            case 3:
                Status.GetComponent<Image>().color = UnselectColor;
                Buy.GetComponent<Image>().color = UnselectColor;
                Hire.GetComponent<Image>().color = DefaultColor;
                Upgrade.GetComponent<Image>().color = UnselectColor;
                Shop.GetComponent<Image>().color = UnselectColor;
                Achivement.GetComponent<Image>().color = UnselectColor;
                //ScrollStatus.SetActive(false);
                ScrollStatus.transform.localPosition = StatusVec;
                ScrollBuy.SetActive(false);
                ScrollHire.SetActive(true);
                ScrollUpgrade.SetActive(false);
                ScrollAchivemnt.SetActive(false);
                ScrollShop.SetActive(false);
                break;
            case 4:
                Status.GetComponent<Image>().color = UnselectColor;
                Buy.GetComponent<Image>().color = UnselectColor;
                Hire.GetComponent<Image>().color = UnselectColor;
                Upgrade.GetComponent<Image>().color = DefaultColor;
                Shop.GetComponent<Image>().color = UnselectColor;
                Achivement.GetComponent<Image>().color = UnselectColor;
                //ScrollStatus.SetActive(false);
                ScrollStatus.transform.localPosition = StatusVec;
                ScrollBuy.SetActive(false);
                ScrollHire.SetActive(false);
                ScrollUpgrade.SetActive(true);
                ScrollAchivemnt.SetActive(false);
                ScrollShop.SetActive(false);
                break;
            case 5:
                Status.GetComponent<Image>().color = UnselectColor;
                Buy.GetComponent<Image>().color = UnselectColor;
                Hire.GetComponent<Image>().color = UnselectColor;
                Upgrade.GetComponent<Image>().color = UnselectColor;
                Shop.GetComponent<Image>().color = UnselectColor;
                Achivement.GetComponent<Image>().color = DefaultColor;
                //ScrollStatus.SetActive(false);
                ScrollStatus.transform.localPosition = StatusVec;
                ScrollBuy.SetActive(false);
                ScrollHire.SetActive(false);
                ScrollUpgrade.SetActive(false);                
                ScrollAchivemnt.SetActive(true);
                ScrollShop.SetActive(false);

                Status.transform.Find("Notice").gameObject.SetActive(false);
                break;
            case 6:
                Status.GetComponent<Image>().color = UnselectColor;
                Buy.GetComponent<Image>().color = UnselectColor;
                Hire.GetComponent<Image>().color = UnselectColor;
                Upgrade.GetComponent<Image>().color = UnselectColor;
                Achivement.GetComponent<Image>().color = UnselectColor;
                Shop.GetComponent<Image>().color = DefaultColor;
                //ScrollStatus.SetActive(false);
                ScrollStatus.transform.localPosition = StatusVec;
                ScrollBuy.SetActive(false);
                ScrollHire.SetActive(false);
                ScrollUpgrade.SetActive(false);
                ScrollAchivemnt.SetActive(false);
                ScrollShop.SetActive(true);
                break;

        }
    }
}

