using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadMainmenuButton()
    {
        Time.timeScale = 1f;
        SharedUI.NEXT_SCENE_TO_BE_LOAD = "Start menu";
        SceneManager.LoadScene("Loading");
    }
}
