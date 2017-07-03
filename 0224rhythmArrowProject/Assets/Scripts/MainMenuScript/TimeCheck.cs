using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCheck : MonoBehaviour {

    private static TimeCheck instance;
    public static TimeCheck Instance
    {
        get
        {
            if (instance == null)
            {
                return GameObject.FindObjectOfType<TimeCheck>();
            }
            return TimeCheck.instance;
        }
    }

    public static float tempTime;
    public GameObject mainMenuCanvas;

	void Start ()
    {
		
	}
	
	
	void Update ()
    {
        if(mainMenuCanvas.activeSelf)
            tempTime = Time.time;

       // Debug.Log(tempTime);
	}
}
