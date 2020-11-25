using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGenerator : MonoBehaviour
{
    public GameObject theLight;
    public Transform generationPoint;
    public float distanceBetween;
    private float lightWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    public ObjectPooler theObjectPool;

    // Start is called before the first frame update
    void Start()
    {
        lightWidth = theObjectPool.pooledObject.GetComponent<CircleCollider2D>().radius;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            
            int randomYPos = Random.Range(-2, 1);

            transform.position = new Vector3(transform.position.x + (lightWidth / 2) + distanceBetween, randomYPos, transform.position.z);

            //Instantiate(thePlatforms[platformSelector], transform.position, transform.rotation);

            GameObject newLight = theObjectPool.GetPooledObject();

            newLight.transform.position = transform.position;
            newLight.transform.rotation = transform.rotation;
            newLight.SetActive(true);
        }
    }
}
