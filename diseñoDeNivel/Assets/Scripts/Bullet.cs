using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    void Start()
    {
        Destroy(gameObject, 5);    
    }

    void Update ()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
