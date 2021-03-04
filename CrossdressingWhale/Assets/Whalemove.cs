using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Whalemove : MonoBehaviour
{
    public Rigidbody2D whale;
    private Animator anim;
    private bool direction = true;
    public float speed = 10.0f;
    private float moveinput;
    private int cuba;
    public LayerMask whatIsGround;
    public Transform feetpos;
    public float checkRadius;
    private bool isGrounded;
    public GameObject YouDiedPanel;
    //
    public float jumpforce;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool jump;
    public int enemycount;
    private int enemyNo;
    private int no;
    public Animator transition;
    private int cane = 1, bowtie = 2, tophat = 4;
    private bool canez=true, bowtiez=true, tophatz=true;
    private int cek;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        YouDiedPanel.SetActive(false);
        anim = GetComponent<Animator>();
        direction = true;
        PlayerPrefs.SetInt("enemyNo", enemycount);
    }

    // Update is called once per frame
    private void Update()
    {
       

        PlayerPrefs.SetInt("enemyNo", enemycount);
        isGrounded = Physics2D.OverlapCircle(feetpos.position, checkRadius, whatIsGround);

        if (isGrounded == true && (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.UpArrow)))) 
        {
            jumpTimeCounter = jumpTime;
            jump = true;
            whale.velocity = Vector2.up * jumpforce;
        }

        if ((Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.UpArrow))) && jump == true)
        {
            if (jumpTimeCounter > 0)
            {
                whale.velocity = Vector2.up * jumpforce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                jump = false;
            }
        }
    }
    void FixedUpdate()
    {
       
       
        moveinput = Input.GetAxisRaw("Horizontal");

        whale.velocity = new Vector2(moveinput * speed * Time.deltaTime, whale.velocity.y);
        anim.SetFloat("speed", moveinput * moveinput);

        // if (moveinput2>0)
        //{
        //   whale.velocity = new Vector2(whale.velocity.x, speed * 3 * Time.deltaTime);
        //}


        if (moveinput>0 && !direction)
        {
            flip();
        }

        if(moveinput<0 && direction)
        {
            flip();
        }

        
    }

    void flip()
    {
        direction = !direction;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void isDead()
    {
        //FindObjectOfType<AudioManager>().Play("something");
        YouDiedPanel.SetActive(true);
        Time.timeScale = 0.0f;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("FLAMES") || col.gameObject.name.Equals("jatuhmati"))
        {
            isDead();
        }

        if (col.gameObject.name.Equals("clown1"))
        {
            whale.velocity = new Vector2(whale.velocity.x, speed * 1.5f * Time.deltaTime);
            Destroy(GameObject.FindGameObjectWithTag("Clown1"));
            enemycount--;
            PlayerPrefs.SetInt("enemyNo", enemycount);
           // Debug.Log(PlayerPrefs.GetInt("enemyNo"));
        }

        if (col.gameObject.name.Equals("clown2"))
        {
            whale.velocity = new Vector2(whale.velocity.x, speed * 1.5f * Time.deltaTime);
            Destroy(GameObject.FindGameObjectWithTag("Clown2"));
            enemycount--;
            PlayerPrefs.SetInt("enemyNo", enemycount);
        }

        if (col.gameObject.name.Equals("clown3"))
        {
            whale.velocity = new Vector2(whale.velocity.x, speed * 1.5f * Time.deltaTime);
            Destroy(GameObject.FindGameObjectWithTag("Clown3"));
            enemycount--;
            PlayerPrefs.SetInt("enemyNo", enemycount);
        }

        if (col.gameObject.name.Equals("Portal"))
        {
            no = PlayerPrefs.GetInt("mama");
            if (no == 1)
            {
                StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
               // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                
            }
            else
            {
                StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 2));
                //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
                
            }

            
        }

        if (col.gameObject.name.Equals("Portal1"))
        {
           
                StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
                // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (col.gameObject.name.Equals("PortalEnding"))
        {
            cek = PlayerPrefs.GetInt("Score");
            if (cek == 0)
            {
                //bad
                StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
            }
            if (cek >0 &&  cek<7)
            {
                //confused
                StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 2));
            }
            if (cek == 7)
            {
                StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 3));
            }


        }

        if (col.gameObject.name.Equals("Cane(Clone)") && canez)
        {
            canez = false;
            PlayerPrefs.SetInt("Score", cane);
           // Debug.Log(PlayerPrefs.GetInt("Score"));
            
          //  Debug.Log("Bowi");
        }

        if (col.gameObject.name.Equals("Bowtie(Clone)") && bowtiez)
        {
            bowtiez = false;
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 2);
            //Debug.Log("Ulang : "+PlayerPrefs.GetInt("Score"));
        }

        if (col.gameObject.name.Equals("Tophat(Clone)") && tophatz)
        {
            tophatz = false;
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 4);
            //Debug.Log("aftermomo : " + PlayerPrefs.GetInt("Score"));
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelIndex);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("clown1") || collision.gameObject.name.Equals("clown2") || collision.gameObject.name.Equals("clown3"))
        {
            isDead();
        }

        
    }
}
