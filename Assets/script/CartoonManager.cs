using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartoonManager : MonoBehaviour {

    // Use this for initialization
    public List<GameObject> CartoonList;

    public List<GameObject> Cartoon1List;
    public List<GameObject> Cartoon2List;
    public List<GameObject> Cartoon3List;
    public List<GameObject> Cartoon4List;
    public List<GameObject> Cartoon5List;
    public List<GameObject> Cartoon6List;
    
    void Start () {
        
	}
	
    IEnumerator StartCartoonRoutine(List<GameObject> Cartoon,float sec)
    {
        for(int i=0; i< Cartoon.Count; i++)
        {
            Cartoon[i].SetActive(true);
            yield return new WaitForSeconds(sec);
        }
    }
    private void OnEnable()
    {
        CartoonList[0].SetActive(true);
        StartCoroutine(StartCartoonRoutine(Cartoon1List, 1));
    }
    private void OnDisable()
    {
        for(int i=0; i< CartoonList.Count; i++)
        {
            CartoonList[i].SetActive(false);
        }

        for (int i = 0; i < Cartoon1List.Count; i++)
        {
            Cartoon1List[i].SetActive(false);
        }
        for (int i = 0; i < Cartoon2List.Count; i++)
        {
            Cartoon2List[i].SetActive(false);
        }
        for (int i = 0; i < Cartoon3List.Count; i++)
        {
            Cartoon3List[i].SetActive(false);
        }
        for (int i = 0; i < Cartoon4List.Count; i++)
        {
            Cartoon4List[i].SetActive(false);
        }
        for (int i = 0; i < Cartoon5List.Count; i++)
        {
            Cartoon5List[i].SetActive(false);
        }
        for (int i = 0; i < Cartoon6List.Count; i++)
        {
            Cartoon6List[i].SetActive(false);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
    public void ClickNext(int number)
    {
        CartoonList[number].SetActive(false);
        if(CartoonList.Count > number+1)
        {
            CartoonList[number+1].SetActive(true);
        }
        switch(number)
        {
            case 0:
                StartCoroutine(StartCartoonRoutine(Cartoon2List, 0.7f));
                break;
            case 1:
                StartCoroutine(StartCartoonRoutine(Cartoon3List, 0.7f));
                break;
            case 2:
                StartCoroutine(StartCartoonRoutine(Cartoon4List, 0.7f));
                break;
            case 3:
                StartCoroutine(StartCartoonRoutine(Cartoon5List, 0.7f));
                break;
            case 4:
                StartCoroutine(StartCartoonRoutine(Cartoon6List, 0.7f));
                break;
            case 5:
                GameObject.Find("GameManager").GetComponent<GameManagerSrc>().PressCartoonObj(0);
                break;
        }
    }
}
 