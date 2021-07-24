using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeToAudio : MonoBehaviour
{
    public AudioSource sound;
    public float minDistance;
    public float maxDistance;
    public Transform[] players;
    private bool isPlaying = false;
    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(players[Shared.CURRENT_SHIPPER].position, transform.position);
        if (distance > maxDistance)
        {
            sound.volume = 0;
        }
        else if (distance < minDistance)
        {
            sound.volume = 1;
        }
        else
        {
            sound.volume = 1 - ((distance - minDistance) / (maxDistance - minDistance));
        }
        if (isPlaying == false)
        {
            isPlaying = true;
            StartCoroutine(PlaySound());
        }
        
    }

    IEnumerator PlaySound()
    {
        sound.Play();
        yield return new WaitForSeconds(0.5f);
        isPlaying = false;
    }
}
