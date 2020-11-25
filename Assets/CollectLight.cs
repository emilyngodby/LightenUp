using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectLight : MonoBehaviour
{
    public int lightCount = 0;
    public Text lightCountText;

    public GameObject playerOrb;
    public GameObject deathOrb;
    public GameObject attackOrb;


    // Start is called before the first frame update
    void Start()
    {
        playerOrb.SetActive(false);
        deathOrb.SetActive(true);
        attackOrb.SetActive(false);
        lightCount = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(lightCount == 0)
        {
            playerOrb.SetActive(false);
            attackOrb.SetActive(false);
            deathOrb.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Light"))
        {
            lightCount++;
            SetCountText();
            collision.gameObject.SetActive(false);
            playerOrb.SetActive(true);
            //lightAudioSource = GetComponent<AudioSource>();
            //lightAudioSource.PlayOneShot(pickUpAudio, 1F);
        }
    }

    public void SetCountText()
    {
        lightCountText.text = "Light x" + lightCount;
    }
}
