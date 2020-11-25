using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class HitMonster : MonoBehaviour
{
    public GameObject redMonsterOrb;
    public GameObject blackMonsterOrb;

    public CollectLight lightCollecter;

    public bool firstHit;
    public bool secondHit;

    public int numOfHits = 0;

    // Start is called before the first frame update
    void Start()
    {
        firstHit = false;
        secondHit = false;

        redMonsterOrb.SetActive(false);
        blackMonsterOrb.SetActive(true);

        lightCollecter = FindObjectOfType(typeof(CollectLight)) as CollectLight;
    }

    // Update is called once per frame
    void Update()
    {
        if(numOfHits > 5)
        {
            Debug.Log("You lost");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Monster"))
        {
            lightCollecter.lightCount = 0;
            lightCollecter.SetCountText();

            blackMonsterOrb.SetActive(false);
            redMonsterOrb.SetActive(true);
            numOfHits++;


            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    IEnumerator HitTimer()
    {
        yield return new WaitForSeconds(100);
    }
}
