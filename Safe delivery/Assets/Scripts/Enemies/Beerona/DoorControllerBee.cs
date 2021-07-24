using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControllerBee : MonoBehaviour
{
    public Transform pointUp;
    public Transform pointDown;
    public float speed;
    // Update is called once per frame
    void Update()
    {
        if (Sharedbee.IS_ACTIVATE == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointUp.position, speed * Time.deltaTime);
        }
        if (Sharedbee.IS_DEATH == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointDown.position, speed * Time.deltaTime);
        }
    }
}
