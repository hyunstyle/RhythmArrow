using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_ToggleMenu : MonoBehaviour {

    private GameManager_EventMaster eventMaster;
    public GameObject menu;
    private bool isMenuOn;
    private bool isAudioPaused;

    // Use this for initialization
    void Start()
    {
        isMenuOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            isMenuOn = !isMenuOn;
        CheckForMenuToggleRequest();
        
    }

    void OnEnable()
    {
        SetInitialReferences();
        eventMaster.GameOverEvent += ToggleMenu; //gameOver시에 메뉴가 토글되도록
    }

    void OnDisable()
    {
        eventMaster.GameOverEvent -= ToggleMenu;
    }

    void SetInitialReferences()
    {
        eventMaster = GetComponent<GameManager_EventMaster>();
    }

    void CheckForMenuToggleRequest()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && !eventMaster.isGameOver && !eventMaster.isInventoryUIOn)
        {
            ToggleMenu();
            if(isMenuOn)
            {
                AudioPeer.Instance._audioSource.Pause();
                isAudioPaused = true;
            }
            else
            {
                AudioPeer.Instance._audioSource.Play();
                isAudioPaused = false;
            }
        }
    }

    void ToggleMenu()  //메뉴를 킨다. 메뉴토글 이벤트를 호출한다.
    {
        if (menu != null)
        {
            menu.SetActive(!menu.activeSelf); // 메뉴를 키려면 SetActive(true)-> activeself 아닐때=메뉴 자신이 안보이는 상태일때, 안보이게하려면 거꾸로 SetActive(false)
            eventMaster.isMenuOn = !eventMaster.isMenuOn;
            eventMaster.CallEventMenuToggle();
        }
        else // 게임오브젝트 생성되지 않았을때 에러
        {
            Debug.LogWarning("YOU NEED TO ASSIGN UI GAMEOBJECT TO THE TOGGLE MENU SCRIPT IN THE INSPECTOR");
        }
    }
}
