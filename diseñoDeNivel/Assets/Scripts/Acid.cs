using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Health>())
        {
            other.GetComponent<Health>().hp = 0;
        }
        if (other.GetComponent<Enemy>())
        {
            other.GetComponent<Enemy>().hp = 0;
        }
    }
}
