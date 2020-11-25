using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    private int platformSelector;
    //public GameObject[] thePlatforms;
    private float[] platformWidths;

    public ObjectPooler[] theObjectPools;

    private void Start()
    {
        //platformWidth = thePlatform.GetComponent<CapsuleCollider2D>().size.x;
        platformWidths = new float[theObjectPools.Length];

        for(int i = 0; i < theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<CapsuleCollider2D>().size.x;
        }
    }

    private void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            platformSelector = Random.Range(0, theObjectPools.Length);

            int randomYPos = Random.Range(-2, 1);

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, randomYPos, transform.position.z);

            //Instantiate(thePlatforms[platformSelector], transform.position, transform.rotation);

            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
        }
    }
    /* FIRST TRY
    //when the game first starts there's enough blocks all the way to the edge of the screen
    //make sure the blocks are spaced out enough that we can make it through them

    //if two large blocks were to be set in the same row, the player would not be able to get through at all.
    //so, we are pairing up the small and large blocks randomly every time (in terms of position in the y direction)
    public List<GameObject> smallBlocks;
    public List<GameObject> largeBlocks;

    public int blocksToGenerate = 12;
    int blockNumber = 1;

    public int spawnRange;

    public bool canSpawn;

    System.Random rand = new System.Random();

    //first thing we want to happen
    private void Awake()
    {
        //generate blocks on awake.
        for (int i = 0; i < blocksToGenerate; i++)
        {
            /*
            int blockType = rand.Next(0, 1);

            if(blockType == 0)
            {
                int smallBlockToGenerate = rand.Next(0, smallBlocks.Count);
                GameObject smallBlock = GameObject.Instantiate(smallBlocks[smallBlockToGenerate]);
                smallBlock.GetComponent<Block>().SetBlockNumberAndSpan(blockNumber, transform, true);
            }
            else
            {
                int largeBlockToGenerate = rand.Next(0, largeBlocks.Count);
                GameObject largeBlock = GameObject.Instantiate(largeBlocks[largeBlockToGenerate]);
                largeBlock.GetComponent<Block>().SetBlockNumberAndSpanLarge(blockNumber, transform, false);
            }
            */
    /*

    //generate a SMALL BLOCK
    //give us a random number between 0 and the number of small blocks in the list
    //Reminder: the max number (smallBlocks.count) will not be included in a possible number result (0 - (count-1))
    if(blockNumber % 2 == 0)
    {
        int smallBlockToGenerate = rand.Next(0, smallBlocks.Count);
        GameObject smallBlock = GameObject.Instantiate(smallBlocks[smallBlockToGenerate]);

        //transform = return the transform attached to the game object making that call.
        smallBlock.GetComponent<Block>().SetBlockNumberAndSpan(blockNumber, transform, true);
    }
    else
    {
        //repeat for LARGE BLOCK
        int largeBlockToGenerate = rand.Next(0, largeBlocks.Count);
        GameObject largeBlock = GameObject.Instantiate(largeBlocks[largeBlockToGenerate]);
        largeBlock.GetComponent<Block>().SetBlockNumberAndSpanLarge(blockNumber, transform, false);

        //increment block number after each generation of a block. (remember, blockNumber starts at 1.)

    }


    blockNumber++;

}
}
*/
}
