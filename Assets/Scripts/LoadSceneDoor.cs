using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneDoor : MonoBehaviour
{
    public string sceneName;
    private bool playerClose = false;
    public GameObject leaveText;
    void Start(){
        leaveText.SetActive(false);
    }
    void OnDisable(){
        
    }
    void Update()
    {
        if (playerClose)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (sceneName != null)
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
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
