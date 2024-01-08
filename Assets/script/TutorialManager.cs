using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutorialManager : MonoBehaviour {

    // Use this for initialization
    Globalvariable gv;
    public List<GameObject> TutorialList;
    int index = 0;
    private void Awake()
    {
        gv = Globalvariable.Instance;
    }
    void Start () {
		
	}
    private void OnEnable()
    {
        bNext = false;
        index = 0;
        TutorialList[index].SetActive(true);
    }
    // Update is called once per frame
    void Update () {
		
	}
    bool bNext = false;
    public void ClickTutorial1()
    {
        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().ClickMeth();
        TutorialList[index].SetActive(false);
        index++;
        TutorialList[index].SetActive(true);
    }
    int ClickIndex =0;
    public void ClickTutorial2_4(int number)
    {
        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().NoramlClickTop();
        ClickIndex++;
        if(ClickIndex >=7)
        {
            TutorialList[index].SetActive(false);
            index++;
            TutorialList[index].SetActive(true);
            ClickIndex = 0;
            if(number ==2)
            {
                StartCoroutine(StartBNext());
            }
        }
    }
    IEnumerator StartBNext()
    {
        yield return new WaitForSeconds(1f);
        bNext = true;
    }
    public void ClickTutorial3()
    {
        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().ClickMoney();
        TutorialList[index].SetActive(false);
        index++;
        TutorialList[index].SetActive(true);
    }
    public void ClickTutorial5_8()
    {
        if(bNext == true)
        {
            TutorialList[index].SetActive(false);
            index++;
            if(index < TutorialList.Count)
            {
                TutorialList[index].SetActive(true);
            }
            else
            {
                GameObject.Find("GameManager").GetComponent<GameManagerSrc>().PressTutorialFalse();
            }
                
        }        
    }
}
