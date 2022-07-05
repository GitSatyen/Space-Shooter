using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public AudioClip Explosion;
    GameObject prefab;
    public void Start()
    {
        prefab = Resources.Load("Bullet") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject projectile = Instantiate(prefab) as GameObject;
            projectile.transform.position = transform.position + Camera.main.transform.forward * 2;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = Camera.main.transform.forward * 40;

        }
    }

}
