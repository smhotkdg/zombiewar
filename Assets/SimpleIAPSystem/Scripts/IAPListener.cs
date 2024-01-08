/*  This file is part of the "Simple IAP System" project by Rebound Games.
 *  You are only allowed to use these resources if you've bought them from the Unity Asset Store.
 * 	You shall not license, sublicense, sell, resell, transfer, assign, distribute or
 * 	otherwise make available to any third party the Service or the Content. */

using UnityEngine;

#if UNITY_PURCHASING
using UnityEngine.Purchasing;
#endif

namespace SIS
{
    /// <summary>
    /// Script that listens to purchases and other IAP events:
    /// here we tell our game what to do when these events happen.
    /// <summary>
    public class IAPListener : MonoBehaviour
    {
        //subscribe to the most important IAP events
        Globalvariable gv;

        private void Awake()
        {
            gv = Globalvariable.Instance;
        }
        private void OnEnable()
        {
            IAPManager.purchaseSucceededEvent += HandleSuccessfulPurchase;
            IAPManager.purchaseFailedEvent += HandleFailedPurchase;
            ShopManager.itemSelectedEvent += HandleSelectedItem;
            ShopManager.itemDeselectedEvent += HandleDeselectedItem;
        }


        private void OnDisable()
        {
			IAPManager.purchaseSucceededEvent -= HandleSuccessfulPurchase;
			IAPManager.purchaseFailedEvent -= HandleFailedPurchase;
			ShopManager.itemSelectedEvent -= HandleSelectedItem;
			ShopManager.itemDeselectedEvent -= HandleDeselectedItem;
        }


        /// <summary>
        /// Handle the completion of purchases, be it for products or virtual currency.
        /// Most of the IAP logic is handled internally already, such as adding products or currency to the inventory.
        /// However, this is the spot for you to implement your custom game logic for instantiating in-game products etc.
        /// </summary>
        public void HandleSuccessfulPurchase(string id)
        {
            if (IAPManager.isDebug) Debug.Log("IAPListener reports: HandleSuccessfulPurchase: " + id);

            //differ between ids set in the IAP Settings editor
            switch (id)
            {
                //section for in app purchases
                case "reward3":
                    gv.IapType = 1;
                    gv.isiapp[gv.IapType - 1] = 1;
                    gv.SaveIapp(gv.IapType-1);
                    GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetShopVIew();
                    break;
                case "autoclick":
                    gv.IapType = 2;
                    gv.isiapp[gv.IapType - 1] = 1;
                    gv.SaveIapp(gv.IapType-1);
                    GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetShopVIew();
                    break;
                case "normalpotion1":
                    gv.Potion10 += 50;
                    gv.SavePotion10();
                    GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetPotionText();
                    gv.IapType = 5;
                    break;
                case "superpotion1":
                    gv.IapType = 4;
                    gv.Potion100 += 50;
                    gv.SavePotion100();
                    GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetPotionText();
                    break;
                case "meth1":
                    gv.IapType = 7;
                    if(gv.TimeMoney ==0)
                    {
                        double money = GameObject.Find("GameManager").GetComponent<GameManagerSrc>().GetTimeMoney();
                        gv.TimeMoney = money;
                    }
                    gv.TotalMeth += (gv.TimeMoney / 2);
                    gv.endingMeht += (gv.TimeMoney/2);
                    gv.SaveTotalMeth();
                    gv.SaveEndingMeth();
                    GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetTextMeth();
                    break;
                case "meth2":
                    gv.IapType = 8;
                    if (gv.TimeMoney == 0)
                    {
                        double money = GameObject.Find("GameManager").GetComponent<GameManagerSrc>().GetTimeMoney();
                        gv.TimeMoney = money;
                    }
                    gv.TotalMeth += gv.TimeMoney;
                    gv.endingMeht += gv.TimeMoney;
                    gv.SaveTotalMeth();
                    gv.SaveEndingMeth();
                    GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetTextMeth();
                    break;
                case "money1":
                    gv.IapType = 9;
                    if (gv.TimeMoney == 0)
                    {
                        double money = GameObject.Find("GameManager").GetComponent<GameManagerSrc>().GetTimeMoney();
                        gv.TimeMoney = money;
                    }
                    gv.TotalMoney += gv.TimeMoney;
                    gv.SaveTotalMoney();
                    GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetTextMoney();
                    break;
                case "money2":
                    gv.IapType = 10;
                    if (gv.TimeMoney == 0)
                    {
                        double money = GameObject.Find("GameManager").GetComponent<GameManagerSrc>().GetTimeMoney();
                        gv.TimeMoney = money;
                    }
                    gv.TotalMoney += (gv.TimeMoney*2.5);
                    gv.SaveTotalMoney();
                    GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetTextMoney();
                    break;
                case "package1":
                    gv.IapType = 3;
                    gv.Potion10 += 50;
                    gv.SavePotion10();
                    GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetPotionText();
                    if (gv.TimeMoney == 0)
                    {
                        double money = GameObject.Find("GameManager").GetComponent<GameManagerSrc>().GetTimeMoney();
                        gv.TimeMoney = money;
                    }
                    gv.TotalMoney += gv.TimeMoney;
                    gv.SaveTotalMoney();
                    GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetTextMoney();
                    //+ money
                    break;
                case "package2":
                    gv.IapType = 6;
                    gv.Potion100 += 50;
                    gv.SavePotion100();//
                    GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetPotionText();
                    if (gv.TimeMoney == 0)
                    {
                        double money = GameObject.Find("GameManager").GetComponent<GameManagerSrc>().GetTimeMoney();
                        gv.TimeMoney = money;
                    }
                    gv.TotalMoney += (gv.TimeMoney*2.5);
                    gv.SaveTotalMoney();
                    GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetTextMoney();
                    //+ money
                    break;
            }

            if (gv.AchivementStatus[15] == 0)
            {
                gv.SetAchivement(15);
                GameObject.Find("GameManager").GetComponent<BottomUIController>().SetNotice(5);
            }

            GameObject.Find("GameManager").GetComponent<GameManagerSrc>().PressPanelNotification("IAP");
        }

        //just shows a message via our ShopManager component,
        //but checks for an instance of it first
        void ShowMessage(string text)
        {
            if (ShopManager.GetInstance())
                ShopManager.ShowMessage(text);
        }

        //called when an purchaseFailedEvent happens,
        //we do the same here
        void HandleFailedPurchase(string error)
        {
            if (ShopManager.GetInstance())
                ShopManager.ShowMessage(error);
        }


        //called when a purchased shop item gets selected
        void HandleSelectedItem(string id)
        {
            if (IAPManager.isDebug) Debug.Log("Selected: " + id);
        }


        //called when a selected shop item gets deselected
        void HandleDeselectedItem(string id)
        {
            if (IAPManager.isDebug) Debug.Log("Deselected: " + id);
        }
    }
}