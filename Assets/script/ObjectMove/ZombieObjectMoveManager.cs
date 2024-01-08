using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ZombieObjectMoveManager : MonoBehaviour {

    // Use this for initialization
    public int MoveType;
    public float MoveSpeed;
    bool bRight = false;
    Color InitColor;

    public void SetSpeed(float _speed)
    {
        MoveSpeed = _speed;
    }

    void Start () {

        InitColor= this.GetComponent<Image>().color;
        InitColor.a = 0;
        this.GetComponent<Image>().color = InitColor;
        int rand = Random.Range(0, 2);
        if(rand ==1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            //right walk
            bRight = true;
        }        
        StartCoroutine(StartColor());
        if(MoveType ==0)
            StartCoroutine(StartMove());
    }
    IEnumerator StartMove()
    {
        yield return new WaitForSeconds(0.1f);
        if(bRight == true)
        {
            WalkRight();
        }
        else
        {
            WalkLeft();
        }
        StartCoroutine(StartMove());
    }
    IEnumerator StartColor()
    {        
        yield return new WaitForSeconds(0.001f);
        InitColor.a +=0.01f;
        this.GetComponent<Image>().color = InitColor;
        if(InitColor.a <1)
        {
            StartCoroutine(StartColor());
        }
        else
        {
            StartCoroutine(EndView());
        }
    }
    IEnumerator EndColor()
    {
        yield return new WaitForSeconds(0.001f);
        InitColor.a -= 0.01f;
        this.GetComponent<Image>().color = InitColor;
        if (InitColor.a > 0)
        {
            StartCoroutine(EndColor());
        }
        else
        {
            //Debug.Log("End Anim Zombie");
            StopCoroutine(EndColor());
            StopCoroutine(StartMove());
        }
    }
    public void EndViewStart()
    {
        StartCoroutine(EndColor());
    }
    
    IEnumerator EndView()
    {
        int time = Random.Range(35, 40);
        yield return new WaitForSeconds(time);
        StartCoroutine(EndColor());
    }
    // Update is called once per frame
    void Update () {
		
	}

    void WalkLeft()
    {
        Vector2 Move = this.transform.localPosition;
        Move.x -= MoveSpeed;
        this.transform.localPosition = Move;
    }
    void WalkRight()
    {
        Vector2 Move = this.transform.localPosition;
        Move.x += MoveSpeed;
        this.transform.localPosition = Move;
    }
}
