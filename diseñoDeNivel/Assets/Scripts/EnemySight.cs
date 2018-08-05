using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public GameObject target;
    public float viewAngle;
    public float viewDistance;
    //public float listenDistance;

    public Vector3 _dirToTarget;
    public float _angleToTarget;
    public float _distanceToTarget;
    public bool _targetInSight;
    //public bool _targetInListen;

    void Update()
    {
        /*if (!GetComponent<Enemy>().pursuitOn)
        {
            if (target.GetComponent<Player>().LightSight)
            {
                viewDistance = 10;
                listenDistance = 0;
            }
            else if (target.GetComponent<Player>().inPot)
            {
                viewDistance = 1;
                listenDistance = 0;
            }
            else
            {
                listenDistance = 0;
                if (viewDistance > 4 && GetComponent<Enemy>().pursuitOn)
                {
                    viewDistance -= 0.01f;
                }
                else
                {
                    viewDistance = 3;
                }
            }
        }*/
        _dirToTarget = (target.transform.position - transform.position).normalized;

        _angleToTarget = Vector3.Angle(transform.forward, _dirToTarget);

        _distanceToTarget = Vector3.Distance(transform.position, target.transform.position);

        /*if (_distanceToTarget <= listenDistance)
        {
            _targetInListen = true;
        }*/

        if (_angleToTarget <= viewAngle && _distanceToTarget <= viewDistance)
        {
            RaycastHit rch;
            bool obstaclesBetween = false;

            if (Physics.Raycast(transform.position, _dirToTarget, out rch, _distanceToTarget))
                if (rch.collider.gameObject.layer == 8)
                    obstaclesBetween = true;

            if (!obstaclesBetween)
            {
                _targetInSight = true;
            }
            else
                _targetInSight = false;
        }
        else
            _targetInSight = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, viewDistance);

        //Gizmos.color = Color.yellow;
        //Gizmos.DrawWireSphere(transform.position, listenDistance);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, transform.position + (transform.forward * viewDistance));

        Vector3 rightLimit = Quaternion.AngleAxis(viewAngle, transform.up) * transform.forward;
        Gizmos.DrawLine(transform.position, transform.position + (rightLimit * viewDistance));

        Vector3 leftLimit = Quaternion.AngleAxis(-viewAngle, transform.up) * transform.forward;
        Gizmos.DrawLine(transform.position, transform.position + (leftLimit * viewDistance));


    }
}
