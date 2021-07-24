using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinField : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && CollectingSystem.isCollectEnough == true)
        {
            Shared.IS_WIN = true;
        }
    }
}
