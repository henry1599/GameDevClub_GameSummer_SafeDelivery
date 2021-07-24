using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStartGame : MonoBehaviour
{
    public Animator transition;
    public void LoadStartMenu()
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
