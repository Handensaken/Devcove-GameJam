using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitDoor : MonoBehaviour
{
    public GameObject leaveText;
    public string sceneName;
    private bool playerClose = false;
    void Start()
    {
        leaveText.SetActive(false);
    }
    void Update()
    {
        if (playerClose)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                GameEventManger.instance.playerEvents.GameOver();
                if (sceneName != null)
                {
                    SceneManager.LoadScene(sceneName);
                }
            }
        }
    }
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            leaveText.SetActive(true);
            playerClose = true;
        }
    }
    public void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            leaveText.SetActive(false);
            playerClose = false;
        }
    }
}
