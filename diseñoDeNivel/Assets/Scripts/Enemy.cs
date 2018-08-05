using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool pursuitOn;
    public EnemySight eS;

    public float speed;
    public float rotationSpeed;

    public Vector3 _dirToGo;

    public float _dirToGoX;
    public float _dirToGoY;

    public List<GameObject> waypoints = new List<GameObject>();

    public bool followWaypoint;

    public bool waypointLoop;
    public float distToWaypoint;
    public int i;
    public int maxI;
    public bool loopingWaypoint;

    public float pursuitTimer;
    public float pursuitOnTime;

    public bool isRanged;
    public GameObject bulletPrefab;
    public float onTimeToShoot;
    public float shootTimer;


    void Update()
    {
        eS = GetComponent<EnemySight>();

        if (eS._targetInSight /*|| eS._targetInListen*/)
        {
            pursuitOn = true;
        }

        if (pursuitOn)
        {
            //alarm.SetActive(true);
            followWaypoint = false;

            _dirToGo = eS.target.transform.position - transform.position;

            transform.forward = Vector3.Lerp(transform.forward, _dirToGo, rotationSpeed * Time.deltaTime);

            transform.position += transform.forward * speed * Time.deltaTime;

            // eS.target.GetComponent<Player>().hp = 0;
            if (isRanged)
            {
                shootTimer += Time.deltaTime;
                if (shootTimer > onTimeToShoot)
                {
                    Shoot();
                    shootTimer = 0;
                }
            }
        }

        /*if (eS.target.GetComponent<Player>().death == true)
        {
            pursuitTimer += Time.deltaTime;
            if (pursuitTimer > pursuitOnTime)
            {
                pursuitTimer = 0;
                pursuitOn = false;
                followWaypoint = true;
                alarm.SetActive(false);
            }
        }*/

        if (followWaypoint)
        {
            if (distToWaypoint <= 1f)
            {
                if (waypointLoop)
                {
                    if (i < maxI && !loopingWaypoint)
                    {
                        loopingWaypoint = false;
                        i++;
                    }
                    else
                    {
                        loopingWaypoint = true;
                        i--;
                    }
                }
                else
                {
                    if (i < maxI)
                    {
                        i++;
                    }
                    else
                    {
                        i = 0;
                    }
                }
            }
            if (i < 0)
            {
                loopingWaypoint = false;
            }
            distToWaypoint = Vector3.Distance(transform.position, waypoints[i].transform.position);

            _dirToGo = waypoints[i].transform.position - transform.position;
            transform.forward = Vector3.Lerp(transform.forward, _dirToGo, rotationSpeed * Time.deltaTime);
            transform.position += transform.forward * speed * Time.deltaTime;
            Debug.Log(i);
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = transform.position;
        bullet.transform.forward = transform.forward;
    }
}
