using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float speed;

    void Start()
    {
        // me destruyo a mi mismo cada 5 segundos 
        Destroy(gameObject, 25);
    }

    // Update is called once per frame
    void Update()
    {
        //traslado mi posición hacia adelante 
        StartCoroutine(disparo());
    }

    IEnumerator disparo()
    {
        yield return new WaitForSeconds(0.8f); 
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

}
