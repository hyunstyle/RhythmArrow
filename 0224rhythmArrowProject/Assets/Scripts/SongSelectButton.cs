using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongSelectButton : MonoBehaviour
{
    private Song songToPlay;

    public void SetGame()
    {
        //Instantiate(Songlist.instance.buttons, Song )
        GetComponentInParent<CanvasGroup>().alpha = 0;
        GetComponentInParent<CanvasGroup>().blocksRaycasts = false;

        GameManager_GenerateArrow.Instance.canvas.GetComponent<CanvasGroup>().alpha = 1;
        GameManager_GenerateArrow.Instance.canvas.GetComponent<CanvasGroup>().blocksRaycasts = true;

        Song song = Instantiate(songToPlay);
        song.name = "Song-" + songToPlay.songIndex;

        Time.timeScale = 1;       //노래를 골라야 시간이 흐르기시작함

        for (int i = 1; i < 10; i++)
        {
            if (i == 5)
                continue;
            if(!GameManager_GenerateArrow.Instance.isEditing)
            EffectManager.Instance.guideArrow[i].SetActive(true);
        }
    }

    public void SetSong(Song _songToPlay)
    {
        songToPlay = _songToPlay;
    }
}
