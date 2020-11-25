using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Transform blockGenerator;
    int blockNumber;
    bool smallBlock;

    public float minDistBetweenPlatforms = 10;
    public float spawnRange;
    public float spawnRangeY;

    System.Random rand = new System.Random();

    public void SetBlockNumberAndSpan(int _blockNumber, Transform _blockGenerator, bool _smallBlock)
    {
        blockNumber = _blockNumber;
        blockGenerator = _blockGenerator;
        smallBlock = _smallBlock;

        Vector3 pos = Vector3.zero;
        pos.x = Camera.main.transform.position.x + 10f + (blockNumber*rand.Next(3,20)); //blocks will be separated by 1 unit and 1.25

        PlaceBlock(pos);
    }

    public void SetBlockNumberAndSpanLarge(int _blockNumber, Transform _blockGenerator, bool _largeBlock)
    {
        blockNumber = _blockNumber;
        blockGenerator = _blockGenerator;
        smallBlock = _largeBlock;

        Vector3 pos = Vector3.zero;
        pos.x = Camera.main.transform.position.x + 10f + (blockNumber * 8); //blocks will be separated by 1 unit and 1.25

        PlaceBlock(pos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cleaner")
        {
            Move();
        }
    }

    private void Move()
    {
        //generate the new x value for the block 
        Vector3 pos = transform.position; //where the block currently is
        pos.x = blockGenerator.position.x; //span this block exactly where the block generator currently is
        PlaceBlock(pos);

    }

    private void PlaceBlock(Vector3 pos)
    {
        if (smallBlock)
        {
            //pos.y = UnityEngine.Random.Range(-3f, 0f);
            //if its even, put a small block on top
            
            if (blockNumber % 2 == 0)
            {
                pos.y = UnityEngine.Random.Range(-3f, 0f);

            }
            else
            {
                pos.y = UnityEngine.Random.Range(1.8f, 3f);
            }
            

        }
        else
        {
            //pos.y = UnityEngine.Random.Range(-3f, 0f);
            
            if (blockNumber % 2 != 0)
            {
                pos.y = UnityEngine.Random.Range(-3f, 0f);

            }
            //block number even, put large block on bottom
            else
            {
                pos.y = UnityEngine.Random.Range(1.7f, 3f);
            }
            
        }

        transform.position = pos;
    }
}
