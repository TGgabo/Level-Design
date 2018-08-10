using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public GameObject target;
    public float viewAngle;
    public float viewDistance;
    public float viewDistanceToShoot;

    public Vector3 _dirToTarget;
    public float _angleToTarget;
    public float _distanceToTarget;
    public bool _targetInSight;

    void Update()
    {
        _dirToTarget = (target.transform.position - transform.position).normalized;

        _angleToTarget = Vector3.Angle(transform.forward, _dirToTarget);

        _distanceToTarget = Vector3.Distance(transform.position, target.transform.position);

        if (_angleToTarget <= viewAngle && _distanceToTarget <= viewDistance)
        {
            RaycastHit rch;
            bool obstaclesBetween = false;

            if (Physics.Raycast(transform.position, _dirToTarget, out rch, 9))
            {
                if (rch.collider.gameObject.layer == 8)
                {
                    obstaclesBetween = true;
                }
            }

            if (obstaclesBetween)
            {
                Debug.Log("lo veo");
                _targetInSight = true;
            }
            else
            {
                Debug.Log("no lo veo");
                _targetInSight = false;
            }
        }
        //_targetInSight = false;
        Debug.Log(_targetInSight);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, viewDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, viewDistanceToShoot);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, transform.position + (transform.forward * viewDistance));

        Vector3 rightLimit = Quaternion.AngleAxis(viewAngle, transform.up) * transform.forward;
        Gizmos.DrawLine(transform.position, transform.position + (rightLimit * viewDistance));

        Vector3 leftLimit = Quaternion.AngleAxis(-viewAngle, transform.up) * transform.forward;
        Gizmos.DrawLine(transform.position, transform.position + (leftLimit * viewDistance));


    }
}
