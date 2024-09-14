using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlickerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
[SerializeField]
    private Light myLight;
    [SerializeField]
    private float maxInterval = 1f;
[SerializeField]
private float minIntensity = 0.3f;
    float targetIntensity;
    float lastIntensity;
    float interval;
    float timer;

    public float maxDisplacement = 0.25f;

    private void Start() { }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > interval)
        {
            lastIntensity = myLight.intensity;
            targetIntensity = Random.Range(minIntensity, 1f);
            timer = 0;
            interval = Random.Range(0, maxInterval);
        }

        myLight.intensity = Mathf.Lerp(lastIntensity, targetIntensity, timer / interval);
    }
}
