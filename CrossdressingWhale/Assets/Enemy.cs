using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Rigidbody2D clown;
    public float speedc = 10.0f;
    private Animator anim;
    
    private int randomspot;
    private float waitTime;
    public float startWaitTime;
    public Transform[] movespots;
    private float x;
    private bool direction = true;
    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        clown = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        randomspot = Random.Range(0, movespots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movespots[randomspot].position, speedc * Time.deltaTime);
        anim.SetBool("moving", true);
        if(x<randomspot && !direction)
        {
            flip();
        }

        if (x >= randomspot && direction)
        {
            flip();
        }
        if (Vector2.Distance(transform.position,movespots[randomspot].position) <0.2f)
        {
            if (waitTime <= 0)
            {
                x = randomspot;
                randomspot = Random.Range(0, movespots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                anim.SetBool("moving", false);
                waitTime -= Time.deltaTime;
            }
        }
    }
    void flip()
    {
        direction = !direction;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
