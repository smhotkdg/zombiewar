using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ClickUpdateManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject GameManagerSrc;
    bool check = false;
    Globalvariable gv;
        

    public void OnPointerDown(PointerEventData eventData)
    {
        check = true;        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        check = false;        
    }

    void Awake()
    {
        gv = Globalvariable.Instance;
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (check && gv.isiapp[1] != 0)
        {
            GameManagerSrc.GetComponent<GameManagerSrc>().ClickTop();            
        }
    }
}
