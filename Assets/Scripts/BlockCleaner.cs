using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCleaner : MonoBehaviour
{
    public GameObject platformCleanupPoint;

    // Start is called before the first frame update
    void Start()
    {
        platformCleanupPoint = GameObject.Find("CleanupPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < platformCleanupPoint.transform.position.x)
        {
            //Destroy(gameObject);

            gameObject.SetActive(false);
        }
    }
}
