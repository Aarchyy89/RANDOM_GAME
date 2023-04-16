using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Machine : MonoBehaviour
{
    public Vector3 offset_distance;
    public Transform target;
    [Range(0, 1)]public float lerpValue;

    /**private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset_distance, lerpValue);
    }*/

    private void Update()
    {
        transform.LookAt(target);
        transform.position = Vector3.Lerp(transform.position, target.position + offset_distance, lerpValue);
    }
}
