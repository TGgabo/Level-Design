using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public DoorHandle dH;
    Animator anim;
    public string animName;

    public float speed;

    public bool specialDoor;

    public bool doorOpened;

    public bool trapDoor;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (trapDoor)
            {
                if (dH.canOpen)
                {
                    if (doorOpened)
                    {
                        Debug.Log("Door Opened");
                        anim.Play("trampaCerrar");
                        dH.anim.Play("movimientopalanca2");
                    }
                }
            }
            if (dH.canOpen)
            {
                if (!specialDoor)
                {
                    anim.Play(animName);
                }
                dH.anim.Play("movimientopalanca");
                doorOpened = true;
            }
        }
        if (doorOpened)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
    }
}
