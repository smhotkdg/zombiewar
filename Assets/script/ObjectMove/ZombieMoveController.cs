using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ZombieMoveController : MonoBehaviour {

    // Use this for initialization
    public List<GameObject> ZombieList;
    public List<GameObject> ManList;
    public List<GameObject> EventList;

    public GameObject Pans;
    //pans
    //y 7
    public GameObject BackGround;
    //Background 
    //y -80 155
    //x 320 -335

    List<GameObject> ManCloneList = new List<GameObject>();
    List<GameObject> ZombieCloneList = new List<GameObject>();
    List<GameObject> EventCloneList = new List<GameObject>();
    void Start() {
        StartCoroutine(ZombieMoveRountine());
        StartCoroutine(DeleteZombie());
    }
    int GetBGType()
    {
        int rand = Random.Range(0, 5);
        if (rand == 4)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
    Vector2 SetBGPos()
    {
        Vector2 Pos = new Vector2();
        int randx = Random.Range(-335, 320);
        int randy = Random.Range(-80, 155);
        Pos.x = randx;
        Pos.y = randy;
        return Pos;
    }
    Vector2 SetPansPos()
    {
        Vector2 Pos = new Vector2();
        int randx = Random.Range(-335, 320);
        int randy = Random.Range(6, 7);
        Pos.x = randx;
        Pos.y = randy;
        return Pos;
    }
    IEnumerator ZombieMoveRountine()
    {

        int time = Random.Range(5, 20);
        int BGType = GetBGType();
        if (BGType == 0)
        {            
            SetMan(BackGround, BGType);
            SetZombie(BackGround, BGType);
            SetEvent(BackGround, BGType);
        }
        else
        {
            SetMan(Pans, BGType);
            SetZombie(Pans, BGType);
            //SetEvent(Pans, BGType);
        }        
        yield return new WaitForSeconds(time);
        StartCoroutine(ZombieMoveRountine());
    }
    IEnumerator DeleteZombie()
    {
        yield return new WaitForSeconds(5);
        if (ManCloneList.Count > 0)
        {
            ManCloneList[0].GetComponent<ZombieObjectMoveManager>().EndViewStart();
            yield return new WaitForSeconds(2);
            Destroy(ManCloneList[0]);
            ManCloneList.RemoveAt(0);
        }
        if (ZombieCloneList.Count > 0)
        {
            ZombieCloneList[0].GetComponent<ZombieObjectMoveManager>().EndViewStart();
            yield return new WaitForSeconds(2);
            Destroy(ZombieCloneList[0]);
            ZombieCloneList.RemoveAt(0);
        }
        if (EventCloneList.Count > 0)
        {
            EventCloneList[0].GetComponent<ZombieObjectMoveManager>().EndViewStart();
            yield return new WaitForSeconds(2);
            Destroy(EventCloneList[0]);
            EventCloneList.RemoveAt(0);
        }
        
        StartCoroutine(DeleteZombie());
    }
    void DeleteObj()
    {
        
    }


    void SetMan(GameObject p, int type)
    {
        int rnd = Random.Range(0, ManList.Count);
        GameObject temp = Instantiate(ManList[rnd]);
        temp.transform.SetParent(p.transform);
        temp.transform.localScale = ManList[rnd].transform.localScale;
        if (type == 0)
            temp.transform.localPosition = SetBGPos();
        else
            temp.transform.localPosition = SetPansPos();
        float speed = Random.Range(1, 2);
        temp.GetComponent<ZombieObjectMoveManager>().SetSpeed(speed);
        temp.SetActive(true);
        ManCloneList.Add(temp);
    }
    void SetZombie(GameObject p, int type)
    {
        int rnd = Random.Range(0, ZombieList.Count);
        GameObject temp = Instantiate(ZombieList[rnd]);
        temp.transform.SetParent(p.transform);
        temp.transform.localScale = ZombieList[rnd].transform.localScale;
        if (type == 0)
            temp.transform.localPosition = SetBGPos();
        else
            temp.transform.localPosition = SetPansPos();
        float speed = Random.Range(1, 2);
        temp.GetComponent<ZombieObjectMoveManager>().SetSpeed(speed);
        temp.SetActive(true);
        ZombieCloneList.Add(temp);
    }
    void SetEvent(GameObject p, int type)
    {
        int rnd = Random.Range(0, EventList.Count);
        GameObject temp = Instantiate(EventList[rnd]);
        temp.transform.SetParent(p.transform);
        temp.transform.localScale = EventList[rnd].transform.localScale;
        if (type == 0)
            temp.transform.localPosition = SetBGPos();
        else
            temp.transform.localPosition = SetPansPos();
        float speed = Random.Range(1, 2);
        temp.GetComponent<ZombieObjectMoveManager>().SetSpeed(speed);
        temp.SetActive(true);
        EventCloneList.Add(temp);

    }
    // Update is called once per frame
    void Update () {
		
	}
}
