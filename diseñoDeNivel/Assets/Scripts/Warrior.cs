using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    public Enemy e;
    public EnemySight eS;
    public Animator anim;

    public bool shootRange;

    public float onTimeToShoot;
    public float shootTimer;

    void Start()
    {
        e = GetComponent<Enemy>();
        eS = GetComponent<EnemySight>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        var distToPlayer = Vector3.Distance(transform.position, eS.target.transform.position);

        if (distToPlayer < eS.viewDistanceToShoot)
        {
            shootRange = true;
            e.speed = 0;
        }
        else if (distToPlayer > eS.viewDistanceToShoot && distToPlayer < eS.viewDistance && eS._targetInSight)
        {
            shootRange = false;
            e.speed = 5;
        }
        else if (distToPlayer > eS.viewDistance)
        {
            e.speed = 0;
        }

        if (e.speed == 5)
        {
            anim.Play("Run");
        }
        else if (shootRange && e.speed == 0)
        {
            anim.Play("Attack1");
            shootTimer += Time.deltaTime;
            if (shootTimer > onTimeToShoot)
            {
                e.Shoot();
                shootTimer = 0;
            }
        }
        else if (!shootRange && e.speed == 0)
        {
            anim.Play("Idle");
        }
    }
}

