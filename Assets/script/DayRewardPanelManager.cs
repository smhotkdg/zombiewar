using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayRewardPanelManager : MonoBehaviour {

    // Use this for initialization
    Globalvariable gv;
    public List<GameObject> DayRewadObj;
    private void Awake()
    {
        gv = Globalvariable.Instance;
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnEnable()
    {
        bStartReward = false;
        if (gv.DayRewardCount == 7)
        {
            gv.DayRewardCount = 0;
            gv.SaveDayReward();
            ResetReward();
        }
        for (int i =0; i< gv.DayRewardCount; i++)
        {
            DayRewadObj[i].transform.Find("DayStamp").gameObject.SetActive(true);
        }
    }
    bool bStartReward = false;
    public void GetReward(int i)
    {
        if(i==0 && gv.DayRewardCount ==0)
        {
            if(bStartReward == false)
            {
                bStartReward = true;
                SuccessReward(i);
                Debug.Log(i+"  일차  일일 보상 받음");                
            }            
        }
        else if (i == gv.DayRewardCount && GameObject.Find("GameManager").gameObject.GetComponent<TimerManager>().SetTimerText("DayRewardTime_Time", gv.DayRewardTime) == -1)
        {
            if(bStartReward ==false)
            {
                bStartReward = true;
                SuccessReward(i);
                Debug.Log(i + "  일차  일일 보상 받음");
            }
        }
        else
        {
            Debug.Log(i + "  일차  일일 보상 못 받음");
        }

        
    }
    void SuccessReward(int i)
    {
        switch (i)
        {
            case 0:
                if(gv.isiapp[0] ==1)
                    gv.Potion10 += 9;
                else
                    gv.Potion10 += 3;
                break;
            case 1:
                if (gv.isiapp[0] == 1)
                    gv.Potion100 += 3;
                else
                    gv.Potion100 += 1;
                break;
            case 2:
                if (gv.isiapp[0] == 1)
                    gv.Potion10 += 15;
                else
                    gv.Potion10 += 5;
                break;                
            case 3:
                if (gv.isiapp[0] == 1)
                    gv.Potion100 += 3;
                else
                    gv.Potion100 += 1;
                break;
            case 4:
                if (gv.isiapp[0] == 1)
                    gv.Potion10 += 15;
                else
                    gv.Potion10 += 5;                
                break;
            case 5:
                if (gv.isiapp[0] == 1)
                    gv.Potion100 += 3;
                else
                    gv.Potion100 += 1;
                break;
            case 6:
                if (gv.isiapp[0] == 1)
                    gv.Potion100 += 9;
                else
                    gv.Potion100 += 3;
                if (gv.isiapp[0] == 1)
                    gv.Potion10 += 30;
                else
                    gv.Potion10 += 10;                

                break;
        }
        gv.SavePotion10();
        gv.SavePotion100();
        DayRewadObj[i].transform.Find("DayStamp").gameObject.SetActive(true);
        gv.DayRewardCount++;
        gv.SaveDayReward();      
        GameObject.Find("GameManager").gameObject.GetComponent<TimerManager>().StartTimer("DayRewardTime_Time", gv.DayRewardTime);
        GameObject.Find("GameManager").gameObject.GetComponent<GameManagerSrc>().SetPotionText();

    }
    void ResetReward()
    {
        for (int i = 0; i < DayRewadObj.Count; i++)
        {
            DayRewadObj[i].transform.Find("DayStamp").gameObject.SetActive(false);
        }
    }
}
