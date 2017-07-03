using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Input : MonoBehaviour {

    private static GameManager_Input instance;
    public static GameManager_Input Instance
    {
        get
        {
            if (instance == null)
            {
                return GameObject.FindObjectOfType<GameManager_Input>();
            }
            return GameManager_Input.instance;
        }
    }

    public Container[] container;

    public int[] commandindex; 

    public Animator anim;

    private bool isChecking;

    void Start()
    {
        anim = GetComponent<Animator>();

        container = new Container[10];

        commandindex = new int[container.Length];

        for (int i = 0; i < commandindex.Length; i++)
        {
            commandindex[i] = 0;
        }

        container[1] = GameObject.Find("Container1").GetComponent<Container>();
        container[2] = GameObject.Find("Container2").GetComponent<Container>();
        container[3] = GameObject.Find("Container3").GetComponent<Container>();
        container[4] = GameObject.Find("Container4").GetComponent<Container>();
        container[6] = GameObject.Find("Container6").GetComponent<Container>();
        container[7] = GameObject.Find("Container7").GetComponent<Container>();
        container[8] = GameObject.Find("Container8").GetComponent<Container>();
        container[9] = GameObject.Find("Container9").GetComponent<Container>();

    }

    void Update()
    {
        InputHandler();
    }

    public void setCommand()
    {
        
    }

    void InputHandler()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            anim.SetTrigger("DownLeft");
            return;
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            anim.SetTrigger("Down");
            return;
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            anim.SetTrigger("DownRight");
            return;
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            anim.SetTrigger("Left");
            return;
        }
             
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            anim.SetTrigger("Right");
            return;
        }
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            anim.SetTrigger("UpLeft");
            return;
        }
         if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            anim.SetTrigger("Up");
            return;
        }
        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            anim.SetTrigger("UpRight");
            return;
        }
      
    }

    public void CheckCorrect(int input)
    {
        anim.SetTrigger("Idle");
        anim.ResetTrigger("Up");
        anim.ResetTrigger("Down");
        anim.ResetTrigger("Left");
        anim.ResetTrigger("Right");
        anim.ResetTrigger("UpLeft");
        anim.ResetTrigger("UpRight");
        anim.ResetTrigger("DownLeft");
        anim.ResetTrigger("DownRight");

        if (!isChecking)
        {
            isChecking = true;

            if (CompareTime(input) == -1 )  //화살표가 근처에 있지도않은데 막눌렀을경우 (손풀기상황)
            {
                return;
            }

            GameManager_GenerateArrow.Instance.judgeCounter(CompareTime(input));     


        }

        input = 0;

        isChecking = false;
    }

    int CompareTime(int index)
    {
        float temp = Time.time - TimeCheck.tempTime ;
        
        if ((container[index].commands[commandindex[index]] + 1) < temp + 0.5f)
        {
           
            return CalScore(index, temp);

        }

        return -1;
    }

    int CalScore(int index, float inputTime)
    {     
        if ((container[index].commands[commandindex[index]] + 1) <= inputTime + 0.2f && (container[index].commands[commandindex[index]] + 1) >= inputTime + 0.1f) //0.1초
        {
            return 2;
        }
                                                                                 //perfect
        else if((  container[index].commands[commandindex[index]] + 1) <= inputTime + 0.4f &&  (container[index].commands[commandindex[index]] + 1) >= inputTime - 0.3f  ) //0.1초
        {
            return 1;
        }
           
        else
        {
            return 0;
        }      
    }
}


