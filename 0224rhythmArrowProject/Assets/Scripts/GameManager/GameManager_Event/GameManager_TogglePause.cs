using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_TogglePause : MonoBehaviour {
    private GameManager_EventMaster eventMaster;
    private bool isPaused;

    void OnEnable()
    {
        SetInitialReferences();
        eventMaster.MenuToggleEvent += TogglePause;          //menutoggleevent가 발생하면 togglepause가 호출된다.
        eventMaster.InventoryUIToggleEvent += TogglePause;   //인벤토리 ui toggle이벤트가 발생하면 togglepause가 호출된다.
    }

    void OnDisable()
    {
        eventMaster.MenuToggleEvent -= TogglePause;
        eventMaster.InventoryUIToggleEvent -= TogglePause;
    }

    void SetInitialReferences()
    {
        eventMaster = GetComponent<GameManager_EventMaster>();
    }

    void TogglePause()
    {
        if (isPaused)              //지금까지 pause가 되어있었다면
        {
            Time.timeScale = 1;   //timescale이  1이면 정삭작동
            isPaused = false;     //다시 pause를 풀어준다.
        }
        else                      //지금까지 게임이 진행중이라면
        {
            Time.timeScale = 0;   //timescale이 0이면 정지
            isPaused = true;      //현재는 pasue중이다.
        }
    }

}
