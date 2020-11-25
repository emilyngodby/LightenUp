using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public Entity player;
    public Entity monster;

    public int monsterPosMin = 15;
    public int monsterPosMax = 30;

    public int monsterDistanceBetween = 30;
    public float monsterVelocity = -20;

    public float monsterStartPos;
    public float monsterEndPos;
    public float speed = 100;
    public Vector2 currentVelocity = Vector2.zero;

    Animator anim;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        monsterStartPos = player.transform.position.x + Random.Range(player.position.x + monsterPosMin, player.position.x + monsterPosMax);
        monster.position.x = monsterStartPos;
        transform.localPosition = monster.position;

        rb.velocity = Vector3.zero;

        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        
    }

    private void Update()
    {
        //monster.position = transform.position;
        
        if (Mathf.Abs(monster.position.x - player.transform.position.x) > monsterDistanceBetween)
        {
            monster.position.x = Random.Range(player.position.x + monsterPosMin, player.position.x + monsterPosMax);
            monster.position.y = 0;
            transform.localPosition = monster.position;
            
        }
        
        //monster.position = monster.position + monster.velocity * Time.deltaTime;
        rb.AddForce(Vector2.left * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentVelocity = rb.velocity;

        if(currentVelocity.x == 0)
        {
            anim.SetBool("isMoving", false);
        }
        else
        {
            anim.SetBool("isMoving", true);
        }
        
    }
}
