using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hp;

    public List<GameObject> hps = new List<GameObject>();

    public bool hasKey;

    public Vector3 lastCheckPoint;

    public GameObject keyInCanvas;

    void Start()
    {
        lastCheckPoint = transform.position;
    }

    void Update()
    {
        for (int i = 0; i < hps.Count; i++)
        {
            hps[i].SetActive(true);
            if (hp == 2)
            {
                if (i < 1)
                {
                    hps[i].SetActive(false);
                }
            }
            else if (hp == 1)
            {
                if (i < 2)
                {
                    hps[i].SetActive(false);
                }
            }
            else if (hp <= 0)
            {
                if (i < 3)
                {
                    hps[i].SetActive(false);
                    transform.position = lastCheckPoint;
                    hp = 3;
                }
            }
        }
        if (hasKey)
        {
            keyInCanvas.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            hp--;
        }
        if (other.gameObject.tag == "Health")
        {
            if (hp < 3)
            {
                hp++;
                Destroy(other.gameObject);
            }
        }
    }
}
