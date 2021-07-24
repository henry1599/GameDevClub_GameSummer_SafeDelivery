using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explore;
    private Transform target;
    private static Bullet instance;
    public float speed;
    public float rotateSpeed;
    private Rigidbody2D rb;

    public static Bullet Instance { get => instance; set => instance = value; }
    private void Start()
    {
        Physics2D.queriesStartInColliders = false;
        rb = transform.GetComponent<Rigidbody2D>();
        Instance = this;
    }

    private void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = rotateAmount * rotateSpeed;
        rb.velocity = transform.up * speed;
    }

    public void GetTarget(Transform _target)
    {
        target = _target;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.tag.Equals("Player"))
            Instantiate(explore, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.tag.Equals("Player"))
            Instantiate(explore, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
