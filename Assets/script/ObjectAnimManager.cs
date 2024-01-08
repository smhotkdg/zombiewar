using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAnimManager : MonoBehaviour
{

    // Use this for initialization
    //-325 ~ 325
    public int MoveProbability = 0;
    float speed = 1;
    Vector2 Move = new Vector2();
    void Start()
    {
        StartCoroutine(AnimController());
    }
   
    IEnumerator AnimController()
    {
        yield return new WaitForSeconds(3f);
        {
            int rand = Random.Range(0, 3);
            if (rand == 0)
            {
                this.GetComponent<Animator>().SetBool("isWork", true);
                yield return new WaitForSeconds(10f);
                this.GetComponent<Animator>().SetBool("isWork", false);                
            }         
            if (rand == 1)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                this.GetComponent<Animator>().SetBool("isWalk", true);
                Vector2 Move = this.transform.localPosition;
                if (Move.x > -325)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        yield return new WaitForSeconds(0.1f);
                        if (Move.x > -325)
                        {
                            WalkLeft();
                        }
                    }
                    this.GetComponent<Animator>().SetBool("isWalk", false);
                }

            }
            if (rand == 2)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                this.GetComponent<Animator>().SetBool("isWalk", true);
                Vector2 Move = this.transform.localPosition;
                if (Move.x < 325)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        yield return new WaitForSeconds(0.1f);
                        if (Move.x < 325)
                        {
                            WalkRight();
                        }
                    }
                    this.GetComponent<Animator>().SetBool("isWalk", false);
                }
            }            
            StartCoroutine(AnimController());            
        }
    }
    void WalkLeft()
    {
        Vector2 Move = this.transform.localPosition;        
        Move.x -= speed;
        this.transform.localPosition = Move;
    }
    void WalkRight()
    {
        Vector2 Move = this.transform.localPosition;        
        Move.x += speed;
        this.transform.localPosition = Move;
    }

}