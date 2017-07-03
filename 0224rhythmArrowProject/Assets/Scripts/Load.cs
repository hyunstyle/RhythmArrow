using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadSong : MonoBehaviour
{
    public static void SaveSong(Song song)
    {
        BinaryFormatter bf = new BinaryFormatter();

        FileStream stream = new FileStream(Application.dataPath + "/SaveCommands/song-" + song.songIndex + ".sav", FileMode.Create);

        Debug.Log(Application.dataPath + "/SaveCommands/song-" + song.songIndex + ".sav");

        SongData data = new SongData(song);

        bf.Serialize(stream, data);  //파일에저장

        stream.Close();
    }

    public static float[] LoadPlayer(string songIndex)
    {
        if (File.Exists(Application.dataPath + "/SaveCommands/song-" + songIndex + ".sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream stream = new FileStream(Application.dataPath + "/SaveCommands/song-" + songIndex + ".sav", FileMode.Open);

            SongData data = (SongData)bf.Deserialize(stream);

            stream.Close();

            return data.stats;
        }
        else
        {
            Debug.LogError(Application.dataPath + "/SaveCommands/song-.sav" + " : File does not exist.");

            return new float[0];
        }
    }
}

[Serializable]
public class SongData
{
    public float[] stats;

    public SongData(Song song)
    {
        //Song _song = song.GetComponent<Song>();
        stats = new float[song.CommandsArray.Length];

        for (int i = 0; i < stats.Length; i++)
        {
            stats[i] = song.CommandsArray[i];
        }
    }
}
