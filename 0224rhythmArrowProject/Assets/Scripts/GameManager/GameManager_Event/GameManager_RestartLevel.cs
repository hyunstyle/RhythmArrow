using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_RestartLevel : MonoBehaviour {
    private GameManager_EventMaster eventMaster;

    void OnEnable()
    {
        SetInitializeReferences();
        eventMaster.RestartLevelEvent += RestartLevel;
    }

    void OnDisable()
    {
        eventMaster.RestartLevelEvent -= RestartLevel;
    }

    void SetInitializeReferences()
    {
        eventMaster = GetComponent<GameManager_EventMaster>();
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(1);
        if (Time.timeScale == 0)
            Time.timeScale = 1;
    }

}
