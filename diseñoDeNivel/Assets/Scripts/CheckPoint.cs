using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Vector3 positionSaved;
    bool positionChecked;

    void OnTriggerEnter(Collider other)
    {
        if (!positionChecked)
        {
            if (other.gameObject.tag == "Player")
            {
                positionSaved = transform.position;
                other.gameObject.GetComponent<Health>().lastCheckPoint = positionSaved;
            }
        }
    }
}