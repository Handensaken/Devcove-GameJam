using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mimic : MonoBehaviour
{
    private bool isMimic;
    public List<GameObject> mimicAttributes = new List<GameObject>();
    private void RandomAttributes()
    {
        if (mimicAttributes.Count == 0)
        {
            for (int i = 0; i < mimicAttributes.Count; i++)
            {
                mimicAttributes[i].SetActive(false);
            }
            int random = Random.Range(0, mimicAttributes.Count);
            mimicAttributes[random].SetActive(true);
        }
    }
    public void SetMimic(bool setMimic)
    {
        isMimic = setMimic;
        RandomAttributes();
    }
}
