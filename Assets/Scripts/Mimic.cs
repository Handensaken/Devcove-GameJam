using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mimic : MonoBehaviour
{
    public bool isMimic = false;
    public List<GameObject> mimicAttributes = new List<GameObject>();
    public void Awake(){
        for (int i = 0; i < mimicAttributes.Count; i++)
        {
            mimicAttributes[i].SetActive(false);
        }
    }
    private void RandomAttributes()
    {
        if (mimicAttributes.Count != 0)
        {
            int random = Random.Range(0, mimicAttributes.Count);
            mimicAttributes[random].SetActive(true);
        }
    }
    public void SetMimic()
    {
        isMimic = true;
        RandomAttributes();
    }
}
