using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public Animator transition;
    public void LoadGameplay()
    {
        StartCoroutine(LoadStartMenuTrasition());
    }

    IEnumerator LoadStartMenuTrasition()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Level choosing");
    }

}
