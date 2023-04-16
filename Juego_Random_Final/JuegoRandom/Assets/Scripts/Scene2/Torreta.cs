using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    public Transform target;
    public Transform part_Torotate;

    [Header("Attributes")]
    public float range;
    public float turret_speed;
    public float fire_Rate = 1f;
    private float fire_Countdown = 0f;

    public string playertag = "Player";

    public GameObject bullet;
    public Transform fire_Point;



    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(playertag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemies)
        {

            float distanceToPlayer = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToPlayer < shortestDistance)
            {
                shortestDistance = distanceToPlayer;
                nearestEnemy = enemy;

            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void Update()
    {
        if(target == null)
        {
            return;
        }

        //rotacion de la torreta al jugador 
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(part_Torotate.rotation, lookRotation, Time.deltaTime * turret_speed).eulerAngles;
        part_Torotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        
        if(fire_Countdown <= 0f)
        {
            Shoot();
            fire_Countdown = 1f / fire_Rate;
        }

        fire_Countdown -= Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bullet, fire_Point.position, fire_Point.rotation);
        Bala_Torreta buullet = bulletGO.GetComponent<Bala_Torreta>();

        if(buullet != null)
        {
            buullet.Seek(target);
        }
        
    }
}
