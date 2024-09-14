using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MimicHandeler : MonoBehaviour
{
    public List<GameObject> mimics = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        mimics = FindGameObjectsInLayer(7).ToList();
    }

    // Update is called once per frame
    void Update()
    {

    }

    GameObject[] FindGameObjectsInLayer(int layer)
    {
        var goArray = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        var goList = new System.Collections.Generic.List<GameObject>();
        for (int i = 0; i < goArray.Length; i++)
        {
            if (goArray[i].layer == layer)
            {
                goList.Add(goArray[i]);
            }
        }
        if (goList.Count == 0)
        {
            return null;
        }
        return goList.ToArray();
    }
}
