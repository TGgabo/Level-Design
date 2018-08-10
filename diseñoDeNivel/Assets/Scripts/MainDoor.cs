using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoor : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            bool key = other.gameObject.GetComponent<Health>().hasKey;
            if (key)
            {
                Animator anim = GetComponent<Animator>();
                anim.Play("PortonFinalAbrir");
            }
        }
    }

}
