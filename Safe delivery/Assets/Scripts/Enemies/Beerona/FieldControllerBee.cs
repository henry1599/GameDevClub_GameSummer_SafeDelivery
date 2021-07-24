using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldControllerBee : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && Sharedbee.IS_DEATH == false)
        {
            Sharedbee.IS_ACTIVATE = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            if (Sharedbee.IS_DEATH == true)
            {
                Sharedbee.IS_ACTIVATE = false;
            }
            else
            {
                Sharedbee.IS_ACTIVATE = true;
            }
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag.Equals("Player") && Sharedbee.IS_DEATH == true)
    //    {
    //        Sharedbee.IS_ACTIVATE = false;
    //    }
    //}
}
