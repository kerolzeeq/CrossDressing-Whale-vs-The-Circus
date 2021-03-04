using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Characters;
    private int checking;
    public Transform playerPos;
    void Awake()
    {
        
        checking = PlayerPrefs.GetInt("Score");
        
        for(int i = 0; i < 8; i++)
        {
            if (i == checking)
            {
                continue;
            }
            Destroy(Characters[i]);
        }
        
        
    }

  
}
