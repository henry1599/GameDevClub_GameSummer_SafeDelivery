using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    private void Start()
    {
        LoadSceneByName(SharedUI.NEXT_SCENE_TO_BE_LOAD);
    }
    public void LoadSceneByName(string _name)
    {
        StartCoroutine(Timing(_name));
    }

    IEnumerator Timing(string _name)
    {
        yield return new WaitForSeconds(Random.Range(3, 5));
        SceneManager.LoadScene(_name);
        SharedUI.CURRENT_SCENE = _name;
    }
}
