using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    enum SHIPPERS
    {
        SHOPEE = 0,
        BEE = 1,
        GRAB = 2,
        FAST = 3
    }
    public float rotationSpeed;
    public float distance;
    public LineRenderer[] lines;
    public Gradient[] colorGradient;
    public GameObject[] explore;
    public bool[] isSpawn;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        RaycastHit2D hitInfo1 = Physics2D.Raycast(transform.position, transform.right, distance);
        RaycastHit2D hitInfo2 = Physics2D.Raycast(transform.position, transform.up, distance);
        RaycastHit2D hitInfo3 = Physics2D.Raycast(transform.position, -transform.right, distance);
        RaycastHit2D hitInfo4 = Physics2D.Raycast(transform.position, -transform.up, distance);
        RaycastHit2D hitInfo5 = Physics2D.Raycast(transform.position, transform.right + transform.up, distance);
        RaycastHit2D hitInfo6 = Physics2D.Raycast(transform.position, -transform.right + transform.up, distance);
        RaycastHit2D hitInfo7 = Physics2D.Raycast(transform.position, -transform.right + -transform.up, distance);
        RaycastHit2D hitInfo8 = Physics2D.Raycast(transform.position, transform.right + -transform.up, distance);

        if (hitInfo1.collider != null)
        {
            lines[0].SetPosition(1, hitInfo1.point);
            lines[0].colorGradient = colorGradient[0];
            if (hitInfo1.transform.tag.Equals("Player"))
            {
                if (Shared.CURRENT_SHIPPER != (int)SHIPPERS.SHOPEE)
                {
                    if (Shared.CURRENT_SHIPPER == (int)SHIPPERS.BEE)
                    {
                        PlayerControllerBee.Instance.transform.GetComponent<PlayerBehavior>().TakeDamage(10);
                    }
                    if (Shared.CURRENT_SHIPPER == (int)SHIPPERS.GRAB)
                    {
                        PlayerControllerGrab.Instance.transform.GetComponent<PlayerBehavior>().TakeDamage(10);
                    }
                    if (Shared.CURRENT_SHIPPER == (int)SHIPPERS.FAST)
                    {
                        PlayerControllerFast.Instance.transform.GetComponent<PlayerBehavior>().TakeDamage(10);
                    }
                }
                else
                {
                    PlayerControllerShopee.Instance.transform.GetComponent<PlayerBehavior>().Heal(10);
                }
            }
            if (isSpawn[0] == false)
            {
                StartCoroutine(Spawn(explore[0], hitInfo1.point, 0));
            }
        }
        else
        {
            lines[0].SetPosition(1, transform.position + transform.right * distance);
        }


        if (hitInfo2.collider != null)
        {
            lines[1].SetPosition(1, hitInfo2.point);
            lines[1].colorGradient = colorGradient[1];
            if (hitInfo2.transform.tag.Equals("Player"))
            {
                if (Shared.CURRENT_SHIPPER != (int)SHIPPERS.GRAB)
                {
                    if (Shared.CURRENT_SHIPPER == (int)SHIPPERS.BEE)
                    {
                        PlayerControllerBee.Instance.transform.GetComponent<PlayerBehavior>().TakeDamage(5);
                    }
                    if (Shared.CURRENT_SHIPPER == (int)SHIPPERS.SHOPEE)
                    {
                        PlayerControllerShopee.Instance.transform.GetComponent<PlayerBehavior>().TakeDamage(5);
                    }
                    if (Shared.CURRENT_SHIPPER == (int)SHIPPERS.FAST)
                    {
                        PlayerControllerFast.Instance.transform.GetComponent<PlayerBehavior>().TakeDamage(5);
                    }
                }
                else
                {
                    PlayerControllerGrab.Instance.transform.GetComponent<PlayerBehavior>().Heal(10);
                }
            }
            if (isSpawn[1] == false)
            {
                StartCoroutine(Spawn(explore[1], hitInfo2.point, 1));
            }
        }
        else
        {
            lines[1].SetPosition(1, transform.position + transform.up * distance);
        }


        if (hitInfo3.collider != null)
        {
            lines[2].SetPosition(1, hitInfo3.point);
            lines[2].colorGradient = colorGradient[2];
            if (hitInfo3.transform.tag.Equals("Player"))
            {
                if (Shared.CURRENT_SHIPPER != (int)SHIPPERS.SHOPEE)
                {
                    if (Shared.CURRENT_SHIPPER == (int)SHIPPERS.BEE)
                    {
                        PlayerControllerBee.Instance.transform.GetComponent<PlayerBehavior>().TakeDamage(5);
                    }
                    if (Shared.CURRENT_SHIPPER == (int)SHIPPERS.GRAB)
                    {
                        PlayerControllerGrab.Instance.transform.GetComponent<PlayerBehavior>().TakeDamage(5);
                    }
                    if (Shared.CURRENT_SHIPPER == (int)SHIPPERS.FAST)
                    {
                        PlayerControllerFast.Instance.transform.GetComponent<PlayerBehavior>().TakeDamage(5);
                    }
                }
                else
                {
                    PlayerControllerShopee.Instance.transform.GetComponent<PlayerBehavior>().Heal(10);
                }
            }
            if (isSpawn[2] == false)
            {
                StartCoroutine(Spawn(explore[2], hitInfo3.point, 2));
            }
        }
        else
        {
            lines[2].SetPosition(1, transform.position + -transform.right * distance);
        }


        if (hitInfo4.collider != null)
        {
            lines[3].SetPosition(1, hitInfo4.point);
            lines[3].colorGradient = colorGradient[3];
            if (hitInfo4.transform.tag.Equals("Player"))
            {
                if (Shared.CURRENT_SHIPPER != (int)SHIPPERS.GRAB)
                {
                    if (Shared.CURRENT_SHIPPER == (int)SHIPPERS.BEE)
                    {
                        PlayerControllerBee.Instance.transform.GetComponent<PlayerBehavior>().TakeDamage(5);
                    }
                    if (Shared.CURRENT_SHIPPER == (int)SHIPPERS.SHOPEE)
                    {
                        PlayerControllerShopee.Instance.transform.GetComponent<PlayerBehavior>().TakeDamage(5);
                    }
                    if (Shared.CURRENT_SHIPPER == (int)SHIPPERS.FAST)
                    {
                        PlayerControllerFast.Instance.transform.GetComponent<PlayerBehavior>().TakeDamage(5);
                    }
                }
                else
                {
                    PlayerControllerGrab.Instance.transform.GetComponent<PlayerBehavior>().Heal(10);
                }
            }
            if (isSpawn[3] == false)
            {
                StartCoroutine(Spawn(explore[3], hitInfo4.point, 3));
            }
        }
        else
        {
            lines[3].SetPosition(1, transform.position + -transform.up * distance);
        }

        if (hitInfo5.collider != null)
        {
            lines[4].SetPosition(1, hitInfo5.point);
            lines[4].colorGradient = colorGradient[4];
            if (hitInfo5.transform.tag.Equals("Player"))
            {
                if (Shared.CURRENT_SHIPPER != (int)SHIPPERS.BEE)
                {
                    if (Shared.CURRENT_SHIPPER == (int)SHIPPERS.SHOPEE)
                    {
                        PlayerControllerShopee.Instance.transform.GetComponent<PlayerBehavior>().TakeDamage(5);
                    }
                    if (Shared.CURRENT_SHIPPER == (int)SHIPPERS.GRAB)
                    {
                        PlayerControllerGrab.Instance.transform.GetComponent<PlayerBehavior>().TakeDamage(5);
                    }
                    if (Shared.CURRENT_SHIPPER == (int)SHIPPERS.FAST)
                    {
                        PlayerControllerFast.Instance.transform.GetComponent<PlayerBehavior>().TakeDamage(5);
                    }
                }
                else
                {
                    PlayerControllerBee.Instance.transform.GetComponent<PlayerBehavior>().Heal(10);
                }
            }
            if (isSpawn[4] == false)
            {
                StartCoroutine(Spawn(explore[4], hitInfo5.point, 4));
            }
        }
        else
        {
            lines[4].SetPosition(1, transform.position + (transform.right + transform.up) * distance);
        }

        if (hitInfo6.collider != null)
        {
            lines[5].SetPosition(1, hitInfo6.point);
            lines[5].colorGradient = colorGradient[5];
            if (hitInfo6.transform.tag.Equals("Player"))
            {
                if (Shared.CURRENT_SHIPPER != (int)SHIPPERS.FAST)
                {
                    if (Shared.CURRENT_SHIPPER == (int)SHIPPERS.BEE)
                    {
                        PlayerControllerBee.Instance.transform.GetComponent<PlayerBehavior>().TakeDamage(5);
                    }
                    if (Shared.CURRENT_SHIPPER == (int)SHIPPERS.GRAB)
                    {
                        PlayerControllerGrab.Instance.transform.GetComponent<PlayerBehavior>().TakeDamage(5);
                    }
                    if (Shared.CURRENT_SHIPPER == (int)SHIPPERS.SHOPEE)
                    {
                        PlayerControllerShopee.Instance.transform.GetComponent<PlayerBehavior>().TakeDamage(5);
                    }
                }
                else
                {
                    PlayerControllerFast.Instance.transform.GetComponent<PlayerBehavior>().Heal(10);
                }
            }
            if (isSpawn[5] == false)
            {
                StartCoroutine(Spawn(explore[5], hitInfo6.point, 5));
            }
        }
        else
        {
            lines[5].SetPosition(1, transform.position + (-transform.right + transform.up) * distance);
        }

        if (hitInfo7.collider != null)
        {
            lines[6].SetPosition(1, hitInfo7.point);
            lines[6].colorGradient = colorGradient[6];
            if (hitInfo7.transform.tag.Equals("Player"))
            {
                if (Shared.CURRENT_SHIPPER != (int)SHIPPERS.BEE)
                {
                    if (Shared.CURRENT_SHIPPER == (int)SHIPPERS.SHOPEE)
                    {
                        PlayerControllerShopee.Instance.transform.GetComponent<PlayerBehavior>().TakeDamage(5);
                    }
                    if (Shared.CURRENT_SHIPPER == (int)SHIPPERS.GRAB)
                    {
                        PlayerControllerGrab.Instance.transform.GetComponent<PlayerBehavior>().TakeDamage(5);
                    }
                    if (Shared.CURRENT_SHIPPER == (int)SHIPPERS.FAST)
                    {
                        PlayerControllerFast.Instance.transform.GetComponent<PlayerBehavior>().TakeDamage(5);
                    }
                }
                else
                {
                    PlayerControllerBee.Instance.transform.GetComponent<PlayerBehavior>().Heal(10);
                }
            }
            if (isSpawn[6] == false)
            {
                StartCoroutine(Spawn(explore[6], hitInfo7.point, 6));
            }
        }
        else
        {
            lines[6].SetPosition(1, transform.position + (-transform.right + -transform.up) * distance);
        }
        

        if (hitInfo8.collider != null)
        {
            lines[7].SetPosition(1, hitInfo8.point);
            lines[7].colorGradient = colorGradient[7];
            if (hitInfo8.transform.tag.Equals("Player"))
            {
                if (Shared.CURRENT_SHIPPER != (int)SHIPPERS.FAST)
                {
                    if (Shared.CURRENT_SHIPPER == (int)SHIPPERS.BEE)
                    {
                        PlayerControllerBee.Instance.transform.GetComponent<PlayerBehavior>().TakeDamage(5);
                    }
                    if (Shared.CURRENT_SHIPPER == (int)SHIPPERS.GRAB)
                    {
                        PlayerControllerGrab.Instance.transform.GetComponent<PlayerBehavior>().TakeDamage(5);
                    }
                    if (Shared.CURRENT_SHIPPER == (int)SHIPPERS.SHOPEE)
                    {
                        PlayerControllerShopee.Instance.transform.GetComponent<PlayerBehavior>().TakeDamage(5);
                    }
                }
                else
                {
                    PlayerControllerFast.Instance.transform.GetComponent<PlayerBehavior>().Heal(10);
                }
            }
            if (isSpawn[7] == false)
            {
                StartCoroutine(Spawn(explore[7], hitInfo8.point, 7));
            }
        }
        else
        {
            lines[7].SetPosition(1, transform.position + (transform.right + -transform.up) * distance);
        }

        lines[0].SetPosition(0, transform.position);
        lines[1].SetPosition(0, transform.position);
        lines[2].SetPosition(0, transform.position);
        lines[3].SetPosition(0, transform.position);
        lines[4].SetPosition(0, transform.position);
        lines[5].SetPosition(0, transform.position);
        lines[6].SetPosition(0, transform.position);
        lines[7].SetPosition(0, transform.position);
    }

    IEnumerator Spawn(GameObject explore, Vector2 pos, int idx)
    {
        isSpawn[idx] = true;
        Instantiate(explore, pos, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        isSpawn[idx] = false;
    }
}

