using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    public int timeToDie;

    public GameObject shooter;

    public GameObject blood;

    void Start()
    {
        Destroy(gameObject, timeToDie);    
    }

    void Update ()
    {
        transform.position += transform.right * speed * Time.deltaTime * -1;
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject != shooter.gameObject 
            || other.gameObject.layer == 9 && other.gameObject != shooter.gameObject)
        {
            GameObject particle = Instantiate(blood);
            particle.transform.position = transform.position;
            particle.SetActive(true);
        }
    }
}
