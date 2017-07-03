using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_Editmode : MonoBehaviour
{
    private static GameManager_Editmode instance;
    public static GameManager_Editmode Instance
    {
        get
        {
            if (instance == null)
            {
                return GameObject.FindObjectOfType<GameManager_Editmode>();
            }
            return GameManager_Editmode.instance;
        }
    }

    public Song songPlaying;

    [SerializeField]
    bool isEditing;

    [SerializeField]
    private Text recordText;

    [SerializeField]
    private Button endButton;
    
    private void Start()
    {
        if (isEditing)
        {
            recordText.gameObject.SetActive(true);
            endButton.gameObject.SetActive(true);
        }
        else
        {
            recordText.gameObject.SetActive(false);
            endButton.gameObject.SetActive(false);
        }
    }

    public void SaveSong()
    {
        songPlaying.SaveSong();
    }
}
