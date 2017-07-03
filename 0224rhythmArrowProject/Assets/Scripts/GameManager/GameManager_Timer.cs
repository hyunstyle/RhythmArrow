using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_Timer : MonoBehaviour {

    private static GameManager_Timer instance;
    public static GameManager_Timer Instance
    {
        get
        {
            if (instance == null)
            {
                return GameObject.FindObjectOfType<GameManager_Timer>();
            }
            return GameManager_Timer.instance;
        }
    }
    void Start()
    {
        Time.timeScale = 0;

    }

    void Update()
    {
       //// Timer();               //countdown을 계속 늘려주고, text를 업데이트해준다.
       // CalContent();          //fillAmount를 계속 업데이트해준다.
       // CalContentColor();     //색을 업데이트해준다(선택)
    }

 

    //private void CalContent()
    //{
    //    TimerContent.fillAmount = countdown / secPerBlock;
    //}

    //private void CalContentColor()
    //{
    //    TimerContent.color = Color.Lerp(lowColor, fullColor, TimerContent.fillAmount);
    //}

}
