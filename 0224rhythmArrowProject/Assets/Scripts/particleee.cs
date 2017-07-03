using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleee : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(0), false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
