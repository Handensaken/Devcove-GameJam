using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayImages : MonoBehaviour
{
    public List<Sprite> image = new List<Sprite>();
    public Image activeImage;
    public string sceneName;
    void Start()
    {
        activeImage.sprite = image[0];
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (image.Count == 1)
            {
                if (sceneName != null)
                {
                    SceneManager.LoadScene(sceneName);
                }
            }
            else
            {
                image.RemoveAt(0);
                activeImage.sprite = image[0];
            }
        }
    }
}
