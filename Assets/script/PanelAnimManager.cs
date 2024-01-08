using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAnimManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void EndPanelAnim()
    {
        GameObject.Find("GameManager").GetComponent<GameManagerSrc>().PressPanelNotification(0);
    }
}
