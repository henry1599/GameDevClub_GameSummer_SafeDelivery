using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBack : MonoBehaviour
{
    public void LoadBackToMainMenu()
    {
        SharedUI.NEXT_SCENE_TO_BE_LOAD = "Start menu";
        SceneManager.LoadScene("Loading");
    }
}
