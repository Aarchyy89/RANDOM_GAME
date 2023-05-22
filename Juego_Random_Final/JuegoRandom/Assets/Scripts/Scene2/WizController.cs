using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizController : MonoBehaviour
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
            transform.position += transform.forward * Engine_Power * Time.deltaTime;

            active_vertical_dir = Input.GetAxisRaw("Vertical");
            active_roll = Input.GetAxisRaw("Horizontal");

            transform.Rotate(Vector3.forward * (100 * Time.deltaTime * active_roll));
            transform.Rotate(Vector3.right * (80 * Time.deltaTime * active_vertical_dir));

        }
        else
        {


            active_vertical_dir = Input.GetAxisRaw("Vertical");
            active_roll = Input.GetAxisRaw("Horizontal");

            transform.Rotate(Vector3.forward * (100  * Time.deltaTime * active_roll));
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

