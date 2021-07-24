using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTheGame : MonoBehaviour
{
    public void LoadTheGameplay()
    {
        SharedUI.NEXT_SCENE_TO_BE_LOAD = "Gameplay";
        SceneManager.LoadScene("Loading");
    }
}
