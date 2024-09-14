using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BlinkRandomizer : MonoBehaviour
{
    public int blinkTime = 10;
    [Description("If blink time i 5 and randomrange is 2 then it will be 3-7")]
    public int randomRange = 4;
    private float currentRandomTime;
    private float timer = 0;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        timer = 0;
        currentRandomTime = NextRandom();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > currentRandomTime){
            timer = 0;
            //animator.SetTrigger("", false); or idk
        }
    }
    public float NextRandom(){
        return Random.Range(blinkTime - randomRange, blinkTime + randomRange);
    }
}
