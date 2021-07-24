using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingSystem : MonoBehaviour
{
    private float requiredAmount;
    public HealthBar itemBar;
    public static int collectedItems;
    public static bool isCollectEnough;
    public Transform[] positions;
    public GameObject[] items;
    private int realAmount;
    private List<int> alreadySpawn;
    // Start is called before the first frame update
    void Start()
    {
        realAmount = positions.Length;
        collectedItems = 0;
        isCollectEnough = false;
        requiredAmount = SharedUI.LEVEL;
        alreadySpawn = new List<int>(realAmount);
        GetRandomPos();
        foreach (int i in alreadySpawn)
        {
            Instantiate(items[Random.Range(0, items.Length)], positions[i].position, Quaternion.identity);
        }
        Mathf.Clamp(requiredAmount, 0, realAmount);
        itemBar.SetMaxValue(requiredAmount);
        itemBar.SetValue(0);
    }

    // Update is called once per frame
    void Update()
    {
        Mathf.Clamp(collectedItems, 0, requiredAmount);
        itemBar.SetValue(collectedItems);
        if (collectedItems >= requiredAmount)
        {
            isCollectEnough = true;
        }
    }

    void GetRandomPos()
    {
        for (int i = 0; i < realAmount; i++)
        {
            int k = Random.Range(0, positions.Length);
            while (alreadySpawn.Contains(k))
            {
                k = Random.Range(0, positions.Length);
            }
            alreadySpawn.Add(k);
        }
    }
}
