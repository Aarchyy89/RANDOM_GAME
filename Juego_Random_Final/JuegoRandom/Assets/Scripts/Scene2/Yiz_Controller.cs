using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yiz_Controller : MonoBehaviour
{
    [Header("--- Speeds ---")]
    public float Engine_Power;
    public float Turn_vel;
    public float vertical_dir_power;
    public float roll_power;


    private float active_roll, active_vertical_dir;

    [Header("--- Accelerations ---")]
    //public float forward_Acceleration;
    //public float roll_Acceleration;
    public int power_pitch;
    public float Yaw_Acceleration;

    [Header("--- Emptys ---")]
    public GameObject ObjetoACrear;
    public GameObject punto_disparo;
    public GameObject Lose_panel;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private AudioClip Attack_clip;
    [SerializeField] private AudioClip Move_clip;
    [SerializeField] private AudioClip Defeat;
    public Animator anim;

    public static Yiz_Controller instance;

    private void Awake()
    {
        instance = this;
    }

    public bool Throttle;

    private void Update()
    {
        if (Throttle == true)
        {
            //Audio_Manager.instance.AudioClip(Move_clip);
            //rb.AddForce(transform.forward * Engine_Power * Time.deltaTime, ForceMode.VelocityChange);
            //anim.SetFloat("VelY", active_vertical_dir);
            //anim.SetFloat("VelX", active_roll);

            transform.position += transform.forward * Engine_Power * Time.deltaTime;

            active_vertical_dir = Input.GetAxisRaw("Vertical");
            active_roll = Input.GetAxisRaw("Horizontal");
            //active_turn = Input.GetAxisRaw("Yaw") * Turn_vel * Yaw_Acceleration;

            /*
            transform.Rotate(active_pitch * pitch_Power * forward_Acceleration * Time.deltaTime,
                active_yaw * yaw_Power * Yaw_Acceleration * Time.deltaTime,
                -active_roll * roll_power * roll_Acceleration * Time.deltaTime, Space.Self);
            */


            transform.Rotate(Vector3.forward * (100 * Time.deltaTime * active_roll));
            transform.Rotate(Vector3.right * (80 * Time.deltaTime * active_vertical_dir));
            //transform.Rotate(transform.right * active_vertical_dir * Time.deltaTime);
            //transform.Rotate(transform.up * active_turn * Time.deltaTime);



        }
        else
        {


            active_vertical_dir = Input.GetAxisRaw("Vertical");
            active_roll = Input.GetAxisRaw("Horizontal");

            transform.Rotate(Vector3.forward * (100 * Time.deltaTime * active_roll));
            transform.Rotate(Vector3.right * (80 * Time.deltaTime * active_vertical_dir));

        }

        //MODO TURBO
        if (Throttle && Input.GetKey(KeyCode.P))
        {
            rb.AddForce(transform.forward * power_pitch * Time.deltaTime, ForceMode.VelocityChange);
            GetComponent<Animator>().SetBool("Run", true);

        }
        else
        {
            GetComponent<Animator>().SetBool("Run", false);
        }


        if (Input.GetKeyDown(KeyCode.L))
        {
            // M�todo para crear un objetos, en una posicion que le indicamos y con la rotaci�n que le indicamos
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
            GetComponent<Animator>().SetTrigger("Death");
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {

        yield return new WaitForSeconds(2f);

        Audio_Manager.instance.audioSource.Stop();


        Audio_Manager.instance.AudioClip(Defeat);
        Time.timeScale = 0;
        Lose_panel.SetActive(true);
    }
}