using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NonMimicDestroyedCounter : MonoBehaviour
{
    private int Count = 0;
    public int destroyedForLose = 3;
    public string sceneName;

    void Start()
    {
        GameEventManger.instance.playerEvents.OnDestroyedNonMimic += Counter;
    }
    void OnDisable()
    {
        GameEventManger.instance.playerEvents.OnDestroyedNonMimic -= Counter;
    }
    private void Counter()
    {
        Count++;
        if (Count == destroyedForLose)
        {
            if (sceneName != null)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
