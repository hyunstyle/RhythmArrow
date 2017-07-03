using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Songlist : MonoBehaviour
{     
    //song 어레이에 따라서 버튼을생성한다.

    public static Songlist instance;

    public Song[] songs;

    public GameObject buttons;

    void Start()
    {
        if (instance == null)
            instance = this;

        GameManager_GenerateArrow.Instance.canvas.GetComponent<CanvasGroup>().alpha = 0;
        GameManager_GenerateArrow.Instance.canvas.GetComponent<CanvasGroup>().blocksRaycasts = false;
        CreateList();
    }

    void CreateList()
    {
        for (int i = 0; i < songs.Length; i++)
        {
            GameObject musicButton = (GameObject)Instantiate(buttons, this.transform);
            musicButton.GetComponentInChildren<Text>().text = songs[i].audioSource.clip.name;
            musicButton.GetComponent<SongSelectButton>().SetSong(songs[i]);
        }
    }

}
