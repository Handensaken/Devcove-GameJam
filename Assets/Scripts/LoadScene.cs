using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour
{
    public string sceneName;
    public void Load()
    {
        Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
        SceneManager.LoadScene(sceneName);
    }
}
