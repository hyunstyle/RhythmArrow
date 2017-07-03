using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_GotoResultmenu : MonoBehaviour
{
    private static GameManager_GotoResultmenu instance;
    public static GameManager_GotoResultmenu Instance
    {
        get
        {
            if (instance == null)
            {
                return GameObject.FindObjectOfType<GameManager_GotoResultmenu>();
            }
            return GameManager_GotoResultmenu.instance;
        }
    }


    private GameManager_EventMaster eventMaster;
    public GameObject resultMenu;

    void OnEnable()
    {
        SetInitializeReferecnes();
        eventMaster.GoToResultMenuEvent += GoToResultCanvas; 
    }

    void SetInitializeReferecnes()
    {
        eventMaster = GetComponent<GameManager_EventMaster>();
    }

    public void GoToResultCanvas()
    {
        resultMenu.SetActive(!resultMenu.activeSelf); 
        if(resultMenu.activeSelf)
        {
            GameManager_GenerateArrow.Instance.judgeRank(true);
        }

    }
}
