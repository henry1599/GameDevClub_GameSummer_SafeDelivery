using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public HealthBar healthBar;
    public GameObject bloodPrefab;
    [Range(0, 1000)]
    public float maxHP;
    private float currentHP;
    public GameObject blooding;
    private bool isBlooding;
    // Start is called before the first frame update
    void Start()
    {
        isBlooding = false;
        currentHP = maxHP;
        healthBar.SetMaxValue(maxHP);
    }

    private void Update()
    {
        if (currentHP <= 0)
        {
            Shared.SHIPPER_STATE[Shared.CURRENT_SHIPPER] = false;
            // Perform switch to the next shipper
            SwitchingShipper.Instance.SwitchImmediately();
        }
        if (Shared.IS_ALL_DEATH == true)
        {
            Debug.Log("All death, Game over");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Enemy Bullet") && gameObject.activeSelf)
        {
            currentHP -= Random.Range(40, 50);
        }
        if (collision.collider.tag.Equals("Enemy") && gameObject.activeSelf)
        {
            currentHP -= Random.Range(20, 30);
        }
        if (collision.collider.tag.Equals("Rhino horn") && gameObject.activeSelf)
        {
            currentHP -= Random.Range(50, 60);
        }
        if (collision.collider.tag.Equals("Rhino boss") && gameObject.activeSelf)
        {
            currentHP -= Random.Range(50, 60);
        }
        healthBar.SetValue(currentHP);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Lava"))
        {
            if (isBlooding == false)
                StartCoroutine(EffectLava());
        }
        healthBar.SetValue(currentHP);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Lava"))
        {
            if (isBlooding == false)
                StartCoroutine(EffectLava());
        }
        healthBar.SetValue(currentHP);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Lava"))
        {
            isBlooding = false;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        Instantiate(bloodPrefab, healthBar.transform.position, Quaternion.identity);
        Mathf.Clamp(currentHP, 0, maxHP);
        healthBar.SetValue(currentHP);
    }

    public void Heal(float HP)
    {
        currentHP += HP;
        Mathf.Clamp(currentHP, 0, maxHP);
        healthBar.SetValue(currentHP);
    }

    IEnumerator EffectLava()
    {
        isBlooding = true;
        Instantiate(blooding, transform.position, Quaternion.identity);
        currentHP -= 20f;
        Instantiate(bloodPrefab, healthBar.transform.position, Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("Lava");
        yield return new WaitForSeconds(0.3f);
        isBlooding = false;
    }
}
