using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandle : MonoBehaviour
{
    public GameObject player;
    public Animator anim;

    public bool canOpen;

    public bool openedDoor;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            canOpen = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            canOpen = false;
        }
    }
}
