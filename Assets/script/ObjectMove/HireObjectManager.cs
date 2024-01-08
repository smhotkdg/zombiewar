using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HireObjectManager : MonoBehaviour {

    // Use this for initialization
    public int type;
	void Start () {
        StartCoroutine(MoveRoutine());
	}
    int ranage;
    IEnumerator MoveRoutine()
    {
        if (type == 0)
        {
            int waitRandstart = Random.Range(1, 5);
            yield return new WaitForSeconds(waitRandstart);
            this.GetComponent<Animator>().SetBool("isMotion", true);        
            int waitRand = Random.Range(3, 15);
            yield return new WaitForSeconds(waitRand);
            this.GetComponent<Animator>().SetBool("isMotion", false);
            StartCoroutine(MoveRoutine());
        }
        else
        {
            int random = Random.Range(0, 200);
            if(random ==1)
            {
                this.GetComponent<Animator>().SetBool("isMotion", true);
                this.transform.Find("Text").gameObject.SetActive(true);
                ranage = Random.Range(1, 8);
                this.transform.Find("Text").gameObject.GetComponent<Text>().text = ranage + " %";               
                this.transform.GetComponent<Button>().enabled = true;                
                yield return new WaitForSeconds(180);
                this.GetComponent<Animator>().SetBool("isMotion", false);
                this.transform.Find("Text").gameObject.SetActive(false);                
            }                        
            yield return new WaitForSeconds(5);
            this.transform.GetComponent<Button>().enabled = false;
            this.transform.Find("Text").gameObject.SetActive(false);
            StartCoroutine(MoveRoutine());
            
        }
        
    }
    public void AddMoneyBakner()
    {
        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().AddMoneyBaker(ranage);
        this.GetComponent<Animator>().SetBool("isMotion", false);
        this.transform.Find("Text").gameObject.SetActive(false);
        if(type ==1)
        {
            this.transform.GetComponent<Button>().enabled = false;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
