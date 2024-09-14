using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitDoor : MonoBehaviour
{
    public GameObject leaveText;
    public string sceneName;
    void Start()
    {
        leaveText.SetActive(false);
    }
    public void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            leaveText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                GameEventManger.instance.playerEvents.GameOver();
                Debug.Log(sceneName);
                if (sceneName != null)
                {
                    SceneManager.LoadScene(sceneName);
                }
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
