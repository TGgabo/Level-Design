using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp;

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

    public GameObject bulletPrefab;

    void Start()
    {
        eS = GetComponent<EnemySight>();
    }

    void Update()
    {
        if (eS._targetInSight)
        {
            pursuitOn = true;
        }

        if (pursuitOn)
        {
            followWaypoint = false;

            _dirToGo = eS.target.transform.position - transform.position;

            transform.forward = Vector3.Lerp(transform.forward, new Vector3(_dirToGo.x, 0, _dirToGo.z), rotationSpeed * Time.deltaTime);

            transform.position += transform.forward * speed * Time.deltaTime;
        }

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

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = transform.position;
        bullet.transform.position += Vector3.up * 1.3f;
        bullet.transform.forward = transform.forward;
        bullet.transform.Rotate(new Vector3(0, 90, 0));
        bullet.GetComponent<Bullet>().shooter = gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerHit")
        {
            hp--;
        }
    }
}
