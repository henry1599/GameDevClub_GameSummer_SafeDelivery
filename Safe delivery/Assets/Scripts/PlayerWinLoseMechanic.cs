using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWinLoseMechanic : MonoBehaviour
{
    public GameObject loseMenu;
    public GameObject winMenu;
    // Start is called before the first frame update
    void Start()
    {
        Shared.IS_WIN = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Shared.IS_WIN == true)
        {
            winMenu.SetActive(true);
        }
        if (Shared.IS_ALL_DEATH == true)
        {
            loseMenu.SetActive(true);
            Destroy(gameObject);
        }
    }
}
