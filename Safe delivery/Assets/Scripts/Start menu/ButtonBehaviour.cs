using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    public Animator transition;
    public void HightlightedHover()
    {
        FindObjectOfType<AudioManager>().Play("Select");
    }

    public void StartToPlay()
    {
        SharedUI.NEXT_SCENE_TO_BE_LOAD = "Gameplay";
        SceneManager.LoadScene("Loading");
    }

    public void BackToMainMenu()
    {
        StartCoroutine(LoadStartMenuTrasition());
    }

    IEnumerator LoadStartMenuTrasition()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Start menu");
    }
}
