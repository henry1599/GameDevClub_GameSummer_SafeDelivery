using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour
{
    public bool isBoss;
    [Range(0, 1000)]
    public float maxHP;
    public GameObject healthBar;
    private Enemy e;
    // Start is called before the first frame update
    void Start()
    {
        if (isBoss == true)
        {
            Sharedbee.HEALTH = maxHP;
            Sharedbee.IS_DEATH = false;
        }
        if (healthBar != null)
            healthBar.GetComponent<HealthBar>().SetMaxValue(Sharedbee.HEALTH);
        e = transform.GetComponent<Enemy>();
        e.SetMaXHP(maxHP);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar != null)
        {
            if (Sharedbee.IS_ACTIVATE == true)
            {
                healthBar.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Bullet"))
        {
            float damage = Random.Range(10, 30);
            e.TakeDamage(damage);
            if (isBoss == true)
                Sharedbee.HEALTH -= damage;
            if (healthBar != null)
                healthBar.GetComponent<HealthBar>().SetValue(Sharedbee.HEALTH);
            if (isBoss == true)
            {
                if (Sharedbee.HEALTH <= 0)
                {
                    Sharedbee.IS_DEATH = true;
                    Sharedbee.IS_ACTIVATE = false;
                    healthBar.SetActive(false);
                }
            }
        }
    }
}
