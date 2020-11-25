using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCleaner : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //make the background seamlessly scroll.
        if (collision.tag == "Background")
        {
            float widthOfObject = ((BoxCollider2D)collision).size.x;

            //position is the current background position
            Vector3 position = collision.transform.position;

            //update position with the width of the object * 1.99 to bump the object in front of the character/player
            //1.99 helps with the gap in the background (we want the background to slightly overlap to make it seamless)
            position.x += widthOfObject * 1.99f;

            //transforming the background's position to the new calculated position.
            collision.transform.position = position;
        }
    }
}
