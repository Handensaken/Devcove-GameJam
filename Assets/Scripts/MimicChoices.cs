using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicChoices : MonoBehaviour
{
    public GameObject kill, releace;
    // Start is called before the first frame update
    void Start()
    {
        GameEventManger.instance.playerEvents.OnChooseMimic += EnnableGui;
    }
    void OnDisable()
    {
        GameEventManger.instance.playerEvents.OnChooseMimic -= EnnableGui;
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void EnnableGui()
    {
        
    }
}
