using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    enum SHIPPERS
    {
        SHOPEE = 0,
        BEE = 1,
        GRAB = 2,
        FAST = 3
    }
    private static Attack instance;
    private bool isLaserAttacking;
    public float distance;
    public Gradient aimLaserColor;
    public Gradient laserColor;
    public float timeAimLaserValue;
    private float timeAimLaser;
    public float timeLaserValue;
    private float timeLaser;
    private bool isAiming;
    private bool isLaserStart;
    public Transform laserPoint;
    public GameObject aimLineLaser;
    public GameObject lineLaser;
    private bool isSpawn;
    public GameObject explorePrefab;
    private bool isPlayingAudioLaser;
    public AudioSource sound;
    public float minDistance;
    public float maxDistance;
    public Transform[] players;

    public float gapBtw2KindsOfAttackValue;
    private float gapBtw2KindsOfAttack;

    private bool isBulletAttacking;
    public Transform firePoint;
    public GameObject bulletPrefabs;
    public float timeSpawnBulletValue;
    private float timeSpawnBullet;
    public float bulletSpeed;

    public static Attack Instance { get => instance; set => instance = value; }

    private void Awake()
    {
        Instance = this;
        isPlayingAudioLaser = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        isSpawn = false;
        aimLineLaser.SetActive(false);
        lineLaser.SetActive(false);
        timeSpawnBullet = timeSpawnBulletValue;
        isLaserStart = false;
        isAiming = false;
        timeAimLaser = timeAimLaserValue;
        timeLaser = timeLaserValue;
        gapBtw2KindsOfAttack = gapBtw2KindsOfAttackValue;
        Physics2D.queriesStartInColliders = false;
        isBulletAttacking = true;
        isLaserAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBulletAttacking == true)
        {
            if (gapBtw2KindsOfAttack <= 0)
            {
                gapBtw2KindsOfAttack = gapBtw2KindsOfAttackValue;
                isBulletAttacking = false;
                isLaserAttacking = true;
                isAiming = true;
            }
            else
            {
                if (timeSpawnBullet <= 0)
                {
                    timeSpawnBullet = timeSpawnBulletValue;
                    GameObject bullet = Instantiate(bulletPrefabs, firePoint.position, Quaternion.identity);
                    bullet.transform.GetComponent<Rigidbody2D>().AddForce(-Vector2.up * bulletSpeed, ForceMode2D.Impulse);
                    Destroy(bullet, 10f);
                }
                else
                {
                    timeSpawnBullet -= Time.deltaTime;
                }
                gapBtw2KindsOfAttack -= Time.deltaTime;
            }
        }
        if (isLaserAttacking == true)
        {
            if (isAiming == true)
            {
                aimLineLaser.SetActive(true);
                if (timeAimLaser <= 0)
                {
                    isAiming = false;
                    isLaserStart = true;
                    aimLineLaser.SetActive(false);
                    timeAimLaser = timeAimLaserValue;
                }
                else
                {
                    isLaserStart = false;
                    isAiming = true;
                    RaycastHit2D hitInfo = Physics2D.Raycast(laserPoint.position, -laserPoint.up, distance);
                    if (hitInfo.collider != null)
                    {
                        aimLineLaser.GetComponent<LineRenderer>().SetPosition(1, hitInfo.point);
                        aimLineLaser.GetComponent<LineRenderer>().colorGradient = aimLaserColor;
                    }
                    else
                    {
                        aimLineLaser.GetComponent<LineRenderer>().SetPosition(1, laserPoint.position + -laserPoint.up * distance);
                    }
                    aimLineLaser.GetComponent<LineRenderer>().SetPosition(0, laserPoint.position);
                    timeAimLaser -= Time.deltaTime;
                }
            }

            if (isLaserStart == true)
            {
                lineLaser.SetActive(true);
                if (timeLaser <= 0)
                {
                    isLaserStart = false;
                    isAiming = false;
                    isLaserAttacking = false;
                    isBulletAttacking = true;
                    lineLaser.SetActive(false);
                    gapBtw2KindsOfAttack = gapBtw2KindsOfAttackValue;
                    timeLaser = timeLaserValue;
                }
                else
                {
                    try
                    {
                        sound.volume = CalculateVolumeByDistance(Vector2.Distance(players[Shared.CURRENT_SHIPPER].position, transform.position));
                    }
                    catch { }
                    isLaserStart = true;
                    isAiming = false;
                    RaycastHit2D hitInfo = Physics2D.Raycast(laserPoint.position, -laserPoint.up, distance);
                    if (hitInfo.collider != null)
                    {
                        lineLaser.GetComponent<LineRenderer>().SetPosition(1, hitInfo.point);
                        lineLaser.GetComponent<LineRenderer>().colorGradient = laserColor;
                        if (hitInfo.transform.tag.Equals("Player"))
                        {
                            if (Shared.CURRENT_SHIPPER == (int)SHIPPERS.SHOPEE)
                            {
                                PlayerControllerShopee.Instance.transform.GetComponent<PlayerBehavior>().TakeDamage(5);
                            }
                            else if (Shared.CURRENT_SHIPPER == (int)SHIPPERS.BEE)
                            {
                                PlayerControllerBee.Instance.transform.GetComponent<PlayerBehavior>().TakeDamage(5);
                            }
                            else if (Shared.CURRENT_SHIPPER == (int)SHIPPERS.GRAB)
                            {
                                PlayerControllerGrab.Instance.transform.GetComponent<PlayerBehavior>().TakeDamage(5);
                            }
                            else if (Shared.CURRENT_SHIPPER == (int)SHIPPERS.FAST)
                            {
                                PlayerControllerFast.Instance.transform.GetComponent<PlayerBehavior>().TakeDamage(5);
                            }
                        }
                        if (isSpawn == false)
                        {
                            StartCoroutine(Spawn(explorePrefab, hitInfo.point));
                        }
                    }
                    else
                    {
                        lineLaser.GetComponent<LineRenderer>().SetPosition(1, laserPoint.position + -laserPoint.up * distance);
                    }
                    lineLaser.GetComponent<LineRenderer>().SetPosition(0, laserPoint.position);
                    timeLaser -= Time.deltaTime;
                    if (isPlayingAudioLaser == false)
                    {
                        isPlayingAudioLaser = true;
                        StartCoroutine(PlayAudio());
                    }
                }
            }
        }
    }

    public float CalculateVolumeByDistance(float distance)
    {
        if (distance > maxDistance)
        {
            return 0;
        }
        else if (distance < minDistance)
        {
            return 1;
        }
        else
        {
            return 1 - ((distance - minDistance) / (maxDistance - minDistance));
        }
    }

    IEnumerator Spawn(GameObject explore, Vector2 pos)
    {
        isSpawn = true;
        Instantiate(explore, pos, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        isSpawn= false;
    }

    IEnumerator PlayAudio()
    {
        if (sound != null)
        {
            sound.Play();
            yield return new WaitForSeconds(0.5f);
            isPlayingAudioLaser = false;
        }
    }
}
