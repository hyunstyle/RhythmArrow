using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_EventMaster : MonoBehaviour
{
    public delegate void GameManagerEventHandler();

    public event GameManagerEventHandler MenuToggleEvent;
    public event GameManagerEventHandler InventoryUIToggleEvent;
    public event GameManagerEventHandler RestartLevelEvent;
    public event GameManagerEventHandler GoToMenuSceneEvent;
    public event GameManagerEventHandler GameOverEvent;
    public event GameManagerEventHandler GoToResultMenuEvent;

    public bool isGameOver;
    public bool isInventoryUIOn;
    public bool isMenuOn;

    public void CallEventMenuToggle() // 메뉴 호출
    {
        if (MenuToggleEvent != null)
        {
            MenuToggleEvent();
        }
    }

    public void CallEventInventoryUIToggle()
    {
        if (InventoryUIToggleEvent != null)
        {
            InventoryUIToggleEvent();
        }
    }

    public void CallEventRestartLevel()
    {
        if (RestartLevelEvent != null)
        {
            RestartLevelEvent();
        }
    }

    public void CallEventGoToMenuScene()
    {
        if (GoToMenuSceneEvent != null)
        {
            GoToMenuSceneEvent();
        }
    }

    public void CallEventGameOver()
    {
        if (GameOverEvent != null)
        {
            isGameOver = true;
            GameOverEvent();
        }
    }

    public void CallEventGoToResultMenu()
    {
        if (GoToResultMenuEvent != null)
        {
            GoToResultMenuEvent();
        }
    }
}
