using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Entity player;

    // Start is called before the first frame update
    void Start()
    {
        player.position = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
