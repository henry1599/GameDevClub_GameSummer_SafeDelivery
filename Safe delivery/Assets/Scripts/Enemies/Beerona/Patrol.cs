using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    private float timeWait;
    public float startTimeWait;
    private Vector2 moveSpot;
    // Start is called before the first frame update
    void Start()
    {
        timeWait = startTimeWait;
        moveSpot = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpot) < 0.02f)
        {
            if (timeWait <= 0)
            {
                timeWait = startTimeWait;
                moveSpot = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            }
            else
            {
                timeWait -= Time.deltaTime;
            }
        }
    }
}
