using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

//gpg
using GooglePlayGames.BasicApi.SavedGame;
using System;
using System.Text;

public class GPGSManager : MonoBehaviour {

    Globalvariable gv;

    private void Awake()
    {
        gv = Globalvariable.Instance;
    }
    private void Start()
    {
        Init();
    } 
    void Init()
    {
        //PlayGamesClientConfiguration conf = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesClientConfiguration conf = new PlayGamesClientConfiguration.Builder()
            .EnableSavedGames()
            .Build();

        PlayGamesPlatform.InitializeInstance(conf);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();

        Login();
    }
    public void Login()
    {
        if (Social.localUser.authenticated == false)
        {
            Social.localUser.Authenticate((bool success) => {
                // handle success or failure                         
                if (success)
                {
                    gv.iGoogle = 1;
                }
            });
        }
    }

    public void AddAchive(int index)
    {
        if (Social.localUser.authenticated == true)
        {
            switch (index)
            {
                case 1:
                    Social.ReportProgress(GPGSIds.achievement, 100f, (bool success) =>
                    {
                        if (success)
                        {
                            gv.googleAchivementList[index - 1] = 1;
                            gv.SaveGoogleAchivement(index-1);
                        }
                    });
                    break;
                case 2:
                    Social.ReportProgress(GPGSIds.achievement_2, 100f, (bool success) =>
                    {
                        if (success)
                        {
                            gv.googleAchivementList[index - 1] = 1;
                            gv.SaveGoogleAchivement(index - 1);
                        }
                    });
                    break;
                case 3:
                    Social.ReportProgress(GPGSIds.achievement_3, 100f, (bool success) =>
                    {
                        if (success)
                        {
                            gv.googleAchivementList[index - 1] = 1;
                            gv.SaveGoogleAchivement(index - 1);
                        }
                    });
                    break;
                case 4:
                    Social.ReportProgress(GPGSIds.achievement_4, 100f, (bool success) =>
                    {
                        if (success)
                        {
                            gv.googleAchivementList[index - 1] = 1;
                            gv.SaveGoogleAchivement(index - 1);
                        }
                    });
                    break;
                case 5:
                    Social.ReportProgress(GPGSIds.achievement_5, 100f, (bool success) =>
                    {
                        if (success)
                        {
                            gv.googleAchivementList[index - 1] = 1;
                            gv.SaveGoogleAchivement(index - 1);
                        }
                    });
                    break;
                case 6:
                    Social.ReportProgress(GPGSIds.achievement_6, 100f, (bool success) =>
                    {
                        if (success)
                        {
                            gv.googleAchivementList[index - 1] = 1;
                            gv.SaveGoogleAchivement(index - 1);
                        }
                    });
                    break;
                case 7:
                    Social.ReportProgress(GPGSIds.achievement_7, 100f, (bool success) =>
                    {
                        if (success)
                        {
                            gv.googleAchivementList[index - 1] = 1;
                            gv.SaveGoogleAchivement(index - 1);
                        }
                    });
                    break;
                case 8:
                    Social.ReportProgress(GPGSIds.achievement_8, 100f, (bool success) =>
                    {
                        if (success)
                        {
                            gv.googleAchivementList[index - 1] = 1;
                            gv.SaveGoogleAchivement(index - 1);
                        }
                    });
                    break;
                case 9:
                    Social.ReportProgress(GPGSIds.achievement_9, 100f, (bool success) =>
                    {
                        if (success)
                        {
                            gv.googleAchivementList[index - 1] = 1;
                            gv.SaveGoogleAchivement(index - 1);
                        }
                    });
                    break;
                case 10:
                    Social.ReportProgress(GPGSIds.achievement_10, 100f, (bool success) =>
                    {
                        if (success)
                        {
                            gv.googleAchivementList[index - 1] = 1;
                            gv.SaveGoogleAchivement(index - 1);
                        }
                    });
                    break;
                case 11:
                    Social.ReportProgress(GPGSIds.achievement_11, 100f, (bool success) =>
                    {
                        if (success)
                        {
                            gv.googleAchivementList[index - 1] = 1;
                            gv.SaveGoogleAchivement(index - 1);
                        }
                    });
                    break;
                case 12:
                    Social.ReportProgress(GPGSIds.achievement_12, 100f, (bool success) =>
                    {
                        if (success)
                        {
                            gv.googleAchivementList[index - 1] = 1;
                            gv.SaveGoogleAchivement(index - 1);
                        }
                    });
                    break;
                case 13:
                    Social.ReportProgress(GPGSIds.achievement_13, 100f, (bool success) =>
                    {
                        if (success)
                        {
                            gv.googleAchivementList[index - 1] = 1;
                            gv.SaveGoogleAchivement(index - 1);
                        }
                    });
                    break;
                case 14:
                    Social.ReportProgress(GPGSIds.achievement_14, 100f, (bool success) =>
                    {
                        if (success)
                        {
                            gv.googleAchivementList[index - 1] = 1;
                            gv.SaveGoogleAchivement(index - 1);
                        }
                    });
                    break;
                case 15:
                    Social.ReportProgress(GPGSIds.achievement_15, 100f, (bool success) =>
                    {
                        if (success)
                        {
                            gv.googleAchivementList[index - 1] = 1;
                            gv.SaveGoogleAchivement(index - 1);
                        }
                    });
                    break;
                case 16:
                    Social.ReportProgress(GPGSIds.achievement__10, 100f, (bool success) =>
                    {
                        if (success)
                        {
                            gv.googleAchivementList[index - 1] = 1;
                            gv.SaveGoogleAchivement(index - 1);
                        }
                    });
                    break;
                case 17:
                    Social.ReportProgress(GPGSIds.achievement__100, 100f, (bool success) =>
                    {
                        if (success)
                        {
                            gv.googleAchivementList[index - 1] = 1;
                            gv.SaveGoogleAchivement(index - 1);
                        }
                    });
                    break;
                case 18:
                    Social.ReportProgress(GPGSIds.achievement_swat, 100f, (bool success) =>
                    {
                        if (success)
                        {
                            gv.googleAchivementList[index - 1] = 1;
                            gv.SaveGoogleAchivement(index - 1);
                        }
                    });
                    break;
                case 19:
                    Social.ReportProgress(GPGSIds.achievement_16, 100f, (bool success) =>
                    {
                        if (success)
                        {
                            gv.googleAchivementList[index - 1] = 1;
                            gv.SaveGoogleAchivement(index - 1);
                        }
                    });
                    break;
                case 20:
                    Social.ReportProgress(GPGSIds.achievement_17, 100f, (bool success) =>
                    {
                        if (success)
                        {
                            gv.googleAchivementList[index - 1] = 1;
                            gv.SaveGoogleAchivement(index - 1);
                        }
                    });
                    break;
            }

        }    

    }
    public void LogOut()
    {
        if (Social.localUser.authenticated == true)
        {
            ((PlayGamesPlatform)Social.Active).SignOut();
            gv.iGoogle = 0;
        }
        else
        {
        }
    }

    public void OnAddScoreToLeaderBorad(double score, string key)
    {
        if (Social.localUser.authenticated)
        {
            //Social.Active.ReportScore(score, key, (bool success) =>
            PlayGamesPlatform.Instance.ReportScore((long)score, key, (bool success) =>
              {
                  if (success)
                  {
                      Debug.Log("Update Score Success");
                  }
                  else
                  {
                      Debug.Log("Update Score Fail");
                  }
              });
        }
    }

    public void ShowAchivementClick()
    {
        if (Social.localUser.authenticated == true)
        {
            Social.ShowAchievementsUI();
        }
        else
        {
            Login();
        }
    }

    public void AddScore()
    {
        OnAddScoreToLeaderBorad(gv.TotalMeth / gv.scaleFactor, GPGSIds.leaderboard_2);
    }
    public void AddScoreMoney()
    {

        OnAddScoreToLeaderBorad(gv.TotalMoney / gv.scaleFactor, GPGSIds.leaderboard);
    }

    public void ShowLeaderboard()
    {
        if (Social.localUser.authenticated == true)
        {
            AddScore();
            AddScoreMoney();
            PlayGamesPlatform.Instance.ShowLeaderboardUI();
        }
        else
        {
            Login();
        }
    }
    bool onSaving = false;
    string SaveData = string.Empty;
    public void SaveToCloud()
    {
        StartCoroutine(Save());
    }
    IEnumerator Save()
    {
        Debug.Log("Try to Save Data");

        while(gv.iGoogle==0)
        {
            Login();
            yield return new WaitForSeconds(2f);
        }
        onSaving = true;

        string id = Social.localUser.id;
        string filename = string.Format("{0}_DATA", id);
        

        OpenSaveGame(filename, true);
    }
    void OpenSaveGame(string _fileName, bool _saved)
    {
        ISavedGameClient savedClient = PlayGamesPlatform.Instance.SavedGame;
        if(_saved == true)
        {
            //save
            savedClient.OpenWithAutomaticConflictResolution(_fileName, DataSource.ReadCacheOrNetwork, ConflictResolutionStrategy.UseLongestPlaytime, OnSaveGameOpnedToSave);
        }
        else
        {
            //load
            savedClient.OpenWithAutomaticConflictResolution(_fileName, DataSource.ReadCacheOrNetwork, ConflictResolutionStrategy.UseLongestPlaytime, OnsaveGameOpenedtoRead);
        }
    }
    void OnSaveGameOpnedToSave(SavedGameRequestStatus _Status, ISavedGameMetadata _data)
    {
        if(_Status == SavedGameRequestStatus.Success)
        {
            SaveGame(_data, gv.saveByte, DateTime.Now.TimeOfDay);
        }
        else
        {
            GameObject.Find("GameManager").GetComponent<GameManagerSrc>().EndNotificationPane("Saving");
            Debug.Log("save Fail");
        }
    }
    void SaveGame(ISavedGameMetadata _data, byte[] _byte, TimeSpan _playTime)
    {
        ISavedGameClient savedClient = PlayGamesPlatform.Instance.SavedGame;
        SavedGameMetadataUpdate.Builder builder = new SavedGameMetadataUpdate.Builder();

        builder = builder.WithUpdatedPlayedTime(_playTime).WithUpdatedDescription("Saved at " + DateTime.Now);

        SavedGameMetadataUpdate updatedata = builder.Build();
        savedClient.CommitUpdate(_data, updatedata, _byte, OnsaveGameWritten);
    }
    void OnsaveGameWritten(SavedGameRequestStatus _status, ISavedGameMetadata _data)
    {
        onSaving = false;
        if(_status == SavedGameRequestStatus.Success)
        {
            GameObject.Find("GameManager").GetComponent<GameManagerSrc>().EndNotificationPane("Saving");
            Debug.Log("Save Completet");
            GameObject.Find("GameManager").GetComponent<GameManagerSrc>().PressPanelNotification("Save");
        }
        else
        {
            GameObject.Find("GameManager").GetComponent<GameManagerSrc>().EndNotificationPane("Saving");
            Debug.Log("Written Save fail");

        }
    }

    public void LoadFromCloud()
    {
        StartCoroutine(Load());
    }
    IEnumerator Load()
    {
        Debug.Log("Try to Load Data");

        while (gv.iGoogle == 0)
        {
            Login();
            yield return new WaitForSeconds(2f);
        }
        onSaving = true;

        string id = Social.localUser.id;
        string filename = string.Format("{0}_DATA", id);        

        OpenSaveGame(filename, false);
    }
    void OnsaveGameOpenedtoRead(SavedGameRequestStatus _status,ISavedGameMetadata _data)
    {
        if(_status == SavedGameRequestStatus.Success)
        {
            LoadGameData(_data);
        }
        else
        {
            GameObject.Find("GameManager").GetComponent<GameManagerSrc>().EndNotificationPane("Loading");
            Debug.Log("Load Fail");
        }
    }
    void LoadGameData(ISavedGameMetadata _data)
    {
        ISavedGameClient savedClient = PlayGamesPlatform.Instance.SavedGame;
        savedClient.ReadBinaryData(_data, OnSaveGameDataRead);
    }
    void OnSaveGameDataRead(SavedGameRequestStatus _status,byte[] _byte)
    {
        if(_status == SavedGameRequestStatus.Success)
        {
            gv.saveByte = _byte;
            if(gv.saveByte !=null)
            {
                DataInfo dataInfo;
                dataInfo = GameObject.Find("GameManager").GetComponent<SaveLoad>().LoadGameInfo(gv.saveByte);

                if(dataInfo != null)
                {
                    gv.TimeMoney = dataInfo.TimeMoney;                    
                    for (int i = 0; i < gv.isiapp.Count; i++)
                    {
                        gv.isiapp[i]= dataInfo.isiapp[i];
                        gv.SaveIapp(i);
                    }
                    gv.DayRewardTime = dataInfo.DayRewardTime;

                    gv.iMapPrograss = dataInfo.iMapPrograss;
                    gv.SaveiMapPrograss();

                    gv.endingMeht = dataInfo.endingMeht;
                    gv.SaveEndingMeth();
                    gv.Potion10 = dataInfo.Potion10 ;
                    gv.SavePotion10();
                    gv.Potion100 = dataInfo.Potion100 ;
                    gv.SavePotion100();
                    gv.TotalClickCount = dataInfo.TotalClickCount;
                    gv.SaveTotalClickCount();
                    gv.iBGM = dataInfo.iBGM ;
                    gv.SaveiBGM();
                    gv.iFx = dataInfo.iFx ;
                    gv.SaveiFx();
                    gv.iGoogle = dataInfo.iGoogle ;
                    
                    gv.iLanguage = dataInfo.iLanguage;
                    gv.SaveiLanguage();
                    gv.DayRewardCount = dataInfo.DayRewardCount;
                    gv.SaveDayReward();
                    gv.IapType = dataInfo.IapType;
                    gv.bStartPotion = dataInfo.bStartPotion ;
                    gv.potiontype = dataInfo.potiontype;
                    gv.UpgradePurity= dataInfo.UpgradePurity;
                    

                    gv.MethPerDeSec = dataInfo.MethPerDeSec;
                    gv.MasterDealerCount= dataInfo.MasterDealerCount;
                    gv.SaveMasterDealerCount();

                    gv.TotalMoney = dataInfo.TotalMoney;
                    gv.SaveTotalMoney();
                    gv.TotalMeth = dataInfo.TotalMeth ;
                    gv.SaveTotalMeth();
                    gv.MoneyPerSec = dataInfo.MoneyPerSec ;
                    gv.SaveMoneyPerSec();
                    gv.Purity= dataInfo.Purity ;
                    gv.SavePurity();
                    gv.DealerPower = dataInfo.DealerPower;
                    
                    gv.MethPerSec_Dealer = dataInfo.MethPerSec_Dealer ;
                    gv.MethPerSec_Worker = dataInfo.MethPerSec_Worker;
                    gv.DealerCost=  dataInfo.DealerCost;
                    gv.TotalDealer = dataInfo.TotalDealer ;
                    gv.SaveTotalDealer();
                    gv.MaxDealer = dataInfo.MaxDealer ;
                    gv.MethPerSec = dataInfo.MethPerSec;
                    gv.SaveMethPerSec();

                    gv.DealrHirePerSec = dataInfo.DealrHirePerSec ;
                    
                    gv.scaleFactor = dataInfo.scaleFactor;
                    gv.totalpalyTime = dataInfo.totalpalyTime;
                    gv.SaveTotalPlayTime();
                    for (int i = 0; i < 4; i++)
                    {
                        gv.Facilities[i] = dataInfo.Facilities[i] ;
                        gv.SaveFacilities(i);
                    }
                    for (int i = 0; i < gv.SlaveCount.Count; i++)
                    {
                        gv.SlaveCount[i] = dataInfo.SlaveCount[i] ;
                        gv.SaveSlaveCount(i);
                    }
                    for (int i = 0; i < gv.FacilityCount.Count; i++)
                    {
                        gv.FacilityCount[i] = dataInfo.FacilityCount[i] ;
                        gv.SaveFacilityCount(i);
                    }
                    for (int i = 0; i < gv.HireStatus.Count; i++)
                    {
                        gv.HireStatus[i] = dataInfo.HireStatus[i] ;
                        gv.SaveHireStatus(i);
                    }
                    for (int i = 0; i < gv.BuyStatus.Count; i++)
                    {
                        gv.BuyStatus[i] = dataInfo.BuyStatus[i] ;
                        gv.SaveBuyStatus(i);
                    }
                    for (int i = 0; i < gv.UpgradeStatus.Count; i++)
                    {
                        gv.UpgradeStatus[i] = dataInfo.UpgradeStatus[i] ;
                        gv.SaveUpgradeStatus(i);
                    }
                    for (int i = 0; i < gv.AchivementStatus.Count; i++)
                    {
                        gv.AchivementStatus[i] = dataInfo.AchivementStatus[i] ;
                        gv.SaveAchivementStatus(i);
                    }
                    for (int i = 0; i < gv.HireViewStatus.Count; i++)
                    {
                        gv.HireViewStatus[i] = dataInfo.HireViewStatus[i];
                        gv.SaveHireViewStatus(i);
                    }
                    for (int i = 0; i < gv.BuyViewStatus.Count; i++)
                    {
                        gv.BuyViewStatus[i] = dataInfo.BuyViewStatus[i] ;
                        gv.SaveBuyViewStatus(i);
                    }
                    for (int i = 0; i < gv.UpgradeViewStatus.Count; i++)
                    {
                        gv.UpgradeViewStatus[i] = dataInfo.UpgradeViewStatus[i];
                        gv.SaveUpgradeViewStatus(i);
                    }
                    GameObject.Find("GameManager").GetComponent<GameManagerSrc>().EndNotificationPane("Loading");
                    GameObject.Find("GameManager").GetComponent<GameManagerSrc>().PressPanelNotification("Load");
                }
                else
                {
                    GameObject.Find("GameManager").GetComponent<GameManagerSrc>().EndNotificationPane("Loading");
                    Debug.Log("dataInfo Null");
                }
            }
        }
        else
        {
            GameObject.Find("GameManager").GetComponent<GameManagerSrc>().EndNotificationPane("Loading");
            Debug.Log("Load Fail");
        }
    }
}
