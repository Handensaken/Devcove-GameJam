using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RotateTowardsPlayer : MonoBehaviour
{
    public Transform player;
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - player.position);
    }
}
