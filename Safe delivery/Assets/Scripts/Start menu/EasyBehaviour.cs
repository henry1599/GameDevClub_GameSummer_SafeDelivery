using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EasyBehaviour : MonoBehaviour
{
    public void LoadEasyGame()
    {
        SharedUI.NEXT_SCENE_TO_BE_LOAD = "Gameplay";
        SharedUI.LEVEL = 0;
        SceneManager.LoadScene("Loading");
    }
    public void LoadMediumGame()
    {
        SharedUI.NEXT_SCENE_TO_BE_LOAD = "Gameplay";
        SharedUI.LEVEL = 1;
        SceneManager.LoadScene("Loading");
    }
    public void LoadHardGame()
    {
        SharedUI.NEXT_SCENE_TO_BE_LOAD = "Gameplay";
        SharedUI.LEVEL = 2;
        SceneManager.LoadScene("Loading");
    }
    public void LoadExpertGame()
    {
        SharedUI.NEXT_SCENE_TO_BE_LOAD = "Gameplay";
        SharedUI.LEVEL = 3;
        SceneManager.LoadScene("Loading");
    }

    public void LoadBack()
    {
        SceneManager.LoadScene("Start menu");
    }
}
