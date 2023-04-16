using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinemachine : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public Transform orientation;
    public Rigidbody rb;

    public float rotation_Speeed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //rotar orientación
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        //se rota al player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if(inputDir != Vector3.zero)
        {
            player.forward = Vector3.Slerp(player.forward, inputDir.normalized, Time.deltaTime * rotation_Speeed);
        }

    }
}
