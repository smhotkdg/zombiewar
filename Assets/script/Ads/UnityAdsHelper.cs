using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class UnityAdsHelper : MonoBehaviour
{
    Globalvariable gv;
    private const string android_game_id = "3094017";
    private const string ios_game_id = "3094016";

    private const string rewarded_video_id = "rewardedVideo";
    public GameObject AdsManager;
    private void Awake()
    {
        gv = Globalvariable.Instance;
    }
    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
#if UNITY_ANDROID
        Advertisement.Initialize(android_game_id);
#elif UNITY_IOS
        Advertisement.Initialize(ios_game_id);
#endif
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady(rewarded_video_id))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };

            Advertisement.Show(rewarded_video_id, options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                {
                    Debug.Log("The ad was successfully shown.");

                    // to do ...
                    // 광고 시청이 완료되었을 때 처리
                    //_Text.text = "Unity Ad 완료";        
                    switch(gv.AdsType)
                    {
                        case 1:
                            gv.Potion10 +=1;
                            gv.SavePotion10();
                            GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetPotionText();
                            gv.SetAdsTime();
                            GameObject.Find("GameManager").GetComponent<GameManagerSrc>().PressPanelNotification("ADS");
                            break;
                        case 2:
                            gv.TotalMoney += (gv.TimeTotalMoney*2);
                            gv.TotalMeth += (gv.TimeTotalMeth*2);
                            gv.endingMeht += (gv.TimeTotalMeth * 2);
                            gv.SaveTotalMoney();
                            gv.SaveTotalMeth();
                            gv.SaveEndingMeth();
                            GameObject.Find("GameManager").GetComponent<GameManagerSrc>().EndNotificationPane("TimeReward");
                            break;
                        case 3:
                            //Meth or Money *5
                            //gv.adsRewardType = 1;
                            //gv.adsRewardType =2;
                            if (gv.adsRewardType == 1)
                            {
                                gv.adsRewardMoeny = gv.adsRewardMoeny * 20;
                                GameObject.Find("GameManager").GetComponent<GameManagerSrc>().PressPanelNotification("ADS2", 1);
                            }
                            if (gv.adsRewardType == 2)
                            {
                                gv.adsRewardMeth = gv.adsRewardMeth * 20;
                                GameObject.Find("GameManager").GetComponent<GameManagerSrc>().PressPanelNotification("ADS2", 2);
                            }
                            break;
                        case 4:
                            //x20 10sec Buff
                            //gv.adsRewardType =3;
                            GameObject.Find("GameManager").GetComponent<GameManagerSrc>().PressPanelNotification("ADS2", 3);
                            break;
                    }
                    
                    gv.AdsType = 0;
                    break;
                }
            case ShowResult.Skipped:
                {
                    Debug.Log("The ad was skipped before reaching the end.");

                    // to do ...
                    // 광고가 스킵되었을 때 처리

                    break;
                }
            case ShowResult.Failed:
                {
                    Debug.LogError("The ad failed to be shown.");

                    // to do ...
                    // 광고 시청에 실패했을 때 처리

                    break;
                }
        }
    }
}
