using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Destroy());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private  IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1.0f);

        Destroy(gameObject);
    }
}
