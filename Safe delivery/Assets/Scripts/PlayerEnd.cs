using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnd : MonoBehaviour
{
    public GameObject arrowEnd;

    // Update is called once per frame
    void Update()
    {
        if (CollectingSystem.isCollectEnough == true)
        {
            arrowEnd.SetActive(true);
        }
        else
        {
            arrowEnd.SetActive(false);
        }
    }
}
