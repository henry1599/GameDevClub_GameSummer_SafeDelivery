using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialButton : MonoBehaviour
{
    public void LoadTutorial()
    {
        SharedUI.NEXT_SCENE_TO_BE_LOAD = "Tutorial";
        SceneManager.LoadScene("Loading");
    }
}
