using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public GameObject leaveText;
    // Start is called before the first frame update
    void Start()
    {
        leaveText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            leaveText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                GameEventManger.instance.playerEvents.GameOver();
            }
        }
    }
    public void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            leaveText.SetActive(false);
        }
    }
}
