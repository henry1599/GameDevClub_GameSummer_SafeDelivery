using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBeeBehaviour : MonoBehaviour
{
    private Sound sound;
    public GameObject explore;
    enum SHIPPERS
    {
        SHOPEE = 0,
        BEE = 1,
        GRAB = 2,
        FAST = 3
    }
    private void Awake()
    {
        sound = FindObjectOfType<AudioManager>().GetSound("Hit");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            if (Shared.CURRENT_SHIPPER == (int)SHIPPERS.SHOPEE)
            {
                PlayerControllerShopee.Instance.transform.GetComponent<PlayerBehavior>().TakeDamage(50);
            }
            else if (Shared.CURRENT_SHIPPER == (int)SHIPPERS.BEE)
            {
                PlayerControllerBee.Instance.transform.GetComponent<PlayerBehavior>().TakeDamage(50);
            }
            else if (Shared.CURRENT_SHIPPER == (int)SHIPPERS.GRAB)
            {
                PlayerControllerGrab.Instance.transform.GetComponent<PlayerBehavior>().TakeDamage(50);
            }
            else if (Shared.CURRENT_SHIPPER == (int)SHIPPERS.FAST)
            {
                PlayerControllerFast.Instance.transform.GetComponent<PlayerBehavior>().TakeDamage(50);
            }
        }
        sound.source.volume = Attack.Instance.CalculateVolumeByDistance(Vector2.Distance(transform.position, Attack.Instance.players[Shared.CURRENT_SHIPPER].position));
        sound.source.Play();
        Instantiate(explore, new Vector3(transform.position.x, transform.position.y - 15f, 0), Quaternion.identity);
        Destroy(gameObject);
    }
}
