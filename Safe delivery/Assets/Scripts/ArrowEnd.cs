using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowEnd : MonoBehaviour
{
    public Transform endPoint;
    public Transform[] habitats;
    public float speed;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        follow();
        Vector2 direction = endPoint.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    void follow()
    {
        if (Vector2.Distance(rb.position, habitats[Shared.CURRENT_SHIPPER].position) > 0.2f)
        {
            //rb.velocity = (habitats[SwitchingShipper.Instance.currentIdx].position - transform.position).normalized * speed;
            //transform.Translate(habitats[SwitchingShipper.Instance.currentIdx].position);
            rb.MovePosition(habitats[Shared.CURRENT_SHIPPER].position);
        }
    }
}
