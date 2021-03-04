using UnityEngine;

public class CheckClown : MonoBehaviour
{
    public GameObject barang;
    private int enemycnt;
    public Transform barangposition;
    private bool flag;
    // Start is called before the first frame update
    void Start()
    {
        flag = true;
    }

    // Update is called once per frame
    void Update()
    {

        enemycnt = PlayerPrefs.GetInt("enemyNo");

        if (enemycnt == 0 && flag)
        {
            Instantiate(barang, barangposition.position, Quaternion.identity);
            flag = false;
        }
    }
}
