using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndText : MonoBehaviour
{
    public MimicStats stats;
    public GameObject win;
    public GameObject lose;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(stats.mimicAmount + " " + stats.mimicsFound);
        lose.SetActive(false);
        win.SetActive(false);
        if (stats.mimicAmount > stats.mimicsFound)
        {
            lose.SetActive(true);
        }
        else
        {
            win.SetActive(true);
        }
        Debug.Log("idk");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
