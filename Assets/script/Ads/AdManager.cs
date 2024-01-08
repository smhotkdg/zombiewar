using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AdManager : MonoBehaviour
{

    // Use this for initialization    
    public GameObject AdMobObj;
    public GameObject UnityAdsObj;
    Globalvariable gv;

    private void Awake()
    {
        gv = Globalvariable.Instance;

    }
    void Start()
    {

    }
    IEnumerator LoadAd()
    {
        AdMobObj.GetComponent<AdsMobManager>().LoadAd();
        yield return new WaitForSeconds(25);
        if (AdMobObj.GetComponent<AdsMobManager>().rewardBasedVideo.IsLoaded() == false)
        {
            StartCoroutine(LoadAd());
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

    }
    void Update()
    {

    }    
    public void ShowReward(int number)
    {
        gv.AdsType = number;
        if(gv.AdsType ==3)
        {
            GameObject.Find("GameManager").GetComponent<GameManagerSrc>().DisablePanel("Supply1");
        }
        if(gv.AdsType ==4)
        {
            GameObject.Find("GameManager").GetComponent<GameManagerSrc>().DisablePanel("Supply2");
        }
        
        UnityAdsObj.GetComponent<UnityAdsHelper>().ShowRewardedAd();
       
    
        //for debug

    }
}

