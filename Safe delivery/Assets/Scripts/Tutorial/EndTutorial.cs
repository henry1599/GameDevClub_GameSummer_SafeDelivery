using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTutorial : MonoBehaviour
{
    public GameObject backGame;
    private void Start()
    {
        backGame.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("End tut"))
        {
            Debug.Log("End tutorial");
            backGame.SetActive(true);
        }
    }
}
