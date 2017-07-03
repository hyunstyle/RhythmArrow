using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;


public class Song : MonoBehaviour
{
    
    bool isEditing;

    public Container[] container;

    public AudioSource audioSource;

    public string songIndex;

    public float[] CommandsArray;

    public float[] CommandsArray_trans;

    public List<float> editCommandList;

    private void Awake()
    {
        isEditing = GameManager_GenerateArrow.Instance.isEditing;
        string[] songNameSplit = gameObject.name.Split('-');
        songIndex = songNameSplit[1];

    }


    private void Start()
    {
        if(isEditing)
        GameManager_Editmode.Instance.songPlaying = this;

        editCommandList = new List<float>();

        container = new Container[10];

        audioSource = GetComponent<AudioSource>();

        if (!GameManager_GenerateArrow.Instance.isEditing)
        {
            AudioPeer.Instance._audioSource = GetComponent<AudioSource>();
            AudioPeer.Instance.isPlaying = true;
        }
        
        if (!isEditing)
        LoadSongInfo();
        
        asdfasddf();

        GameManager_Input.Instance.setCommand();

        if (CommandsArray.Length > 0)
        {
            Debug.Log("CommandsArray.Length : " + CommandsArray.Length);
            TranslateCommandsArray();
        }

        SetStartEnd();
    }

    private void Update()
    {
        if(isEditing && Input.GetKeyDown(KeyCode.Space))
        {
            editCommandList.Add(Time.time);
        }
    }

    public void SaveSong()
    {
        CommandsArray = new float[editCommandList.Count];

        for (int i = 0; i < editCommandList.Count; i++)
        {
            CommandsArray[i] = editCommandList[i];
        }
        SaveLoadSong.SaveSong(this);      
    }

    public void LoadSongInfo()
    {
        float[] loadedCommands = SaveLoadSong.LoadPlayer(songIndex);

        CommandsArray = loadedCommands;

        Debug.Log("Commands loaded");
    }

    private void TranslateCommandsArray()
    {
        CommandsArray_trans = new float[CommandsArray.Length];

        for (int i = 0; i < CommandsArray.Length - 1; i++)
        {
            CommandsArray_trans[i] = CommandsArray[i + 1] - CommandsArray[i];
        }
    }

    private void SetStartEnd()
    {
    //    GameManager_Timer.Instance.startTime = CommandsArray[0];  //첫번째 커맨드의 시작 시점
    //    GameManager_Timer.Instance.endTime = CommandsArray[CommandsArray.Length - 1]; //마지막 노드끝나는 시점
    //    GameManager_Timer.Instance.isLoaded = true;
    }

    private void asdfasddf()        //각컨테이너들에게 스크립트를 부여하는 함수. 커맨드 어레이를 각 컨테이너마다 랜덤으로 분배한다.
    {
        if (!GameManager_GenerateArrow.Instance.isEditing)
        {
            container[1] = GameObject.Find("Container1").GetComponent<Container>();
            container[2] = GameObject.Find("Container2").GetComponent<Container>();
            container[3] = GameObject.Find("Container3").GetComponent<Container>();
            container[4] = GameObject.Find("Container4").GetComponent<Container>();
            container[6] = GameObject.Find("Container6").GetComponent<Container>();
            container[7] = GameObject.Find("Container7").GetComponent<Container>();
            container[8] = GameObject.Find("Container8").GetComponent<Container>();
            container[9] = GameObject.Find("Container9").GetComponent<Container>();
        }
        int j = 0;
        for (int i = 1; i < container.Length; i++)
        {
            if (i == 5)
                continue;
               
            container[i].LoadingCommands();

            container[i].songPlaying = GetComponent<Song>();

            container[i].isPlaying = true;
        }

        for (int i = 0; i < CommandsArray.Length ; i++)
        {
            j = Random.Range(1, 10);

            while (j==5)
            {
                j = Random.Range(1, 10);
            }

            container[j].commands.Add( CommandsArray[i] - 1.0f);
        }
    }


}
