using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[ExecuteInEditMode]
public class MimicReplacerObject : MonoBehaviour
{
    public GameObject replacer;
    private List<GameObject> gameObjects = new List<GameObject>();

    void OnGUI()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Mimicable").ToList();
           Debug.Log(gameObjects.Count);
           foreach (GameObject G in gameObjects){
                Vector3 pos = G.transform.position;
                Quaternion rot = G.transform.rotation;
                Instantiate(replacer, pos, rot);
                DestroyImmediate(G);
                Debug.Log(gameObjects.Count);
            }
    }

    // Update is called once per frame
    void Update() { 
        if(Input.GetKeyDown(KeyCode.G)){
            Debug.Log("Fucktou");
        }
    }
    void Execute(){

    }
}
