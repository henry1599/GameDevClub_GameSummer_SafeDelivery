using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayButton : MonoBehaviour
{
    public Animator transition;
    public void LoadHowToPlay()
    {
        StartCoroutine(LoadAboutTrasition());
    }

    IEnumerator LoadAboutTrasition()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("How to play");
    }
}
