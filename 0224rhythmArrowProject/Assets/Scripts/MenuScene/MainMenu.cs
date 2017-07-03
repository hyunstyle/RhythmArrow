using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
        public void PlayGame()
        {
            SceneManager.LoadScene("ingame2");
            if(Time.timeScale == 0)
                Time.timeScale = 1;

        }

        public void ExitGame()
        {
            Application.Quit();
        }

}
