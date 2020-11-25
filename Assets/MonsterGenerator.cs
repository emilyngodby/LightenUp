using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenerator : MonoBehaviour
{
    public GameObject theMonster;
    public Transform generationPoint;
    public float distanceBetween;
    private float monsterWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;


    public ObjectPooler theObjectPool;
    // Start is called before the first frame update
    void Start()
    {
        monsterWidth = theObjectPool.pooledObject.GetComponent<CapsuleCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            int yPos = 0;

            transform.position = new Vector3(transform.position.x + (monsterWidth / 2) + distanceBetween, yPos, transform.position.z);

            //Instantiate(thePlatforms[platformSelector], transform.position, transform.rotation);

            GameObject newMonster = theObjectPool.GetPooledObject();

            newMonster.transform.position = transform.position;
            newMonster.transform.rotation = transform.rotation;
            newMonster.SetActive(true);
        }
    }
}
