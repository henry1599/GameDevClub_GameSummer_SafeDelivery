using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AboutButton : MonoBehaviour
{
    public Animator transition;
    public void LoadAbout()
    {
        StartCoroutine(LoadAboutTrasition());
    }

    IEnumerator LoadAboutTrasition()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("About");
    }
}
