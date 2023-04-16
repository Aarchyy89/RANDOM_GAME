using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala_Torreta : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distance_This = speed * Time.deltaTime;

        if(dir.magnitude <= distance_This)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distance_This, Space.World);
    }

    public void HitTarget()
    {
        Debug.Log("Hit");
        Destroy(gameObject);    
    }
}
