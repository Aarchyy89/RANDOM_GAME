using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizController : MonoBehaviour
{
    [Header("--- Speeds ---")]
    public float pitch_Power;
    public float roll_power;
    public float yaw_Power;
    public float Engine_Power;

    private float active_roll, active_pitch, active_yaw;

    [Header("--- Accelerations ---")]
    public float forward_Acceleration;
    public float roll_Acceleration;
    public float Yaw_Acceleration;

    [Header("--- Emptys ---")]
    public GameObject ObjetoACrear;
    public GameObject punto_disparo;
    public GameObject Lose_panel;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private AudioClip Attack_clip;
    [SerializeField] private AudioClip Move_clip;
    public Animator anim;

    public static WizController instance;

    private void Awake()
    {
        instance = this;
    }

    public bool Throttle => Input.GetKey(KeyCode.Space);

    private void Update()
    {
        if(Throttle)
        {
            //Audio_Manager.instance.AudioClip(Move_clip);
            rb.AddForce(transform.forward * Engine_Power * Time.deltaTime, ForceMode.VelocityChange);
            anim.SetFloat("VelY", active_pitch);
            anim.SetFloat("VelX", active_roll);

            //transform.position += transform.up * Engine_Power * Time.deltaTime;

            active_pitch = Input.GetAxisRaw("Vertical") * pitch_Power;
            active_roll = Input.GetAxisRaw("Horizontal") * roll_power;
            active_yaw = Input.GetAxisRaw("Yaw") * yaw_Power * Yaw_Acceleration;

            /*
            transform.Rotate(active_pitch * pitch_Power * forward_Acceleration * Time.deltaTime,
                active_yaw * yaw_Power * Yaw_Acceleration * Time.deltaTime,
                -active_roll * roll_power * roll_Acceleration * Time.deltaTime, Space.Self);
            */


            transform.Rotate(transform.forward * active_roll * Time.deltaTime);
            transform.Rotate(transform.right * active_pitch * Time.deltaTime);
            transform.Rotate(transform.up * active_yaw * Time.deltaTime);

            

        }
        else
        {
            

            active_pitch = Input.GetAxisRaw("Vertical") * pitch_Power/2;
            active_roll = Input.GetAxisRaw("Horizontal") * roll_power/2;
            active_yaw = Input.GetAxisRaw("Yaw") * yaw_Power/2;

            /**
            transform.Rotate(active_pitch * pitch_Power * Time.deltaTime,
                active_yaw * yaw_Power * Time.deltaTime,
                -active_roll * roll_power * Time.deltaTime, Space.Self);
            */

            transform.Rotate(transform.forward * active_roll * Time.deltaTime);
            transform.Rotate(transform.right * active_pitch * Time.deltaTime);
            transform.Rotate(transform.up * active_yaw * Time.deltaTime);

        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            // Método para crear un objetos, en una posicion que le indicamos y con la rotación que le indicamos
            Audio_Manager.instance.AudioClip(Attack_clip);
            GetComponent<Animator>().SetBool("Attack", true);
            Instantiate(ObjetoACrear, punto_disparo.transform.position, punto_disparo.transform.rotation);
        }
        else
        {
            GetComponent<Animator>().SetBool("Attack", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Suelo"))
        {
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(0.5f);

        GetComponent<Animator>().SetTrigger("Death");
        Time.timeScale = 0;
        Lose_panel.SetActive(true);
    }
}

