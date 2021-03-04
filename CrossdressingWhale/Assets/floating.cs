using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class floating : MonoBehaviour
{
    
    private Vector2 v;
    private int no;
    // Start is called before the first frame update
    void Start()
    {

        PlayerPrefs.SetInt("mama", 0);

        //if (SceneManager.GetActiveScene().buildIndex == 3) // LEVEL 2
        //{
        //    PlayerPrefs.SetInt("mama", 0);
        //}

        //if (SceneManager.GetActiveScene().buildIndex == 5) // LEVEL 3
        //{
        //    PlayerPrefs.SetInt("mama", PlayerPrefs.GetInt("mama"));
        //    PlayerPrefs.SetInt("mimi", 0);
        //}

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void OnTriggerEnter2D(Collider2D col)
    {
       
        if (col.gameObject.tag.Equals("Player"))
        {
            
            PlayerPrefs.SetInt("mama", 1);
            Destroy(gameObject);

        }
        
        
    }
}
