using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BashAbility : MonoBehaviour
{
    [Header("Bash Ability")]
    public float RadiusBash;
    private GameObject BashAbleObj;
    private bool nearToBashAbleObj;
    //private bool isChoosingDirection;
    public float bashPower;
    public float bashTime;
    public GameObject arrow;
    private Vector2 bashDirection;
    private float bashTimeReset;
    public GameObject arrowPivot;
    private Rigidbody2D rb;
    public GameObject bashEffect;
    private bool isChoosingDirection;
    private bool somethingKeepTheAudioBashPlayOnce;
    // Start is called before the first frame update
    void Start()
    {
        somethingKeepTheAudioBashPlayOnce = false;
        rb = transform.GetComponent<Rigidbody2D>();
        bashTimeReset = bashTime;
        isChoosingDirection = false;
        ShareVariables.IS_BASHING = false;
    }

    // Update is called once per frame
    void Update()
    {
        Bash();
    }

    //////////////////////////////////////-- BASH
    void Bash()
    {
        Debug.Log("Go to this ???");
        //RaycastHit2D[] Rays = Physics2D.CircleCastAll(transform.position, RadiusBash, Vector3.forward);
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, RadiusBash);
        //foreach (RaycastHit2D ray in Rays)
        //{
        //    Debug.Log("Inside foreach");
        //    nearToBashAbleObj = false;
        //    if (ray.collider.tag.Equals("Bashable") || ray.collider.tag.Equals("Enemy") || ray.collider.tag.Equals("Enemy Bullet"))
        //    {
        //        Debug.Log("Found near");
        //        nearToBashAbleObj = true;
        //        BashAbleObj = ray.collider.transform.gameObject;
        //        break;
        //    }
        //}

        foreach (Collider2D col in cols)
        {
            nearToBashAbleObj = false;
            if (col.tag.Equals("Bashable") || col.tag.Equals("Enemy") || col.tag.Equals("Enemy Bullet") || col.tag.Equals("Bullet beerona"))
            {
                nearToBashAbleObj = true;
                BashAbleObj = col.transform.gameObject;
                break;
            }
        }
        if (nearToBashAbleObj == true)
        {
            if (Input.GetKey(KeyCode.F) && ShareVariables.IS_LAUNCHING == false && ShareVariables.CURRENT_ENERGY >= 20)
            {
                if (somethingKeepTheAudioBashPlayOnce == false)
                {
                    FindObjectOfType<AudioManager>().Play("Bash");
                    somethingKeepTheAudioBashPlayOnce = true;
                }
                Shared.IS_ENABLE_TO_SWITCH = false;
                Time.timeScale = 0f;
                //BashAbleObj.transform.localScale = new Vector2(1.4f, 1.4f);
                ShareVariables.BASH_ABLE_OBJECT = BashAbleObj.transform.position;
                arrow.SetActive(true);
                arrow.transform.position = BashAbleObj.transform.transform.position;
                isChoosingDirection = true;
            }
            else if (isChoosingDirection == true && Input.GetKeyUp(KeyCode.F))
            {
                somethingKeepTheAudioBashPlayOnce = false;
                FindObjectOfType<AudioManager>().Play("After Bash");
                ShareVariables.IS_USING_ABILITY = true;
                Time.timeScale = 1;
                //BashAbleObj.transform.localScale = new Vector2(1, 1);
                isChoosingDirection = false;
                ShareVariables.IS_BASHING = true;
                rb.velocity = Vector2.zero;
                //transform.position = BashAbleObj.transform.position;
                bashDirection = arrowPivot.transform.position - BashAbleObj.transform.position;
                //bashDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - BashAbleObj.transform.position;
                //bashDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                bashDirection = bashDirection.normalized;
                if (BashAbleObj.transform.tag.Equals("Bullet beerona"))
                {
                    Vector2 lookDir = -bashDirection;
                    float deg = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90;
                    BashAbleObj.transform.GetComponent<Rigidbody2D>().rotation = deg;
                }
                BashAbleObj.GetComponent<Rigidbody2D>().AddForce(-bashDirection * bashPower, ForceMode2D.Force);
                Instantiate(bashEffect, BashAbleObj.transform.position, Quaternion.identity);
                ShareVariables.EXTRA_JUMP = ShareVariables.EXTRA_JUMP_VALUE;
                arrow.SetActive(false);
                Shared.IS_ENABLE_TO_SWITCH = true;
            }
        }

        //// Perform bash movement
        if (ShareVariables.IS_BASHING == true)
        {
            if (bashTime > 0)
            {
                if (Mathf.Abs(bashDirection.x) > Mathf.Abs(bashDirection.y))
                {
                    transform.GetComponent<Rigidbody2D>().AddForce(bashDirection * bashPower, ForceMode2D.Force);
                    //rb.MovePosition(bashDirection * 100);
                }
                else
                {
                    transform.GetComponent<Rigidbody2D>().AddForce(bashDirection * bashPower * 0.5f, ForceMode2D.Force);
                    //rb.MovePosition(bashDirection * 100);
                }
                    
                bashTime -= Time.deltaTime;
                //rb.AddForce(bashDirection * bashPower, ForceMode2D.Impulse);
            }
            else
            {
                rb.gravityScale = 30;
                ShareVariables.IS_BASHING = false;
                ShareVariables.ENABLE_LAUNCH = true;
                bashTime = bashTimeReset;
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
        }
    }



    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, RadiusBash);
    }
    
}
