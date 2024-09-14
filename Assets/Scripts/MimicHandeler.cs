using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MimicHandeler : MonoBehaviour
{
    private List<GameObject> mimics = new List<GameObject>();
    public int mimicAmount = 1;
    // Start is called before the first frame update
    void Start()
    {
        mimics = FindGameObjectsInLayer(7).ToList();
        if (mimics.Count < mimicAmount){
            mimicAmount = mimics.Count;
        }
        RandomMimics();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void RandomMimics()
    {
        List<GameObject> tempMimics = mimics;
        for (int i = 0; i < mimicAmount; i++)
        {
            Debug.Log(mimicAmount);
            int random = Random.Range(0, tempMimics.Count);
            tempMimics[random].GetComponent<Mimic>().SetMimic();
            tempMimics.RemoveAt(random);
        }
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
