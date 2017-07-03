using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_GotoMainmenu : MonoBehaviour {

    private GameManager_EventMaster eventMaster;

    void OnEnable()
    {
        SetInitializeReferecnes();
        eventMaster.GoToMenuSceneEvent += GoToMenuScene;
    }

    void OnDisable()
    {
        eventMaster.GoToMenuSceneEvent -= GoToMenuScene;
    }

    void SetInitializeReferecnes()
    {
        eventMaster = GetComponent<GameManager_EventMaster>();
    }

    public void GoToMenuScene()
    {
        SceneManager.LoadScene(0);
    }


}
