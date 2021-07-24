using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject explore;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Collect items");
            Instantiate(explore, transform.position, Quaternion.identity);
            CollectingSystem.collectedItems++;
            Destroy(gameObject);
        }
    }
}
