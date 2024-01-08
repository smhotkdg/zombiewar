using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

    // Use this for initialization
    public float speed = 0.5f;
    Material m_Material;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 offset = new Vector2(Time.time * speed, 0);

        m_Material = GetComponent<Renderer>().material;
        m_Material.mainTextureOffset = offset;
    }
}
