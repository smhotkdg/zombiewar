﻿using System;
using UnityEngine;
using GoogleMobileAds.Api;

using UnityEngine.UI;

public class AdsMobManager : MonoBehaviour
{
    public RewardBasedVideoAd rewardBasedVideo;
    Globalvariable gv;
    public GameObject AdsManager;

    private void Awake()
    {
        gv = Globalvariable.Instance;
    }

    private void _BannerShow()
    {
#if UNITY_ANDROID
        //string AdUnitID = "ca-app-pub-7939215518934371/9117981273";
        //test
        string AdUnitID = "ca-app-pub-3940256099942544/6300978111";
#else
        string AdUnitID = "unDefind";
#endif

        BannerView _banner = new BannerView(AdUnitID, AdSize.Banner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder()
     .AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
     .AddTestDevice("EDB5A505509200AC")  // My test device.
     .Build();

        //***For Production When Submit App***
        //AdRequest request = new AdRequest.Builder().Build();

        BannerView bannerAd = new BannerView(AdUnitID, AdSize.SmartBanner, AdPosition.Bottom);

        _banner.LoadAd(request);
        _banner.Show();


    }
    public void Start()
    {
#if UNITY_ANDROID
        string appId = "ca-app-pub-7939215518934371~7277451840";
#elif UNITY_IPHONE
        string appId = "ca-app-pub-3940256099942544~1458002511";
#else
        string appId = "unexpected_platform";
#endif

        //Get singleton reward based video ad reference.
        this.rewardBasedVideo = RewardBasedVideoAd.Instance;

        // Called when an ad request has successfully loaded.
        rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
        // Called when an ad request failed to load.
        rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        // Called when an ad is shown.
        rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
        // Called when the ad starts to play.
        rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
        // Called when the user should be rewarded for watching a video.
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
        // Called when the ad click caused the user to leave the application.
        rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;


        MobileAds.Initialize(appId);

        this.RequestRewardBasedVideo();
        //_BannerShow();
    }

    private void RequestRewardBasedVideo()
    {

#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-7939215518934371/5549081980";
        //test
        //string adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-7939215518934371/8863564247";
#else
            string adUnitId = "unexpected_platform";
#endif

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        //AdRequest request = new AdRequest.Builder()
        //.AddExtra("max_ad_content_rating", "G")
        //.Build();
     

        // Load the rewarded video ad with the request.
        this.rewardBasedVideo.LoadAd(request, adUnitId);


    }
    public void LoadAd()
    {
        RequestRewardBasedVideo();
    }
    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardBasedVideoFailedToLoad event received with message: "
                             + args.Message);
    }

    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
    }

    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        //MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
        this.RequestRewardBasedVideo();
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {

        //text.text = "리워드 성공";
        this.RequestRewardBasedVideo();

        switch (gv.AdsType)
        {
            case 1:
                gv.Potion10 += 1;
                gv.SavePotion10();
                GameObject.Find("GameManager").GetComponent<GameManagerSrc>().SetPotionText();
                gv.SetAdsTime();
                GameObject.Find("GameManager").GetComponent<GameManagerSrc>().PressPanelNotification("ADS");
                break;
            case 2:
                gv.TotalMoney += (gv.TimeTotalMoney * 2);
                gv.TotalMeth += (gv.TimeTotalMeth * 2);
                gv.endingMeht += (gv.TimeTotalMeth * 2);
                gv.SaveTotalMoney();
                gv.SaveTotalMeth();
                GameObject.Find("GameManager").GetComponent<GameManagerSrc>().EndNotificationPane("TimeReward");
                break;
            case 3:
                //Meth or Money *5
                //gv.adsRewardType = 1;
                //gv.adsRewardType =2;
                if(gv.adsRewardType ==1)
                {                    
                    gv.adsRewardMoeny = gv.adsRewardMoeny * 20;                    
                    GameObject.Find("GameManager").GetComponent<GameManagerSrc>().PressPanelNotification("ADS2",1);
                }
                if(gv.adsRewardType ==2)
                {                    
                    gv.adsRewardMeth= gv.adsRewardMeth * 20;
                    GameObject.Find("GameManager").GetComponent<GameManagerSrc>().PressPanelNotification("ADS2",2);
                }
                break;
            case 4:
                //x20 10sec Buff
                //gv.adsRewardType =3;                
                GameObject.Find("GameManager").GetComponent<GameManagerSrc>().PressPanelNotification("ADS2",3);
                break;
        }
        
        gv.AdsType = 0;
    }
     

    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
    }
}
