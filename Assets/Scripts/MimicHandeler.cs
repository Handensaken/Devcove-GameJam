using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class MimicHandeler : MonoBehaviour
{
    private List<GameObject> mimics = new List<GameObject>();
    public int mimicAmount = 1;
    public MimicStats mimicStats;
    // Start is called before the first frame update
    void Start()
    {
        mimics = FindGameObjectsInLayer(7).ToList();
        for (int i = 0; i < mimics.Count; i++)
        {
            if(mimics[i].GetComponent<Mimic>() == null){
                mimics[i].AddComponent<Mimic>();
            }
        }
        if (mimics.Count < mimicAmount)
        {
            mimicAmount = mimics.Count;
        }
        RandomMimics();
        GameEventManger.instance.playerEvents.OnGameOver += CreateStats;
    }
    void OnDisable()
    {
        GameEventManger.instance.playerEvents.OnGameOver -= CreateStats;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void CreateStats()
    {
        List<GameObject> objectsLeft = new List<GameObject>();
        if (mimicStats != null)
        {
            if (FindGameObjectsInLayer(7).ToList() != null)
            {
                objectsLeft = FindGameObjectsInLayer(7).ToList();
            }
            mimicStats.mimicAmount = mimicAmount;
            int mimicsLeft = 0;
            for (int i = 0; i < mimics.Count; i++)
            {
                if (mimics[i] != null)
                {
                    Debug.Log(mimics[i].gameObject.name);
                    if (mimics[i].GetComponent<Mimic>().isMimic)
                    {
                        mimicsLeft++;
                    }
                }
            }
            Debug.Log(mimicsLeft + " mimicsleft");
            mimicStats.mimicsFound = mimicAmount - mimicsLeft;
            mimicStats.nonMimicsDestroyed = mimics.Count + mimicsLeft - mimicAmount - objectsLeft.Count;
        }
    }
    private void RandomMimics()
    {
        List<GameObject> tempMimics = new List<GameObject>();
        for (int i = 0; i < mimics.Count; i++)
        {
            tempMimics.Add(mimics[i]);
        }
        for (int i = 0; i < mimicAmount; i++)
        {
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
