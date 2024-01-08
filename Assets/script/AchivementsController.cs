using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AchivementsController : MonoBehaviour {

    // Use this for initialization
    Globalvariable gv;
    public GameObject Contents;
    List<GameObject> AchivementList = new List<GameObject>();
    private void Awake()
    {
        gv = Globalvariable.Instance;
        InitData();
    }
    void InitData()
    {
        
        for (int i=0; i< 24; i++)
        {
            int index = 0;
            string strAchive = "Achivements";
            index = i + 1;
            strAchive = strAchive + index;
            GameObject temp = Contents.transform.Find(strAchive).gameObject;
            AchivementList.Add(temp);
        }
    }
    private void OnEnable()
    {
        for(int i=0; i< AchivementList.Count; i++)
        {
            if(gv.AchivementStatus[i] ==1)
            {
                AchivementList[i].transform.Find("Achive").gameObject.SetActive(true);
                AchivementList[i].transform.Find("TextInfoAchive").gameObject.SetActive(true);
                AchivementList[i].transform.Find("AchiveLock").gameObject.SetActive(false);
            }
        }
        GameObject.Find("GameManager").GetComponent<BottomUIController>().UnSetNotice(5);
    }
    
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
