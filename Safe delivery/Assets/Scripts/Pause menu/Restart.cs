using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void LoadRestartButton()
    {
        Time.timeScale = 1f;
        SharedUI.NEXT_SCENE_TO_BE_LOAD = "Gameplay";
        SceneManager.LoadScene("Loading");
    }
}
